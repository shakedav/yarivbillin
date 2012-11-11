using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billing
{
    public partial class BillForm : Form
    {
        public BillForm()
        {
            Onload();
        }

        private void Onload()
        {
            InitializeComponent();
            billNumberTxtBox.Text = (ExcelHelper.Instance.Bills.Rows.Count + 1).ToString();
            clientNameComboBox.DataSource = ExcelHelper.Instance.Clients.Columns[ColumnNames.CLIENT_CODE].Table;
            clientNameComboBox.DisplayMember = ColumnNames.CLIENT_NAME;
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString();
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
            string billSequence = null ;
            lastBillTxtBox.Clear();
            totalToPayTxtBox.Clear();
            maamTxtBox.Clear();
            contractCodeComboBox.DataSource = null;
            contractCodeComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Contracts, ColumnNames.CLIENT_CODE,
                ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE), ColumnNames.CONTRACT_CODE_YARIV);
            contractCodeComboBox.Text = contractCodeComboBox.SelectedItem == null ? "אין חוזים ללקוח זה" : contractCodeComboBox.SelectedItem.ToString();
            billSequenceInContractTxtBox.Text = (billSequence == null ? "1" : billSequence); 
            if (contractCodeComboBox.Text != "אין חוזים ללקוח זה")
            {
                lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
                    //ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Bills, (int.Parse(billSequenceInContractTxtBox.Text) - 1).ToString(), ColumnNames.BILL_NUMBER_YARIV, ColumnNames.PREVIOUS_BILL);
            }
            totalBillsTxtBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
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
            string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", ExcelHelper.Path);
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
                DataRow row = ExcelHelper.Instance.Bills.NewRow();
                if (!errorsLabel.Visible)
                {
                    row[ColumnNames.CONTRACT_CODE_YARIV] = contractCodeComboBox.Text;
                    row[ColumnNames.BILL_NUMBER_YARIV] = billNumberTxtBox.Text;
                    row[ColumnNames.BILL_DATE] = billDateBox.Text;
                    row[ColumnNames.BILL_SEQUENCE] = billSequenceInContractTxtBox.Text;
                    row[ColumnNames.VALUE_CALC] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ValueTypes, valueComboBox.Text, ColumnNames.VALUE_TYPE, ColumnNames.VALUE_CODE);
                    row[ColumnNames.PREVIOUS_BILL] = lastBillTxtBox.Text;
                    row[ColumnNames.BILL_AMOUNT] = totalToPayTxtBox.Text;
                    row[ColumnNames.MAAM] = maamTxtBox.Text;
                    row[ColumnNames.TOTAL_AMOUNT] = totalWithMaamTextBox.Text;
                    row[ColumnNames.STATUS_TYPE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.StatusTypes, billStatusComboBox.Text, ColumnNames.STATUS_NAME, ColumnNames.STATUS_CODE);
                    ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Bills.TableName);
                    ExcelHelper.Instance.Bills.Rows.Add(row);
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

        private void maamTxtBox_TextChanged(object sender, EventArgs e)
        {
            double maamAmount;
            errorsLabel.Visible = false;
            bool maam = double.TryParse(maamTxtBox.Text, out maamAmount);
            if ((maam) && (!string.IsNullOrEmpty(totalToPayTxtBox.Text)))
            {
                totalWithMaamTextBox.Text = ((double.Parse(totalToPayTxtBox.Text) + (double.Parse(totalToPayTxtBox.Text) * (double.Parse(maamTxtBox.Text)))).ToString());
            }
            else
            {
                errorsLabel.Visible = true;
                errorsLabel.Text = "מע\"מ שגוי, בדוק את המע\"מ ונסה שוב ";
                errorsLabel.ForeColor = Color.Red;
            }
        }

        private void totalToPayTxtBox_Leave(object sender, EventArgs e)
        {
            double tot;
            bool total = double.TryParse(totalToPayTxtBox.Text, out tot);
            maamTxtBox.Text = string.IsNullOrEmpty(maamTxtBox.Text) ? "0" : maamTxtBox.Text;
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
        }

        private void billDateBox_Leave(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(billDateBox.Text);
            DateTime saveDate = DateTime.Parse(date.Month.ToString() + "/01/" + date.Year.ToString());
            billDateBox.Text = saveDate.ToString();
        }

        private void billSequenceInContractTxtBox_Leave(object sender, EventArgs e)
        {
            //billSequenceInContractTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, ColumnNames.BILL_SEQUENCE, ColumnNames.CONTRACT_CODE_YARIV, contractCodeComboBox.Text);
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalBillsTxtBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
        }
    }
}
