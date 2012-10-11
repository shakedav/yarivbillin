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
    public partial class DataExists : Form
    {
        public bool ShouldSave { get; set; }

        public DataExists(string message)
        {
            InitializeComponent();
            errorMessage.Text = string.Format("{0} כבר קיים, האם ברצונך לשמור {0} נוסף?", message);            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ShouldSave = true;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShouldSave = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }

       
    }
}
