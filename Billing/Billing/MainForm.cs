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
using System.Text.RegularExpressions;
using System.Configuration;

namespace Billing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            billsPathTxt.Text = config.AppSettings.Settings["BillsFolder"].Value;
            maamSettingsTxt.Text = config.AppSettings.Settings["maam"].Value;
            DBPathTxt.Text = AppDomain.CurrentDomain.BaseDirectory + config.AppSettings.Settings["excelFileName"].Value;
            maamBtn.Enabled = false;
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            DialogResult dr = checkFormsStatus();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.None))
            {
                splitContainer1.Panel1.Controls.Clear();
                BillUserControl billForm = new BillUserControl();
                splitContainer1.Panel1.Visible = true;
                splitContainer1.Panel1.Select();
                splitContainer1.Panel1.Controls.Add(billForm);      
            }
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            DialogResult dr = checkFormsStatus();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.None))
            {
                splitContainer1.Panel1.Controls.Clear();
                ContractUserControl contractForm = new ContractUserControl();
                splitContainer1.Panel1.Visible = true;
                splitContainer1.Panel1.Select();
                splitContainer1.Panel1.Controls.Add(contractForm);
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            DialogResult dr = checkFormsStatus();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.None))
            {
                splitContainer1.Panel1.Controls.Clear();
                ProjectUserControl projectForm = new ProjectUserControl();
                splitContainer1.Panel1.Visible = true;
                splitContainer1.Panel1.Select();
                splitContainer1.Panel1.Controls.Add(projectForm);
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
           DialogResult dr = checkFormsStatus();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.None))
            {
                splitContainer1.Panel1.Controls.Clear();            
                ClientUserControl control = new ClientUserControl();
                splitContainer1.Panel1.Visible = true;
                splitContainer1.Panel1.Select();
                splitContainer1.Panel1.Controls.Add(control);
            }
        }

        public DialogResult checkFormsStatus()
        {
            if (tabControl1.SelectedTab.Name == "AddDataTab")
            {
                if (splitContainer1.Panel1.Controls.Count >= 1)
                {
                    return MessageBox.Show("האם לנקות את הטופס?", "", MessageBoxButtons.YesNo);
                    
                }
            }
            else
            {
                if (searchSplit.Panel1.Controls.Count >= 1)
                {
                    return MessageBox.Show("האם לנקות את הטופס?", "", MessageBoxButtons.YesNo);                
                }
            }
            return DialogResult.None;
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
            if (tabControl1.SelectedTab.Name != "Settings")
            {
                DialogResult dr = checkFormsStatus();
                if ((dr == DialogResult.Yes) || (dr == DialogResult.None))
                {
                    if (((System.Windows.Forms.TabControl)(sender)).SelectedTab.Name == "EditDataTab")
                    {
                        searchSplit.Panel1.Controls.Clear();
                    }
                    else
                    {
                        splitContainer1.Panel1.Controls.Clear();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration config=ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); 
            DBPathFileDialog.FileName = System.Configuration.ConfigurationManager.AppSettings["excelFileName"];
            DBPathFileDialog.Title = "בחר את קובץ בסיס הנתונים";
            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            DBPathFileDialog.InitialDirectory = filePath;
            DialogResult dr = DBPathFileDialog.ShowDialog();
            string fullPath = DBPathFileDialog.FileName;
            string fileName = DBPathFileDialog.SafeFileName;
            string path = fullPath.Replace(fileName, "");
            config.AppSettings.Settings["excelFileName"].Value = fullPath;
            config.Save(ConfigurationSaveMode.Modified); 
            ConfigurationManager.RefreshSection("appSettings");
            DBPathTxt.Text = fullPath;
        }

        private void maamBtn_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); 
            config.AppSettings.Settings["maam"].Value = maamSettingsTxt.Text.Trim('%');
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            maamSettingsTxt.Text = config.AppSettings.Settings["maam"].Value;
            maamBtn.Enabled = false;
        }

        private void billsPathBtn_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            billsFolderDialog.Description = "בחר נתיב לשמירת חשבונות";
            billsFolderDialog.SelectedPath = billsPathTxt.Text;
            DialogResult dr = billsFolderDialog.ShowDialog();
            config.AppSettings.Settings["BillsFolder"].Value = billsFolderDialog.SelectedPath;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            billsPathTxt.Text = config.AppSettings.Settings["BillsFolder"].Value;
        }

        private void maamSettingsTxt_TextChanged(object sender, EventArgs e)
        {
            maamBtn.Enabled = true;
        }

        private void searchTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                searchBtn_Click(sender, e);
            }
        }
    }
}
