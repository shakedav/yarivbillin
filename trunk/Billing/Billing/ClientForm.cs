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
        ExcelHelper clientsHelper;
        
        public ClientForm(ExcelHelper helper)
        {
            InitializeComponent();
            clientsHelper = helper;
            ClientsDataGrid.DataSource = helper.Clients;           
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DataRow row = clientsHelper.Clients.NewRow();
            try
            {
                //TODO: Verify all fields are filled.
                row["שם לקוח"] = clientNameTxtBox.Text;
                row["כתובת"] = ClientAddressTxtBox.Text;
                row["טלפון"] = phoneTxtBox.Text;
                row["אימייל"] = emailTxtBox.Text;
                row["קוד לקוח"] = (clientsHelper.Clients.Rows.Count + 1).ToString();
                clientsHelper.SaveDataToExcel(row, clientsHelper.Clients.TableName);                
                clientsHelper.Clients.Rows.Add(row);
                Close();               
            }
            catch (Exception ex)
            {
                MessageBoxOptions options = MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
                string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש", ExcelHelper.Path);
                MessageBox.Show(this, text, "בעיה בשמירת לקוח", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);            
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
    }
}
