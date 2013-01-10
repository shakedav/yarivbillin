using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billing.InsertData
{
    public partial class AddValueForm : Form
    {
        public string valueType {get;set;}
        public string valueIndex { get; set; }

        public AddValueForm()
        {
            InitializeComponent();
            valueComboBox.DataSource = ExcelHelper.Instance.ValueTypes.Columns[ColumnNames.VALUE_CODE].Table;
            valueComboBox.DisplayMember = ColumnNames.VALUE_TYPE;
            valueComboBox.Text = ExcelHelper.Instance.ValueTypes.Rows[valueComboBox.SelectedIndex][ColumnNames.VALUE_TYPE].ToString();            
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            this.valueType = valueComboBox.Text;
            this.valueIndex = (valueComboBox.SelectedIndex + 1).ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
             
        }
    }
}
