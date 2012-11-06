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
            ClientNamesComboBox.Text = "לחץ כאן להצגת רשימת הלקוחות";
        }
        #region Clients
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
                FillProjectsData();                
            }
        }       

        private void ClientNamesComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            ClientNamesComboBox.DataSource = ExcelHelper.Instance.Clients.Columns["שם לקוח"].Table;
            ClientNamesComboBox.DisplayMember = "שם לקוח";
            ClientNamesComboBox.ValueMember = "קוד לקוח";
        }

        #endregion Clients

        #region Projects

        private void FillProjectsData()
        {
            projectCodeComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Projects, "קוד הלקוח", clientCodeTxtBox.Text, "קוד פרוייקט");
            GetProjectData();
        }       

        private void projectCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProjectData();            
        }

        private void projectCodeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetProjectData();
        }

        private void GetProjectData()
        {
            Dictionary<string, string> ProjectDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Projects, "קוד פרוייקט",
                                                           ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectCodeComboBox.Text, "קוד פרוייקט", "קוד פרוייקט"));
            if (ProjectDataList.Count != 0)
            {
                ClientNamesComboBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, ProjectDataList["קוד הלקוח"], "קוד לקוח", "שם לקוח");
                projectCodeComboBox.Text = ProjectDataList["קוד פרוייקט"];
                projectNametxtBox.Text = ProjectDataList["שם הפרוייקט"];
                contactManTxtBox.Text = ProjectDataList["איש קשר בפרוייקט"];
                projectNameInviterTxtBox.Text = ProjectDataList["שם פרוייקט אצל המזמין"];
                projectCodeInviterTxtBox.Text = ProjectDataList["קוד פרוייקט אצל המזמין"];
                projectDescriptiontxtBox.Text = ProjectDataList["תיאור הפרוייקט"];
                FillContractsData();
            }
        }
        #endregion Projects

        #region Contracts

        private void FillContractsData()
        {
            YarivComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Contracts, "קוד פרוייקט", projectCodeComboBox.Text, "קוד חוזה יריב");
            GetContractData();
        }

        private void GetContractData()
        {
            Dictionary<string, string> contractDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Contracts, "קוד חוזה יריב",
                                                           ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Contracts, YarivComboBox.Text, "קוד חוזה יריב", "קוד חוזה יריב"));
            clientContractCodetxtBox.Text = contractDataList["קוד חוזה לקוח"];
            valueTxtBox.Text = contractDataList["תמורה"];
            contractTypeComboBox.Text = ExcelHelper.Instance.ContractTypes.Rows[int.Parse(contractDataList["סיווג חוזה"])]["שם הסוג"].ToString();
            valueCalculationtxtBox.Text = contractDataList["נגזרת התמורה"];
            signingDateTxt.Text = contractDataList["תאריך חתימת החוזה"];
            startDateTxt.Text = contractDataList["מועד תחילת חוזה"];
            endDateTxt.Text = contractDataList["מועד סיום חוזה"];
            valueCalculationWaytxtBox.Text = contractDataList["אופן חישוב תמורה"];
            contractParttxtBox.Text = contractDataList["ניצול חוזה"];
        }

        #endregion Contracts

        

        private void YarivComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetContractData();
            fillBillsListBox();

        }

        private void fillBillsListBox()
        {
            BillsListBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Bills, "קוד חוזה", projectCodeComboBox.Text, "מספר חשבון ביריב");
        }

        private void BillsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBillData();
        }

        private void GetBillData()
        {
            Dictionary<string, string> billDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Bills, "מספר חשבון ביריב",
                                                         ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Bills, BillsListBox.Text, "מספר חשבון ביריב", "מספר חשבון ביריב"));
            billDateTxt.Text = billDataList["תאריך החשבון"];
            billNumberTxtBox.Text = billDataList["מספר חשבון ביריב"];
            billSequenceInContractTxtBox.Text = billDataList["מספר חשבון חלקי בחוזה"];
            valueTxt.Text = billDataList["חישוב התמורה"];
            lastBillTxtBox.Text = billDataList["חשבון קודם"];
            totalToPayTxtBox.Text = billDataList["סכום החשבון"];
            maamTxtBox.Text = billDataList["המע\"מ"];
            totalWithMaamTextBox.Text = billDataList["סה\"כ לתשלום"];
            totalBillsTxt.Text = ExcelHelper.Instance.getTotalOfBills(YarivComboBox.Text);
            billStatusTxt.Text = ExcelHelper.Instance.StatusTypes.Rows[int.Parse(billDataList["סוג סטטוס"])]["שם סטטוס"].ToString();            
        }

    }
}
