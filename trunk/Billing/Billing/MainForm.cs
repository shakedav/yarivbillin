using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Billing.InsertData;
using Microsoft.Office.Interop.Word;

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
            checkFormsStatus();
            BillUserControl billForm = new BillUserControl();
            splitContainer1.Panel1.Visible = true;
            splitContainer1.Panel1.Select();
            splitContainer1.Panel1.Controls.Add(billForm);      
          
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            checkFormsStatus();
            ContractUserControl contractForm = new ContractUserControl();
            splitContainer1.Panel1.Visible = true;
            splitContainer1.Panel1.Select();
            splitContainer1.Panel1.Controls.Add(contractForm);                      
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
            if (tabControl1.SelectedTab.Name == "AddDataTab")
            {
                if (splitContainer1.Panel1.Controls.Count >= 1)
                {
                    DialogResult dr = MessageBox.Show("לשמור או לא?", "aaa", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.OK)
                    {
                        //Form.save;
                        splitContainer1.Panel1.Controls.Clear();
                    }
                    else
                    {
                        splitContainer1.Panel1.Controls.Clear();
                    }
                }
            }
            else
            {
                if (searchSplit.Panel1.Controls.Count >= 1)
                {
                    DialogResult dr = MessageBox.Show("לשמור או לא?", "aaa", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.OK)
                    {
                        //Form.save;
                        searchSplit.Panel1.Controls.Clear();
                    }
                    else
                    {
                        searchSplit.Panel1.Controls.Clear();
                    }
                }
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("-----------לקוחות------------");
            //Clients
            List<string> clientsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Clients, searchTxtBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE, "לקוח");
            foreach (string client in clientsList)
            {
                listBox1.Items.Add(client);
            }
            listBox1.Items.Add("-------------------------------------");
            listBox1.Items.Add("");
            listBox1.Items.Add("-----------פרוייקטים------------");
            //Projects
           List<string> projectsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Projects, searchTxtBox.Text, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_CODE, "פרוייקט");
            foreach (string project in projectsList)
            {
                listBox1.Items.Add(project);
            }
            listBox1.Items.Add("-------------------------------------");
            listBox1.Items.Add("");
            listBox1.Items.Add("-----------חוזים------------");
            //Contracts
            List<string> contractsList  = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Contracts, searchTxtBox.Text, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CLIENT_CODE, "חוזה");
            foreach (string contract in contractsList)
            {
                listBox1.Items.Add(contract);
            }
            listBox1.Items.Add("-------------------------------------");
            listBox1.Items.Add("");
            listBox1.Items.Add("-----------חשבונות------------");
            //Bills
            List<string> billsList = ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Bills, searchTxtBox.Text, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CLIENT_CODE, "חשבון");
            foreach (string bill in billsList)
            {
                listBox1.Items.Add(bill);
            }
            listBox1.Items.Add("-------------------------------------");

            //clientsList.AddRange(ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Projects, searchTxtBox.Text, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_CODE, "פרוייקט"));
            //clientsList.AddRange(ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Contracts, searchTxtBox.Text, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CONTRACT_CODE_YARIV,ColumnNames.CLIENT_CODE,"חוזה"));
            //clientsList.AddRange(ExcelHelper.Instance.searchInTable(ExcelHelper.Instance.Bills, searchTxtBox.Text, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.BILL_NUMBER_YARIV,ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CLIENT_CODE, "חשבון"));
            //foreach (string client in clientsList)
            //{                
            //    listBox1.Items.Add(client);
            //}
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            string type = string.Empty;
            string value1 = string.Empty;
            string value2 = string.Empty;
            string value3 = string.Empty;
            try
            {
                searchSplit.Panel1.Controls.Clear();
                string a = listBox1.SelectedItems[0].ToString();
                type = a.Split('-')[0];
                value1 = a.Split('-')[1];
                value2 = a.Split('-')[2];
                value3 = a.Split('-')[3];
            }
            catch(Exception ex)
            {
                LogWriter.Instance.Error("Split Error of search", ex);
            }
            switch (type)
            {
                case "לקוח":
                    {
                        ClientUserControl control = new ClientUserControl(value1);
                        ShowControl(control);
                        break;
                    }
                case "פרוייקט":
                    {
                        ProjectUserControl control = new ProjectUserControl(value1, string.Empty);
                        ShowControl(control);
                        break;
                    }
                case "חוזה":
                    {
                        ContractUserControl control = new ContractUserControl(value1, ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Contracts, value2, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.PROJECT_CODE));
                        ShowControl(control);
                        break;
                    }
                case "חשבון":
                    {
                        //string clientCode = ExcelHelper.Instance.get
                        string clientCode = value3;
                        string clientName = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientCode, ColumnNames.CLIENT_CODE, ColumnNames.CLIENT_NAME);
                        BillUserControl control = new BillUserControl(clientCode, value2/*contract*/, SaveType.Update);
                        ShowControl(control);
                        break;
                    }
            }          
        }

        private void ShowControl(UserControl control)
        {
            searchSplit.Panel1.Visible = true;
            searchSplit.Panel1.Select();
            searchSplit.Panel1.Controls.Add(control);
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            checkFormsStatus();
        }
    }
}
