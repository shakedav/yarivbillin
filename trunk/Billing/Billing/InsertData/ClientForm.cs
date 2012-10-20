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
    public partial class ClientForm : Form
    {
        Dictionary<string, string> clientTypeDic = new Dictionary<string, string>();
        public ClientForm()
        {
            InitializeComponent();
            
            foreach (DataRow row in ExcelHelper.Instance.ClientTypes.Rows)
            {
                clientTypeDic.Add(row[1].ToString(), row[0].ToString());
            }
            ClientsDataGrid.DataSource = ExcelHelper.Instance.Clients;

            ClientTypeComboBox.DataSource = ExcelHelper.Instance.ClientTypes.Columns["קוד לקוח"].Table;
            ClientTypeComboBox.DisplayMember = "סוג לקוח";
            ClientTypeComboBox.Text = ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex]["סוג לקוח"].ToString();
            clientCodeTxtBox.Text =ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, "קוד לקוח",
                                                  ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex]["קוד לקוח"].ToString()
                                                  , "סוג לקוח");
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

        private void CheckAndSave()
        {
            if (IsDataExist())
            {
                if (ExcelHelper.Instance.shouldSave("לקוח {0}", clientNameTxtBox.Text))
                {
                    SaveData();
                }
            }
            else
            {
                SaveData();
            }
        }
                      
    

        private bool CheckAllFieldsAreFilled()
        {
            if ((string.IsNullOrEmpty(clientNameTxtBox.Text)) || (string.IsNullOrEmpty(ClientAddressTxtBox.Text))
                || (string.IsNullOrEmpty(phoneTxtBox.Text)) || (string.IsNullOrEmpty(emailTxtBox.Text)))
            {
                return false;
            }
            return true;
        }

        private bool IsDataExist()
        {
            return ExcelHelper.Instance.CheckExistence(clientNameTxtBox.Text, clientTypeDic[ClientTypeComboBox.Text], "שם לקוח", "סוג לקוח", ExcelHelper.Instance.Clients);
        }

        private void btnSaveAndAddProj_Click(object sender, EventArgs e)
        {
            if (CheckAllFieldsAreFilled())
            {
                CheckAndSave();
                this.Hide();
                this.Close();
                Form f = new ProjectForm(clientNameTxtBox.Text);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("מלא את כל השדות בבקשה"); 
            }
        }        

        private void SaveData()
        {
            try
            {
                DataRow row = ExcelHelper.Instance.Clients.NewRow();                
                row["שם לקוח"] = clientNameTxtBox.Text;
                row["כתובת"] = ClientAddressTxtBox.Text;
                row["טלפון"] = phoneTxtBox.Text;
                row["אימייל"] = emailTxtBox.Text;
                row["סוג לקוח"] = ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex]["קוד לקוח"].ToString();
                row["קוד לקוח"] = clientCodeTxtBox.Text;
                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Clients.TableName);
                ExcelHelper.Instance.Clients.Rows.Add(row);
                
            }
            catch (Exception ex)
            {
                MessageBoxOptions options = MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
                string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", ExcelHelper.Path);
                MessageBox.Show(this, text + "\n\n" + ex, "בעיה בשמירת לקוח", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
            }
        }

        private void ClearAllFields()
        {
            ClientAddressTxtBox.Clear();
            clientNameTxtBox.Clear();            
            emailTxtBox.Clear();
            phoneTxtBox.Clear();
        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            clientCodeTxtBox.Text = ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, "קוד לקוח",
                                                  ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex]["קוד לקוח"].ToString()
                                                  , "סוג לקוח");
        }

       
    }
}
