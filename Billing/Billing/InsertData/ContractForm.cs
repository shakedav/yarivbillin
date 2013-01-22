using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Billing.InsertData;

namespace Billing
{
    public partial class ContractForm : Form
    {

        private string valueTypes = string.Empty;

        public ContractForm()
        {
            Onload();
            //TODO: לכתוב את ColumnNames.CONTRACT_USAGE כמו שצריך
           
        }

        public ContractForm(string selectedClient, string selectedProject)
        {
            Onload();
            clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(selectedClient);
            clientNameComboBox.Enabled = false;
            projectNameComboBox.SelectedIndex = projectNameComboBox.FindStringExact(selectedProject);
            projectNameComboBox.Enabled = false;
            projectCodeTxtBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectNameComboBox.Text, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_CODE);
            projectCodeTxtBox.Enabled = false;
        }

        private void Onload()
        {
            InitializeComponent();
            yarivContractCodeTxtBox.Text = (ExcelHelper.Instance.Contracts.Rows.Count + 1).ToString();
            clientNameComboBox.DataSource = ExcelHelper.Instance.Clients.Columns[ColumnNames.CLIENT_CODE].Table;
            clientNameComboBox.DisplayMember = ColumnNames.CLIENT_NAME;
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString();
            projectNameComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Projects, ColumnNames.CLIENT_CODE,
                ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE)
                , ColumnNames.PROJECT_NAME);
            projectCodeTxtBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectNameComboBox.Text, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_CODE);
            contractTypeComboBox.DataSource = ExcelHelper.Instance.ContractTypes.Columns[ColumnNames.TYPE_CODE].Table;
            contractTypeComboBox.DisplayMember = ColumnNames.TYPE_NAME;
            contractTypeComboBox.Text = projectNameComboBox.SelectedIndex < 0 ? "0" : ExcelHelper.Instance.ContractTypes.Rows[projectNameComboBox.SelectedIndex][ColumnNames.TYPE_NAME].ToString();            
        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            clientContractCodetxtBox.Clear();
            valueTxtBox.Clear();         
            valueWithMaamTxtBox.Clear();
        }

        private void clientNameComboBox_Click(object sender, EventArgs e)
        {
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString();
            clientNameComboBox.Refresh();
        }

        private void projectNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectNameComboBox.Refresh();
            projectNameComboBox.Text = projectNameComboBox.Text = projectNameComboBox.SelectedItem == null ? "אין פרוייקטים ללקוח זה" : projectNameComboBox.SelectedItem.ToString();
            projectCodeTxtBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectNameComboBox.Text, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_CODE);
            projectCodeTxtBox.Refresh();
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
                LogWriter.Instance.Error("error when saving contract info", ex);
            }
            LogWriter.Instance.Trace("Contract Saved");
        }

        private void ShowErrorMessage(Exception ex)
        {
            MessageBoxOptions options = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", Constants.Instance.Path);
            MessageBox.Show(this, text + "\n\n" + ex, "בעיה בשמירת חוזה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
        }

        private void btnSaveAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsAreFilled())
                {
                    if (CheckAndSave())
                    {
                        this.Hide();
                        this.Close();
                        Form f = new BillForm(clientNameComboBox.Text, yarivContractCodeTxtBox.Text);
                        f.ShowDialog();
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
                LogWriter.Instance.Error("error when saving client info", ex);
            }
            LogWriter.Instance.Trace("Client Saved");
        }

        private bool CheckAllFieldsAreFilled()
        {
            if ((string.IsNullOrEmpty(clientNameComboBox.Text)) || (string.IsNullOrEmpty(projectNameComboBox.Text))
                || (string.IsNullOrEmpty(projectCodeTxtBox.Text)) || (string.IsNullOrEmpty(yarivContractCodeTxtBox.Text))
                || (string.IsNullOrEmpty(clientContractCodetxtBox.Text)) || (string.IsNullOrEmpty(valueTxtBox.Text))
                || (string.IsNullOrEmpty(signingDatePicker.Text)) || (string.IsNullOrEmpty(startDatePicker.Text))
                || (string.IsNullOrEmpty(endDatePicker.Text)) || (string.IsNullOrEmpty(contractTypeComboBox.Text)))
            {
                return false;
            }
            return true;
        }

        private bool CheckAndSave()
        {
            if (!(startDatePicker.Value > endDatePicker.Value))
            {

                if (IsDataExist())
                {
                    if (ExcelHelper.Instance.shouldSave(string.Format("קוד חוזה {0} או", clientContractCodetxtBox.Text) + " או חוזה {0}", yarivContractCodeTxtBox.Text))
                    {
                        return SaveData();
                    }
                }
                else
                {
                    return SaveData();
                }
            }
            else
            {
                MessageBox.Show("תאריך התחלה קטן מתאריך סיום, אנא וודא תאריכים תקפים");               
            }
            return false;
        }

        private bool IsDataExist()
        {
            return ((ExcelHelper.Instance.CheckExistence(clientContractCodetxtBox.Text,
                ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE),
                ColumnNames.CONRACT_CODE_CLIENT, ColumnNames.CLIENT_CODE, ExcelHelper.Instance.Contracts)) ||
                (ExcelHelper.Instance.CheckExistenceOfSingleValue(clientContractCodetxtBox.Text,ColumnNames.CONTRACT_CODE_YARIV,ExcelHelper.Instance.Contracts)));
        }

        private bool SaveData()
        {
            DataRow row = ExcelHelper.Instance.Contracts.NewRow();
            try
            {                
                row[ColumnNames.CLIENT_CODE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE);
                row[ColumnNames.PROJECT_CODE] = projectCodeTxtBox.Text;
                row[ColumnNames.CONTRACT_CODE_YARIV] = yarivContractCodeTxtBox.Text;
                row[ColumnNames.CONRACT_CODE_CLIENT] = clientContractCodetxtBox.Text;
                row[ColumnNames.VALUE] = valueTxtBox.Text;
                row[ColumnNames.CONTRACT_SIGNING_DATE] = signingDatePicker.Text;
                row[ColumnNames.CONTRACT_START_DATE] = startDatePicker.Text;
                row[ColumnNames.CONTRACT_END_DATE] = endDatePicker.Text;
                row[ColumnNames.CONTRACT_TYPE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ContractTypes, contractTypeComboBox.Text, ColumnNames.TYPE_NAME, ColumnNames.TYPE_CODE);                
                row[ColumnNames.VALUE_TYPES] = valueTypes;
                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Contracts.TableName);
                ExcelHelper.Instance.Contracts.Rows.Add(row);
                return true;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
                return false;
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
            projectNameComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Projects, ColumnNames.CLIENT_CODE, ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE), ColumnNames.PROJECT_NAME);

            projectNameComboBox.Text = projectNameComboBox.SelectedItem == null ? "אין פרוייקטים ללקוח זה" : projectNameComboBox.SelectedItem.ToString();
        }

        private void valueTxtBox_Leave(object sender, EventArgs e)
        {
            double value = double.Parse(valueTxtBox.Text);
            valueWithMaamTxtBox.Text = (value + value * Constants.Instance.MAAM).ToString();
        }

        private void addValue_Click(object sender, EventArgs e)
        {
            using (AddValueForm form = new AddValueForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                   valueListBox.Items.Add(form.valueType);
                   valueTypes = valueTypes + form.valueIndex + ";";
                   valueListBox.Visible = true;
                }
            }  
        }        
    }
}

