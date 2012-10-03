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
            ArrayList clientDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Clients, "שם לקוח", ClientNamesComboBox.Text);
            if (clientDataList.Count != 0)
            {
                clientTypeTxtBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ClientTypes, clientDataList[1].ToString(), "קוד לקוח", "סוג לקוח");
            }
        }

        private void ClientNamesComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            ClientNamesComboBox.DataSource = ExcelHelper.Instance.Clients.Columns["שם לקוח"].Table;
            ClientNamesComboBox.DisplayMember = "שם לקוח";
            ClientNamesComboBox.ValueMember = "קוד לקוח";
        }
    }
}
