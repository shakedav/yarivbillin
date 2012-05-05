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
        ExcelHelper helper;

        public ClientForm()
        {
            InitializeComponent();
            helper = new ExcelHelper();
            ClientsDataGrid.DataSource = helper.Clients;
            projectCodeTxtBox.Text = (helper.Projects.Rows.Count +1).ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //TODO: Verify all fields are filled.
            DataRow row = helper.Clients.NewRow();
            row["שם לקוח"] = clientNameTxtBox.Text;
            row["כתובת"] = ClientAddressTxtBox.Text;
            row["טלפון"] = phoneTxtBox.Text;
            row["אימייל"] = emailTxtBox.Text;
            row["שם הפרוייקט"] = projectNameTxtBox.Text;
            row["איש קשר בפרוייקט"] = contactManTxtBox.Text;
            row["שם פרוייקט אצל המזמין"] = projectNameInviterTxtBox.Text;
            row["קוד פרוייקט אצל המזמין"] = projectCodeInviterTxtBox.Text;
            row["קוד לקוח"] = (helper.Clients.Rows.Count + 1).ToString();
            row["קוד פרוייקט"] = projectCodeTxtBox.Text;
            helper.Clients.Rows.Add(row);
            ClearAllFields();
            helper.SaveDataToExcel(row, helper.Clients.TableName);
            ClientsDataGrid.Refresh();
        }

        private void ClearAllFields()
        {
            ClientAddressTxtBox.Clear();
            clientNameTxtBox.Clear();
            contactManTxtBox.Clear();
            emailTxtBox.Clear();
            phoneTxtBox.Clear();
            projectCodeInviterTxtBox.Clear();
            projectCodeTxtBox.Clear();
            projectNameInviterTxtBox.Clear();
            projectNameTxtBox.Clear();           
        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }
    }
}
