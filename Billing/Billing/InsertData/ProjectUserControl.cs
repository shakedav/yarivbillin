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
    public partial class ProjectUserControl : UserControl
    {
        bool isNew = true;

        public ProjectUserControl()
        {           
            Onload();
        }

        private void Onload()
        {
            InitializeComponent();
            projectCodetxtBox.Text = (ExcelHelper.Instance.Projects.Rows.Count + 1).ToString();
            clientNameComboBox.DataSource = ExcelHelper.Instance.Clients.Columns[ColumnNames.CLIENT_CODE].Table;
            clientNameComboBox.DisplayMember = ColumnNames.CLIENT_NAME;
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString();
        }      

        public ProjectUserControl(string selectedProject, string selectedClient)
        {
            Onload();
            Dictionary<string, string> dic = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Projects, ColumnNames.PROJECT_CODE, selectedProject);

            if (dic.Count > 0)
            {
                isNew = false;
            }
            if (isNew)
            {
                clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(selectedClient);
                clientNameComboBox.Enabled = false;
            }
            else
            {
                clientNameComboBox.SelectedItem = dic[ColumnNames.CLIENT_CODE];
                projectCodetxtBox.Text = dic[ColumnNames.PROJECT_CODE];
                projectNametxtBox.Text = dic[ColumnNames.PROJECT_NAME];
                contactManTxtBox.Text = dic[ColumnNames.PROJECT_CONTACT_MAN];
                contactManDescTxt.Text = dic[ColumnNames.CONTACT_MAN_DESC];
                contactManPhoneTxtBox.Text = dic[ColumnNames.CONTACT_MAN_PHONE];
                contactManEmailTxtBox.Text = dic[ColumnNames.CONTACT_MAN_EMAIL];
                projectCodeInviterTxtBox.Text = dic[ColumnNames.INVITER_PROJECT_CODE];
                projectNameInviterTxtBox.Text = dic[ColumnNames.INVITER_PROJECT_NAME];
                projectDescriptiontxtBox.Text = dic[ColumnNames.PROJECT_DESCRIPTION];
                clientNameComboBox.Enabled = false;
            }
        }

        private void ClearAllFields(object sender, EventArgs e)
        {
            projectNametxtBox.Clear();
            contactManTxtBox.Clear();
            projectDescriptiontxtBox.Clear();
            projectCodeInviterTxtBox.Clear();
            projectNameInviterTxtBox.Clear();
            contactManDescTxt.Clear();
            contactManPhoneTxtBox.Clear();
            contactManEmailTxtBox.Clear();
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
                LogWriter.Instance.Error("error when saving Project info", ex);
            }
            LogWriter.Instance.Trace("Project Saved");
        }

        private bool IsDataExist()
        {
            return ((ExcelHelper.Instance.CheckExistence(projectNametxtBox.Text,
                                                        ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients,
                                                        clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE), ColumnNames.PROJECT_NAME,
                                                        ColumnNames.CLIENT_CODE, ExcelHelper.Instance.Projects)) ||
                                                        (ExcelHelper.Instance.CheckExistenceOfSingleValue(projectCodetxtBox.Text,ColumnNames.PROJECT_CODE,ExcelHelper.Instance.Projects)));
        }

        private void SaveData(SaveType saveType)
        {
            if (isNew)
            {
                DataRow row = ExcelHelper.Instance.Projects.NewRow();
                row[ColumnNames.PROJECT_CODE] = projectCodetxtBox.Text;
                row[ColumnNames.PROJECT_NAME] = projectNametxtBox.Text;
                row[ColumnNames.PROJECT_CONTACT_MAN] = contactManTxtBox.Text;
                row[ColumnNames.INVITER_PROJECT_NAME] = projectNameInviterTxtBox.Text;
                row[ColumnNames.INVITER_PROJECT_CODE] = projectCodeInviterTxtBox.Text;
                row[ColumnNames.PROJECT_DESCRIPTION] = projectDescriptiontxtBox.Text;
                row[ColumnNames.CLIENT_CODE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE);
                row[ColumnNames.CONTACT_MAN_DESC] = contactManDescTxt.Text;
                row[ColumnNames.CONTACT_MAN_PHONE] = contactManPhoneTxtBox.Text;
                row[ColumnNames.CONTACT_MAN_EMAIL] = contactManEmailTxtBox.Text;
                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Projects.TableName, saveType);
            }
            else
            {
                object[] obj = new object[2] { projectCodetxtBox.Text, projectNametxtBox.Text };
                DataRow row = ExcelHelper.Instance.Projects.Rows.Find(obj);
                if (saveType == SaveType.SaveNew)
                {
                    projectCodetxtBox.Text = (ExcelHelper.Instance.Projects.Rows.Count + 1).ToString();
                }
                row[ColumnNames.PROJECT_CODE] = projectCodetxtBox.Text;
                row[ColumnNames.PROJECT_NAME] = projectNametxtBox.Text;
                row[ColumnNames.PROJECT_CONTACT_MAN] = contactManTxtBox.Text;
                row[ColumnNames.INVITER_PROJECT_NAME] = projectNameInviterTxtBox.Text;
                row[ColumnNames.INVITER_PROJECT_CODE] = projectCodeInviterTxtBox.Text;
                row[ColumnNames.PROJECT_DESCRIPTION] = projectDescriptiontxtBox.Text;
                row[ColumnNames.CLIENT_CODE] = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE);
                row[ColumnNames.CONTACT_MAN_DESC] = contactManDescTxt.Text;
                row[ColumnNames.CONTACT_MAN_PHONE] = contactManPhoneTxtBox.Text;
                row[ColumnNames.CONTACT_MAN_EMAIL] = contactManEmailTxtBox.Text;
                ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Projects.TableName, saveType);                
            }
        }

        private void ShowErrorMessage(Exception ex)
        {
            MessageBoxOptions options = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", Constants.Instance.Path);
            MessageBox.Show(this, text + "\n\n" + ex, "בעיה בשמירת פרוייקט", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
        }
        

        private void clientNamecomboBox_Click(object sender, EventArgs e)
        {
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString();
            clientNameComboBox.Refresh();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnSaveAddContract_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsAreFilled())
                {
                    if (CheckAndSave())
                    {
                        ContractUserControl f = new ContractUserControl(clientNameComboBox.Text, projectNametxtBox.Text);
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
                LogWriter.Instance.Error("error when saving Project info", ex);
            }
            LogWriter.Instance.Trace("Project Saved");
        }

        private bool CheckAllFieldsAreFilled()
        {
            if ((string.IsNullOrEmpty(clientNameComboBox.Text)) || (string.IsNullOrEmpty(projectCodetxtBox.Text))
                || (string.IsNullOrEmpty(projectNameInviterTxtBox.Text)) || (string.IsNullOrEmpty(contactManTxtBox.Text))
                || (string.IsNullOrEmpty(projectCodeInviterTxtBox.Text)) || (string.IsNullOrEmpty(projectNameInviterTxtBox.Text))
                || (string.IsNullOrEmpty(projectDescriptiontxtBox.Text)) || (string.IsNullOrEmpty(contactManDescTxt.Text)))
            {
                return false;
            }
            return true;
        }

        private bool CheckAndSave()
        {
            if (IsDataExist())
            {
                SaveType type =ExcelHelper.Instance.shouldSave(string.Format("קוד פרוייקט {0} או", projectCodetxtBox.Text) + " או פרוייקט {0}", projectNametxtBox.Text);
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
    }
}
