namespace Billing.InsertData
{
    partial class BillUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contractused = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.totalBillsIncludingTxtBox = new System.Windows.Forms.TextBox();
            this.totalBillsIncludingLbl = new System.Windows.Forms.Label();
            this.hebDateTxtBox = new System.Windows.Forms.TextBox();
            this.hebDateLbl = new System.Windows.Forms.Label();
            this.CheckTotalAmount = new System.Windows.Forms.Button();
            this.totalToPayTxtBox = new System.Windows.Forms.TextBox();
            this.billAmountlbl = new System.Windows.Forms.Label();
            this.ValuesCollection = new System.Windows.Forms.TableLayoutPanel();
            this.valueComboBox = new System.Windows.Forms.ComboBox();
            this.valuelbl = new System.Windows.Forms.Label();
            this.addValue = new System.Windows.Forms.Button();
            this.totalBillsTxtBox = new System.Windows.Forms.TextBox();
            this.contractPartlbl = new System.Windows.Forms.Label();
            this.contractParttxtBox = new System.Windows.Forms.TextBox();
            this.billDateBox = new System.Windows.Forms.DateTimePicker();
            this.billDatelbl = new System.Windows.Forms.Label();
            this.totalBillsLbl = new System.Windows.Forms.Label();
            this.totalWithMaamTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lastBillTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.ClearFieldsBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.contractCodeComboBox = new System.Windows.Forms.ComboBox();
            this.billStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maamTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clientNameComboBox = new System.Windows.Forms.ComboBox();
            this.clientNamelbl = new System.Windows.Forms.Label();
            this.billSequenceInContractTxtBox = new System.Windows.Forms.TextBox();
            this.clientContractCodelbl = new System.Windows.Forms.Label();
            this.billNumberTxtBox = new System.Windows.Forms.TextBox();
            this.yarivContractCodeLbl = new System.Windows.Forms.Label();
            this.projectCodeLbl = new System.Windows.Forms.Label();
            this.errorsLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.createBillBtn = new System.Windows.Forms.Button();
            this.totalHrsIncludingBill = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.totalHrsNotIncludingBill = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // contractused
            // 
            this.contractused.Location = new System.Drawing.Point(307, 354);
            this.contractused.Name = "contractused";
            this.contractused.Size = new System.Drawing.Size(75, 20);
            this.contractused.TabIndex = 153;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 13);
            this.label6.TabIndex = 152;
            this.label6.Text = "ניצול חוזה כולל חשבון זה (ש\"ח)";
            // 
            // totalBillsIncludingTxtBox
            // 
            this.totalBillsIncludingTxtBox.Location = new System.Drawing.Point(86, 275);
            this.totalBillsIncludingTxtBox.Name = "totalBillsIncludingTxtBox";
            this.totalBillsIncludingTxtBox.Size = new System.Drawing.Size(245, 20);
            this.totalBillsIncludingTxtBox.TabIndex = 151;
            // 
            // totalBillsIncludingLbl
            // 
            this.totalBillsIncludingLbl.AutoSize = true;
            this.totalBillsIncludingLbl.Location = new System.Drawing.Point(366, 278);
            this.totalBillsIncludingLbl.Name = "totalBillsIncludingLbl";
            this.totalBillsIncludingLbl.Size = new System.Drawing.Size(216, 13);
            this.totalBillsIncludingLbl.TabIndex = 150;
            this.totalBillsIncludingLbl.Text = "סכום החשבונות החלקיים כולל חשבון זה";
            // 
            // hebDateTxtBox
            // 
            this.hebDateTxtBox.Location = new System.Drawing.Point(86, 118);
            this.hebDateTxtBox.Name = "hebDateTxtBox";
            this.hebDateTxtBox.ReadOnly = true;
            this.hebDateTxtBox.Size = new System.Drawing.Size(296, 20);
            this.hebDateTxtBox.TabIndex = 148;
            // 
            // hebDateLbl
            // 
            this.hebDateLbl.AutoSize = true;
            this.hebDateLbl.Location = new System.Drawing.Point(517, 121);
            this.hebDateLbl.Name = "hebDateLbl";
            this.hebDateLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.hebDateLbl.Size = new System.Drawing.Size(68, 13);
            this.hebDateLbl.TabIndex = 149;
            this.hebDateLbl.Text = "תאריך עברי";
            // 
            // CheckTotalAmount
            // 
            this.CheckTotalAmount.Location = new System.Drawing.Point(420, 558);
            this.CheckTotalAmount.Name = "CheckTotalAmount";
            this.CheckTotalAmount.Size = new System.Drawing.Size(83, 23);
            this.CheckTotalAmount.TabIndex = 147;
            this.CheckTotalAmount.Text = "חשב סכום";
            this.CheckTotalAmount.UseVisualStyleBackColor = true;
            this.CheckTotalAmount.Click += new System.EventHandler(this.CheckTotalAmount_Click);
            // 
            // totalToPayTxtBox
            // 
            this.totalToPayTxtBox.Enabled = false;
            this.totalToPayTxtBox.Location = new System.Drawing.Point(86, 560);
            this.totalToPayTxtBox.Name = "totalToPayTxtBox";
            this.totalToPayTxtBox.ReadOnly = true;
            this.totalToPayTxtBox.Size = new System.Drawing.Size(296, 20);
            this.totalToPayTxtBox.TabIndex = 145;
            this.totalToPayTxtBox.Text = "0";
            // 
            // billAmountlbl
            // 
            this.billAmountlbl.AutoSize = true;
            this.billAmountlbl.Location = new System.Drawing.Point(509, 563);
            this.billAmountlbl.Name = "billAmountlbl";
            this.billAmountlbl.Size = new System.Drawing.Size(76, 13);
            this.billAmountlbl.TabIndex = 146;
            this.billAmountlbl.Text = "סכום החשבון";
            // 
            // ValuesCollection
            // 
            this.ValuesCollection.AutoScroll = true;
            this.ValuesCollection.CausesValidation = false;
            this.ValuesCollection.ColumnCount = 5;
            this.ValuesCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesCollection.Location = new System.Drawing.Point(86, 416);
            this.ValuesCollection.Name = "ValuesCollection";
            this.ValuesCollection.RowCount = 2;
            this.ValuesCollection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesCollection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesCollection.Size = new System.Drawing.Size(496, 136);
            this.ValuesCollection.TabIndex = 144;
            // 
            // valueComboBox
            // 
            this.valueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.valueComboBox.FormattingEnabled = true;
            this.valueComboBox.Location = new System.Drawing.Point(86, 380);
            this.valueComboBox.Name = "valueComboBox";
            this.valueComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.valueComboBox.Size = new System.Drawing.Size(296, 21);
            this.valueComboBox.TabIndex = 142;
            this.valueComboBox.Visible = false;
            this.valueComboBox.SelectionChangeCommitted += new System.EventHandler(this.valueComboBox_SelectionChangeCommitted);
            // 
            // valuelbl
            // 
            this.valuelbl.AutoSize = true;
            this.valuelbl.Location = new System.Drawing.Point(388, 383);
            this.valuelbl.Name = "valuelbl";
            this.valuelbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.valuelbl.Size = new System.Drawing.Size(86, 13);
            this.valuelbl.TabIndex = 143;
            this.valuelbl.Text = "בחר סוג תמורה:";
            this.valuelbl.Visible = false;
            // 
            // addValue
            // 
            this.addValue.Location = new System.Drawing.Point(502, 378);
            this.addValue.Name = "addValue";
            this.addValue.Size = new System.Drawing.Size(83, 23);
            this.addValue.TabIndex = 141;
            this.addValue.Text = "הוסף תמורה";
            this.addValue.UseVisualStyleBackColor = true;
            this.addValue.Click += new System.EventHandler(this.addValue_Click);
            // 
            // totalBillsTxtBox
            // 
            this.totalBillsTxtBox.Location = new System.Drawing.Point(86, 249);
            this.totalBillsTxtBox.Name = "totalBillsTxtBox";
            this.totalBillsTxtBox.Size = new System.Drawing.Size(296, 20);
            this.totalBillsTxtBox.TabIndex = 140;
            // 
            // contractPartlbl
            // 
            this.contractPartlbl.AutoSize = true;
            this.contractPartlbl.Location = new System.Drawing.Point(391, 331);
            this.contractPartlbl.Name = "contractPartlbl";
            this.contractPartlbl.Size = new System.Drawing.Size(191, 13);
            this.contractPartlbl.TabIndex = 139;
            this.contractPartlbl.Text = "ניצול חוזה לא כולל חשבון זה (ש\"ח)";
            // 
            // contractParttxtBox
            // 
            this.contractParttxtBox.Location = new System.Drawing.Point(307, 328);
            this.contractParttxtBox.Name = "contractParttxtBox";
            this.contractParttxtBox.Size = new System.Drawing.Size(75, 20);
            this.contractParttxtBox.TabIndex = 138;
            // 
            // billDateBox
            // 
            this.billDateBox.CustomFormat = "";
            this.billDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.billDateBox.Location = new System.Drawing.Point(86, 92);
            this.billDateBox.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.billDateBox.Name = "billDateBox";
            this.billDateBox.ShowUpDown = true;
            this.billDateBox.Size = new System.Drawing.Size(296, 20);
            this.billDateBox.TabIndex = 137;
            this.billDateBox.Value = new System.DateTime(2012, 11, 11, 0, 0, 0, 0);
            this.billDateBox.ValueChanged += new System.EventHandler(this.billDateBox_ValueChanged);
            // 
            // billDatelbl
            // 
            this.billDatelbl.AutoSize = true;
            this.billDatelbl.Location = new System.Drawing.Point(502, 98);
            this.billDatelbl.Name = "billDatelbl";
            this.billDatelbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.billDatelbl.Size = new System.Drawing.Size(83, 13);
            this.billDatelbl.TabIndex = 136;
            this.billDatelbl.Text = "תאריך החשבון";
            // 
            // totalBillsLbl
            // 
            this.totalBillsLbl.AutoSize = true;
            this.totalBillsLbl.Location = new System.Drawing.Point(446, 252);
            this.totalBillsLbl.Name = "totalBillsLbl";
            this.totalBillsLbl.Size = new System.Drawing.Size(136, 13);
            this.totalBillsLbl.TabIndex = 135;
            this.totalBillsLbl.Text = "סכום החשבונות החלקיים";
            // 
            // totalWithMaamTextBox
            // 
            this.totalWithMaamTextBox.Location = new System.Drawing.Point(86, 586);
            this.totalWithMaamTextBox.Name = "totalWithMaamTextBox";
            this.totalWithMaamTextBox.ReadOnly = true;
            this.totalWithMaamTextBox.Size = new System.Drawing.Size(296, 20);
            this.totalWithMaamTextBox.TabIndex = 122;
            this.totalWithMaamTextBox.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(448, 589);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 134;
            this.label5.Text = "סכום החשבון כולל מע\"מ";
            // 
            // lastBillTxtBox
            // 
            this.lastBillTxtBox.Enabled = false;
            this.lastBillTxtBox.Location = new System.Drawing.Point(86, 197);
            this.lastBillTxtBox.Name = "lastBillTxtBox";
            this.lastBillTxtBox.Size = new System.Drawing.Size(296, 20);
            this.lastBillTxtBox.TabIndex = 120;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 133;
            this.label4.Text = "חשבון קודם";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(226, 612);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 126;
            this.cancelBtn.Text = "ביטול";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ClearFieldsBtn
            // 
            this.ClearFieldsBtn.Location = new System.Drawing.Point(307, 612);
            this.ClearFieldsBtn.Name = "ClearFieldsBtn";
            this.ClearFieldsBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearFieldsBtn.TabIndex = 125;
            this.ClearFieldsBtn.Text = "נקה";
            this.ClearFieldsBtn.UseVisualStyleBackColor = true;
            this.ClearFieldsBtn.Click += new System.EventHandler(this.ClearFieldsBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(388, 612);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 124;
            this.saveBtn.Text = "שמור";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // contractCodeComboBox
            // 
            this.contractCodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contractCodeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.contractCodeComboBox.FormattingEnabled = true;
            this.contractCodeComboBox.Location = new System.Drawing.Point(86, 65);
            this.contractCodeComboBox.Name = "contractCodeComboBox";
            this.contractCodeComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contractCodeComboBox.Size = new System.Drawing.Size(296, 21);
            this.contractCodeComboBox.TabIndex = 117;
            this.contractCodeComboBox.SelectedIndexChanged += new System.EventHandler(this.contractCodeComboBox_SelectedIndexChanged);
            // 
            // billStatusComboBox
            // 
            this.billStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.billStatusComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.billStatusComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.billStatusComboBox.FormattingEnabled = true;
            this.billStatusComboBox.Location = new System.Drawing.Point(86, 301);
            this.billStatusComboBox.Name = "billStatusComboBox";
            this.billStatusComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.billStatusComboBox.Size = new System.Drawing.Size(296, 21);
            this.billStatusComboBox.TabIndex = 123;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 132;
            this.label3.Text = "סטטוס";
            // 
            // maamTxtBox
            // 
            this.maamTxtBox.Location = new System.Drawing.Point(86, 223);
            this.maamTxtBox.Name = "maamTxtBox";
            this.maamTxtBox.Size = new System.Drawing.Size(296, 20);
            this.maamTxtBox.TabIndex = 121;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 131;
            this.label2.Text = "המע\"מ";
            // 
            // clientNameComboBox
            // 
            this.clientNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientNameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clientNameComboBox.FormattingEnabled = true;
            this.clientNameComboBox.Location = new System.Drawing.Point(86, 38);
            this.clientNameComboBox.Name = "clientNameComboBox";
            this.clientNameComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientNameComboBox.Size = new System.Drawing.Size(296, 21);
            this.clientNameComboBox.TabIndex = 116;
            this.clientNameComboBox.SelectedIndexChanged += new System.EventHandler(this.clientNameComboBox_SelectedIndexChanged);
            // 
            // clientNamelbl
            // 
            this.clientNamelbl.AutoSize = true;
            this.clientNamelbl.Location = new System.Drawing.Point(523, 41);
            this.clientNamelbl.Name = "clientNamelbl";
            this.clientNamelbl.Size = new System.Drawing.Size(59, 13);
            this.clientNamelbl.TabIndex = 130;
            this.clientNamelbl.Text = "שם הלקוח";
            // 
            // billSequenceInContractTxtBox
            // 
            this.billSequenceInContractTxtBox.Location = new System.Drawing.Point(86, 171);
            this.billSequenceInContractTxtBox.Name = "billSequenceInContractTxtBox";
            this.billSequenceInContractTxtBox.Size = new System.Drawing.Size(296, 20);
            this.billSequenceInContractTxtBox.TabIndex = 119;
            this.billSequenceInContractTxtBox.Leave += new System.EventHandler(this.billSequenceInContractTxtBox_Leave);
            // 
            // clientContractCodelbl
            // 
            this.clientContractCodelbl.AutoSize = true;
            this.clientContractCodelbl.Location = new System.Drawing.Point(452, 174);
            this.clientContractCodelbl.Name = "clientContractCodelbl";
            this.clientContractCodelbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientContractCodelbl.Size = new System.Drawing.Size(133, 13);
            this.clientContractCodelbl.TabIndex = 129;
            this.clientContractCodelbl.Text = "מספר חשבון חלקי בחוזה";
            // 
            // billNumberTxtBox
            // 
            this.billNumberTxtBox.Enabled = false;
            this.billNumberTxtBox.Location = new System.Drawing.Point(86, 145);
            this.billNumberTxtBox.Name = "billNumberTxtBox";
            this.billNumberTxtBox.Size = new System.Drawing.Size(296, 20);
            this.billNumberTxtBox.TabIndex = 118;
            this.billNumberTxtBox.TextChanged += new System.EventHandler(this.billNumberTxtBox_TextChanged);
            // 
            // yarivContractCodeLbl
            // 
            this.yarivContractCodeLbl.AutoSize = true;
            this.yarivContractCodeLbl.Location = new System.Drawing.Point(483, 148);
            this.yarivContractCodeLbl.Name = "yarivContractCodeLbl";
            this.yarivContractCodeLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.yarivContractCodeLbl.Size = new System.Drawing.Size(102, 13);
            this.yarivContractCodeLbl.TabIndex = 128;
            this.yarivContractCodeLbl.Text = "מספר חשבון (יריב)";
            // 
            // projectCodeLbl
            // 
            this.projectCodeLbl.AutoSize = true;
            this.projectCodeLbl.Location = new System.Drawing.Point(529, 68);
            this.projectCodeLbl.Name = "projectCodeLbl";
            this.projectCodeLbl.Size = new System.Drawing.Size(53, 13);
            this.projectCodeLbl.TabIndex = 127;
            this.projectCodeLbl.Text = "קוד חוזה";
            // 
            // errorsLabel
            // 
            this.errorsLabel.AutoSize = true;
            this.errorsLabel.Location = new System.Drawing.Point(250, 638);
            this.errorsLabel.Name = "errorsLabel";
            this.errorsLabel.Padding = new System.Windows.Forms.Padding(100, 10, 100, 10);
            this.errorsLabel.Size = new System.Drawing.Size(200, 33);
            this.errorsLabel.TabIndex = 154;
            this.errorsLabel.Visible = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(298, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(40, 13);
            this.titleLabel.TabIndex = 155;
            this.titleLabel.Text = "חשבון";
            // 
            // createBillBtn
            // 
            this.createBillBtn.Location = new System.Drawing.Point(3, 638);
            this.createBillBtn.Name = "createBillBtn";
            this.createBillBtn.Size = new System.Drawing.Size(114, 23);
            this.createBillBtn.TabIndex = 156;
            this.createBillBtn.Text = "צור מסמך חשבון";
            this.createBillBtn.UseVisualStyleBackColor = true;
            this.createBillBtn.Click += new System.EventHandler(this.createBillBtn_Click);
            // 
            // totalHrsIncludingBill
            // 
            this.totalHrsIncludingBill.Location = new System.Drawing.Point(26, 354);
            this.totalHrsIncludingBill.Name = "totalHrsIncludingBill";
            this.totalHrsIncludingBill.Size = new System.Drawing.Size(75, 20);
            this.totalHrsIncludingBill.TabIndex = 160;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 159;
            this.label1.Text = "ניצול חוזה כולל חשבון זה (שעות)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 13);
            this.label7.TabIndex = 158;
            this.label7.Text = "ניצול חוזה לא כולל חשבון זה (שעות)";
            // 
            // totalHrsNotIncludingBill
            // 
            this.totalHrsNotIncludingBill.Location = new System.Drawing.Point(26, 328);
            this.totalHrsNotIncludingBill.Name = "totalHrsNotIncludingBill";
            this.totalHrsNotIncludingBill.Size = new System.Drawing.Size(75, 20);
            this.totalHrsNotIncludingBill.TabIndex = 157;
            // 
            // BillUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.totalHrsIncludingBill);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.totalHrsNotIncludingBill);
            this.Controls.Add(this.createBillBtn);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.errorsLabel);
            this.Controls.Add(this.contractused);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.totalBillsIncludingTxtBox);
            this.Controls.Add(this.totalBillsIncludingLbl);
            this.Controls.Add(this.hebDateTxtBox);
            this.Controls.Add(this.hebDateLbl);
            this.Controls.Add(this.CheckTotalAmount);
            this.Controls.Add(this.totalToPayTxtBox);
            this.Controls.Add(this.billAmountlbl);
            this.Controls.Add(this.ValuesCollection);
            this.Controls.Add(this.valueComboBox);
            this.Controls.Add(this.valuelbl);
            this.Controls.Add(this.addValue);
            this.Controls.Add(this.totalBillsTxtBox);
            this.Controls.Add(this.contractPartlbl);
            this.Controls.Add(this.contractParttxtBox);
            this.Controls.Add(this.billDateBox);
            this.Controls.Add(this.billDatelbl);
            this.Controls.Add(this.totalBillsLbl);
            this.Controls.Add(this.totalWithMaamTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lastBillTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.ClearFieldsBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.contractCodeComboBox);
            this.Controls.Add(this.billStatusComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maamTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clientNameComboBox);
            this.Controls.Add(this.clientNamelbl);
            this.Controls.Add(this.billSequenceInContractTxtBox);
            this.Controls.Add(this.clientContractCodelbl);
            this.Controls.Add(this.billNumberTxtBox);
            this.Controls.Add(this.yarivContractCodeLbl);
            this.Controls.Add(this.projectCodeLbl);
            this.Name = "BillUserControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(588, 671);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contractused;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox totalBillsIncludingTxtBox;
        private System.Windows.Forms.Label totalBillsIncludingLbl;
        private System.Windows.Forms.TextBox hebDateTxtBox;
        private System.Windows.Forms.Label hebDateLbl;
        private System.Windows.Forms.Button CheckTotalAmount;
        private System.Windows.Forms.TextBox totalToPayTxtBox;
        private System.Windows.Forms.Label billAmountlbl;
        private System.Windows.Forms.TableLayoutPanel ValuesCollection;
        private System.Windows.Forms.ComboBox valueComboBox;
        private System.Windows.Forms.Label valuelbl;
        private System.Windows.Forms.Button addValue;
        private System.Windows.Forms.TextBox totalBillsTxtBox;
        private System.Windows.Forms.Label contractPartlbl;
        private System.Windows.Forms.TextBox contractParttxtBox;
        private System.Windows.Forms.DateTimePicker billDateBox;
        private System.Windows.Forms.Label billDatelbl;
        private System.Windows.Forms.Label totalBillsLbl;
        private System.Windows.Forms.TextBox totalWithMaamTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lastBillTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button ClearFieldsBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox contractCodeComboBox;
        private System.Windows.Forms.ComboBox billStatusComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox maamTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox clientNameComboBox;
        private System.Windows.Forms.Label clientNamelbl;
        private System.Windows.Forms.TextBox billSequenceInContractTxtBox;
        private System.Windows.Forms.Label clientContractCodelbl;
        private System.Windows.Forms.TextBox billNumberTxtBox;
        private System.Windows.Forms.Label yarivContractCodeLbl;
        private System.Windows.Forms.Label projectCodeLbl;
        private System.Windows.Forms.Label errorsLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button createBillBtn;
        private System.Windows.Forms.TextBox totalHrsIncludingBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox totalHrsNotIncludingBill;
    }
}
