using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Billing.DisplayData;
using Billing.Documents;

namespace Billing
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();            
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.ShowDialog();            
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm();
            projectForm.ShowDialog();
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            ContractForm contractForm = new ContractForm();
            contractForm.ShowDialog();
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            BillForm billForm = new BillForm();
            billForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new DisplayClientDataForm();
            f.ShowDialog();
        }

        private void createBillDocument_Click(object sender, EventArgs e)
        {
            Form Doc = new DocTemplate();
            Doc.ShowDialog();
        }
    }
}
