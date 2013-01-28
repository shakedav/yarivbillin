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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            BillForm billForm = new BillForm();
            displayFormInTab(billForm);
          
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            ContractForm contractForm = new ContractForm();
            displayFormInTab(contractForm);
          
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm();
            displayFormInTab(projectForm);
          
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            displayFormInTab(clientForm);
          
        }

        private void displayFormInTab(Form form)
        {
            if (splitContainer1.Panel1.Controls.Count >= 1)
            {
                DialogResult dr = MessageBox.Show("לשמור או לא?", "aaa", MessageBoxButtons.YesNoCancel);
                if ( dr  == DialogResult.OK)
                {
                    //Form.save;
                }
                else
                {
                    splitContainer1.Panel1.Controls.Clear();
                }
            }
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            
            form.Left = (ClientSize.Width - splitContainer1.Panel1.Width) / 2;
            form.Top = (ClientSize.Height - splitContainer1.Panel1.Height) / 2;
            splitContainer1.Panel1.Visible = true;
            splitContainer1.Panel1.Select();
            splitContainer1.Panel1.Controls.Add(form);
            form.Show();
           
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            //Clients
            List<string> clientsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Clients, searchTxtBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_NAME);
            foreach (string client in clientsList)
            {
                listView1.Items.Add("לקוח - " + client);
            }

            List<string> projectsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Projects, searchTxtBox.Text, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_NAME);
            foreach (string project in projectsList)
            {
                listView1.Items.Add("פרוייקט - " + project);
            }

            List<string> contractsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Contracts, searchTxtBox.Text, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CONTRACT_CODE_YARIV);
            foreach (string contract in contractsList)
            {
                listView1.Items.Add("חוזה - " + contract);
            }

            List<string> billsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Bills, searchTxtBox.Text, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.BILL_NUMBER_YARIV);
            foreach (string bill in billsList)
            {
                listView1.Items.Add("חשבון - " + bill);
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            var a = listView1.SelectedItems[0];
        }
    }
}
