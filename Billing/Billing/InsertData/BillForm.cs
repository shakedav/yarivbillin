﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Billing.DataObjects;

namespace Billing
{
    public partial class BillForm : Form
    {        
        public string clientCode;
        public Point lastControl;
        private int tblRow = 0;
        private int tblCol = 0;
        private ArrayList valuesList;
        public BillForm()
        {
            Onload();
            lastControl = new Point(contractParttxtBox.Location.X, addValue.Location.Y+15);
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
            valueComboBox.DataSource = ExcelHelper.Instance.ValueTypes.Columns[ColumnNames.VALUE_CODE].Table;
            valueComboBox.DisplayMember = ColumnNames.VALUE_TYPE;
            valueComboBox.Text = ExcelHelper.Instance.ValueTypes.Rows[valueComboBox.SelectedIndex][ColumnNames.VALUE_TYPE].ToString();
            billStatusComboBox.DataSource = ExcelHelper.Instance.StatusTypes.Columns[ColumnNames.STATUS_CODE].Table;
            billStatusComboBox.DisplayMember = ColumnNames.STATUS_NAME;
            billStatusComboBox.Text = ExcelHelper.Instance.StatusTypes.Rows[billStatusComboBox.SelectedIndex][ColumnNames.STATUS_NAME].ToString();
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalBillsTxtBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(contractCodeComboBox.Text);
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
            totalToPayTxtBox.Clear();
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
                    CheckAndSave();
                    Close();
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
                || (string.IsNullOrEmpty(totalWithMaamTextBox.Text)) || (string.IsNullOrEmpty(billStatusComboBox.Text)))
            {
                return false;
            }
            return true;
        }

        private void CheckAndSave()
        {
            if (IsDataExist())
            {
                if (ExcelHelper.Instance.shouldSave("חשבון חלקי {0} או חשבון עבור חודש זה", billSequenceInContractTxtBox.Text))
                {
                    SaveData();
                }
            }
            else
            {
                SaveData();
            }
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
                    //billsRow[ColumnNames.VALUE_CALC] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ValueTypes, valueComboBox.Text, ColumnNames.VALUE_TYPE, ColumnNames.VALUE_CODE);
                    billsRow[ColumnNames.PREVIOUS_BILL] = lastBillTxtBox.Text;
                    billsRow[ColumnNames.BILL_AMOUNT] = totalToPayTxtBox.Text;
                    billsRow[ColumnNames.MAAM] = maamTxtBox.Text;
                    billsRow[ColumnNames.TOTAL_AMOUNT] = totalWithMaamTextBox.Text;
                    billsRow[ColumnNames.STATUS_TYPE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.StatusTypes, billStatusComboBox.Text, ColumnNames.STATUS_NAME, ColumnNames.STATUS_CODE);
                    billsRow[ColumnNames.CLIENT_CODE] = clientCode;
                    ExcelHelper.Instance.SaveDataToExcel(billsRow, ExcelHelper.Instance.Bills.TableName);
                    ExcelHelper.Instance.Bills.Rows.Add(billsRow);
                    int y = 0;
                    DataRow valueRow = ExcelHelper.Instance.ValueInBill.NewRow();
                    foreach(Control c in tblControls.Controls)
                    {
                        if (c.Location.Y == 3)
                        {
                            ExcelHelper.Instance.SaveDataToExcel(valueRow, ExcelHelper.Instance.ValueInBill.TableName);
                            ExcelHelper.Instance.Bills.Rows.Add(valueRow);
                        }

                        if (c.Location.Y != y)
                        {
                            valueRow = ExcelHelper.Instance.ValueInBill.NewRow();
                            y = c.Location.Y;
                        }
                        valueRow[ColumnNames.VALUE_CODE] = valueComboBox.SelectedValue;
                        valueRow[ColumnNames.CONTRACT_CODE_YARIV] = contractCodeComboBox.Text;
                        valueRow[ColumnNames.BILL_NUMBER_YARIV] = billNumberTxtBox.Text;
                        if (c.Name == "payment")
                        {
                            valueRow[ColumnNames.PAYMENT] = c.Text;
                        }
                        if (c.Name == "quantity")
                        {
                            valueRow[ColumnNames.QUANTITY] = billNumberTxtBox.Text;
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

        private void totalToPayTxtBox_Leave(object sender, EventArgs e)
        {
            double tot;
            bool total = double.TryParse(totalToPayTxtBox.Text, out tot);
            maamTxtBox.Text = string.IsNullOrEmpty(Constants.Instance.MAAM.ToString()) ? "0" : maamTxtBox.Text;
            if ((total) && (!string.IsNullOrEmpty(maamTxtBox.Text)))
            {
                totalWithMaamTextBox.Text = ((double.Parse(totalToPayTxtBox.Text) + (double.Parse(totalToPayTxtBox.Text) * (double.Parse(maamTxtBox.Text)))).ToString());
            }
            else
            {
                errorsLabel.Visible = true;
                errorsLabel.Text = "סכום שגוי, בדוק את הסכום ונסה שוב";
                errorsLabel.ForeColor = Color.Red;
            }
        }

        private void totalToPayTxtBox_Enter(object sender, EventArgs e)
        {
            errorsLabel.Visible = false;
        }

        private void totalToPayTxtBox_TextChanged(object sender, EventArgs e)
        {
            errorsLabel.Visible = false;
        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {           
            billNumberTxtBox.Clear();
            billSequenceInContractTxtBox.Clear();
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalToPayTxtBox.Clear();
            maamTxtBox.Clear();
            totalWithMaamTextBox.Clear();
            errorsLabel.Visible = false;
            contractParttxtBox.Clear();
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(contractCodeComboBox.Text);
        }

        private void contractCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            billSequenceInContractTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, ColumnNames.BILL_SEQUENCE, ColumnNames.CONTRACT_CODE_YARIV, contractCodeComboBox.Text);
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalBillsTxtBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
            billNumberTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.CLIENT_CODE, clientCode);
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(contractCodeComboBox.Text);
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
        }

        private void addValue_Click(object sender, EventArgs e)
        {
            valuelbl.Visible = true;
            valueComboBox.Visible = true;            
        }

        private void valueComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Point size = new Point(160, 10);
            tblControls.Visible = true;
            switch (valueComboBox.SelectedIndex)
            {                    
                case 0:
                    {
                        TextBox txt = CreateTextBox("הכנס תעריף שעתי");
                        txt.Name = "payment";
                        txt.Size = new Size(size);
                        tblControls.Controls.Add(txt,tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("הכנס מספר שעות עבודה");                        
                        text.Size = new Size(size);
                        text.Name = "quantity";
                        tblControls.Controls.Add(text,tblCol,tblRow);
                        tblCol++;
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b);         
                        tblCol = 0;
                        tblRow++;                        
                        break;
                    }
                case 1:
                    {
                        TextBox txt = CreateTextBox("הכנס תעריף חודשי");
                        txt.Size = new Size(size);
                        txt.Name = "payment";
                        tblControls.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("הכנס מספר חודשי עבודה");
                        text.Size = new Size(size);
                        text.Name = "quantity";
                        tblControls.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 2:
                    {
                        TextBox txt = CreateTextBox("הכנס אחוז משכר טרחה");
                        txt.Size = new Size(size);
                        txt.Name = "payment";
                        tblControls.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "quantity";
                        text.Visible = false;
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 3:
                    {
                        TextBox txt = CreateTextBox("הכנס סכום לתשלום");
                        txt.Size = new Size(size);
                        txt.Name = "payment";
                        tblControls.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "quantity";
                        text.Visible = false;                       
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 4:
                    {
                        TextBox txt = CreateTextBox("הכנס אחוז מהסכום של הקבלן");
                        txt.Size = new Size(size);
                        txt.Name = "payment";
                        tblControls.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "quantity";
                        text.Visible = false;                       
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 5:
                    {
                        TextBox txt = CreateTextBox("הכנס את סכום החשבון");
                        txt.Size = new Size(size);
                        txt.Name = "payment";
                        tblControls.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "quantity";
                        text.Visible = false;                       
                        Button b = CreateDeleteBtn();
                        tblControls.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
            }
          
            valuelbl.Visible = false;
            valueComboBox.Visible = false;
        }

        private void SetDeleteEventHandler(TextBox txt, TextBox text, Button b)
        {
            b.Click += (sender1, e1) =>
            {
                tblControls.Controls.Remove(b);
                tblControls.Controls.Remove(txt);
                tblControls.Controls.Remove(text);
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
            txt.Leave += (sender1, e1) =>
                {
                    valuesList.Add(new ValueItem(txt.Text, text.Text));
                };

            return txt;
        }

        private void clearText(object sender, Control e)
        {
            e.Text = "";
        }
    }
}
