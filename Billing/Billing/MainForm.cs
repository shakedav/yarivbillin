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
            displayFormInTab(billForm, splitContainer1);
          
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            ContractForm contractForm = new ContractForm();
            displayFormInTab(contractForm, splitContainer1);                   
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm();
            displayFormInTab(projectForm, splitContainer1);
          
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            displayFormInTab(clientForm, splitContainer1);          
        }

        private void displayFormInTab(Form form, SplitContainer container)
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
            container.Panel1.Visible = true;
            container.Panel1.Select();
            container.Panel1.Controls.Add(form);
            form.Show();
           
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //Clients
            List<string> clientsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Clients, searchTxtBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE, "לקוח");
            clientsList.AddRange(ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Projects, searchTxtBox.Text, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_CODE, "פרוייקט"));
            clientsList.AddRange(ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Contracts, searchTxtBox.Text, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CONTRACT_CODE_YARIV,ColumnNames.CLIENT_CODE,"חוזה"));
            clientsList.AddRange(ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Bills, searchTxtBox.Text, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.BILL_NUMBER_YARIV,ColumnNames.CONTRACT_CODE_YARIV,"חשבון"));
            foreach (string client in clientsList)
            {                
                listBox1.Items.Add(client);
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            searchSplit.Panel1.Controls.Clear();
            string a = listBox1.SelectedItems[0].ToString();
            string type = a.Split('-')[0];
            string value1 = a.Split('-')[1];
            string value2 = a.Split('-')[2];

            switch (type)
            {
                case "לקוח":
                    {
                        ClientForm form = new ClientForm(value2);
                        displayFormInTab(form, searchSplit);
                        break;
                    }
                case "פרוייקט":
                    {
                        ProjectForm form = new ProjectForm(value2, string.Empty);
                        displayFormInTab(form, searchSplit);
                        break;
                    }
                case "חוזה":
                    {
                        ContractForm form = new ContractForm(value1, value2);
                        displayFormInTab(form, searchSplit);
                        break;
                    }
                case "חשבון":
                    {
                        BillForm form = new BillForm(value1, value2);
                        displayFormInTab(form, searchSplit);
                        break;
                    }
            }
        }
    }
}
