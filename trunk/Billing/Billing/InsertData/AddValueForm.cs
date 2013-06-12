using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Billing.DataObjects;

namespace Billing.InsertData
{
    public partial class AddValueForm : Form
    {
        public List<ValueItem> valueTypes = new List<ValueItem>();
        private int tblRow = 0;
        private int tblCol = 0;
        public string contractCode { get; set; }
        public Dictionary<int, List<TextBox>> valuesList = new Dictionary<int, List<TextBox>>();

        public AddValueForm()
        {
            InitializeComponent();
            valueComboBox.DataSource = ExcelHelper.Instance.ValueTypes.Columns[ColumnNames.VALUE_CODE].Table;
            valueComboBox.DisplayMember = ColumnNames.VALUE_TYPE;
            valueComboBox.Text = ExcelHelper.Instance.ValueTypes.Rows[valueComboBox.SelectedIndex][ColumnNames.VALUE_TYPE].ToString();            
        }

        public AddValueForm(string contractCode)
        {
            InitializeComponent();
            this.contractCode = contractCode;
            valueComboBox.DataSource = ExcelHelper.Instance.getValuesFromDB();//ValueTypes.Columns[ColumnNames.VALUE_CODE].Table;
            valueComboBox.DisplayMember = ColumnNames.VALUE_TYPE;
            valueComboBox.Text = ExcelHelper.Instance.ValueTypes.Rows[valueComboBox.SelectedIndex][ColumnNames.VALUE_TYPE].ToString();
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {                        
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
             
        }

        //private void SaveValues()
        //{
        //    foreach (KeyValuePair<int, List<TextBox>> list in valuesList)
        //    {
        //        this.valueTypes.Add(valueComboBox.Text);
        //        if (list.Value.Count == 2)
        //        {
        //            DataRow valueRow = ExcelHelper.Instance.ValueInBill.NewRow();
        //            valueRow[ColumnNames.PAYMENT] = list.Value[0].Text;
        //            valueRow[ColumnNames.QUANTITY] = list.Value[1].Text;
        //            valueRow[ColumnNames.VALUE_CODE] = list.Value[0].Name;
        //            valueRow[ColumnNames.CONTRACT_CODE_YARIV] = contractCode;
        //            valueRow[ColumnNames.BILL_NUMBER_YARIV] = string.Empty;
        //            ExcelHelper.Instance.SaveDataToExcel(valueRow, ExcelHelper.Instance.ValueInBill.TableName, SaveType.SaveNew);
        //        }
        //    }
        //}

        private void valueComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ValueItem item = new ValueItem(valueComboBox.Text, (valueComboBox.SelectedIndex + 1).ToString());
            CreateValues(int.Parse(ExcelHelper.Instance.getItemFromTable(ExcelHelper.Instance.ValueTypes,valueComboBox.SelectedValue.ToString(), ColumnNames.VALUE_TYPE, ColumnNames.VALUE_CODE)));
            valueTypes.Add(item);
        }

        private void CreateValues(int valueType)
        {
            Point size = new Point(60, 50);
            Point lblSize = new Point(100, 50);
            ValuesCollection.Visible = true;
            List<TextBox> textBoxes = new List<TextBox>();
            switch (valueType)
            {
                case 1:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Name = "1";
                        txt.Size = new Size(size);
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("תעריף שעתי");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "1";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "1";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("מספר שעות עבודה");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "1";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 2:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "2";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("תעריף חודשי");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "2";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "2";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("מספר חודשים");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "2";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 3:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "3";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("אחוז משכר טרחה");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "3";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "3";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("שכר הטרחה");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "3";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 4:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "4";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("סכום לתשלום");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "4";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "4";
                        text.Visible = false;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, null);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 5:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "5";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("אחוז מהקבלן");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "5";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("");
                        text.Size = new Size(size);
                        text.Name = "5";
                        ValuesCollection.Controls.Add(text, tblCol, tblRow);
                        tblCol++;
                        Label lbl1 = CreateLabel("סכום הקבלן");
                        lbl1.Size = new Size(lblSize);
                        lbl1.Name = "5";
                        ValuesCollection.Controls.Add(lbl1, tblCol, tblRow);
                        tblCol++;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, lbl1);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
                case 6:
                    {
                        TextBox txt = CreateTextBox("");
                        txt.Size = new Size(size);
                        txt.Name = "6";
                        ValuesCollection.Controls.Add(txt, tblCol, tblRow);
                        tblCol++;
                        Label lbl = CreateLabel("סכום החשבון");
                        lbl.Size = new Size(lblSize);
                        lbl.Name = "6";
                        ValuesCollection.Controls.Add(lbl, tblCol, tblRow);
                        tblCol++;
                        TextBox text = CreateTextBox("1");
                        text.Size = new Size(size);
                        text.Name = "6";
                        text.Visible = false;
                        textBoxes.Add(txt);
                        textBoxes.Add(text);
                        valuesList.Add(tblRow, textBoxes);
                        Button b = CreateDeleteBtn();
                        ValuesCollection.Controls.Add(b, tblCol, tblRow);
                        SetDeleteEventHandler(txt, text, b, tblRow, lbl, null);
                        tblCol = 0;
                        tblRow++;
                        break;
                    }
            }

            //valuelbl.Visible = false;
            //valueComboBox.Visible = false;
        }

        private static Button CreateDeleteBtn()
        {
            Button b = new Button();
            b.Text = "מחק";
            b.Size = new Size(50, 25);
            return b;
        }

        private static TextBox CreateTextBox(string text)
        {
            TextBox txt = new TextBox();
            txt.Text = text;
            txt.Click += (sender1, e1) =>
            {
                txt.Clear();
            };

            return txt;
        }

        private void clearText(object sender, Control e)
        {
            e.Text = "";
        }

        private Label CreateLabel(string p)
        {
            Label lbl = new Label();
            lbl.Text = p;
            return lbl;
        }

        private void SetDeleteEventHandler(TextBox txt, TextBox text, Button b, int row, Label lbl, Label lbl1)
        {
            b.Click += (sender1, e1) =>
            {
                ValuesCollection.Controls.Remove(b);
                ValuesCollection.Controls.Remove(txt);
                ValuesCollection.Controls.Remove(text);
                ValuesCollection.Controls.Remove(lbl);
                if (lbl1 != null)
                {
                    ValuesCollection.Controls.Remove(lbl1);
                }
                valuesList.Remove(row);
                if (ValuesCollection.Controls.Count == 0)
                {
                    ValuesCollection.Visible = false;
                }
            };
        }

    }
}
