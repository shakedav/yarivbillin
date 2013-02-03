﻿using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            BillForm billForm = new BillForm(this);
            billForm.Parent = this;
            //displayFormInTab(billForm, splitContainer1);
          
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            ContractForm contractForm = new ContractForm(this);
            contractForm.Parent = this;
            //displayFormInTab(contractForm, splitContainer1);                   
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            checkFormsStatus();
            ProjectUserControl projectForm = new ProjectUserControl();
            splitContainer1.Panel1.Visible = true;
            splitContainer1.Panel1.Select();
            splitContainer1.Panel1.Controls.Add(projectForm);       
          
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            checkFormsStatus();
            ClientUserControl control = new ClientUserControl();
            splitContainer1.Panel1.Visible = true;
            splitContainer1.Panel1.Select();
            splitContainer1.Panel1.Controls.Add(control);        
        }

        public void checkFormsStatus()
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
                        ClientUserControl form = new ClientUserControl(value2);
                        //displayFormInTab(form, searchSplit);
                        break;
                    }
                case "פרוייקט":
                    {
                        ProjectUserControl form = new ProjectUserControl(value2, string.Empty);
                        //displayFormInTab(form, searchSplit);
                        break;
                    }
                case "חוזה":
                    {
                        ContractForm form = new ContractForm(value1, value2);
                        //displayFormInTab(form, searchSplit);
                        break;
                    }
                case "חשבון":
                    {
                        BillForm form = new BillForm(value1, value2);
                        //displayFormInTab(form, searchSplit);
                        break;
                    }
            }
        }
    }
}
