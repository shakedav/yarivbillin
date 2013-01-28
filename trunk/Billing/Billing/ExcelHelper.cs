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

namespace Billing
{
   public sealed class ExcelHelper
   {       
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
       static string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Constants.Instance.Path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
       OleDbConnection dbCon;
       private static object locker = new Object();
       private static volatile ExcelHelper instance;
       private bool disposed;
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
            DataSet ds = ReadExcelData(Constants.Instance.Path);
            Clients = ds.Tables["לקוחות"];
            Contracts = ds.Tables["חוזים"];
            Bills = ds.Tables["חשבונות"];
            Projects = ds.Tables["פרוייקטים"];
            ContractTypes = ds.Tables["סוגי חוזים"];
            StatusTypes = ds.Tables["סוגי סטטוס"];
            ClientTypes = ds.Tables["סוגי לקוחות"];
            ValueTypes = ds.Tables["סוגי תמורה"];  
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

        public void SaveDataToExcel(DataRow row, string sheetName)
        {          
            ExcelApp.Application excelApp = new ExcelApp.Application();
            excelApp.DisplayAlerts = false;
            ExcelApp.Workbook excelWorkbook = excelApp.Workbooks.Open(Constants.Instance.Path, 0, false, 5, "", "", false, ExcelApp.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            ExcelApp.Sheets excelSheets = excelWorkbook.Worksheets;
            ExcelApp.Worksheet excelWorksheet = (ExcelApp.Worksheet)excelSheets.get_Item(sheetName);
            // get the last used column number 
            int lastCol = excelWorksheet.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, ExcelApp.XlSearchOrder.xlByColumns, ExcelApp.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;
            int lastRow = excelWorksheet.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, ExcelApp.XlSearchOrder.xlByRows, ExcelApp.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row + 1;

            for (int col = 1;col <= lastCol; col++)
            {
                ExcelApp.Range excelCell = (ExcelApp.Range)excelWorksheet.get_Range(toAlphabet(col) + lastRow.ToString(), toAlphabet(col) + lastRow.ToString());
                excelCell.Value = row.ItemArray[col-1];
                if (excelCell != null) { Marshal.ReleaseComObject(excelCell); }
                excelCell = null;
            }
            bool SaveChanges = true;
            excelWorksheet.SaveAs(Constants.Instance.Path);
            excelWorkbook.SaveAs(Constants.Instance.Path);
            excelWorkbook.Close(SaveChanges, Constants.Instance.Path, null);
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
            ReadExcelData(Constants.Instance.Path);
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

        public List<string> searchInTable(DataTable table, string stringToMatch, string columnNameToSearchIn, string whatToFind)
        {
            List<string> list = new List<string>();
            try
            {
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                {
                    if (table.Rows[i][columnNameToSearchIn].ToString().Contains(stringToMatch))
                        list.Add(table.Rows[i][whatToFind].ToString());
                }
            }
            catch (Exception ex)
            {
                LogWriter.Instance.Error("Error on search", ex);
            }
            return list;
        }

        public string GetMaxIDOfType(DataTable table, string columnName, string typeID, string typeName)
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
                return max.ToString();
            }
            catch (Exception ex)
            {
                return "";
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

        private double getContractBillsSum(string contractCode)
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

        public string getUsedAmountOfContract(string contractCode)
        {
            try
            {
                int totalAmount = int.Parse(getItemFromTable(Contracts, contractCode, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.VALUE));
                return ((double)getContractBillsSum(contractCode) / totalAmount).ToString("0.0%");
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
                ArrayList list = new ArrayList();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                for (int i = 0; i <= fromTable.Rows.Count - 1; i++)
                {
                    if (valueToFilterBy == fromTable.Rows[i][filterByColumn].ToString())
                    {
                        for (int j = 0; j <= fromTable.Columns.Count - 1; j++)
                        {
                            dictionary.Add(fromTable.Columns[j].ToString(), fromTable.Rows[i][j].ToString());
                            //list.Add(fromTable.Rows[i][j].ToString());                            
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
            ExcelApp.Workbook excelWorkbook = excelApp.Workbooks.Open(Constants.Instance.Path, 0, false, 5, "", "", false, ExcelApp.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            ExcelApp.Sheets excelSheets = excelWorkbook.Worksheets;
            ExcelApp.Worksheet excelWorksheet = (ExcelApp.Worksheet)excelSheets.get_Item(sheetName);
            for (int row = 0; row <= table.Rows.Count - 1; row++)
            {
                if (TextToSearch == table.Rows[row][column].ToString())
                {
                    table.Rows[row].Delete();
                    ((Microsoft.Office.Interop.Excel.Range)excelWorksheet.Rows[row+2]).Delete();
                    bool SaveChanges = true;
                    excelWorksheet.SaveAs(Constants.Instance.Path);
                    excelWorkbook.SaveAs(Constants.Instance.Path);
                    excelWorkbook.Close(SaveChanges, Constants.Instance.Path, null);
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
                    ReadExcelData(Constants.Instance.Path);
                    return;
                }
            }
        }

        public bool shouldSave(string message, string ExistingData)
        {
            using (var form = new DataExists(string.Format(message, ExistingData)))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return form.ShouldSave;
                }
                else return false;
            }
        }

        public string getTotalOfBills(string contractCode)
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
            return billsAmount.ToString();            
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
            DataSet ds = ReadExcelData(Constants.Instance.Path);
            Clients = ds.Tables["לקוחות"];
            Contracts = ds.Tables["חוזים"];
            Bills = ds.Tables["חשבונות"];
            Projects = ds.Tables["פרוייקטים"];
            ContractTypes = ds.Tables["סוגי חוזים"];
            StatusTypes = ds.Tables["סוגי סטטוס"];
            ClientTypes = ds.Tables["סוגי לקוחות"];
            ValueTypes = ds.Tables["סוגי תמורה"];
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
   }
}
