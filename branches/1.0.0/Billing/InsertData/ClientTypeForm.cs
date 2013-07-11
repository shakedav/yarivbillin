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
    public partial class ClientTypeForm : Form
    {
        public ClientTypeForm()
        {
            InitializeComponent();
            string maxClientType = ExcelHelper.Instance.GetMaxItemOfColumn(ExcelHelper.Instance.ClientTypes, ColumnNames.CLIENT_CODE);
            ClientCodeTxtBox.Text = (int.Parse(maxClientType) + 100).ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            CheckAndSave();
            cancelBtn.Text = "סגור";
        }        

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool IsDataExist()
        {
            return ExcelHelper.Instance.CheckExistenceOfSingleValue(clientTypetxtBox.Text, ColumnNames.CLIENT_TYPE, ExcelHelper.Instance.ClientTypes);
        }

        private void CheckAndSave()
        {
            if (!IsDataExist())
            {
                SaveData();
            }
            else
            {
                string message = string.Format("סוג לקוח {0} כבר קיים, לא ניתן לשמור", ClientCodeTxtBox.Text);
                MessageBox.Show(message);
            }
        }

        private void SaveData()
        {
            DataRow row = ExcelHelper.Instance.ClientTypes.NewRow();

            row[ColumnNames.CLIENT_CODE] = ClientCodeTxtBox.Text;
            row[ColumnNames.CLIENT_TYPE] = clientTypetxtBox.Text;
            ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.ClientTypes.TableName, SaveType.SaveNew);
            ExcelHelper.Instance.ClientTypes.Rows.Add(row);
        }
    }
}
