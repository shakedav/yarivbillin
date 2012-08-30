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
            //TODO: לכתוב את "ניצול חוזה" כמו שצריך
           
        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            clientContractCodetxtBox.Clear();
            valueTxtBox.Clear();         
            valueCalculationtxtBox.Clear();
            valueCalculationWaytxtBox.Clear();
            contractParttxtBox.Clear();
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
            DataRow row = ExcelHelper.Instance.Contracts.NewRow();
            try
            {
                row["קוד לקוח"] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients,clientNameComboBox.Text,"שם לקוח","קוד לקוח");
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
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxOptions options = MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
                string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש", ExcelHelper.Path);
                MessageBox.Show(this, text, "בעיה בשמירת פרוייקט", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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

