using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billing
{
    public partial class ProjectForm : Form
    {
        ExcelHelper projectsHelper;

        public ProjectForm(ExcelHelper helper)
        {
            InitializeComponent();
            projectsHelper = helper;
            projectCodetxtBox.Text = (projectsHelper.Projects.Rows.Count + 1).ToString();
            clientNameComboBox.DataSource = projectsHelper.Clients.Columns["קוד לקוח"].Table;
            clientNameComboBox.DisplayMember = "שם לקוח";
            clientNameComboBox.Text = projectsHelper.Clients.Rows[clientNameComboBox.SelectedIndex]["שם לקוח"].ToString();
        }

        private void ClearAllFields(object sender, EventArgs e)
        {
            projectNametxtBox.Clear();
            contactManTxtBox.Clear();
            projectDescriptiontxtBox.Clear();
            projectCodeInviterTxtBox.Clear();
            projectNameInviterTxtBox.Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DataRow row = projectsHelper.Projects.NewRow();
            try
            {
                row["קוד פרוייקט"] = projectCodetxtBox.Text;
                row["שם הפרוייקט"] = projectNametxtBox.Text;
                row["איש קשר בפרוייקט"] = contactManTxtBox.Text;
                row["שם פרוייקט אצל המזמין"] = projectNameInviterTxtBox.Text;
                row["קוד פרוייקט אצל המזמין"] = projectCodeInviterTxtBox.Text;
                row["תיאור הפרוייקט"] = projectDescriptiontxtBox.Text;
                row["קוד הלקוח"] = projectsHelper.getItemFromTable(projectsHelper.Clients, clientNameComboBox.Text, "שם לקוח", "קוד לקוח");
                projectsHelper.SaveDataToExcel(row, projectsHelper.Projects.TableName);
                projectsHelper.Projects.Rows.Add(row);
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxOptions options = MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
                string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש", ExcelHelper.Path);
                MessageBox.Show(this, text, "בעיה בשמירת פרוייקט", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
            }
        }

        private void clientNamecomboBox_Click(object sender, EventArgs e)
        {
            clientNameComboBox.Text = projectsHelper.Clients.Rows[clientNameComboBox.SelectedIndex]["שם לקוח"].ToString();
            clientNameComboBox.Refresh();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
