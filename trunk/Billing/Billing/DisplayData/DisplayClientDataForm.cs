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
            Dictionary<string,string> clientDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_NAME, ExcelHelper.Instance.Clients.Rows[ClientNamesComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString());
            if (clientDataList.Count != 0)
            {
                clientTypeTxtBox.Text = clientDataList[ColumnNames.CLIENT_CODE];
                ClientAddressTxtBox.Text = clientDataList[ColumnNames.ADRESS];
                phoneTxtBox.Text = clientDataList[ColumnNames.PHONE];
                clientCodeTxtBox.Text = clientDataList[ColumnNames.CLIENT_CODE];
                emailTxtBox.Text = clientDataList[ColumnNames.EMAIL];
                FillProjectsData();                
            }
        }       

        private void ClientNamesComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            ClientNamesComboBox.DataSource = ExcelHelper.Instance.Clients.Columns[ColumnNames.CLIENT_NAME].Table;
            ClientNamesComboBox.DisplayMember = ColumnNames.CLIENT_NAME;
            ClientNamesComboBox.ValueMember = ColumnNames.CLIENT_CODE;
        }

        #endregion Clients

        #region Projects

        private void FillProjectsData()
        {
            projectCodeComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Projects, ColumnNames.CLIENT_CODE, clientCodeTxtBox.Text, ColumnNames.PROJECT_CODE);
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
            Dictionary<string, string> ProjectDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Projects, ColumnNames.PROJECT_CODE,
                                                           ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectCodeComboBox.Text, ColumnNames.PROJECT_CODE, ColumnNames.PROJECT_CODE));
            if (ProjectDataList.Count != 0)
            {
                ClientNamesComboBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, ProjectDataList[ColumnNames.CLIENT_CODE], ColumnNames.CLIENT_CODE, ColumnNames.CLIENT_NAME);
                projectCodeComboBox.Text = ProjectDataList[ColumnNames.PROJECT_CODE];
                projectNametxtBox.Text = ProjectDataList[ColumnNames.PROJECT_NAME];
                contactManTxtBox.Text = ProjectDataList[ColumnNames.PROJECT_CONTACT_MAN];
                projectNameInviterTxtBox.Text = ProjectDataList[ColumnNames.INVITER_PROJECT_NAME];
                projectCodeInviterTxtBox.Text = ProjectDataList[ColumnNames.INVITER_PROJECT_CODE];
                projectDescriptiontxtBox.Text = ProjectDataList[ColumnNames.PROJECT_DESCRIPTION];
                FillContractsData();
            }
        }
        #endregion Projects

        #region Contracts

        private void FillContractsData()
        {
            YarivComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Contracts, ColumnNames.PROJECT_CODE, projectCodeComboBox.Text, ColumnNames.CONTRACT_CODE_YARIV);
            GetContractData();
        }

        private void GetContractData()
        {
            Dictionary<string, string> contractDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Contracts, ColumnNames.CONTRACT_CODE_YARIV,
                                                           ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Contracts, YarivComboBox.Text, ColumnNames.CONTRACT_CODE_YARIV, ColumnNames.CONTRACT_CODE_YARIV));
            clientContractCodetxtBox.Text = contractDataList[ColumnNames.CONRACT_CODE_CLIENT];
            valueTxtBox.Text = contractDataList[ColumnNames.VALUE];
            contractTypeComboBox.Text = ExcelHelper.Instance.ContractTypes.Rows[int.Parse(contractDataList[ColumnNames.CONTRACT_TYPE])][ColumnNames.TYPE_NAME].ToString();
            valueCalculationtxtBox.Text = contractDataList[ColumnNames.VALUE_CALCULATION];
            signingDateTxt.Text = contractDataList[ColumnNames.CONTRACT_SIGNING_DATE];
            startDateTxt.Text = contractDataList[ColumnNames.CONTRACT_START_DATE];
            endDateTxt.Text = contractDataList[ColumnNames.CONTRACT_END_DATE];
            valueCalculationWaytxtBox.Text = contractDataList[ColumnNames.VALUE_CALCULATION_WAY];
            contractParttxtBox.Text = ExcelHelper.Instance.getUsedAmountOfContract(YarivComboBox.Text);
        }

        #endregion Contracts

        

        private void YarivComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetContractData();
            fillBillsListBox();

        }

        private void fillBillsListBox()
        {
            BillsListBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Bills, ColumnNames.CONTRACT_CODE_YARIV, projectCodeComboBox.Text, ColumnNames.BILL_NUMBER_YARIV);
        }

        private void BillsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBillData();
        }

        private void GetBillData()
        {
            Dictionary<string, string> billDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Bills, ColumnNames.BILL_NUMBER_YARIV,
                                                         ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Bills, BillsListBox.Text, ColumnNames.BILL_NUMBER_YARIV, ColumnNames.BILL_NUMBER_YARIV));
            billDateTxt.Text = billDataList[ColumnNames.BILL_DATE];
            billNumberTxtBox.Text = billDataList[ColumnNames.BILL_NUMBER_YARIV];
            billSequenceInContractTxtBox.Text = billDataList[ColumnNames.BILL_SEQUENCE];
            valueTxt.Text = billDataList[ColumnNames.VALUE_CALC];
            lastBillTxtBox.Text = billDataList[ColumnNames.PREVIOUS_BILL];
            totalToPayTxtBox.Text = billDataList[ColumnNames.BILL_AMOUNT];
            maamTxtBox.Text = billDataList[ColumnNames.MAAM];
            totalWithMaamTextBox.Text = billDataList[ColumnNames.TOTAL_AMOUNT];
            totalBillsTxt.Text = ExcelHelper.Instance.getTotalOfBills(YarivComboBox.Text);
            billStatusTxt.Text = ExcelHelper.Instance.StatusTypes.Rows[int.Parse(billDataList[ColumnNames.STATUS_TYPE])][ColumnNames.STATUS_NAME].ToString();            
        }

    }
}
