﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billing
{
    public partial class ClientForm : Form
    {
        Dictionary<string, string> clientTypeDic = new Dictionary<string, string>();
        public ClientForm()
        {
            InitializeComponent();
            
            foreach (DataRow row in ExcelHelper.Instance.ClientTypes.Rows)
            {
                clientTypeDic.Add(row[1].ToString(), row[0].ToString());
            }
            ClientsDataGrid.DataSource = ExcelHelper.Instance.Clients;

            ClientTypeComboBox.DataSource = ExcelHelper.Instance.ClientTypes.Columns[ColumnNames.CLIENT_CODE].Table;
            ClientTypeComboBox.DisplayMember = ColumnNames.CLIENT_TYPE;
            ClientTypeComboBox.Text = ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_TYPE].ToString();
            clientCodeTxtBox.Text =ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_CODE,
                                                  ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString()
                                                  , ColumnNames.CLIENT_TYPE);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsAreFilled())
                {
                    CheckAndSave();
                    Close();
                }
                else
                {
                    MessageBox.Show("מלא את כל השדות בבקשה");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        private void CheckAndSave()
        {
            if (IsDataExist())
            {
                if (ExcelHelper.Instance.shouldSave("לקוח {0}", clientNameTxtBox.Text))
                {
                    SaveData();
                }
            }
            else
            {
                SaveData();
            }
        }
                      
    

        private bool CheckAllFieldsAreFilled()
        {
            if ((string.IsNullOrEmpty(clientNameTxtBox.Text)) || (string.IsNullOrEmpty(ClientAddressTxtBox.Text))
                || (string.IsNullOrEmpty(phoneTxtBox.Text)) || (string.IsNullOrEmpty(emailTxtBox.Text)))
            {
                return false;
            }
            return true;
        }

        private bool IsDataExist()
        {
            return ExcelHelper.Instance.CheckExistence(clientNameTxtBox.Text, clientTypeDic[ClientTypeComboBox.Text], ColumnNames.CLIENT_NAME, ColumnNames.CLIENT_TYPE, ExcelHelper.Instance.Clients);
        }

        private void btnSaveAndAddProj_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAllFieldsAreFilled())
                {
                    CheckAndSave();
                    this.Hide();
                    this.Close();
                    Form f = new ProjectForm(clientNameTxtBox.Text);
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("מלא את כל השדות בבקשה");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        private void ShowErrorMessage(Exception ex)
        {
            MessageBoxOptions options = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            string text = string.Format("הוספה נכשלה אנא ודא כי {0} אינו בשימוש או שסוג הנתונים שהוכנס תקין", ExcelHelper.Path);
            MessageBox.Show(this, text + "\n\n" + ex, "בעיה בשמירת לקוח", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
        }

        private void SaveData()
        {
            DataRow row = ExcelHelper.Instance.Clients.NewRow();
            row[ColumnNames.CLIENT_NAME] = clientNameTxtBox.Text;
            row[ColumnNames.ADRESS] = ClientAddressTxtBox.Text;
            row[ColumnNames.PHONE] = phoneTxtBox.Text;
            row[ColumnNames.EMAIL] = emailTxtBox.Text;
            row[ColumnNames.CLIENT_TYPE] = ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString();
            row[ColumnNames.CLIENT_CODE] = clientCodeTxtBox.Text;
            ExcelHelper.Instance.SaveDataToExcel(row, ExcelHelper.Instance.Clients.TableName);
            ExcelHelper.Instance.Clients.Rows.Add(row);
        }

        private void ClearAllFields()
        {
            ClientAddressTxtBox.Clear();
            clientNameTxtBox.Clear();            
            emailTxtBox.Clear();
            phoneTxtBox.Clear();
        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            clientCodeTxtBox.Text = ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_CODE,
                                                  ExcelHelper.Instance.ClientTypes.Rows[ClientTypeComboBox.SelectedIndex][ColumnNames.CLIENT_CODE].ToString()
                                                  , ColumnNames.CLIENT_TYPE);
        }

       
    }
}