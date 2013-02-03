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
    public partial class BaseDataForm : Form
    {
        public MainForm Parent { get; set; }

        public BaseDataForm()
        {
            InitializeComponent();
        }
    }
}
