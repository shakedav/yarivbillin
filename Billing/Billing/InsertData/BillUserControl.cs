using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Billing.Properties;
using Word = Microsoft.Office.Interop.Word;

namespace Billing.InsertData
{
    public partial class BillUserControl : UserControl
    {
        bool isNew = true;
        public string clientCode;
        public Point lastControl;
        private int tblRow = 0;
        private int tblCol = 0;
        Dictionary<int,List<TextBox>> valuesList = new Dictionary<int,List<TextBox>>();
        MainForm parent;
    
        public BillUserControl()
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
            billStatusComboBox.DataSource = ExcelHelper.Instance.StatusTypes.Columns[ColumnNames.STATUS_CODE].Table;
            billStatusComboBox.DisplayMember = ColumnNames.STATUS_NAME;
            billStatusComboBox.Text = ExcelHelper.Instance.StatusTypes.Rows[billStatusComboBox.SelectedIndex][ColumnNames.STATUS_NAME].ToString();
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalBillsTxtBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
            totalBillsIncludingTxtBox.Text = (double.Parse(totalBillsTxtBox.Text) + double.Parse(totalToPayTxtBox.Text)).ToString();
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(contractCodeComboBox.Text);
            billDateBox.Text = DateTime.Now.ToString();
            GetHebrewDate();
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

        public BillUserControl(string selectedClient, string selectedContractOrBill, SaveType saveType)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            Onload();
            if (saveType == SaveType.Update)
            {
                dic = ExcelHelper.Instance.GetRowItemsByFilters(ExcelHelper.Instance.Bills, ColumnNames.CLIENT_CODE, selectedClient, ColumnNames.BILL_NUMBER_YARIV, selectedContractOrBill);
            }
            if (dic.Count > 0)
            {
                isNew = false;
            }
            if (isNew)
            {
                clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(selectedClient);
                clientNameComboBox.Enabled = false;
                contractCodeComboBox.SelectedIndex = contractCodeComboBox.FindStringExact(selectedContractOrBill);
                contractCodeComboBox.Enabled = false;
                foreach (string type in (ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.ValueInBill, ColumnNames.CONTRACT_CODE_YARIV, contractCodeComboBox.Text, ColumnNames.BILL_NUMBER_YARIV)))
                {
                    CreateValues(int.Parse(type));
                }
            }
            else
            {
                clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients,selectedClient,ColumnNames.CLIENT_CODE,ColumnNames.CLIENT_NAME));
                clientNameComboBox.Enabled = false;
                contractCodeComboBox.SelectedIndex = contractCodeComboBox.FindStringExact(dic[ColumnNames.CONTRACT_CODE_YARIV]);
                contractCodeComboBox.Enabled = false;
                billDateBox.Text = dic[ColumnNames.BILL_DATE];
                billNumberTxtBox.Text = dic[ColumnNames.BILL_NUMBER_YARIV];
                billSequenceInContractTxtBox.Text = dic[ColumnNames.BILL_SEQUENCE];
                lastBillTxtBox.Text = dic[ColumnNames.PREVIOUS_BILL];
                maamTxtBox.Text = dic[ColumnNames.MAAM];
                billStatusComboBox.SelectedItem = dic[ColumnNames.STATUS_TYPE];
                foreach (int type in ExcelHelper.Instance.getValuesFromDB(contractCodeComboBox.Text))
                {
                    foreach (DataRow row in ExcelHelper.Instance.getValueRows(contractCodeComboBox.Text, billNumberTxtBox.Text, type.ToString()))
                    {                        
                        fillValues(type, row[ColumnNames.PAYMENT].ToString(), row[ColumnNames.QUANTITY].ToString());
                    }
                }
                CheckTotalAmount_Click(this, null);
            }
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
            this.Parent.Controls.Remove(this);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsAreFilled())
                {
                    if (CheckAndSave())
                    {
                        this.Parent.Controls.Remove(this);
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
                LogWriter.Instance.Error("error when saving Bill info", ex);
            }
            LogWriter.Instance.Trace("Bill Saved");
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
                SaveType type = ExcelHelper.Instance.shouldSave("חשבון חלקי {0} או חשבון עבור חודש זה", billSequenceInContractTxtBox.Text);
                switch (type)
                {
                    case SaveType.SaveNew:
                    case SaveType.Update:
                        {
                            SaveData(type);
                            return true;
                        }
                    case SaveType.NA:
                    default:
                        break;
                }
            }
            else
            {
                SaveData(SaveType.SaveNew);
                return true;
            }
            return false;
        }

        private bool IsDataExist()
        {
            return (ExcelHelper.Instance.CheckExistence(billDateBox.Text, contractCodeComboBox.Text, ColumnNames.BILL_DATE, ColumnNames.CONTRACT_CODE_YARIV, ExcelHelper.Instance.Bills)
                || (ExcelHelper.Instance.CheckExistence(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text, ColumnNames.BILL_SEQUENCE, ColumnNames.CONTRACT_CODE_YARIV, ExcelHelper.Instance.Bills)));
        }

        private void SaveData(SaveType saveType)
        {
            if (saveType == SaveType.SaveNew)
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
                    ExcelHelper.Instance.SaveDataToExcel(billsRow, ExcelHelper.Instance.Bills.TableName, SaveType.SaveNew);
                    foreach (KeyValuePair<int, List<TextBox>> list in valuesList)
                    {
                        if (list.Value.Count == 2)
                        {
                            DataRow valueRow = ExcelHelper.Instance.ValueInBill.NewRow();
                            valueRow[ColumnNames.PAYMENT] = list.Value[0].Text;
                            valueRow[ColumnNames.QUANTITY] = list.Value[1].Text;
                            valueRow[ColumnNames.VALUE_CODE] = list.Value[0].Name;
                            valueRow[ColumnNames.CONTRACT_CODE_YARIV] = contractCodeComboBox.Text;
                            valueRow[ColumnNames.BILL_NUMBER_YARIV] = billNumberTxtBox.Text;
                            ExcelHelper.Instance.SaveDataToExcel(valueRow, ExcelHelper.Instance.ValueInBill.TableName, SaveType.SaveNew);
                        }
                    }
                }
            }
            else
            {
                object[] obj = new object[2] { ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Bills,
                                                contractCodeComboBox.Text,ColumnNames.CONTRACT_CODE_YARIV,ColumnNames.BILL_SEQUENCE),billNumberTxtBox.Text};
                DataRow row = ExcelHelper.Instance.Bills.Rows.Find(obj);
                if (row == null)
                {
                    Dictionary<string, string> dic = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Bills, ColumnNames.BILL_DATE, billDateBox.Text);
                    obj = new object[2] { dic[ColumnNames.BILL_NUMBER_YARIV], dic[ColumnNames.CONTRACT_CODE_YARIV] };
                    row = ExcelHelper.Instance.Bills.Rows.Find(obj);
                }
                row[ColumnNames.CONTRACT_CODE_YARIV] = obj[1];
                row[ColumnNames.BILL_NUMBER_YARIV] = obj[0];
                row[ColumnNames.BILL_DATE] = billDateBox.Text;
                row[ColumnNames.BILL_SEQUENCE] = billSequenceInContractTxtBox.Text;
                row[ColumnNames.PREVIOUS_BILL] = lastBillTxtBox.Text;
                row[ColumnNames.BILL_AMOUNT] = totalToPayTxtBox.Text;
                row[ColumnNames.MAAM] = maamTxtBox.Text;
                row[ColumnNames.TOTAL_AMOUNT] = totalWithMaamTextBox.Text;
                row[ColumnNames.STATUS_TYPE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.StatusTypes, billStatusComboBox.Text, ColumnNames.STATUS_NAME, ColumnNames.STATUS_CODE);
                row[ColumnNames.CLIENT_CODE] = clientCode;
                row[ColumnNames.HEBREW_DATE] = hebDateTxtBox.Text;
                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Bills.TableName, SaveType.Update);
                foreach (KeyValuePair<int, List<TextBox>> list in valuesList)
                {
                    if (list.Value.Count == 2)
                    {
                        DataRow valueRow = ExcelHelper.Instance.ValueInBill.NewRow();
                        valueRow[ColumnNames.PAYMENT] = list.Value[0].Text;
                        valueRow[ColumnNames.QUANTITY] = list.Value[1].Text;
                        valueRow[ColumnNames.VALUE_CODE] = list.Value[0].Name;
                        valueRow[ColumnNames.CONTRACT_CODE_YARIV] = contractCodeComboBox.Text;
                        valueRow[ColumnNames.BILL_NUMBER_YARIV] = billNumberTxtBox.Text;
                        ExcelHelper.Instance.SaveDataToExcel(valueRow, ExcelHelper.Instance.ValueInBill.TableName, SaveType.SaveNew);
                    }
                }
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
            ValuesCollection.Controls.Clear();
            valuelbl.Visible = false;
            valueComboBox.Visible = false;
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
            if (ValuesCollection.Controls.Count == 0)
            {
                valuelbl.Visible = true;
                valueComboBox.Visible = true;
            }
            else
            {
                if (ValuesCollection.Controls.Count > 0)
                {
                    if (ValuesCollection.Controls[0].Name == "Error")
                    {
                        ValuesCollection.Controls.Clear();
                        valuelbl.Visible = false;
                        valueComboBox.Visible = false;
                    }
                    else
                    {
                        valuelbl.Visible = true;
                        valueComboBox.Visible = true;
                    }
                }
                else
                {
                    ValuesCollection.Controls.Clear();
                    Label lbl = new Label();
                    Point lblSize = new Point(100, 50);
                    lbl.ForeColor = Color.Red;
                    lbl.Text = "אין חוזה לפרוייקט זה או שאין לו תמורות מוגדרות, צור חדש";
                    lbl.Size = new Size(lblSize);
                    lbl.Name = "Error";
                    ValuesCollection.Controls.Add(lbl);
                }
            }
        }

        private void valueComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CreateValues(int.Parse(ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ValueTypes,valueComboBox.SelectedValue.ToString(), ColumnNames.VALUE_TYPE, ColumnNames.VALUE_CODE)));
        }

        private void CreateValues(int valueType)
        {
            Point size = new Point(60, 50);
            Point lblSize = new Point(100, 50);
            ValuesCollection.Visible = true;
            List<TextBox> textBoxes = new List<TextBox>();
            switch (valueType)
            {
                case 1:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Name = "1";
                        txt.Size = new Size(size);
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("תעריף שעתי");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "1";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "1";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("מספר שעות עבודה");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "1";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 2:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "2";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("תעריף חודשי");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "2";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "2";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("מספר חודשים");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "2";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 3:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "3";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("אחוז משכר טרחה");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "3";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "3";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("שכר הטרחה");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "3";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 4:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "4";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("סכום לתשלום");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "4";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "4";
                        text.Visible = false;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, null);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 5:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "5";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("אחוז מהקבלן");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "5";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "5";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("סכום הקבלן");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "5";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 6:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "6";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("סכום החשבון");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "6";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "6";
                        text.Visible = false;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, null);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
            }

            valuelbl.Visible = false;
            valueComboBox.Visible = false;
        }


        private void fillValues(int valueType, string amount, string sum)
        {
            Point size = new Point(60, 50);
            Point lblSize = new Point(100, 50);
            ValuesCollection.Visible = true;
            List<TextBox> textBoxes = new List<TextBox>();
            switch (valueType)
            {
                case 1:
                    {
                        TextBox txt = CreateTextBox(amount);
                        txt.Name = "1";
                        txt.Size = new Size(size);
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("תעריף שעתי");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "1";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox(sum);
                        text.Size = new Size(size);
                        text.Name = "1";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("מספר שעות עבודה");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "1";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 2:
                    {
                        TextBox txt = CreateTextBox(amount);
                        txt.Size = new Size(size);
                        txt.Name = "2";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("תעריף חודשי");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "2";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox(sum);
                        text.Size = new Size(size);
                        text.Name = "2";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("מספר חודשים");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "6";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 3:
                    {
                        TextBox txt = CreateTextBox(amount);
                        txt.Size = new Size(size);
                        txt.Name = "3";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("אחוז משכר טרחה");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "3";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox(sum);
                        text.Size = new Size(size);
                        text.Name = "3";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("שכר הטרחה");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "3";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 4:
                    {
                        TextBox txt = CreateTextBox(amount);
                        txt.Size = new Size(size);
                        txt.Name = "4";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("סכום לתשלום");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "4";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "4";
                        text.Visible = false;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, null);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 5:
                    {
                        TextBox txt = CreateTextBox(amount);
                        txt.Size = new Size(size);
                        txt.Name = "5";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("אחוז מהקבלן");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "5";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox(sum);
                        text.Size = new Size(size);
                        text.Name = "5";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("סכום הקבלן");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "5";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 6:
                    {
                        TextBox txt = CreateTextBox(amount);
                        txt.Size = new Size(size);
                        txt.Name = "6";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("סכום החשבון");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "6";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "6";
                        text.Visible = false;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, null);
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
                ValuesCollection.Controls.Remove(b);
                ValuesCollection.Controls.Remove(txt);
                ValuesCollection.Controls.Remove(text);
                ValuesCollection.Controls.Remove(lbl);
                if (lbl1 != null)
                {
                    ValuesCollection.Controls.Remove(lbl1);
                    }
                valuesList.Remove(row);
                if (ValuesCollection.Controls.Count == 0)
                {
                    ValuesCollection.Visible = false;
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
            contractused.Text = 100*((double.Parse(totalBillsTxtBox.Text) + 
                                    double.Parse(totalToPayTxtBox.Text)) /
                                    double.Parse(ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Contracts, contractCodeComboBox.Text, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.VALUE))) + "%";
        }

        private void billDateBox_ValueChanged(object sender, EventArgs e)
        {
            GetHebrewDate();            
        }

        private string GetHebrewDate()
        {
            System.Text.StringBuilder hebrewFormatedString = new System.Text.StringBuilder();
            CultureInfo jewishCulture = CultureInfo.CreateSpecificCulture("he-IL");
            jewishCulture.DateTimeFormat.Calendar = new HebrewCalendar();
            hebrewFormatedString.Append(billDateBox.Value.ToString("dddd", jewishCulture) + " ");
            hebrewFormatedString.Append(billDateBox.Value.ToString("dd", jewishCulture) + " ");
            hebrewFormatedString.Append("" + billDateBox.Value.ToString("y", jewishCulture));
            hebDateTxtBox.Text = hebrewFormatedString.ToString();
            return hebDateTxtBox.Text;
        }

        private void createBillBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> client = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_NAME, clientNameComboBox.Text);
            Dictionary<string, string> project = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Projects, ColumnNames.CLIENT_CODE, client[ColumnNames.CLIENT_CODE]);
            Dictionary<string, string> contract = ExcelHelper.Instance.GetRowItemsByFilters(ExcelHelper.Instance.Contracts, ColumnNames.CLIENT_CODE, client[ColumnNames.CLIENT_CODE], ColumnNames.PROJECT_CODE, project[ColumnNames.PROJECT_CODE]);
            

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);
            oWord.ActiveWindow.Selection.ParagraphFormat.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
            oWord.ActiveWindow.Selection.ParagraphFormat.SpaceAfter = 1.0F;
            //Insert a paragraph at the beginning of the document.
            Microsoft.Office.Interop.Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Font.Bold = 1;
            oPara1.Range.Font.Size = 16;
            
            oPara1.Range.Text = CreateAddresseeText(client, project,contract);
            oPara1.Range.InsertParagraphAfter();
            oPara1.Range.Font.Bold = 1;

            float leftPos = (float)oWord.Selection.get_Information(Microsoft.Office.Interop.Word.WdInformation.wdHorizontalPositionRelativeToTextBoundary);
            float topPos = (float)oWord.Selection.get_Information(Microsoft.Office.Interop.Word.WdInformation.wdVerticalPositionRelativeToTextBoundary);
            Size s = new Size(100, 100);
            oDoc.Shapes.AddPicture(System.Configuration.ConfigurationSettings.AppSettings["YarivIcon"], false, true, null, null,s.Width,s.Height);
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            
            oPara1.Range.InsertParagraph();
            oPara1.Range.InsertParagraph();
            oPara1.Range.InsertParagraph();
            oPara1.Indent();
            oPara1.Indent();
            oPara1.Indent();
            oPara1.Indent();
            oPara1.Indent();
            oPara1.Indent();
            oPara1.Indent();
            oPara1.Indent();
            oPara1.Indent();
            oPara1.Indent();
            oPara1.Range.Text = CreateAddresseeText(client, project, contract);

            
            
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
            //this.Parent.Controls.Remove(this);
        }

        private string CreateAddresseeText(Dictionary<string,string> client, Dictionary<string,string> project, Dictionary<string,string> contract)
        {
            return string.Format("לכבוד\n{0}\n{1}\n{2}\n{3}", project[ColumnNames.PROJECT_CONTACT_MAN], project[ColumnNames.CONTACT_MAN_DESC], project[ColumnNames.CONTACT_MAN_DESC], client[ColumnNames.ADRESS]);// ClientAddressTxtBox.Text);
        }        
    }
}
