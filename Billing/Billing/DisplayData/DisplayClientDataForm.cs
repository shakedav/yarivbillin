using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Office.Interop.Word;

namespace Billing.DisplayData
{
    public partial class DisplayClientDataForm : Form
    {
        public DisplayClientDataForm()
        {
            InitializeComponent();   
            ClientNamesComboBox.Text = "לחץ כאן להצגת רשימת הלקוחות";
        }
        #region Clients
        private void ClientNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string,string> clientDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_NAME, ExcelHelper.Instance.Clients.Rows[ClientNamesComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString());
            if (clientDataList.Count != 0)
            {
                clientTypeTxtBox.Text = clientDataList[ColumnNames.CLIENT_CODE];
                ClientAddressTxtBox.Text = clientDataList[ColumnNames.ADRESS];
                phoneTxtBox.Text = clientDataList[ColumnNames.PHONE];
                clientCodeTxtBox.Text = clientDataList[ColumnNames.CLIENT_CODE];
                emailTxtBox.Text = clientDataList[ColumnNames.EMAIL];
                FillProjectsData();                
            }
        }       

        private void ClientNamesComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            ClientNamesComboBox.DataSource = ExcelHelper.Instance.Clients.Columns[ColumnNames.CLIENT_NAME].Table;
            ClientNamesComboBox.DisplayMember = ColumnNames.CLIENT_NAME;
            ClientNamesComboBox.ValueMember = ColumnNames.CLIENT_CODE;
        }

        #endregion Clients

        #region Projects

        private void FillProjectsData()
        {
            projectCodeComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Projects, ColumnNames.CLIENT_CODE, clientCodeTxtBox.Text, ColumnNames.PROJECT_CODE);
            GetProjectData();
        }       

        private void projectCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProjectData();            
        }

        private void projectCodeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetProjectData();
        }

        private void GetProjectData()
        {
            Dictionary<string, string> ProjectDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Projects, ColumnNames.PROJECT_CODE,
                                                           ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectCodeComboBox.Text, ColumnNames.PROJECT_CODE, ColumnNames.PROJECT_CODE));
            if (ProjectDataList.Count != 0)
            {
                ClientNamesComboBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, ProjectDataList[ColumnNames.CLIENT_CODE], ColumnNames.CLIENT_CODE, ColumnNames.CLIENT_NAME);
                projectCodeComboBox.Text = ProjectDataList[ColumnNames.PROJECT_CODE];
                projectNametxtBox.Text = ProjectDataList[ColumnNames.PROJECT_NAME];
                contactManTxtBox.Text = ProjectDataList[ColumnNames.PROJECT_CONTACT_MAN];
                projectNameInviterTxtBox.Text = ProjectDataList[ColumnNames.INVITER_PROJECT_NAME];
                projectCodeInviterTxtBox.Text = ProjectDataList[ColumnNames.INVITER_PROJECT_CODE];
                projectDescriptiontxtBox.Text = ProjectDataList[ColumnNames.PROJECT_DESCRIPTION];
                contactManDesctxt.Text = ProjectDataList[ColumnNames.CONTACT_MAN_DESC];
                FillContractsData();
            }
        }
        #endregion Projects

        #region Contracts

        private void FillContractsData()
        {
            YarivComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Contracts, ColumnNames.PROJECT_CODE, projectCodeComboBox.Text, ColumnNames.CONTRACT_CODE_YARIV);
            GetContractData();
        }

        private void GetContractData()
        {
            Dictionary<string, string> contractDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Contracts, ColumnNames.CONTRACT_CODE_YARIV,
                                                           ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Contracts, YarivComboBox.Text, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CONTRACT_CODE_YARIV));
            clientContractCodetxtBox.Text = contractDataList[ColumnNames.CONRACT_CODE_CLIENT];
            valueTxtBox.Text = contractDataList[ColumnNames.VALUE];
            contractTypeComboBox.Text = ExcelHelper.Instance.ContractTypes.Rows[int.Parse(contractDataList[ColumnNames.CONTRACT_TYPE])][ColumnNames.TYPE_NAME].ToString();
            valueCalculationtxtBox.Text = contractDataList[ColumnNames.VALUE_CALCULATION];
            signingDateTxt.Text = contractDataList[ColumnNames.CONTRACT_SIGNING_DATE];
            startDateTxt.Text = contractDataList[ColumnNames.CONTRACT_START_DATE];
            endDateTxt.Text = contractDataList[ColumnNames.CONTRACT_END_DATE];
            valueCalculationWaytxtBox.Text = contractDataList[ColumnNames.VALUE_CALCULATION_WAY];
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(YarivComboBox.Text);
        }

        #endregion Contracts

        

        private void YarivComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetContractData();
            fillBillsListBox();

        }

        private void fillBillsListBox()
        {
            BillsListBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Bills, ColumnNames.CONTRACT_CODE_YARIV, projectCodeComboBox.Text, ColumnNames.BILL_NUMBER_YARIV);
        }

        private void BillsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBillData();
        }

        private void GetBillData()
        {
            Dictionary<string, string> billDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Bills, ColumnNames.BILL_NUMBER_YARIV,
                                                         ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Bills, BillsListBox.Text, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.BILL_NUMBER_YARIV));
            billDateTxt.Text = billDataList[ColumnNames.BILL_DATE];
            billNumberTxtBox.Text = billDataList[ColumnNames.BILL_NUMBER_YARIV];
            billSequenceInContractTxtBox.Text = billDataList[ColumnNames.BILL_SEQUENCE];
            //valueTxt.Text = billDataList[ColumnNames.VALUE_CALC];
            lastBillTxtBox.Text = billDataList[ColumnNames.PREVIOUS_BILL];
            totalToPayTxtBox.Text = billDataList[ColumnNames.BILL_AMOUNT];
            maamTxtBox.Text = billDataList[ColumnNames.MAAM];
            totalWithMaamTextBox.Text = billDataList[ColumnNames.TOTAL_AMOUNT];
            totalBillsTxt.Text = ExcelHelper.Instance.getTotalOfBills(YarivComboBox.Text);
            billStatusTxt.Text = ExcelHelper.Instance.StatusTypes.Rows[int.Parse(billDataList[ColumnNames.STATUS_TYPE])][ColumnNames.STATUS_NAME].ToString();            
        }

        private void createBillDocument_Click(object sender, EventArgs e)
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Word.Application();
            
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);
            oWord.ActiveWindow.Selection.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
            oWord.ActiveWindow.Selection.ParagraphFormat.SpaceAfter = 1.0F;
            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
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
