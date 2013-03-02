using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Billing.InsertData;
using Microsoft.Office.Interop.Word;

namespace Billing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            checkFormsStatus();
            BillUserControl billForm = new BillUserControl();
            splitContainer1.Panel1.Visible = true;
            splitContainer1.Panel1.Select();
            splitContainer1.Panel1.Controls.Add(billForm);      
          
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            checkFormsStatus();
            ContractUserControl contractForm = new ContractUserControl();
            splitContainer1.Panel1.Visible = true;
            splitContainer1.Panel1.Select();
            splitContainer1.Panel1.Controls.Add(contractForm);                      
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            checkFormsStatus();
            ProjectUserControl projectForm = new ProjectUserControl();
            splitContainer1.Panel1.Visible = true;
            splitContainer1.Panel1.Select();
            splitContainer1.Panel1.Controls.Add(projectForm);       
          
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            checkFormsStatus();
            ClientUserControl control = new ClientUserControl();
            splitContainer1.Panel1.Visible = true;
            splitContainer1.Panel1.Select();
            splitContainer1.Panel1.Controls.Add(control);        
        }

        public void checkFormsStatus()
        {
            if (tabControl1.SelectedTab.Name == "AddDataTab")
            {
                if (splitContainer1.Panel1.Controls.Count >= 1)
                {
                    DialogResult dr = MessageBox.Show("לשמור או לא?", "aaa", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.OK)
                    {
                        //Form.save;
                        splitContainer1.Panel1.Controls.Clear();
                    }
                    else
                    {
                        splitContainer1.Panel1.Controls.Clear();
                    }
                }
            }
            else
            {
                if (searchSplit.Panel1.Controls.Count >= 1)
                {
                    DialogResult dr = MessageBox.Show("לשמור או לא?", "aaa", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.OK)
                    {
                        //Form.save;
                        searchSplit.Panel1.Controls.Clear();
                    }
                    else
                    {
                        searchSplit.Panel1.Controls.Clear();
                    }
                }
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("-----------לקוחות------------");
            //Clients
            List<string> clientsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Clients, searchTxtBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE, "לקוח");
            foreach (string client in clientsList)
            {
                listBox1.Items.Add(client);
            }
            listBox1.Items.Add("-------------------------------------");
            listBox1.Items.Add("");
            listBox1.Items.Add("-----------פרוייקטים------------");
            //Projects
           List<string> projectsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Projects, searchTxtBox.Text, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_CODE, "פרוייקט");
            foreach (string project in projectsList)
            {
                listBox1.Items.Add(project);
            }
            listBox1.Items.Add("-------------------------------------");
            listBox1.Items.Add("");
            listBox1.Items.Add("-----------חוזים------------");
            //Contracts
            List<string> contractsList  = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Contracts, searchTxtBox.Text, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CLIENT_CODE, "חוזה");
            foreach (string contract in contractsList)
            {
                listBox1.Items.Add(contract);
            }
            listBox1.Items.Add("-------------------------------------");
            listBox1.Items.Add("");
            listBox1.Items.Add("-----------חשבונות------------");
            //Bills
            List<string> billsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Bills, searchTxtBox.Text, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CLIENT_CODE, "חשבון");
            foreach (string bill in billsList)
            {
                listBox1.Items.Add(bill);
            }
            listBox1.Items.Add("-------------------------------------");

            //clientsList.AddRange(ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Projects, searchTxtBox.Text, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_CODE, "פרוייקט"));
            //clientsList.AddRange(ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Contracts, searchTxtBox.Text, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CONTRACT_CODE_YARIV,ColumnNames.CLIENT_CODE,"חוזה"));
            //clientsList.AddRange(ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Bills, searchTxtBox.Text, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.BILL_NUMBER_YARIV,ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CLIENT_CODE, "חשבון"));
            //foreach (string client in clientsList)
            //{                
            //    listBox1.Items.Add(client);
            //}
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            string type = string.Empty;
            string value1 = string.Empty;
            string value2 = string.Empty;
            string value3 = string.Empty;
            try
            {
                searchSplit.Panel1.Controls.Clear();
                string a = listBox1.SelectedItems[0].ToString();
                type = a.Split('-')[0];
                value1 = a.Split('-')[1];
                value2 = a.Split('-')[2];
                value3 = a.Split('-')[3];
            }
            catch(Exception ex)
            {
                LogWriter.Instance.Error("Split Error of search", ex);
            }
            switch (type)
            {
                case "לקוח":
                    {
                        ClientUserControl control = new ClientUserControl(value1);
                        ShowControl(control);
                        break;
                    }
                case "פרוייקט":
                    {
                        ProjectUserControl control = new ProjectUserControl(value1, string.Empty);
                        ShowControl(control);
                        break;
                    }
                case "חוזה":
                    {
                        ContractUserControl control = new ContractUserControl(value1, ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Contracts, value2, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.PROJECT_CODE));
                        ShowControl(control);
                        break;
                    }
                case "חשבון":
                    {
                        //string clientCode = ExcelHelper.Instance.get
                        string clientCode = value3;
                        string clientName = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientCode, ColumnNames.CLIENT_CODE, ColumnNames.CLIENT_NAME);
                        BillUserControl control = new BillUserControl(clientCode, value2/*contract*/, SaveType.Update);
                        ShowControl(control);
                        break;
                    }
            }          
        }

        private void ShowControl(UserControl control)
        {
            searchSplit.Panel1.Visible = true;
            searchSplit.Panel1.Select();
            searchSplit.Panel1.Controls.Add(control);
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            checkFormsStatus();
        }

        private void createBillBtn_Click(object sender, EventArgs e)
        {
              object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);
            oWord.ActiveWindow.Selection.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
            oWord.ActiveWindow.Selection.ParagraphFormat.SpaceAfter = 1.0F;
            //Insert a paragraph at the beginning of the document.
            Microsoft.Office.Interop.Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = CreateAddresseeText();
            oPara1.Range.InsertParagraphAfter();
            
               //24 pt spacing after paragraph.
            //oPara1.Range.InsertParagraphAfter();
            /*
            //Insert a paragraph at the end of the document.
            Word.Paragraph oPara2;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara2.Range.Text = "Heading 2";
            oPara2.Format.SpaceAfter = 6;
            oPara2.Range.InsertParagraphAfter();

            //Insert another paragraph.
            Word.Paragraph oPara3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara3.Range.Text = "This is a sentence of normal text. Now here is a table:";
            oPara3.Range.Font.Bold = 0;
            oPara3.Format.SpaceAfter = 24;
            oPara3.Range.InsertParagraphAfter();

            //Insert a 3 x 5 table, fill it with data, and make the first row
            //bold and italic.
            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 3, 5, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            int r, c;
            string strText;
            for (r = 1; r <= 3; r++)
                for (c = 1; c <= 5; c++)
                {
                    strText = "r" + r + "c" + c;
                    oTable.Cell(r, c).Range.Text = strText;
                }
            oTable.Rows[1].Range.Font.Bold = 1;
            oTable.Rows[1].Range.Font.Italic = 1;

            //Add some text after the table.
            Word.Paragraph oPara4;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara4.Range.InsertParagraphBefore();
            oPara4.Range.Text = "And here's another table:";
            oPara4.Format.SpaceAfter = 24;
            oPara4.Range.InsertParagraphAfter();

            //Insert a 5 x 2 table, fill it with data, and change the column widths.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 5, 2, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            for (r = 1; r <= 5; r++)
                for (c = 1; c <= 2; c++)
                {
                    strText = "r" + r + "c" + c;
                    oTable.Cell(r, c).Range.Text = strText;
                }
            oTable.Columns[1].Width = oWord.InchesToPoints(2); //Change width of columns 1 & 2
            oTable.Columns[2].Width = oWord.InchesToPoints(3);

            //Keep inserting text. When you get to 7 inches from top of the
            //document, insert a hard page break.
            object oPos;
            double dPos = oWord.InchesToPoints(7);
            oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range.InsertParagraphAfter();
            do
            {
                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                wrdRng.ParagraphFormat.SpaceAfter = 6;
                wrdRng.InsertAfter("A line of text");
                wrdRng.InsertParagraphAfter();
                oPos = wrdRng.get_Information
                               (Word.WdInformation.wdVerticalPositionRelativeToPage);
            }
            while (dPos >= Convert.ToDouble(oPos));
            object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
            object oPageBreak = Word.WdBreakType.wdPageBreak;
            wrdRng.Collapse(ref oCollapseEnd);
            wrdRng.InsertBreak(ref oPageBreak);
            wrdRng.Collapse(ref oCollapseEnd);
            wrdRng.InsertAfter("We're now on page 2. Here's my chart:");
            wrdRng.InsertParagraphAfter();

            //Insert a chart.
            Word.InlineShape oShape;
            object oClassType = "MSGraph.Chart.8";
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oShape = wrdRng.InlineShapes.AddOLEObject(ref oClassType, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing);

            //Demonstrate use of late bound oChart and oChartApp objects to
            //manipulate the chart object with MSGraph.
            object oChart;
            object oChartApp;
            oChart = oShape.OLEFormat.Object;
            oChartApp = oChart.GetType().InvokeMember("Application",
                BindingFlags.GetProperty, null, oChart, null);

            //Change the chart type to Line.
            object[] Parameters = new Object[1];
            Parameters[0] = 4; //xlLine = 4
            oChart.GetType().InvokeMember("ChartType", BindingFlags.SetProperty,
                null, oChart, Parameters);

            //Update the chart image and quit MSGraph.
            oChartApp.GetType().InvokeMember("Update",
                BindingFlags.InvokeMethod, null, oChartApp, null);
            oChartApp.GetType().InvokeMember("Quit",
                BindingFlags.InvokeMethod, null, oChartApp, null);
            //... If desired, you can proceed from here using the Microsoft Graph 
            //Object model on the oChart and oChartApp objects to make additional
            //changes to the chart.

            //Set the width of the chart.
            oShape.Width = oWord.InchesToPoints(6.25f);
            oShape.Height = oWord.InchesToPoints(3.57f);

            //Add text after the chart.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("THE END.");*/

            //Close this form.
            this.Close();        
        }

        private string CreateAddresseeText()
        {
            return string.Format("לכבוד\n{0}\n{1}\n{2}\n{3}", contactManTxtBox.Text,contactManDesctxt.Text, ClientNamesComboBox.Text,ClientAddressTxtBox.Text);
        }
        }
    }
}
