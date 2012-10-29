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
    public partial class ContractForm : Form
    {
        public ContractForm()
        {
            Onload();
            //TODO: לכתוב את "ניצול חוזה" כמו שצריך
           
        }

        public ContractForm(string selectedClient, string selectedProject)
        {
            Onload();
            clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(selectedClient);
            clientNameComboBox.Enabled = false;
            projectNameComboBox.SelectedIndex = projectNameComboBox.FindStringExact(selectedProject);
            projectNameComboBox.Enabled = false;
            projectCodeTxtBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectNameComboBox.Text, "שם הפרוייקט", "קוד פרוייקט");
            projectCodeTxtBox.Enabled = false;
        }

        private void Onload()
        {
            InitializeComponent();
            yarivContractCodeTxtBox.Text = (ExcelHelper.Instance.Contracts.Rows.Count + 1).ToString();
            clientNameComboBox.DataSource = ExcelHelper.Instance.Clients.Columns["קוד לקוח"].Table;
            clientNameComboBox.DisplayMember = "שם לקוח";
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex]["שם לקוח"].ToString();
            projectNameComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Projects, "קוד הלקוח",
                ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, "שם לקוח", "קוד לקוח")
                , "שם הפרוייקט");
            projectCodeTxtBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectNameComboBox.Text, "שם הפרוייקט", "קוד פרוייקט");
            contractTypeComboBox.DataSource = ExcelHelper.Instance.ContractTypes.Columns["קוד סוג"].Table;
            contractTypeComboBox.DisplayMember = "שם הסוג";
            contractTypeComboBox.Text = projectNameComboBox.SelectedIndex < 0 ? "0" : ExcelHelper.Instance.ContractTypes.Rows[projectNameComboBox.SelectedIndex]["שם הסוג"].ToString();
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(yarivContractCodeTxtBox.Text);
        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            clientContractCodetxtBox.Clear();
            valueTxtBox.Clear();         
            valueCalculationtxtBox.Clear();
            valueCalculationWaytxtBox.Clear();
            contractParttxtBox.Clear();
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(yarivContractCodeTxtBox.Text);
        }

        private void clientNameComboBox_Click(object sender, EventArgs e)
        {
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex]["שם לקוח"].ToString();
            clientNameComboBox.Refresh();
        }

        private void projectNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectNameComboBox.Refresh();
            projectNameComboBox.Text = projectNameComboBox.Text = projectNameComboBox.SelectedItem == null ? "אין פרוייקטים ללקוח זה" : projectNameComboBox.SelectedItem.ToString();
            projectCodeTxtBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectNameComboBox.Text, "שם הפרוייקט", "קוד פרוייקט");
            projectCodeTxtBox.Refresh();
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

        private void btnSaveAddBill_Click(object sender, EventArgs e)
        {
            if (CheckAllFieldsAreFilled())
            {
                CheckAndSave();
                this.Hide();
                this.Close();
                Form f = new BillForm(clientNameComboBox.Text, yarivContractCodeTxtBox.Text);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("מלא את כל השדות בבקשה");
            }
        }

        private bool CheckAllFieldsAreFilled()
        {
            if ((string.IsNullOrEmpty(clientNameComboBox.Text)) || (string.IsNullOrEmpty(projectNameComboBox.Text))
                || (string.IsNullOrEmpty(projectCodeTxtBox.Text)) || (string.IsNullOrEmpty(yarivContractCodeTxtBox.Text))
                || (string.IsNullOrEmpty(clientContractCodetxtBox.Text)) || (string.IsNullOrEmpty(valueTxtBox.Text))
                || (string.IsNullOrEmpty(signingDatePicker.Text)) || (string.IsNullOrEmpty(startDatePicker.Text))
                || (string.IsNullOrEmpty(endDatePicker.Text)) || (string.IsNullOrEmpty(contractTypeComboBox.Text))
                || (string.IsNullOrEmpty(valueCalculationtxtBox.Text)) || (string.IsNullOrEmpty(valueCalculationWaytxtBox.Text))
                || (string.IsNullOrEmpty(contractParttxtBox.Text)))
            {
                return false;
            }
            return true;
        }

        private void CheckAndSave()
        {
            if (IsDataExist())
            {
                if (ExcelHelper.Instance.shouldSave("חוזה {0}", yarivContractCodeTxtBox.Text))
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
            return ExcelHelper.Instance.CheckExistence(clientContractCodetxtBox.Text,
                ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, "שם לקוח", "קוד לקוח"),
                "קוד חוזה לקוח", "קוד לקוח", ExcelHelper.Instance.Contracts);
        }

        private void SaveData()
        {
            DataRow row = ExcelHelper.Instance.Contracts.NewRow();
            try
            {                
                row["קוד לקוח"] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, "שם לקוח", "קוד לקוח");
                row["קוד פרוייקט"] = projectCodeTxtBox.Text;
                row["קוד חוזה יריב"] = yarivContractCodeTxtBox.Text;
                row["קוד חוזה לקוח"] = clientContractCodetxtBox.Text;
                row["תמורה"] = valueTxtBox.Text;
                row["תאריך חתימת החוזה"] = signingDatePicker.Text;
                row["מועד תחילת חוזה"] = startDatePicker.Text;
                row["מועד סיום חוזה"] = endDatePicker.Text;
                row["סיווג חוזה"] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ContractTypes, contractTypeComboBox.Text, "שם הסוג", "קוד סוג");
                row["נגזרת התמורה"] = valueCalculationtxtBox.Text;
                row["אופן חישוב תמורה"] = valueCalculationWaytxtBox.Text;
                row["ניצול חוזה"] = contractParttxtBox.Text;
                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Contracts.TableName);
                ExcelHelper.Instance.Contracts.Rows.Add(row);
            }
            catch (Exception ex)
            {
                MessageBoxOptions options = MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
                string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", ExcelHelper.Path);
                MessageBox.Show(this, text + "\n\n" + ex, "בעיה בשמירת חוזה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
            }
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            endDatePicker.Text = startDatePicker.Text;
            endDatePicker.Refresh();
        }

        private void clientNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {           
            projectNameComboBox.DataSource = null;
            projectNameComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Projects, "קוד הלקוח", ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, "שם לקוח", "קוד לקוח"), "שם הפרוייקט");

            projectNameComboBox.Text = projectNameComboBox.SelectedItem == null ? "אין פרוייקטים ללקוח זה" : projectNameComboBox.SelectedItem.ToString();
        }

        
    }
}

