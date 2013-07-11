using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billing.InsertData
{
    public partial class ClientUserControl : UserControl
    {
        Dictionary<string, string> clientTypeDic = new Dictionary<string, string>();
        bool isNew = true;
        string oldName;

        public ClientUserControl()
        {
            OnLoad();
        }

        private void OnLoad()
        {
            InitializeComponent();            
            foreach (DataRow row in ExcelHelper.Instance.ClientTypes.Rows)
            {
                clientTypeDic.Add(row[1].ToString(), row[0].ToString());
            }

            ClientTypeComboBox.DataSource = ExcelHelper.Instance.ClientTypes.Columns[ColumnNames.CLIENT_CODE].Table;
            ClientTypeComboBox.DisplayMember = ColumnNames.CLIENT_TYPE;
            ClientTypeComboBox.Text = ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_TYPE].ToString();
            clientCodeTxtBox.Text = ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_CODE,
                                                  ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString()
                                                  , ColumnNames.CLIENT_TYPE);
        }

        public ClientUserControl(string clientCode)
        {
            isNew = false;
            OnLoad();
            Dictionary<string,string> dic = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_CODE, clientCode);
            clientNameTxtBox.Text = dic[ColumnNames.CLIENT_NAME];
            clientCodeTxtBox.Text = dic[ColumnNames.CLIENT_CODE];
            ClientTypeComboBox.SelectedItem = dic[ColumnNames.CLIENT_TYPE];
            phoneTxtBox.Text = dic[ColumnNames.PHONE];
            ClientAddressTxtBox.Text = dic[ColumnNames.ADRESS];
            emailTxtBox.Text = dic[ColumnNames.EMAIL];
            oldName = clientNameTxtBox.Text;
            ClearFieldsBtn.Enabled = false;
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
                LogWriter.Instance.Error("error when saving client info",ex);
            }
            LogWriter.Instance.Trace("Client Saved");
        }

        private bool CheckAndSave()
        {
            if (IsDataExist())
            {
                SaveType type = ExcelHelper.Instance.shouldSave("לקוח {0}", clientNameTxtBox.Text);
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
            return false;
        }
                      
    

        private bool CheckAllFieldsAreFilled()
        {
            if ((string.IsNullOrEmpty(clientNameTxtBox.Text)) || (string.IsNullOrEmpty(ClientAddressTxtBox.Text))
                || (string.IsNullOrEmpty(phoneTxtBox.Text)) || (string.IsNullOrEmpty(emailTxtBox.Text)))
            {
                return false;
            }
            return true;
        }

        private bool IsDataExist()
        {
            return (ExcelHelper.Instance.CheckExistence(clientNameTxtBox.Text, clientTypeDic[ClientTypeComboBox.Text], ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_TYPE, ExcelHelper.Instance.Clients))
                || ExcelHelper.Instance.CheckExistence(clientCodeTxtBox.Text, clientTypeDic[ClientTypeComboBox.Text], ColumnNames.CLIENT_CODE, ColumnNames.CLIENT_TYPE, ExcelHelper.Instance.Clients);
        }

        private void btnSaveAndAddProj_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsAreFilled())
                {
                    if (CheckAndSave())
                    {
                        ProjectUserControl f = new ProjectUserControl(string.Empty, clientNameTxtBox.Text);                   
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

        private void ShowErrorMessage(Exception ex)
        {
            MessageBoxOptions options = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", string.Format(@"{0}", Constants.Instance.DB));
            MessageBox.Show(this, text + "\n\n" + ex, "בעיה בשמירת לקוח", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
        }

        private void SaveData(SaveType saveType)
        {
            if (saveType == SaveType.SaveNew)
            {
                DataRow row = ExcelHelper.Instance.Clients.NewRow();
                row[ColumnNames.CLIENT_NAME] = clientNameTxtBox.Text;
                row[ColumnNames.ADRESS] = ClientAddressTxtBox.Text;
                row[ColumnNames.PHONE] = phoneTxtBox.Text;
                row[ColumnNames.EMAIL] = emailTxtBox.Text;
                row[ColumnNames.CLIENT_TYPE] = ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString();
                row[ColumnNames.CLIENT_CODE] = ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_CODE,
                                                 ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString()
                                                 , ColumnNames.CLIENT_TYPE);                
                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Clients.TableName, saveType);
            }
            else
            {               
               object[] obj = new object[2] { ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients,
                                                oldName,ColumnNames.CLIENT_NAME,ColumnNames.CLIENT_CODE),oldName};
               DataRow row = ExcelHelper.Instance.Clients.Rows.Find(obj);
               row[ColumnNames.CLIENT_NAME] = clientNameTxtBox.Text;
               row[ColumnNames.ADRESS] = ClientAddressTxtBox.Text;
               row[ColumnNames.PHONE] = phoneTxtBox.Text;
               row[ColumnNames.EMAIL] = emailTxtBox.Text;
               row[ColumnNames.CLIENT_TYPE] = ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString();
               if (saveType == SaveType.SaveNew)
               {
                   clientCodeTxtBox.Text = ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_CODE,
                                                 ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString()
                                                 , ColumnNames.CLIENT_TYPE);
               }
               row[ColumnNames.CLIENT_CODE] = obj[0];
               ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Clients.TableName, saveType);
            }
        }

        private void ClearAllFields()
        {
            ClientAddressTxtBox.Clear();
            clientNameTxtBox.Clear();            
            emailTxtBox.Clear();
            phoneTxtBox.Clear();
        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void ClientTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isNew)
            {
                clientCodeTxtBox.Text = ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_CODE,
                                                  ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString()
                                                  , ColumnNames.CLIENT_TYPE);
            }
        }

        private void addClientType_Click(object sender, EventArgs e)
        {
            Form f = new ClientTypeForm();
            f.ShowDialog();
        }
    }
}
