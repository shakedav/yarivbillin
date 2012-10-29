using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billing.DisplayData
{
    public partial class DisplayProjectDetails : Form
    {
        public DisplayProjectDetails()
        {
            OnLoad();            
            projectCodeComboBox.DataSource = ExcelHelper.Instance.Projects.Columns["קוד פרוייקט"].Table;
            projectCodeComboBox.DisplayMember = "קוד הפרוייקט";
            projectCodeComboBox.ValueMember = "קוד פרוייקט";
            projectCodeComboBox.Text = ExcelHelper.Instance.Projects.Rows[0]["קוד פרוייקט"].ToString();
            GetProjectData();
        }

        private void OnLoad()
        {
            InitializeComponent();            
        }

        public DisplayProjectDetails(string clientCode, string clientName)
        {
            OnLoad();
            clientNameTxtBox.Enabled = false;
            projectCodeComboBox.DataSource = ExcelHelper.Instance.GetItemsByFilter(ExcelHelper.Instance.Projects, "קוד הלקוח", clientCode, "קוד פרוייקט");

        }

        private void projectCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProjectData();
        }

        private void GetProjectData()
        {
            Dictionary<string, string> ProjectDataList = ExcelHelper.Instance.GetRowItemsByFilter(ExcelHelper.Instance.Projects, "קוד פרוייקט",
                                                           ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Projects, projectCodeComboBox.Text, "קוד פרוייקט", "קוד פרוייקט"));
            if (ProjectDataList.Count != 0)
            {
                clientNameTxtBox.Text = ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.Clients, ProjectDataList["קוד הלקוח"], "קוד לקוח", "שם לקוח");
                projectCodeComboBox.Text = ProjectDataList["קוד פרוייקט"];
                projectNametxtBox.Text = ProjectDataList["שם הפרוייקט"];
                contactManTxtBox.Text = ProjectDataList["איש קשר בפרוייקט"];
                projectNameInviterTxtBox.Text = ProjectDataList["שם פרוייקט אצל המזמין"];
                projectCodeInviterTxtBox.Text = ProjectDataList["קוד פרוייקט אצל המזמין"];
                projectDescriptiontxtBox.Text = ProjectDataList["תיאור הפרוייקט"];
            }
        }
    }
}
