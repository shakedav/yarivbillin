using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Billing.DataObjects;
using System.Text.RegularExpressions;

namespace Billing.InsertData
{
    public partial class ProjectUserControl : UserControl
    {
        Project project  = new Project();
        Client client;
        Client oldClient;
        bool isNew = true;
        int oldProjectCode;

        public ProjectUserControl()
        {
            client = new Client();
            Onload();            
        }

        private void Onload()
        {
            InitializeComponent();
            project.ProjectCode = ExcelHelper.Instance.GetMaxItemOfColumn(ExcelHelper.Instance.Projects, ColumnNames.PROJECT_CODE) + 1;
            clientNameComboBox.DataSource = ExcelHelper.Instance.Clients.Columns[ColumnNames.CLIENT_CODE].Table;
            clientNameComboBox.DisplayMember = ColumnNames.CLIENT_NAME;
            clientNameComboBox.Text = ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex][ColumnNames.CLIENT_NAME].ToString();
            projectCodetxtBox.Text = project.ProjectCode.ToString();
            project.ClientCode = Convert.ToInt32(ExcelHelper.Instance.Clients.Rows[clientNameComboBox.SelectedIndex][ColumnNames.CLIENT_CODE]);
        }

        private void SetTextBoxesText()
        {
            projectCodetxtBox.Text = project.ProjectCode.ToString();
            projectNametxtBox.Text = project.ProjectName;
            contactManTxtBox.Text = project.ContactMan;
            contactManGendreCombo.Text = project.ContactManGendre;
            contactManGendreCombo.SelectedIndex = contactManGendreCombo.FindStringExact(project.ContactManGendre);
            contactManDescTxt.Text = project.ContactManDescription;
            contactManPhoneTxtBox.Text = project.ContactManPhone;
            contactManEmailTxtBox.Text = project.ContactManMail;
            projectCodeInviterTxtBox.Text = project.InviterProjectCode.ToString();
            projectNameInviterTxtBox.Text = project.InviterProjectName;
            projectDescriptiontxtBox.Text = project.ProjectDescription;
        }      

        public ProjectUserControl(string selectedProject, Client selectedClient)
        {
            oldClient = (Client)selectedClient.Clone();
            Onload();            
            if (!string.IsNullOrEmpty(selectedProject))
            {
                project = ExcelHelper.Instance.GetProjectByIdentifier(selectedProject, ColumnNames.PROJECT_CODE);
                isNew = false;
            }
            client = ExcelHelper.Instance.GetClientByIdentifier(selectedClient.ClientCode.ToString(), ColumnNames.CLIENT_CODE);
            clientNameComboBox.SelectedIndex = clientNameComboBox.FindStringExact(client.ClientName);
            clientNameComboBox.Enabled = false;
            SetTextBoxesText();
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
            projectCodetxtBox.Text = (ExcelHelper.Instance.GetMaxItemOfColumn(ExcelHelper.Instance.Projects, ColumnNames.PROJECT_CODE) + 1).ToString();
            project = new Project(ExcelHelper.Instance.GetMaxItemOfColumn(ExcelHelper.Instance.Projects, ColumnNames.PROJECT_CODE) + 1,0);
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

        private bool CheckAndSave()
        {
            UpdateProject();
            //Check existence by project Code and Client Code and if exists --> update the client
            if (ExcelHelper.Instance.CheckExistence(project.ProjectCode.ToString(), project.ClientCode.ToString(),
                ColumnNames.PROJECT_CODE, ColumnNames.CLIENT_CODE, ExcelHelper.Instance.Projects))
            {
                SaveType type = SaveType.Update;
                SaveData(type);
                return true;
            }
            //Check existence by project Name and Project Client Code and ask wwhether to update or save new
            if (IsDataExist())
            {
                SaveType type = ExcelHelper.Instance.shouldSave(string.Format("קוד פרוייקט {0} או", projectCodetxtBox.Text) + " או פרוייקט {0}", projectNametxtBox.Text);
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

        private bool IsDataExist()
        {
            return (ExcelHelper.Instance.CheckExistence(project.ProjectName.ToString(), project.ClientCode.ToString(),
                ColumnNames.PROJECT_NAME, ColumnNames.CLIENT_CODE, ExcelHelper.Instance.Projects));        
        }

        private void SaveData(SaveType saveType)
        {
            ExcelHelper.Instance.SaveProject(project, saveType, oldProjectCode);         
        }

        private void ShowErrorMessage(Exception ex)
        {
            MessageBoxOptions options = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", string.Format(@"{0}", Constants.Instance.DB));
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
                        ContractUserControl f = new ContractUserControl(project.ClientCode.ToString(), project.ProjectCode.ToString());
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
        
        private void UpdateProject()
        {
            if (oldProjectCode == 0)
                oldProjectCode = project.ProjectCode;
        
            project.ProjectCode = Convert.ToInt32(projectCodetxtBox.Text);
            project.ProjectName = projectNametxtBox.Text;
            project.ContactMan= contactManTxtBox.Text;

            Regex myRegularExpression = new
                            Regex(@"^\d+$");
            if (!myRegularExpression.IsMatch(projectCodeInviterTxtBox.Text))
            {
                throw new Exception("הכנס ספרות בלבד");
            }           
            project.InviterProjectName= projectNameInviterTxtBox.Text;           
            project.InviterProjectCode = Convert.ToInt32(projectCodeInviterTxtBox.Text);
            project.ProjectDescription = projectDescriptiontxtBox.Text;
            project.ClientCode = Convert.ToInt32(ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, clientNameComboBox.Text, ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_CODE));
            project.ContactManDescription = contactManDescTxt.Text;
            project.ContactManPhone = contactManPhoneTxtBox.Text;
            project.ContactManMail = contactManEmailTxtBox.Text;
            project.ContactManGendre = contactManGendreCombo.Text;
        }
    }
}
