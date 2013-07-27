using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using Microsoft.Office.Interop;
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Collections;
using System.Windows.Forms;
using Billing.DataObjects;

namespace Billing
{
   public sealed class ExcelHelper
   {
       private string sConnection
       {
           get
           {
               return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Constants.Instance.DB
                                        + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
           }
       }

       public string Con_Str;
       public DataTable Clients;
       public DataTable ClientTypes;
       public DataTable Contracts;
       public DataTable Bills;
       public DataTable Projects;
       public DataTable ContractTypes;
       public DataTable StatusTypes;
       public DataTable ValueTypes;
       public DataTable ValueInBill;      
       OleDbDataAdapter dbDa = new OleDbDataAdapter();
    
       OleDbConnection dbCon;
       private static object locker = new Object();
       private static volatile ExcelHelper instance;
       /// <summary>
       /// Get an instance of the ExcelHelper (create on the first time).
       /// </summary>
       public static ExcelHelper Instance
       {
           get
           {
               // Check if the instance has not been created yet
               if (instance == null)
               {
                   // Enter a locking state
                   lock (locker)
                   {
                       // Ensure that the instance is still not valid
                       if (instance == null)
                       {
                           // Create the instace
                           instance = new ExcelHelper();
                       }
                   }
               }

               // Return the single instance
               return instance;
           }
       }      

        ExcelHelper()
        {
            dbCon = new OleDbConnection(sConnection);
            DataSet ds = ReadExcelData(string.Format(@"{0}", Constants.Instance.DB));
            SetTables(ds);
        }

        private void SetTables(DataSet ds)
        {
            Clients = ds.Tables["לקוחות"];
            DataColumn[] clientsKeys = new DataColumn[2];
            clientsKeys[0] = ds.Tables["לקוחות"].Columns[ColumnNames.CLIENT_CODE];
            clientsKeys[1] = ds.Tables["לקוחות"].Columns[ColumnNames.CLIENT_NAME];
            try
            {
                Clients.PrimaryKey = clientsKeys;
            }
            catch (Exception ex)
            {
                throw new Exception("שם לקוח וקוד לקוח כבר קיימים", ex);
            }

            Contracts = ds.Tables["חוזים"];
            DataColumn[] ContractsKeys = new DataColumn[2];
            ContractsKeys[0] = ds.Tables["חוזים"].Columns[ColumnNames.CONTRACT_CODE_YARIV];
            ContractsKeys[1] = ds.Tables["חוזים"].Columns[ColumnNames.CONRACT_CODE_CLIENT];
            try
            {
                Contracts.PrimaryKey = ContractsKeys;
            }
            catch (Exception ex)
            {
                throw new Exception("קוד חוזה יריב וקוד חוזה לקוח כבר קיימים", ex);
            }

            Bills = ds.Tables["חשבונות"];
            DataColumn[] billsKeys = new DataColumn[2];
            billsKeys[0] = ds.Tables["חשבונות"].Columns[ColumnNames.BILL_NUMBER_YARIV];
            billsKeys[1] = ds.Tables["חשבונות"].Columns[ColumnNames.CONTRACT_CODE_YARIV];
            try 
            {
                Bills.PrimaryKey = billsKeys;
            }
            catch (Exception ex)
            {
                throw new Exception("קוד לקוח ומספר חשבון כבר קיימים", ex);
            }

            Projects = ds.Tables["פרוייקטים"];
            DataColumn[] projectsKeys = new DataColumn[2];
            projectsKeys[0] = ds.Tables["פרוייקטים"].Columns[ColumnNames.PROJECT_CODE];
            projectsKeys[1] = ds.Tables["פרוייקטים"].Columns[ColumnNames.PROJECT_NAME];
            try
            {
                Projects.PrimaryKey = projectsKeys;
            }
            catch (Exception ex)
            {
                throw new Exception("קוד פרוייקט ושם פרוייקט כבר קיימים", ex);
            }

            ContractTypes = ds.Tables["סוגי חוזים"];
            StatusTypes = ds.Tables["סוגי סטטוס"];
            ClientTypes = ds.Tables["סוגי לקוחות"];
            ValueTypes = ds.Tables["סוגי תמורה"];
            DataColumn[] ValueTypesKeys = new DataColumn[2];
            ValueTypesKeys[0] = ds.Tables["סוגי תמורה"].Columns[ColumnNames.VALUE_CODE];
            try
            {
                ValueTypes.PrimaryKey = ValueTypesKeys;
            }
            catch (Exception ex)
            {
                throw new Exception("קוד תמורה כבר קיים", ex);
            }
            ValueInBill = ds.Tables["תמורות בחשבון"];
        }

        private DataSet ReadExcelData(string Path)
        {
            try
            {
                dbCon.Open();
                // Get All Sheets Name
                DataTable dtSheetName = dbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                // Retrive the Data by Sheetwise
                DataSet dsOutput = new DataSet();
                for (int nCount = 0; nCount < dtSheetName.Rows.Count; nCount++)
                {
                    string sSheetName = dtSheetName.Rows[nCount]["TABLE_NAME"].ToString();
                    string sQuery = "Select * From [" + sSheetName + "]";
                    OleDbCommand dbCmd = new OleDbCommand(sQuery, dbCon);
                    dbDa.SelectCommand = dbCmd;
                    DataTable dtData = new DataTable(getCleanName(sSheetName));
                    dbDa.Fill(dtData);
                    dsOutput.Tables.Add(dtData);
                }
                dbCon.Close();
                return dsOutput;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string getCleanName(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] != '$') && (str[i] !='\''))
                    sb.Append(str[i]);
            }

            return sb.ToString();
        }

        public void SaveDataToExcel(DataRow row, string sheetName, SaveType saveType)
        {          
            ExcelApp.Application excelApp = new ExcelApp.Application();
            excelApp.DisplayAlerts = false;
            ExcelApp.Workbook excelWorkbook = excelApp.Workbooks.Open(string.Format(@"{0}", Constants.Instance.DB), 0, false, 5, "", "", false, ExcelApp.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            ExcelApp.Sheets excelSheets = excelWorkbook.Worksheets;
            ExcelApp.Worksheet excelWorksheet = (ExcelApp.Worksheet)excelSheets.get_Item(sheetName);
            // get the last used column number 
            int lastCol = excelWorksheet.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, ExcelApp.XlSearchOrder.xlByColumns, ExcelApp.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;
            switch (saveType)
            {
                case SaveType.NA:
                    break;
                case SaveType.SaveNew:
                    {
                        int lastRow = excelWorksheet.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, ExcelApp.XlSearchOrder.xlByRows, ExcelApp.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row + 1;

                        for (int col = 1; col <= lastCol; col++)
                        {
                            ExcelApp.Range excelCell = (ExcelApp.Range)excelWorksheet.get_Range(toAlphabet(col) + lastRow.ToString(), toAlphabet(col) + lastRow.ToString());
                            excelCell.Value = row.ItemArray[col - 1];
                            if (excelCell != null) { Marshal.ReleaseComObject(excelCell); }
                            excelCell = null;
                        }
                        break;
                    }
                case SaveType.Update:
                    {
                        int lastRow = row.Table.Rows.IndexOf(row) + 2;

                        for (int col = 1; col <= lastCol; col++)
                        {
                            ExcelApp.Range excelCell = (ExcelApp.Range)excelWorksheet.get_Range(toAlphabet(col) + lastRow.ToString(), toAlphabet(col) + lastRow.ToString());
                            excelCell.Value = row.ItemArray[col - 1];
                            excelCell = null;
                        }
                        break;
                    }
            }
            bool SaveChanges = true;
            excelWorksheet.SaveAs(string.Format(@"{0}", Constants.Instance.DB));
            excelWorkbook.SaveAs(string.Format(@"{0}", Constants.Instance.DB));
            excelWorkbook.Close(SaveChanges, string.Format(@"{0}", Constants.Instance.DB), null);
            excelApp.Workbooks.Close();
            excelApp.Quit();
            
            if (excelSheets != null) { Marshal.ReleaseComObject(excelSheets); }
            if (excelWorksheet != null) { Marshal.ReleaseComObject(excelWorksheet); }
            if (excelWorkbook != null) { Marshal.ReleaseComObject(excelWorkbook); }
            if (excelApp != null) { Marshal.ReleaseComObject(excelApp); }

            excelSheets = null;
            excelWorksheet = null;
            excelWorkbook = null;
            excelApp = null;
            GC.Collect();
            ReadExcelData(string.Format(@"{0}", Constants.Instance.DB));
            Reload();
        }

        private string toAlphabet(int col)
        {
            string[] columnNumbers = {"A", "B", "C", "D", "E", "F" , "G", "H", "I", "J", "K" ,"L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            int dividend = col;
            string columnName = string.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = columnNumbers[modulo] + columnName;
                dividend = (dividend - modulo) / 26;
            } 

            return columnName;
        }

        public string getItemFromTable(DataTable table, string stringToMatch, string columnNameToSearchIn, string whatToFind)
        {
            try
            {
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                {
                    if (table.Rows[i][columnNameToSearchIn].ToString() == stringToMatch)
                        return table.Rows[i][whatToFind].ToString();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<string> searchInTable(DataTable table, string stringToMatch, string columnNameToSearchIn, string whatToFind, string secondIdentifier, string itemType)
        {
            List<string> list = new List<string>();
            try
            {
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                {
                    if (table.Rows[i][columnNameToSearchIn].ToString().Contains(stringToMatch))
                        list.Add(itemType + "-" + table.Rows[i][secondIdentifier].ToString() + "-" + table.Rows[i][whatToFind].ToString());
                }
                
            return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<string> searchInTable(DataTable table, string stringToMatch, string columnNameToSearchIn, string whatToFind, string secondIdentifier, string thirdIdentifier, string itemType)
        {
            List<string> list = new List<string>();
            try
            {
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                {
                    if (table.Rows[i][columnNameToSearchIn].ToString().Contains(stringToMatch))
                        list.Add(itemType + "-" + table.Rows[i][secondIdentifier].ToString() + "-" + table.Rows[i][whatToFind].ToString() + "-" + table.Rows[i][thirdIdentifier].ToString());
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int GetMaxIDOfType(DataTable table, string columnName, string typeID, string typeName)
        {
            try
            {
                int max = int.Parse(typeID);
                string maxID = string.Empty;
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                {
                    if (typeID == table.Rows[i][typeName].ToString())
                    {
                        if (int.Parse(table.Rows[i][columnName].ToString()) > max)
                        {
                            maxID = table.Rows[i][columnName].ToString();
                            max = int.Parse(maxID);
                        }
                    }
                }
                max++;
                return max;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public ArrayList GetItemsByFilter(DataTable fromTable, string filterByColumn,string valueToFilterBy, string ItemToGet)
        {
            try
            {
                ArrayList list = new ArrayList();
                for (int i = 0; i <= fromTable.Rows.Count - 1; i++)
                {
                    if (valueToFilterBy == fromTable.Rows[i][filterByColumn].ToString())
                    {
                        list.Add(fromTable.Rows[i][ItemToGet].ToString());
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string GetMaxItemOfColumn(DataTable table, string columnName)
        {
            try
            {
                int max = 0;
                string maxID = string.Empty;
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                {
                    if (int.Parse(table.Rows[i][columnName].ToString()) > max)
                    {
                        maxID = table.Rows[i][columnName].ToString();
                        max = int.Parse(maxID);
                    }
                }  
                return max.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string getLastBillAmount(string billSequence, string contractCode)
        {
            try
            {
                DataTable table = this.Bills;
                if (int.Parse(billSequence) > 0)
                {
                    for (int i = 0; i <= table.Rows.Count - 1; i++)
                    {
                        if ((contractCode == table.Rows[i][ColumnNames.CONTRACT_CODE_YARIV].ToString()) &&
                            ((int.Parse(billSequence) - 1).ToString() == table.Rows[i][ColumnNames.BILL_SEQUENCE].ToString()))
                        {
                            return table.Rows[i][ColumnNames.TOTAL_AMOUNT].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "0";
            }
            return "0";
        }

        public double getContractBillsSum(string contractCode)
        {
            double sum = 0;
            foreach (DataRow row in Bills.Rows)
            {
                if (row[ColumnNames.CONTRACT_CODE_YARIV].ToString() == contractCode)
                {
                    sum = sum + double.Parse(row[ColumnNames.TOTAL_AMOUNT].ToString());
                }
            }
            return sum;
        }

        public string GetMaxItemOfColumnByColumn(DataTable table, string maxItemName, string columnToSearchValueIn, string valueToSearchBy)
        {
            try
            {
                int max = 0;
                string maxID = string.Empty;
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                {
                    if (valueToSearchBy == table.Rows[i][columnToSearchValueIn].ToString())
                    {
                        if (int.Parse(table.Rows[i][maxItemName].ToString()) > max)
                        {
                            maxID = table.Rows[i][maxItemName].ToString();
                            max = int.Parse(maxID);
                        }
                    }
                }
                max++;
                return max.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string getUsedAmountOfContract(string contractCode, string billAmount)
        {
            try
            {
                int totalAmount = int.Parse(getItemFromTable(Contracts, contractCode, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.VALUE));
                return ((double)((getContractBillsSum(contractCode) - int.Parse(billAmount)) / totalAmount)).ToString(".0%");
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        public Dictionary<string,string> GetRowItemsByFilter(DataTable fromTable, string filterByColumn, string valueToFilterBy)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                for (int i = 0; i <= fromTable.Rows.Count - 1; i++)
                {
                    if (valueToFilterBy == fromTable.Rows[i][filterByColumn].ToString())
                    {
                        for (int j = 0; j <= fromTable.Columns.Count - 1; j++)
                        {
                            dictionary.Add(fromTable.Columns[j].ToString(), fromTable.Rows[i][j].ToString());                      
                        }
                        return dictionary;
                    }
                }
                return dictionary;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetRowItemsByFilters(DataTable fromTable, string filterByColumn1, string valueToFilterBy1, string filterByColumn2, string valueToFilterBy2)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                for (int i = 0; i <= fromTable.Rows.Count - 1; i++)
                {
                    if ((valueToFilterBy1 == fromTable.Rows[i][filterByColumn1].ToString()) && (valueToFilterBy2 == fromTable.Rows[i][filterByColumn2].ToString()))
                    {
                        for (int j = 0; j <= fromTable.Columns.Count - 1; j++)
                        {
                            dictionary.Add(fromTable.Columns[j].ToString(), fromTable.Rows[i][j].ToString());
                        }
                        return dictionary;
                    }
                }
                return dictionary;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool CheckExistence(string TextToSearch1, string TextToSearch2, string column1, string column2, DataTable dataTable)
        {
            for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
            {
                if ((TextToSearch1 == dataTable.Rows[i][column1].ToString()) && (TextToSearch2 == dataTable.Rows[i][column2].ToString()))
                {
                    return true;
                }
            }            
            return false;
        }

        public void DeleteRow(DataTable table, string TextToSearch, string column, string sheetName)
        {            
            ExcelApp.Application excelApp = new ExcelApp.Application();
            excelApp.DisplayAlerts = false;
            ExcelApp.Workbook excelWorkbook = excelApp.Workbooks.Open(string.Format(@"{0}", Constants.Instance.DB), 0, false, 5, "", "", false, ExcelApp.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            ExcelApp.Sheets excelSheets = excelWorkbook.Worksheets;
            ExcelApp.Worksheet excelWorksheet = (ExcelApp.Worksheet)excelSheets.get_Item(sheetName);
            for (int row = 0; row <= table.Rows.Count - 1; row++)
            {
                if (TextToSearch == table.Rows[row][column].ToString())
                {
                    table.Rows[row].Delete();
                    ((Microsoft.Office.Interop.Excel.Range)excelWorksheet.Rows[row+2]).Delete();
                    bool SaveChanges = true;
                    excelWorksheet.SaveAs(string.Format(@"{0}",Constants.Instance.DB));
                    excelWorkbook.SaveAs(string.Format(@"{0}", Constants.Instance.DB));
                    excelWorkbook.Close(SaveChanges, string.Format(@"{0}", Constants.Instance.DB), null);
                    excelApp.Workbooks.Close();
                    excelApp.Quit();

                    if (excelSheets != null) { Marshal.ReleaseComObject(excelSheets); }
                    if (excelWorksheet != null) { Marshal.ReleaseComObject(excelWorksheet); }
                    if (excelWorkbook != null) { Marshal.ReleaseComObject(excelWorkbook); }
                    if (excelApp != null) { Marshal.ReleaseComObject(excelApp); }

                    excelSheets = null;
                    excelWorksheet = null;
                    excelWorkbook = null;
                    excelApp = null;
                    GC.Collect();
                    ReadExcelData(string.Format(@"{0}", Constants.Instance.DB));
                    return;
                }
            }
        }        

        public double getTotalOfBills(string contractCode)
        {
            DataTable table = this.Bills;
            double billsAmount = 0;
            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                if (contractCode == table.Rows[i][ColumnNames.CONTRACT_CODE_YARIV].ToString())
                {
                    billsAmount += double.Parse(table.Rows[i][ColumnNames.TOTAL_AMOUNT].ToString());
                }
            }
            return billsAmount;            
        }

        public double getTotalHoursOfBill(string contractCode, string billNumber, string type)
        {
            DataTable table = this.ValueInBill;
            double billsAmount = 0;
            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                if ((contractCode == table.Rows[i][ColumnNames.CONTRACT_CODE_YARIV].ToString()) && (billNumber == table.Rows[i][ColumnNames.BILL_NUMBER_YARIV].ToString()) && (type == table.Rows[i][ColumnNames.VALUE_CODE].ToString()))
                {
                    billsAmount += double.Parse(table.Rows[i][ColumnNames.QUANTITY].ToString());
                }
            }
            return billsAmount;
        }

        public bool CheckExistenceOfSingleValue(string TextToSearch, string columnName, DataTable dataTable)
        {
            for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
            {
                if (TextToSearch == dataTable.Rows[i][columnName].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        internal void Reload()
        {
            dbCon = new OleDbConnection(sConnection);
            DataSet ds = ReadExcelData(Constants.Instance.DB);
            SetTables(ds);
        }

        internal List<int> getValuesFromDB(string contractCode)
        {
            string valuesString = getItemFromTable(Contracts, contractCode, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.VALUE_TYPES);
            List<int> list = new List<int>();
            foreach (string s in valuesString.Split(';'))
            {
                if (!string.IsNullOrEmpty(s))
                {
                    list.Add(Int32.Parse(s));
                }
            }

            return list;
        }

        public List<ValueItem> getValuesByBill(string contractCode, string billCode)
        {
            if ((contractCode != null) && (billCode != null))
            {
                return getValuesByCode(contractCode, billCode);
            }
            if ((contractCode != null) && (billCode == null))
            {
                return getAllowedValuesByContractCode(contractCode);
            }
            return null;
        }

        public List<ValueItem> getValuesByCode(string contractCode, string billNumber)
        {
            try
            {
                List<ValueItem> list = new List<ValueItem>();
                for (int i = 0; i <= ValueInBill.Rows.Count - 1; i++)
                {
                    int index = 0;
                    if ((contractCode == ValueInBill.Rows[i][ColumnNames.CONTRACT_CODE_YARIV].ToString())
                        && (billNumber == ValueInBill.Rows[i][ColumnNames.BILL_NUMBER_YARIV].ToString()))
                    {
                        ValueItem item = new ValueItem(ValueInBill.Rows[i][ColumnNames.VALUE_CODE].ToString(),
                                                        index.ToString(),
                                                        ValueInBill.Rows[i][ColumnNames.PAYMENT].ToString(),
                                                        ValueInBill.Rows[i][ColumnNames.QUANTITY].ToString());
                        list.Add(item);
                        index++;
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                LogWriter.Instance.Error("Error when getting values by code", ex);
                return null;
            }
        }

        internal List<string> getValuesFromDB()
        {
            List<string> list = new List<string>();
            foreach (DataRow row in ExcelHelper.Instance.ValueTypes.Rows)
            {
                list.Add(row[ColumnNames.VALUE_TYPE].ToString());
            }
            return list;
        }

        public  List<DataRow> getValueRows(string contractCode, string billNumber, string valueCode)
        {
            try
            {
                List<DataRow> list = new List<DataRow>();
                for (int i = 0; i <= ValueInBill.Rows.Count - 1; i++)
                {
                    if ((contractCode == ValueInBill.Rows[i][ColumnNames.CONTRACT_CODE_YARIV].ToString()) && (billNumber == ValueInBill.Rows[i][ColumnNames.BILL_NUMBER_YARIV].ToString()) && (valueCode == ValueInBill.Rows[i][ColumnNames.VALUE_CODE].ToString()))
                    {                      
                        list.Add(ValueInBill.Rows[i]);                        
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ValueItem> getAllowedValuesByContractCode(string contractCode)
        {
            List<ValueItem> list = new List<ValueItem>();
            for (int i = 0; i <= ValueInBill.Rows.Count - 1; i++)
            {
                if (contractCode == ValueInBill.Rows[i][ColumnNames.CONTRACT_CODE_YARIV].ToString() && string.IsNullOrEmpty(ValueInBill.Rows[i][ColumnNames.BILL_NUMBER_YARIV].ToString()))
                {
                    ValueItem item = new ValueItem(ValueInBill.Rows[i][ColumnNames.VALUE_CODE].ToString(),
                                        i.ToString(), ValueInBill.Rows[i][ColumnNames.PAYMENT].ToString(),
                                        ValueInBill.Rows[i][ColumnNames.QUANTITY].ToString());
                    list.Add(item);
                }
            }
            return list;
        }

        public string GetContractTotalHrs(string contractCode)
        {
            double hours = 0;
            double hrs;
            for (int i = 0; i <= ValueInBill.Rows.Count - 1; i++)
            {
                // Has contract code but no bill number
                if (contractCode == ValueInBill.Rows[i][ColumnNames.CONTRACT_CODE_YARIV].ToString() && string.IsNullOrEmpty(ValueInBill.Rows[i][ColumnNames.BILL_NUMBER_YARIV].ToString()))
                {
                    if (ValueInBill.Rows[i][ColumnNames.VALUE_CODE].ToString() == "1")
                    {
                        double.TryParse(ValueInBill.Rows[i][ColumnNames.QUANTITY].ToString(),out hrs);
                        hours += hrs;
                    }
                }
            }
            return hours.ToString();
        }

         public string GetContractTotalHrsUsed(string contractCode)
        {
            double hours = 0;
            for (int i = 0; i <= ValueInBill.Rows.Count - 1; i++)
            {
                // Has contract code and bill number
                if (contractCode == ValueInBill.Rows[i][ColumnNames.CONTRACT_CODE_YARIV].ToString() && !string.IsNullOrEmpty(ValueInBill.Rows[i][ColumnNames.BILL_NUMBER_YARIV].ToString()))
                {
                    if (ValueInBill.Rows[i][ColumnNames.VALUE_CODE].ToString() == "1")
                    {
                        hours += double.Parse(ValueInBill.Rows[i][ColumnNames.QUANTITY].ToString());
                    }
                }
            }
            return hours.ToString();
        }

       #region Refactoring
         public void SaveClient(Client client, SaveType saveType, string oldName)
         {
             if (saveType == SaveType.SaveNew)
             {
                 DataRow row = ExcelHelper.Instance.Clients.NewRow();
                 row[ColumnNames.CLIENT_NAME] = client.ClientName;//clientNameTxtBox.Text;
                 row[ColumnNames.ADDRESS] = client.Address; //ClientAddressTxtBox.Text;
                 row[ColumnNames.PHONE] = client.ClientPhone;// phoneTxtBox.Text;
                 row[ColumnNames.EMAIL] = client.ClientMail;// emailTxtBox.Text;
                 row[ColumnNames.CLIENT_TYPE] = client.Type;// ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString();
                 row[ColumnNames.CLIENT_CODE] = client.ClientCode;// ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_CODE,
                                                   //ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString()
                                                   //, ColumnNames.CLIENT_TYPE);
                 ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Clients.TableName, saveType);
             }
             else
             {                 
                 object[] obj = new object[2] { getItemFromTable(ExcelHelper.Instance.Clients,
                                                oldName,ColumnNames.CLIENT_NAME,ColumnNames.CLIENT_CODE),oldName};
                 DataRow row = ExcelHelper.Instance.Clients.Rows.Find(obj);
                 row[ColumnNames.CLIENT_NAME] = client.ClientName;
                 row[ColumnNames.ADDRESS] = client.Address;
                 row[ColumnNames.PHONE] = client.ClientPhone;
                 row[ColumnNames.EMAIL] = client.ClientMail;
                 row[ColumnNames.CLIENT_TYPE] = client.Type;                 
                 row[ColumnNames.CLIENT_CODE] = obj[0];
                 ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Clients.TableName, saveType);
             }
         }

         public Client GetClientByIdentifier(string identifier, string column)
         {
             Client client = new Client();
             try
             {
                 foreach (DataRow row in Clients.Rows)
                 //for (int i = 0; i <= Clients.Rows.Count - 1; i++)
                 {
                     if (row[column].ToString() == identifier)
                     {
                         client.ClientCode = Convert.ToInt32(row[ColumnNames.CLIENT_CODE]);
                         client.Type = Convert.ToInt32(row[ColumnNames.CLIENT_TYPE]);
                         client.Address = row[ColumnNames.ADDRESS].ToString();
                         client.ClientMail = row[ColumnNames.EMAIL].ToString();
                         client.ClientName = row[ColumnNames.CLIENT_NAME].ToString();
                         client.ClientPhone = row[ColumnNames.PHONE].ToString();
                         

                     }
                 }
                 return client;
             }
             catch (Exception ex)
             {
                 throw;
             }
         }

         public Billing.SaveType shouldSave(string message, string ExistingData)
         {
             using (var form = new DataExists(string.Format(message, ExistingData)))
             {
                 var result = form.ShowDialog();
                 if (result == DialogResult.OK)
                 {
                     return form.typeOfSave;
                 }
                 else return form.typeOfSave;
             }
         }
       #endregion Refactoring
   }
}
