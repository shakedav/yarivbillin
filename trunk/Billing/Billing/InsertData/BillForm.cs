using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Billing.DataObjects;
using System.Globalization;

namespace Billing
{
    public partial class BillForm : Form
    {        
        public string clientCode;
        public Point lastControl;
        private int tblRow = 0;
        private int tblCol = 0;
        Dictionary<int,List<TextBox>> valuesList = new Dictionary<int,List<TextBox>>();
        public BillForm()
        {
            Onload();
        }

        private void Onload()
        {
            InitializeComponent();            
            clientNameComboBox.DataSource = ExcelHelper.Instance.Clients.Columns[ColumnNames.CLIENT_CODE].Table;
            clientNameComboBox.DisplayMember = ColumnNames.CLIENT_NAME;
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString();
            clientCode = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE);
            billNumberTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.CONTRACT_CODE_YARIV, clientCode);
            contractCodeComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Contracts, ColumnNames.CLIENT_CODE,
                                                                        ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients,
                                                                        clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE),
                                                                        ColumnNames.CONTRACT_CODE_YARIV);
            billSequenceInContractTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, ColumnNames.BILL_SEQUENCE, ColumnNames.CONTRACT_CODE_YARIV, contractCodeComboBox.Text);            
            valueComboBox.DisplayMember = ColumnNames.VALUE_TYPE;
            valueComboBox.Text = ExcelHelper.Instance.ValueTypes.Rows[valueComboBox.SelectedIndex][ColumnNames.VALUE_TYPE].ToString();
            billStatusComboBox.DataSource = ExcelHelper.Instance.StatusTypes.Columns[ColumnNames.STATUS_CODE].Table;
            billStatusComboBox.DisplayMember = ColumnNames.STATUS_NAME;
            billStatusComboBox.Text = ExcelHelper.Instance.StatusTypes.Rows[billStatusComboBox.SelectedIndex][ColumnNames.STATUS_NAME].ToString();
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalBillsTxtBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
            totalBillsIncludingTxtBox.Text = (double.Parse(totalBillsTxtBox.Text) + double.Parse(totalToPayTxtBox.Text)).ToString();
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(contractCodeComboBox.Text);
        }

        private object GetAllowedValues()
        {
            List<int> valuesAllowed = ExcelHelper.Instance.getValuesFromDB(contractCodeComboBox.Text);

            List<string> valuesDic = new List<string>();

            foreach (int valueCode in valuesAllowed)
            {
                valuesDic.Add(ExcelHelper.Instance.ValueTypes.Rows[valueCode - 1][1].ToString());
                
            }
            return valuesDic;            
        }

        public BillForm(string selectedClient, string selectedContract)
        {
            Onload();
            clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(selectedClient);
            clientNameComboBox.Enabled = false;
            contractCodeComboBox.SelectedIndex = contractCodeComboBox.FindStringExact(selectedContract);
            contractCodeComboBox.Enabled = false;
        }

        private void clientNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastBillTxtBox.Clear();
            totalToPayTxtBox.Text = "0";
            maamTxtBox.Text = Constants.Instance.MAAM.ToString();
            contractCodeComboBox.DataSource = null;
            contractCodeComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Contracts, ColumnNames.CLIENT_CODE,
                ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE), ColumnNames.CONTRACT_CODE_YARIV);
            contractCodeComboBox.Text = contractCodeComboBox.SelectedItem == null ? "אין חוזים ללקוח זה" : contractCodeComboBox.SelectedItem.ToString();            
            billSequenceInContractTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, ColumnNames.BILL_SEQUENCE, ColumnNames.CONTRACT_CODE_YARIV, contractCodeComboBox.Text);
            if (contractCodeComboBox.Text != "אין חוזים ללקוח זה")
            {
                lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            }
            totalBillsTxtBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
            totalBillsIncludingTxtBox.Text = (double.Parse(totalBillsTxtBox.Text) + double.Parse(totalToPayTxtBox.Text)).ToString();
            clientCode = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE);
            billNumberTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.CLIENT_CODE, clientCode);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsAreFilled())
                {
                    if (CheckAndSave())
                    {
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("מלא את כל השדות בבקשה");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        private void ShowErrorMessage(Exception ex)
        {
            MessageBoxOptions options = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", Constants.Instance.Path);
            MessageBox.Show(this, text + "\n\n" + ex, "בעיה בשמירת חשבון", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
        }

        private bool CheckAllFieldsAreFilled()
        {
            if ((string.IsNullOrEmpty(clientNameComboBox.Text)) || (string.IsNullOrEmpty(contractCodeComboBox.Text))
                || (string.IsNullOrEmpty(billNumberTxtBox.Text)) || (string.IsNullOrEmpty(billSequenceInContractTxtBox.Text))
                || (string.IsNullOrEmpty(valueComboBox.Text)) || (string.IsNullOrEmpty(totalToPayTxtBox.Text)) || (string.IsNullOrEmpty(maamTxtBox.Text))
                || (string.IsNullOrEmpty(totalWithMaamTextBox.Text)) || (string.IsNullOrEmpty(billStatusComboBox.Text)) || (string.IsNullOrEmpty(hebDateTxtBox.Text)))
            {
                return false;
            }
            return true;
        }

        private bool CheckAndSave()
        {
            if (IsDataExist())
            {
                if (ExcelHelper.Instance.shouldSave("חשבון חלקי {0} או חשבון עבור חודש זה", billSequenceInContractTxtBox.Text))
                {
                    SaveData();
                    return true;
                }
            }
            else
            {
                SaveData();
                return true;
            }
            return false;
        }

        private bool IsDataExist()
        {
            return (ExcelHelper.Instance.CheckExistence(billDateBox.Text, contractCodeComboBox.Text, ColumnNames.BILL_DATE, ColumnNames.CONTRACT_CODE_YARIV, ExcelHelper.Instance.Bills)
                || (ExcelHelper.Instance.CheckExistence(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text, ColumnNames.BILL_SEQUENCE, ColumnNames.CONTRACT_CODE_YARIV, ExcelHelper.Instance.Bills)));
        }

        private void SaveData()
        {
            try
            {
                DataRow billsRow = ExcelHelper.Instance.Bills.NewRow();
                
                if (!errorsLabel.Visible)
                {
                    billsRow[ColumnNames.CONTRACT_CODE_YARIV] = contractCodeComboBox.Text;
                    billsRow[ColumnNames.BILL_NUMBER_YARIV] = billNumberTxtBox.Text;
                    billsRow[ColumnNames.BILL_DATE] = billDateBox.Text;
                    billsRow[ColumnNames.BILL_SEQUENCE] = billSequenceInContractTxtBox.Text;                    
                    billsRow[ColumnNames.PREVIOUS_BILL] = lastBillTxtBox.Text;
                    billsRow[ColumnNames.BILL_AMOUNT] = totalToPayTxtBox.Text;
                    billsRow[ColumnNames.MAAM] = maamTxtBox.Text;
                    billsRow[ColumnNames.TOTAL_AMOUNT] = totalWithMaamTextBox.Text;
                    billsRow[ColumnNames.STATUS_TYPE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.StatusTypes, billStatusComboBox.Text, ColumnNames.STATUS_NAME, ColumnNames.STATUS_CODE);
                    billsRow[ColumnNames.CLIENT_CODE] = clientCode;
                    billsRow[ColumnNames.HEBREW_DATE] = hebDateTxtBox.Text;
                    ExcelHelper.Instance.SaveDataToExcel(billsRow, ExcelHelper.Instance.Bills.TableName);
                    ExcelHelper.Instance.Bills.Rows.Add(billsRow);           
                    foreach(KeyValuePair<int,List<TextBox>> list in valuesList)
                    {
                        if (list.Value.Count == 2)
                        {
                            DataRow valueRow = ExcelHelper.Instance.ValueInBill.NewRow();
                            valueRow[ColumnNames.PAYMENT] = list.Value[0].Text;
                            valueRow[ColumnNames.QUANTITY] = list.Value[1].Text;
                            valueRow[ColumnNames.VALUE_CODE] = list.Value[0].Name;
                            valueRow[ColumnNames.CONTRACT_CODE_YARIV] = contractCodeComboBox.Text;
                            valueRow[ColumnNames.BILL_NUMBER_YARIV] = billNumberTxtBox.Text;
                            ExcelHelper.Instance.SaveDataToExcel(valueRow, ExcelHelper.Instance.ValueInBill.TableName);
                            ExcelHelper.Instance.ValueInBill.Rows.Add(valueRow);
                        }
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }        

        private void billNumberTxtBox_TextChanged(object sender, EventArgs e)
        {
            billSequenceInContractTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, ColumnNames.BILL_SEQUENCE, ColumnNames.CONTRACT_CODE_YARIV, contractCodeComboBox.Text);
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);            
        }             

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {           
            billNumberTxtBox.Clear();
            billSequenceInContractTxtBox.Clear();
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalToPayTxtBox.Text = "0";
            maamTxtBox.Clear();
            totalWithMaamTextBox.Clear();
            errorsLabel.Visible = false;
            contractParttxtBox.Clear();
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(contractCodeComboBox.Text);
            contractused.Text = (double.Parse(totalBillsTxtBox.Text) + double.Parse(totalToPayTxtBox.Text)).ToString() + "%";
        }

        private void contractCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            billSequenceInContractTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, ColumnNames.BILL_SEQUENCE, ColumnNames.CONTRACT_CODE_YARIV, contractCodeComboBox.Text);
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalBillsTxtBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
            totalBillsIncludingTxtBox.Text = (double.Parse(totalBillsTxtBox.Text) + double.Parse(totalToPayTxtBox.Text)).ToString();
            billNumberTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.CLIENT_CODE, clientCode);
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(contractCodeComboBox.Text);
            contractused.Text = (double.Parse(totalBillsTxtBox.Text) + double.Parse(totalToPayTxtBox.Text)).ToString() + "%";
            valueComboBox.DataSource = GetAllowedValues();
        }

        private void billDateBox_Leave(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(billDateBox.Text);
            DateTime saveDate = DateTime.Parse(date.Month.ToString() + "/01/" + date.Year.ToString());
            billDateBox.Text = saveDate.ToString();
        }

        private void billSequenceInContractTxtBox_Leave(object sender, EventArgs e)
        {            
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalBillsTxtBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);            
            totalBillsIncludingTxtBox.Text = (double.Parse(totalBillsTxtBox.Text) + double.Parse(totalToPayTxtBox.Text)).ToString();
        }

        private void addValue_Click(object sender, EventArgs e)
        {
            valuelbl.Visible = true;
            valueComboBox.Visible = true;            
        }

        private void valueComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Point size = new Point(60, 50);
            Point lblSize = new Point(100, 50);
            tblControls.Visible = true;
            List<TextBox> textBoxes = new List<TextBox>();            
            switch (valueComboBox.SelectedIndex)
            {                    
                case 0:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Name = "1";
                        txt.Size = new Size(size);
                        tblControls.Controls.Add(txt,tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("תעריף שנתי");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "1";
                        tblControls.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");                        
                        text.Size = new Size(size);
                        text.Name = "1";
                        tblControls.Controls.Add(text,tblCol,tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("מספר שעות עבודה");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "1";
                        tblControls.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow,textBoxes);
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                       SetDeleteEventHandler(txt, text, b,tblRow, lbl,lbl1);         
                        tblCol = 0;
                        tblRow++;                        
                        break;
                    }
                case 1:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "2";
                        tblControls.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("תעריף חודשי");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "2";
                        tblControls.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "2";
                        tblControls.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("מספר חודשים");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "6";
                        tblControls.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                       valuesList.Add(tblRow,textBoxes);
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                       SetDeleteEventHandler(txt, text, b,tblRow, lbl,lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 2:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "3";
                        tblControls.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("אחוז משכר טרחה");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "3";
                        tblControls.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "3";
                        tblControls.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("שכר הטרחה");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "3";
                        tblControls.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                       valuesList.Add(tblRow,textBoxes);
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                       SetDeleteEventHandler(txt, text, b,tblRow, lbl,lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 3:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "4";
                        tblControls.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("סכום לתשלום");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "4";
                        tblControls.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "4";
                        text.Visible = false;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow,textBoxes);                     
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b,tblRow, lbl,null);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 4:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "5";
                        tblControls.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("אחוז מהקבלן");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "5";
                        tblControls.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "5";
                        tblControls.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("סכום הקבלן");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "5";
                        tblControls.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                       valuesList.Add(tblRow,textBoxes);                     
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                       SetDeleteEventHandler(txt, text, b,tblRow, lbl,lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 5:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "6";
                        tblControls.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("סכום החשבון");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "6";
                        tblControls.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "6";
                        text.Visible = false;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow,textBoxes);                    
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b,tblRow, lbl,null);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
            }
          
            valuelbl.Visible = false;
            valueComboBox.Visible = false;
        }

        private Label CreateLabel(string p)
        {
            Label lbl = new Label();
            lbl.Text = p;
            return lbl;
        }

        private void SetDeleteEventHandler(TextBox txt, TextBox text, Button b, int row, Label lbl,Label lbl1)
        {
            b.Click += (sender1, e1) =>
            {
                tblControls.Controls.Remove(b);
                tblControls.Controls.Remove(txt);
                tblControls.Controls.Remove(text);
                tblControls.Controls.Remove(lbl);
                if (lbl1 != null)
                {
                    tblControls.Controls.Remove(lbl1);
                    }
                valuesList.Remove(row);
                if (tblControls.Controls.Count == 0)
                {
                    tblControls.Visible = false;
                }               
            };
        }

        private static Button CreateDeleteBtn()
        {
            Button b = new Button();
            b.Text = "מחק";
            b.Size = new Size(50, 25);
            return b;
        }

        private static TextBox CreateTextBox(string text)
        {
            TextBox txt = new TextBox();
            txt.Text = text;
            txt.Click += (sender1, e1) =>
            {
                txt.Clear();
            };

            return txt;
        }

        private void clearText(object sender, Control e)
        {
            e.Text = "";
        }

        private void CheckTotalAmount_Click(object sender, EventArgs e)
        {
            double totalAmount =0;
            double res = 0;
            foreach(KeyValuePair<int,List<TextBox>> list in valuesList)
            {
                if (list.Value.Count == 2)
                {            
                    if (double.TryParse(list.Value[0].Text, out res) && (double.TryParse(list.Value[1].Text, out res)))
                    {
                        totalAmount += double.Parse(list.Value[0].Text) * double.Parse(list.Value[1].Text);
                    }
                }
            }
            totalToPayTxtBox.Text = totalAmount.ToString();
            totalWithMaamTextBox.Text = (totalAmount * (1+Constants.Instance.MAAM)).ToString();
            totalBillsIncludingTxtBox.Text = (double.Parse(totalBillsTxtBox.Text) + double.Parse(totalToPayTxtBox.Text)).ToString();
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(contractCodeComboBox.Text);
            contractused.Text = (double.Parse(totalBillsTxtBox.Text) + double.Parse(totalToPayTxtBox.Text)).ToString() + "%";
        }

        private void billDateBox_ValueChanged(object sender, EventArgs e)
        {
            GetHebrewDate();            
        }

        private void GetHebrewDate()
        {
            System.Text.StringBuilder hebrewFormatedString = new System.Text.StringBuilder();
            CultureInfo jewishCulture = CultureInfo.CreateSpecificCulture("he-IL");
            jewishCulture.DateTimeFormat.Calendar = new HebrewCalendar();
            hebrewFormatedString.Append(billDateBox.Value.ToString("dddd", jewishCulture) + " ");
            hebrewFormatedString.Append(billDateBox.Value.ToString("dd", jewishCulture) + " ");
            hebrewFormatedString.Append("" + billDateBox.Value.ToString("y", jewishCulture));
            hebDateTxtBox.Text = hebrewFormatedString.ToString();
        }
    }
}

