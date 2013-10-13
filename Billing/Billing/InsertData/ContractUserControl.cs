using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Billing.DataObjects;

namespace Billing.InsertData
{
    public partial class ContractUserControl : UserControl
    {
        Project project = new Project();
        Client client = new Client();
        Contract contract = new Contract();
        bool isNew = true;
        private string valueTypes = string.Empty;
        Dictionary<int, List<TextBox>> valuesList = new Dictionary<int, List<TextBox>>();
        string contractCode;

        public ContractUserControl()
        {
            Onload();
            GetClientNames();
            GetProjects();
            GetContractType();
            SetTextBoxesText();
        }

        public ContractUserControl(string selectedClient, string selectedProject)
        {
            Onload();
            GetContract(selectedClient, selectedProject);
            GetClientFromContract();
            GetProjectFromContract();
            isNew = false;
            GetProjects();
            GetContractType();
            SetTextBoxesText();
            //Dictionary<string, string> dic = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Contracts, ColumnNames.CLIENT_CODE, selectedClient);
            
                //FillForm(selectedClient, selectedProject, contract);
        }

        private void GetContract(string selectedClient, string selectedProject)
        {
            contract = ExcelHelper.Instance.getContractByIdentifier(selectedClient, selectedProject, ColumnNames.CLIENT_CODE, ColumnNames.PROJECT_CODE);
        }

        private void GetProjectFromContract()
        {
            project = ExcelHelper.Instance.GetProjectByIdentifier(contract.ProjectCode.ToString(), ColumnNames.PROJECT_CODE);
        }

        private void GetClientFromContract()
        {
            client = ExcelHelper.Instance.GetClientByIdentifier(contract.ClientCode.ToString(), ColumnNames.CLIENT_CODE);
        }

        public ContractUserControl(string selectedClient, string selectedProject, string selectedContract)
        {
            Onload();
            GetContract(selectedClient, selectedProject);
            GetClientFromContract();
            GetProjectFromContract();
            isNew = false;
            GetProjects();
            GetContractType();
            SetTextBoxesText();
            //Dictionary<string, string> dic = ExcelHelper.Instance.GetRowItemsByFilters(ExcelHelper.Instance.Contracts, ColumnNames.CLIENT_CODE, selectedClient, ColumnNames.CONTRACT_CODE_YARIV, selectedContract);
            //FillForm(selectedClient, selectedProject, dic);
        }

        private void Onload()
        {
            InitializeComponent();
            contract.ContractCodeYariv = ExcelHelper.Instance.GetMaxItemOfColumn(ExcelHelper.Instance.Contracts, ColumnNames.CONTRACT_CODE_YARIV) + 1;            
        }

        private void GetClientNames()
        {
            clientNameComboBox.DataSource = ExcelHelper.Instance.Clients.Columns[ColumnNames.CLIENT_CODE].Table;
            clientNameComboBox.DisplayMember = ColumnNames.CLIENT_NAME;
           
        }

        private void clientNameComboBox_Click(object sender, EventArgs e)
        {
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString();
            clientNameComboBox.Refresh();
        }

        private void GetProjects()
        {
            project = ExcelHelper.Instance.GetProjectByIdentifier(contract.ClientCode.ToString(), ColumnNames.CLIENT_CODE);
            projectNameComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Projects, ColumnNames.CLIENT_CODE, client.ClientCode.ToString(), ColumnNames.PROJECT_NAME);
            projectNameComboBox.SelectedItem = project.ProjectName; 
        }

        private void SetTextBoxesText()
        {
            clientNameComboBox.Text = client.ClientName;
            clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(client.ClientName);
            projectNameComboBox.Text = project.ProjectName;
            projectNameComboBox.SelectedIndex = projectNameComboBox.FindStringExact(project.ProjectName);
            projectCodeTxtBox.Text = project.ProjectCode.ToString();
            yarivContractCodeTxtBox.Text = contract.ContractCodeYariv.ToString();
            clientContractCodetxtBox.Text = contract.ContractCodeClient.ToString();
            valueTxtBox.Text = contract.Value.ToString();
            CalculateValueWithMaam();
            signingDatePicker.Value = contract.ContractSigningDate;
            startDatePicker.Value = contract.ContractStartDate;
            endDatePicker.Value = contract.ContractEndTime;
            contractTypeComboBox.Text = projectNameComboBox.SelectedIndex < 0 ? "0" : ExcelHelper.Instance.ContractTypes.Rows[contract.ContractType][ColumnNames.TYPE_NAME].ToString();

            //yarivContractCodeTxtBox.Text = contract.ContractCodeYariv.ToString();
            //clientNameComboBox.Text = client.ClientName;
            //projectCodeTxtBox.Text = project.ProjectCode.ToString();
            //contractTypeComboBox.Text = projectNameComboBox.SelectedIndex < 0 ? "0" : ExcelHelper.Instance.ContractTypes.Rows[contract.ContractType][ColumnNames.TYPE_NAME].ToString();
        }

        private void CalculateValueWithMaam()
        {
            try
            {
                double value = double.Parse(valueTxtBox.Text);
                valueWithMaamTxtBox.Text = (value + value * (Constants.Instance.MAAM /100)).ToString();
            }
            catch
            {
            }
        }
                
        //private void FillForm(string selectedClient, string selectedProject,Contract contract)
        //{
        //    if (contract.Count > 0)
        //    {
        //        isNew = false;
        //    }
        //    if (isNew)
        //    {
        //        clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(selectedClient);
        //        clientNameComboBox.Enabled = false;
        //        GetClientNames();
        //        clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(selectedClient);
        //        GetProjects();
        //        GetContractType();
        //        clientNameComboBox.Enabled = false;
        //        projectNameComboBox.SelectedIndex = projectNameComboBox.FindStringExact(selectedProject);
        //        projectNameComboBox.Enabled = false;
        //        projectCodeTxtBox.Enabled = false;
        //    }
        //    else
        //    {
        //        clientNameComboBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, selectedClient, ColumnNames.CLIENT_CODE, ColumnNames.CLIENT_NAME);
        //        projectNameComboBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, selectedProject, ColumnNames.PROJECT_CODE, ColumnNames.PROJECT_NAME);
        //        projectCodeTxtBox.Text = dic[ColumnNames.PROJECT_CODE];
        //        projectCodeTxtBox.Enabled = false;
        //        yarivContractCodeTxtBox.Text = dic[ColumnNames.CONTRACT_CODE_YARIV];
        //        yarivContractCodeTxtBox.Enabled = false;
        //        clientContractCodetxtBox.Text = dic[ColumnNames.CONRACT_CODE_CLIENT];
        //        clientContractCodetxtBox.Enabled = false;
        //        valueTxtBox.Text = dic[ColumnNames.VALUE];
        //        CalculateValueWithMaam();
        //        signingDatePicker.Value = DateTime.Parse(dic[ColumnNames.CONTRACT_SIGNING_DATE]);
        //        startDatePicker.Value = DateTime.Parse(dic[ColumnNames.CONTRACT_START_DATE]);
        //        endDatePicker.Value = DateTime.Parse(dic[ColumnNames.CONTRACT_END_DATE]);
        //        contractTypeComboBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ContractTypes, dic[ColumnNames.CONTRACT_TYPE], ColumnNames.TYPE_CODE, ColumnNames.TYPE_NAME);
        //        valueListBox.Items.Clear();
        //        getValueTypes(dic[ColumnNames.VALUE_TYPES]);
        //    }
        //}

        private void getValueTypes(string types)
        {
            List<string> list = new List<string>(types.Split(';'));
            foreach (string typeCode in list)
            {
                string item = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ValueTypes, typeCode, ColumnNames.VALUE_CODE, ColumnNames.VALUE_TYPE);
                if (!string.IsNullOrEmpty(item))
                {
                    valueListBox.Items.Add(item);
                    valueTypes = valueTypes + typeCode + ";";
                }            
            }
            valueListBox.Visible = true;
        }        

        private void GetContractType()
        {
            contractTypeComboBox.DataSource = ExcelHelper.Instance.ContractTypes.Columns[ColumnNames.TYPE_CODE].Table;
            contractTypeComboBox.DisplayMember = ColumnNames.TYPE_NAME;            
        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            clientContractCodetxtBox.Clear();
            valueTxtBox.Clear();
            valueWithMaamTxtBox.Clear();
        }

        private void projectNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectNameComboBox.Refresh();
            projectNameComboBox.Text = projectNameComboBox.Text = projectNameComboBox.SelectedItem == null ? "אין פרוייקטים ללקוח זה" : projectNameComboBox.SelectedItem.ToString();
            projectCodeTxtBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectNameComboBox.Text, ColumnNames.PROJECT_NAME, ColumnNames.PROJECT_CODE);
            projectCodeTxtBox.Refresh();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            contract = new Contract();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsAreFilled())
                {
                    if (CheckAndSave())
                    {
                        this.Parent.Controls.Remove(this);
                    }
                }
                else
                {
                    MessageBox.Show("מלא את כל השדות בבקשה");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
                LogWriter.Instance.Error("error when saving contract info", ex);
            }
            LogWriter.Instance.Trace("Contract Saved");
        }

        private void ShowErrorMessage(Exception ex)
        {
            MessageBoxOptions options = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", string.Format(@"{0}", Constants.Instance.DB));
            MessageBox.Show(this, text + "\n\n" + ex, "בעיה בשמירת חוזה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
        }

        private void btnSaveAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsAreFilled())
                {
                    if (CheckAndSave())
                    {
                        BillUserControl f = new BillUserControl(clientNameComboBox.Text, yarivContractCodeTxtBox.Text, SaveType.SaveNew);
                        this.Parent.Controls.Add(f);
                        this.Parent.Controls.Remove(this);
                    }
                }
                else
                {
                    MessageBox.Show("מלא את כל השדות בבקשה");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
                LogWriter.Instance.Error("error when saving client info", ex);
            }
            LogWriter.Instance.Trace("Client Saved");
        }

        private bool CheckAllFieldsAreFilled()
        {
            if ((string.IsNullOrEmpty(clientNameComboBox.Text)) || (string.IsNullOrEmpty(projectNameComboBox.Text))
                || (string.IsNullOrEmpty(projectCodeTxtBox.Text)) || (string.IsNullOrEmpty(yarivContractCodeTxtBox.Text))
                || (string.IsNullOrEmpty(clientContractCodetxtBox.Text)) || (string.IsNullOrEmpty(valueTxtBox.Text))
                || (string.IsNullOrEmpty(signingDatePicker.Text)) || (string.IsNullOrEmpty(startDatePicker.Text))
                || (string.IsNullOrEmpty(endDatePicker.Text)) || (string.IsNullOrEmpty(contractTypeComboBox.Text)))
            {
                return false;
            }
            return true;
        }

        private bool CheckAndSave()
        {
            if (!(startDatePicker.Value > endDatePicker.Value))
            {

                if (IsDataExist())
                {
                    SaveType type = ExcelHelper.Instance.shouldSave(string.Format("קוד חוזה {0} או", clientContractCodetxtBox.Text) + " או חוזה {0}", yarivContractCodeTxtBox.Text);
                    switch (type)
                    {
                        case SaveType.SaveNew:
                        case SaveType.Update:
                            {
                                SaveData(type);
                                return true;
                            }
                        case SaveType.NA:
                        default:
                            break;
                    }
                }   
                else
                {
                    SaveData(SaveType.SaveNew);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("תאריך התחלה קטן מתאריך סיום, אנא וודא תאריכים תקפים");
            }
            return false;
        }

        private bool IsDataExist()
        {
            return ((ExcelHelper.Instance.CheckExistence(clientContractCodetxtBox.Text,yarivContractCodeTxtBox.Text, ColumnNames.CONRACT_CODE_CLIENT, ColumnNames.CLIENT_CODE, ExcelHelper.Instance.Contracts)) ||
                (ExcelHelper.Instance.CheckExistenceOfSingleValue(clientContractCodetxtBox.Text, ColumnNames.CONTRACT_CODE_YARIV, ExcelHelper.Instance.Contracts)));
        }

        private void SaveData(SaveType saveType)
        {
            if (saveType == SaveType.SaveNew)
            {
                DataRow row = ExcelHelper.Instance.Contracts.NewRow();
                row[ColumnNames.CLIENT_CODE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE);
                row[ColumnNames.PROJECT_CODE] = projectCodeTxtBox.Text;
                row[ColumnNames.CONTRACT_CODE_YARIV] = yarivContractCodeTxtBox.Text;
                row[ColumnNames.CONRACT_CODE_CLIENT] = clientContractCodetxtBox.Text;
                row[ColumnNames.VALUE] = valueTxtBox.Text;
                row[ColumnNames.CONTRACT_SIGNING_DATE] = signingDatePicker.Text;
                row[ColumnNames.CONTRACT_START_DATE] = startDatePicker.Text;
                row[ColumnNames.CONTRACT_END_DATE] = endDatePicker.Text;
                row[ColumnNames.CONTRACT_TYPE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ContractTypes, contractTypeComboBox.Text, ColumnNames.TYPE_NAME, ColumnNames.TYPE_CODE);
                row[ColumnNames.VALUE_TYPES] = valueTypes;

                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Contracts.TableName, SaveType.SaveNew);

                foreach (KeyValuePair<int, List<TextBox>> list in valuesList)
                {
                    if (list.Value.Count == 2)
                    {
                        DataRow valueRow = ExcelHelper.Instance.ValueInBill.NewRow();
                        valueRow[ColumnNames.PAYMENT] = list.Value[0].Text;
                        valueRow[ColumnNames.QUANTITY] = list.Value[1].Text;
                        valueRow[ColumnNames.VALUE_CODE] = list.Value[0].Name;
                        valueRow[ColumnNames.CONTRACT_CODE_YARIV] = contractCode;
                        valueRow[ColumnNames.BILL_NUMBER_YARIV] = string.Empty;
                        Dictionary<string,string> dic = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.ValueInBill, ColumnNames.CONTRACT_CODE_YARIV, contractCode);
                        ExcelHelper.Instance.SaveDataToExcel(valueRow, ExcelHelper.Instance.ValueInBill.TableName, SaveType.SaveNew);
                    }
                }            
            }
            else
            {
                string clientCode = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE);
                clientNameComboBox.SelectedItem = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients,clientCode,ColumnNames.CLIENT_CODE,ColumnNames.CLIENT_NAME);
                string projectName = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects,projectNameComboBox.Text,ColumnNames.PROJECT_NAME,ColumnNames.PROJECT_CODE);
                yarivContractCodeTxtBox.Text = ExcelHelper.Instance.getItemFromTable(
                                                                                        ExcelHelper.Instance.Contracts,
                                                                                        projectName, 
                                                                                        ColumnNames.PROJECT_CODE,
                                                                                        ColumnNames.CONTRACT_CODE_YARIV);
                object[] obj = new object[2] { yarivContractCodeTxtBox.Text, clientContractCodetxtBox.Text };
                DataRow row = ExcelHelper.Instance.Contracts.Rows.Find(obj);
                if (saveType == SaveType.SaveNew)
                {
                    yarivContractCodeTxtBox.Text = (ExcelHelper.Instance.Contracts.Rows.Count + 1).ToString();
                }
                row[ColumnNames.CLIENT_CODE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE);
                row[ColumnNames.PROJECT_CODE] = projectCodeTxtBox.Text;
                row[ColumnNames.CONTRACT_CODE_YARIV] = obj[0];
                row[ColumnNames.CONRACT_CODE_CLIENT] = obj[1];
                row[ColumnNames.VALUE] = valueTxtBox.Text;
                row[ColumnNames.CONTRACT_SIGNING_DATE] = signingDatePicker.Text;
                row[ColumnNames.CONTRACT_START_DATE] = startDatePicker.Text;
                row[ColumnNames.CONTRACT_END_DATE] = endDatePicker.Text;
                row[ColumnNames.CONTRACT_TYPE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ContractTypes, contractTypeComboBox.Text, ColumnNames.TYPE_NAME, ColumnNames.TYPE_CODE);
                row[ColumnNames.VALUE_TYPES] = valueTypes;
                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Contracts.TableName, SaveType.Update);
                foreach (KeyValuePair<int, List<TextBox>> list in valuesList)
                {
                    if (list.Value.Count == 2)
                    {
                        DataRow valueRow = ExcelHelper.Instance.ValueInBill.NewRow();
                        valueRow[ColumnNames.PAYMENT] = list.Value[0].Text;
                        valueRow[ColumnNames.QUANTITY] = list.Value[1].Text;
                        valueRow[ColumnNames.VALUE_CODE] = list.Value[0].Name;
                        valueRow[ColumnNames.CONTRACT_CODE_YARIV] = contractCode;
                        valueRow[ColumnNames.BILL_NUMBER_YARIV] = string.Empty;
                        ExcelHelper.Instance.SaveDataToExcel(valueRow, ExcelHelper.Instance.ValueInBill.TableName, SaveType.SaveNew);
                    }
                }
            }
        }    

        private void valueTxtBox_Leave(object sender, EventArgs e)
        {
            CalculateValueWithMaam();
        }

        private void addValue_Click(object sender, EventArgs e)
        {
            using (AddValueForm form = new AddValueForm(yarivContractCodeTxtBox.Text, valueListBox.Items))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    valueListBox.Items.Clear();
                    valueTypes = string.Empty;
                    foreach (ValueItem obj in form.valueTypes)
                    {
                        valueListBox.Items.Add(obj.ValueType);
                        valueTypes += obj.ValueCode + ";";
                    }                                       
                    valuesList = form.valuesList;
                    contractCode = form.contractCode;
                    valueListBox.Visible = true;
                }
            }
        }

        private void clientNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            client.ClientName = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString();
            client = ExcelHelper.Instance.GetClientByIdentifier(client.ClientName, ColumnNames.CLIENT_NAME);
            contract.ClientCode = client.ClientCode;
            GetProjects();
        }
    }
}
