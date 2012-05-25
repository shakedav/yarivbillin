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

namespace Billing
{
    public class ExcelHelper
    {
        public string Con_Str;
        public DataTable Clients;
        public DataTable Contracts;
        public DataTable Bills;
        public DataTable Projects;
        public DataTable ContractTypes;
        public DataTable StatusTypes;
        public static String Path = System.Configuration.ConfigurationSettings.AppSettings["excelFilePath"];
        OleDbDataAdapter dbDa = new OleDbDataAdapter();
        static string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
        OleDbConnection dbCon;

        public ExcelHelper()
        {
            dbCon = new OleDbConnection(sConnection);         
            DataSet ds = ReadExcelData(Path);
            Clients = ds.Tables["לקוחות"];
            Contracts = ds.Tables["חוזים"];
            Bills = ds.Tables["חשבונות"];
            Projects = ds.Tables["פרוייקטים"];
            ContractTypes = ds.Tables["סוגי חוזים"];
            StatusTypes = ds.Tables["סוגי סטטוס"];
        }

        private DataSet ReadExcelData(string Path)
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
            ExcelApp.Workbook excelWorkbook = excelApp.Workbooks.Open(Path, 0, false, 5, "", "", false, ExcelApp.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
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
            excelWorksheet.SaveAs(Path);
            excelWorkbook.SaveAs(Path);
            excelWorkbook.Close(SaveChanges, Path, null);
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
            for (int i = 0; i <= table.Rows.Count; i++)
            {
                if (table.Rows[i][columnNameToSearchIn].ToString() == stringToMatch)
                    return table.Rows[i][whatToFind].ToString();
            }
            return string.Empty;
        }
    }
}
