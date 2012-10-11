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
        
        public ClientForm()
        {
            InitializeComponent();

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
            if (ExcelHelper.Instance.CheckExistence(clientNameTxtBox.Text, "שם לקוח", ExcelHelper.Instance.Clients))
            {
                using (var form = new DataExists(clientNameTxtBox.Text))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        bool save = form.ShouldSave;
                        if (save)
                        {
                            SaveData();
                        }
                    }
                }
            }
            else
            {
                SaveData();
            }
            Close();
        }

        private void SaveData()
        {
            try
            {
                DataRow row = ExcelHelper.Instance.Clients.NewRow();
                //TODO: Verify all fields are filled.
                row["שם לקוח"] = clientNameTxtBox.Text;
                row["כתובת"] = ClientAddressTxtBox.Text;
                row["טלפון"] = phoneTxtBox.Text;
                row["אימייל"] = emailTxtBox.Text;
                row["סוג לקוח"] = ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex]["קוד לקוח"].ToString();
                row["קוד לקוח"] = clientCodeTxtBox.Text;
                //clientCodeTxtBox.Text.Replace(row["סוג לקוח"] + "-", "");
                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Clients.TableName);
                ExcelHelper.Instance.Clients.Rows.Add(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void btnSaveAndAddProj_Click(object sender, EventArgs e)
        {
            //try
            //{
                SaveData();
                this.Hide();
                this.Close();
                Form f = new ProjectForm(clientNameTxtBox.Text);
                f.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBoxOptions options = MessageBoxOptions.RtlReading |
            //    MessageBoxOptions.RightAlign;
            //    string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", ExcelHelper.Path);
            //    MessageBox.Show(this, text, "בעיה בשמירת לקוח", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
            //}
        }        
    }
}
