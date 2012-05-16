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
    public partial class Main : Form
    {
        ExcelHelper helper = new ExcelHelper();

        public Main()
        {
            InitializeComponent();            
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm(helper);
            clientForm.ShowDialog();
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm(helper);
            projectForm.ShowDialog();
        }
    }
}
