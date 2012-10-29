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
    public partial class ProjectForm : Form
    {       
        public ProjectForm()
        {           
            Onload();
        }

        private void Onload()
        {
            InitializeComponent();
            projectCodetxtBox.Text = (ExcelHelper.Instance.Projects.Rows.Count + 1).ToString();
            clientNameComboBox.DataSource = ExcelHelper.Instance.Clients.Columns["קוד לקוח"].Table;
            clientNameComboBox.DisplayMember = "שם לקוח";
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex]["שם לקוח"].ToString();
        }

        public ProjectForm(string selectedClient)
        {
            Onload();
            clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(selectedClient);
            clientNameComboBox.Enabled = false;
        }

        private void ClearAllFields(object sender, EventArgs e)
        {
            projectNametxtBox.Clear();
            contactManTxtBox.Clear();
            projectDescriptiontxtBox.Clear();
            projectCodeInviterTxtBox.Clear();
            projectNameInviterTxtBox.Clear();
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

        private bool IsDataExist()
        {
            return ExcelHelper.Instance.CheckExistence(projectNametxtBox.Text,
                                                        ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients,
                                                        clientNameComboBox.Text, "שם לקוח", "קוד לקוח"), "שם הפרוייקט",
                                                        "קוד הלקוח",ExcelHelper.Instance.Projects);
        }

        private void SaveData()
        {
            try
            {                
                DataRow row = ExcelHelper.Instance.Projects.NewRow();
                row["קוד פרוייקט"] = projectCodetxtBox.Text;
                row["שם הפרוייקט"] = projectNametxtBox.Text;
                row["איש קשר בפרוייקט"] = contactManTxtBox.Text;
                row["שם פרוייקט אצל המזמין"] = projectNameInviterTxtBox.Text;
                row["קוד פרוייקט אצל המזמין"] = projectCodeInviterTxtBox.Text;
                row["תיאור הפרוייקט"] = projectDescriptiontxtBox.Text;
                row["קוד הלקוח"] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, "שם לקוח", "קוד לקוח");
                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Projects.TableName);
                ExcelHelper.Instance.Projects.Rows.Add(row);
            }
            catch (Exception ex)
            {
                MessageBoxOptions options = MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
                string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", ExcelHelper.Path);
                MessageBox.Show(this, text + "\n\n" + ex, "בעיה בשמירת פרוייקט", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
            }
        }
        

        private void clientNamecomboBox_Click(object sender, EventArgs e)
        {
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex]["שם לקוח"].ToString();
            clientNameComboBox.Refresh();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveAddContract_Click(object sender, EventArgs e)
        {
            if (CheckAllFieldsAreFilled())
            {
                CheckAndSave();
                this.Hide();
                this.Close();
                Form f = new ContractForm(clientNameComboBox.Text, projectNametxtBox.Text);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("מלא את כל השדות בבקשה"); 
            }
        }

        private bool CheckAllFieldsAreFilled()
        {
            if ((string.IsNullOrEmpty(clientNameComboBox.Text)) || (string.IsNullOrEmpty(projectCodetxtBox.Text))
                || (string.IsNullOrEmpty(projectNameInviterTxtBox.Text)) || (string.IsNullOrEmpty(contactManTxtBox.Text))
                || (string.IsNullOrEmpty(projectCodeInviterTxtBox.Text)) || (string.IsNullOrEmpty(projectNameInviterTxtBox.Text))
                || (string.IsNullOrEmpty(projectDescriptiontxtBox.Text)))
            {
                return false;
            }
            return true;
        }

        private void CheckAndSave()
        {
            if (IsDataExist())
            {
                if (ExcelHelper.Instance.shouldSave("פרוייקט {0}", projectNametxtBox.Text))
                {
                    SaveData();
                }
            }
            else
            {
                SaveData();
            }
        }
    }
}
