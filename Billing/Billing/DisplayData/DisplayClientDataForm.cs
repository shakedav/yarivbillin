using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Billing.DisplayData
{
    public partial class DisplayClientDataForm : Form
    {
        public DisplayClientDataForm()
        {
            InitializeComponent();

            ClientsDataGrid.DataSource = ExcelHelper.Instance.Clients;
            ClientNamesComboBox.Text = "לחץ כאן להצגת רשימת הלקוחות";
        }             

        private void ClientNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string,string> clientDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Clients, "שם לקוח", ExcelHelper.Instance.Clients.Rows[ClientNamesComboBox.SelectedIndex]["שם לקוח"].ToString());
            if (clientDataList.Count != 0)
            {
                clientTypeTxtBox.Text = clientDataList["סוג לקוח"];
                ClientAddressTxtBox.Text = clientDataList["כתובת"];
                phoneTxtBox.Text = clientDataList["טלפון"];
                clientCodeTxtBox.Text = clientDataList["קוד לקוח"];
                emailTxtBox.Text = clientDataList["אימייל"];
            }
        }

        private void ClientNamesComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            ClientNamesComboBox.DataSource = ExcelHelper.Instance.Clients.Columns["שם לקוח"].Table;
            ClientNamesComboBox.DisplayMember = "שם לקוח";
            ClientNamesComboBox.ValueMember = "קוד לקוח";
        }

        private void getContractsBtn_Click(object sender, EventArgs e)
        {
            Form f = new DisplayContractDetails();
            f.ShowDialog();
        }
    }
}
