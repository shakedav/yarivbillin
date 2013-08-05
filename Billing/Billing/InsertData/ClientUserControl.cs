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
    public partial class ClientUserControl : UserControl
    {
        Client client = new Client();
        bool isNew = true;
        string oldName;

        public ClientUserControl()
        {
            OnLoad();
        }

        private void OnLoad()
        {
            InitializeComponent();
            BindClientTypes();                      
        }

        private void BindClientTypes()
        {
            BindingSource src = new BindingSource();
            src.DataSource = ClientTypes.Instance.ClientTypesList;
            ClientTypeComboBox.DataSource = src.DataSource;
            ClientTypeComboBox.DisplayMember = "Type";
            client.Type = (ClientTypeComboBox.SelectedItem as ClientType).Code;     
        }

        public ClientUserControl(string clientCode)
        {
            isNew = false;
            OnLoad();
            client = ExcelHelper.Instance.GetClientByIdentifier(clientCode, ColumnNames.CLIENT_CODE);
            SetTextBoxesText();
            oldName = client.ClientName;
            ClearFieldsBtn.Enabled = false;
        }

        private void SetTextBoxesText()
        {
            clientNameTxtBox.Text = client.ClientName;
            clientCodeTxtBox.Text = client.ClientCode.ToString();
            ClientTypeComboBox.SelectedItem = client.Type;
            phoneTxtBox.Text = client.ClientPhone;
            ClientAddressTxtBox.Text = client.Address;
            emailTxtBox.Text = client.ClientMail;
        }

        private void ClientTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isNew)
            {
                ComboBox c = ((System.Windows.Forms.ComboBox)(sender)) as ComboBox;
                ClientType ct = (ClientType)c.SelectedItem;
                int maxID = ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_CODE, ct.Code.ToString(), ColumnNames.CLIENT_TYPE);
                clientCodeTxtBox.Text = maxID.ToString();
                client.ClientCode = maxID;
            }
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
            UpdateClient();
            if (ExcelHelper.Instance.CheckExistence(client.ClientCode.ToString(), client.Type.ToString(), ColumnNames.CLIENT_CODE, ColumnNames.CLIENT_TYPE, ExcelHelper.Instance.Clients))
            {
                SaveType type = SaveType.Update;
                SaveData(type);
                return true;                        
            }
            if (IsDataExist())
            {
                SaveType type = ExcelHelper.Instance.shouldSave("לקוח {0}", client.ClientName);
                Client oldClient = ExcelHelper.Instance.GetClientByIdentifier(clientNameTxtBox.Text, ColumnNames.CLIENT_NAME);
                switch (type)
                {
                    case SaveType.Update:
                        {
                            client.ClientCode = oldClient.ClientCode;
                            SaveData(type);
                            return true;
                        }
                    case SaveType.SaveNew:                    
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

        private void UpdateClient()
        {
            if (oldName == null)
            {
                oldName = clientNameTxtBox.Text;
            }
            client.Address = ClientAddressTxtBox.Text;
            client.ClientCode = Convert.ToInt32(clientCodeTxtBox.Text);
            client.ClientMail = emailTxtBox.Text;
            client.ClientName = clientNameTxtBox.Text;
            client.ClientPhone = phoneTxtBox.Text;
            client.Type = (ClientTypeComboBox.SelectedItem as ClientType).Code;
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
            return (ExcelHelper.Instance.CheckExistence(client.ClientName, client.Type.ToString(), ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_TYPE, ExcelHelper.Instance.Clients));
        }

        private void btnSaveAndAddProj_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsAreFilled())
                {
                    if (CheckAndSave())
                    {
                        ProjectUserControl f = new ProjectUserControl(string.Empty, client.ClientName);                   
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
            ExcelHelper.Instance.SaveClient(client, saveType, oldName);
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

        private void addClientType_Click(object sender, EventArgs e)
        {
            Form f = new ClientTypeForm();
            f.ShowDialog();
        }
    }
}
