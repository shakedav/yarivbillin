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
            clientNameComboBox.DataSource = ExcelHelper.Instance.Clients.Columns["קוד לקוח"].Table;
            clientNameComboBox.DisplayMember = "שם לקוח";
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex]["שם לקוח"].ToString();
            contractCodeComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Contracts, "קוד לקוח",
                                                                        ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients,
                                                                        clientNameComboBox.Text, "שם לקוח", "קוד לקוח"),
                                                                        "קוד חוזה יריב");
            billSequenceInContractTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, "מספר חשבון חלקי בחוזה", "קוד חוזה", contractCodeComboBox.Text);             
            valueComboBox.DataSource = ExcelHelper.Instance.ValueTypes.Columns["קוד תמורה"].Table;
            valueComboBox.DisplayMember = "סוג תמורה";
            valueComboBox.Text = ExcelHelper.Instance.ValueTypes.Rows[valueComboBox.SelectedIndex]["סוג תמורה"].ToString();
            billStatusComboBox.DataSource = ExcelHelper.Instance.StatusTypes.Columns["קוד סטטוס"].Table;
            billStatusComboBox.DisplayMember = "שם סטטוס";
            billStatusComboBox.Text = ExcelHelper.Instance.StatusTypes.Rows[billStatusComboBox.SelectedIndex]["שם סטטוס"].ToString();
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalBillsComboBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
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
            contractCodeComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Contracts, "קוד לקוח",
                ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, "שם לקוח", "קוד לקוח"), "קוד חוזה יריב");
            contractCodeComboBox.Text = contractCodeComboBox.SelectedItem == null ? "אין חוזים ללקוח זה" : contractCodeComboBox.SelectedItem.ToString();
            if (contractCodeComboBox.Text != "אין חוזים ללקוח זה")
            {                
                lastBillTxtBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Bills, (int.Parse(billSequenceInContractTxtBox.Text) - 1).ToString(), "מספר חשבון ביריב", "חשבון קודם");
            }
            billSequenceInContractTxtBox.Text = (billSequence == null ? "1" : billSequence);
            totalBillsComboBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
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

        private bool CheckAllFieldsAreFilled()
        {
            if ((string.IsNullOrEmpty(clientNameComboBox.Text)) || (string.IsNullOrEmpty(contractCodeComboBox.Text))
                || (string.IsNullOrEmpty(billNumberTxtBox.Text)) || (string.IsNullOrEmpty(billSequenceInContractTxtBox.Text))
                || (string.IsNullOrEmpty(valueComboBox.Text)) || (string.IsNullOrEmpty(lastBillTxtBox.Text))
                || (string.IsNullOrEmpty(totalToPayTxtBox.Text)) || (string.IsNullOrEmpty(maamTxtBox.Text))
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
                if (ExcelHelper.Instance.shouldSave("חשבון חלקי {0}", billSequenceInContractTxtBox.Text))
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
            return ExcelHelper.Instance.CheckExistence(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text, "מספר חשבון חלקי בחוזה", "קוד חוזה", ExcelHelper.Instance.Bills);
        }

        private void SaveData()
        {
            try
            {
                DataRow row = ExcelHelper.Instance.Bills.NewRow();
                if (!errorsLabel.Visible)
                {
                    row["קוד חוזה"] = contractCodeComboBox.Text;
                    row["מספר חשבון ביריב"] = billNumberTxtBox.Text;
                    row["מספר חשבון חלקי בחוזה"] = billSequenceInContractTxtBox.Text;
                    row["חישוב התמורה"] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ValueTypes, valueComboBox.Text, "סוג תמורה", "קוד תמורה");
                    row["חשבון קודם"] = lastBillTxtBox.Text;
                    row["סכום החשבון"] = totalToPayTxtBox.Text;
                    row["המע\"מ"] = maamTxtBox.Text;
                    row["סה\"כ לתשלום"] = totalWithMaamTextBox.Text;
                    row["סוג סטטוס"] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.StatusTypes, billStatusComboBox.Text, "שם סטטוס", "קוד סטטוס");
                    ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Bills.TableName);
                    ExcelHelper.Instance.Bills.Rows.Add(row);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBoxOptions options = MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
                string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", ExcelHelper.Path);
                MessageBox.Show(this, text + "\n\n" + ex, "בעיה בשמירת חשבון", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
            }
        }

        private void billNumberTxtBox_Leave(object sender, EventArgs e)
        {
            billSequenceInContractTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, "מספר חשבון חלקי בחוזה", "קוד חוזה", contractCodeComboBox.Text);
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, billNumberTxtBox.Text);            
        }

        private void billNumberTxtBox_TextChanged(object sender, EventArgs e)
        {
            billSequenceInContractTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, "מספר חשבון חלקי בחוזה", "קוד חוזה", contractCodeComboBox.Text);
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
        }

        private void contractCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            billSequenceInContractTxtBox.Text = ExcelHelper.Instance.GetMaxItemOfColumnByColumn(ExcelHelper.Instance.Bills, "מספר חשבון חלקי בחוזה", "קוד חוזה", contractCodeComboBox.Text);
            lastBillTxtBox.Text = ExcelHelper.Instance.getLastBillAmount(billSequenceInContractTxtBox.Text, contractCodeComboBox.Text);
            totalBillsComboBox.Text = ExcelHelper.Instance.getTotalOfBills(contractCodeComboBox.Text);
        }
    }
}
