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
    public enum SaveType 
    {
        NA = 0,
        SaveNew = 1,
        Update = 2
    }

    public partial class DataExists : Form
    {
        public bool ShouldSave { get; set; }
        public SaveType typeOfSave = SaveType.NA;

        public DataExists(string message)
        {
            InitializeComponent();
            errorMessage.Text = string.Format("{0} כבר קיים, האם ברצונך לשמור?", message);            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ShouldSave = true;
            DialogResult = DialogResult.OK;
            typeOfSave = SaveType.SaveNew;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShouldSave = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            ShouldSave = true;
            DialogResult = DialogResult.OK;
            typeOfSave = SaveType.Update;
            this.Close();
        }

       
    }
}
