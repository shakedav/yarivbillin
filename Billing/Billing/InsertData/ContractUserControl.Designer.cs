namespace Billing.InsertData
{
    partial class ContractUserControl
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
            this.valueListBox = new System.Windows.Forms.ListBox();
            this.addValue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.valueWithMaamTxtBox = new System.Windows.Forms.TextBox();
            this.valueWithMaam = new System.Windows.Forms.Label();
            this.contractTypelbl = new System.Windows.Forms.Label();
            this.contractTypeComboBox = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.signingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatelbl = new System.Windows.Forms.Label();
            this.projectNameComboBox = new System.Windows.Forms.ComboBox();
            this.startDatelbl = new System.Windows.Forms.Label();
            this.clientNameComboBox = new System.Windows.Forms.ComboBox();
            this.clientNamelbl = new System.Windows.Forms.Label();
            this.btnSaveAddBill = new System.Windows.Forms.Button();
            this.ClearFieldsBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.signingDatelbl = new System.Windows.Forms.Label();
            this.projectCodeTxtBox = new System.Windows.Forms.TextBox();
            this.clientContractCodetxtBox = new System.Windows.Forms.TextBox();
            this.clientContractCodelbl = new System.Windows.Forms.Label();
            this.valueTxtBox = new System.Windows.Forms.TextBox();
            this.valuelbl = new System.Windows.Forms.Label();
            this.yarivContractCodeTxtBox = new System.Windows.Forms.TextBox();
            this.yarivContractCodeLbl = new System.Windows.Forms.Label();
            this.projectNameLbl = new System.Windows.Forms.Label();
            this.projectCodeLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // valueListBox
            // 
            this.valueListBox.FormattingEnabled = true;
            this.valueListBox.Location = new System.Drawing.Point(71, 326);
            this.valueListBox.Name = "valueListBox";
            this.valueListBox.Size = new System.Drawing.Size(296, 69);
            this.valueListBox.Sorted = true;
            this.valueListBox.TabIndex = 107;
            this.valueListBox.Visible = false;
            // 
            // addValue
            // 
            this.addValue.Location = new System.Drawing.Point(417, 326);
            this.addValue.Name = "addValue";
            this.addValue.Size = new System.Drawing.Size(25, 25);
            this.addValue.TabIndex = 106;
            this.addValue.Text = "+";
            this.addValue.UseVisualStyleBackColor = true;
            this.addValue.Click += new System.EventHandler(this.addValue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "חישוב התמורה";
            // 
            // valueWithMaamTxtBox
            // 
            this.valueWithMaamTxtBox.Location = new System.Drawing.Point(71, 195);
            this.valueWithMaamTxtBox.Name = "valueWithMaamTxtBox";
            this.valueWithMaamTxtBox.Size = new System.Drawing.Size(296, 20);
            this.valueWithMaamTxtBox.TabIndex = 103;
            // 
            // valueWithMaam
            // 
            this.valueWithMaam.AutoSize = true;
            this.valueWithMaam.Location = new System.Drawing.Point(435, 198);
            this.valueWithMaam.Name = "valueWithMaam";
            this.valueWithMaam.Size = new System.Drawing.Size(97, 13);
            this.valueWithMaam.TabIndex = 104;
            this.valueWithMaam.Text = "תמורה כולל מע\"מ";
            // 
            // contractTypelbl
            // 
            this.contractTypelbl.AutoSize = true;
            this.contractTypelbl.Location = new System.Drawing.Point(473, 302);
            this.contractTypelbl.Name = "contractTypelbl";
            this.contractTypelbl.Size = new System.Drawing.Size(59, 13);
            this.contractTypelbl.TabIndex = 102;
            this.contractTypelbl.Text = "סוג החוזה";
            // 
            // contractTypeComboBox
            // 
            this.contractTypeComboBox.FormattingEnabled = true;
            this.contractTypeComboBox.Location = new System.Drawing.Point(71, 299);
            this.contractTypeComboBox.Name = "contractTypeComboBox";
            this.contractTypeComboBox.Size = new System.Drawing.Size(296, 21);
            this.contractTypeComboBox.TabIndex = 88;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(82, 429);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 92;
            this.cancelBtn.Text = "ביטול";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(71, 273);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(296, 20);
            this.endDatePicker.TabIndex = 87;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(71, 247);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(296, 20);
            this.startDatePicker.TabIndex = 86;
            this.startDatePicker.ValueChanged += new System.EventHandler(this.startDatePicker_ValueChanged);
            // 
            // signingDatePicker
            // 
            this.signingDatePicker.Location = new System.Drawing.Point(71, 221);
            this.signingDatePicker.Name = "signingDatePicker";
            this.signingDatePicker.Size = new System.Drawing.Size(296, 20);
            this.signingDatePicker.TabIndex = 85;
            // 
            // endDatelbl
            // 
            this.endDatelbl.AutoSize = true;
            this.endDatelbl.Location = new System.Drawing.Point(445, 279);
            this.endDatelbl.Name = "endDatelbl";
            this.endDatelbl.Size = new System.Drawing.Size(87, 13);
            this.endDatelbl.TabIndex = 101;
            this.endDatelbl.Text = "מועד סיום חוזה";
            // 
            // projectNameComboBox
            // 
            this.projectNameComboBox.FormattingEnabled = true;
            this.projectNameComboBox.Location = new System.Drawing.Point(71, 64);
            this.projectNameComboBox.Name = "projectNameComboBox";
            this.projectNameComboBox.Size = new System.Drawing.Size(296, 21);
            this.projectNameComboBox.TabIndex = 80;
            this.projectNameComboBox.SelectedIndexChanged += new System.EventHandler(this.projectNameComboBox_SelectedIndexChanged);
            // 
            // startDatelbl
            // 
            this.startDatelbl.AutoSize = true;
            this.startDatelbl.Location = new System.Drawing.Point(436, 253);
            this.startDatelbl.Name = "startDatelbl";
            this.startDatelbl.Size = new System.Drawing.Size(96, 13);
            this.startDatelbl.TabIndex = 100;
            this.startDatelbl.Text = "מועד תחילת חוזה";
            // 
            // clientNameComboBox
            // 
            this.clientNameComboBox.FormattingEnabled = true;
            this.clientNameComboBox.Location = new System.Drawing.Point(71, 37);
            this.clientNameComboBox.Name = "clientNameComboBox";
            this.clientNameComboBox.Size = new System.Drawing.Size(296, 21);
            this.clientNameComboBox.TabIndex = 79;
            this.clientNameComboBox.SelectedIndexChanged += new System.EventHandler(this.clientNameComboBox_SelectedIndexChanged);
            this.clientNameComboBox.Click += new System.EventHandler(this.clientNameComboBox_Click);
            // 
            // clientNamelbl
            // 
            this.clientNamelbl.AutoSize = true;
            this.clientNamelbl.Location = new System.Drawing.Point(473, 40);
            this.clientNamelbl.Name = "clientNamelbl";
            this.clientNamelbl.Size = new System.Drawing.Size(59, 13);
            this.clientNamelbl.TabIndex = 99;
            this.clientNamelbl.Text = "שם הלקוח";
            // 
            // btnSaveAddBill
            // 
            this.btnSaveAddBill.Location = new System.Drawing.Point(244, 429);
            this.btnSaveAddBill.Name = "btnSaveAddBill";
            this.btnSaveAddBill.Size = new System.Drawing.Size(146, 23);
            this.btnSaveAddBill.TabIndex = 90;
            this.btnSaveAddBill.Text = "שמור והוסף חשבון";
            this.btnSaveAddBill.UseVisualStyleBackColor = true;
            this.btnSaveAddBill.Click += new System.EventHandler(this.btnSaveAddBill_Click);
            // 
            // ClearFieldsBtn
            // 
            this.ClearFieldsBtn.Location = new System.Drawing.Point(163, 429);
            this.ClearFieldsBtn.Name = "ClearFieldsBtn";
            this.ClearFieldsBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearFieldsBtn.TabIndex = 91;
            this.ClearFieldsBtn.Text = "נקה";
            this.ClearFieldsBtn.UseVisualStyleBackColor = true;
            this.ClearFieldsBtn.Click += new System.EventHandler(this.ClearFieldsBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(396, 429);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 89;
            this.saveBtn.Text = "שמור";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // signingDatelbl
            // 
            this.signingDatelbl.AutoSize = true;
            this.signingDatelbl.Location = new System.Drawing.Point(422, 228);
            this.signingDatelbl.Name = "signingDatelbl";
            this.signingDatelbl.Size = new System.Drawing.Size(110, 13);
            this.signingDatelbl.TabIndex = 98;
            this.signingDatelbl.Text = "תאריך חתימת החוזה";
            // 
            // projectCodeTxtBox
            // 
            this.projectCodeTxtBox.Location = new System.Drawing.Point(71, 91);
            this.projectCodeTxtBox.Name = "projectCodeTxtBox";
            this.projectCodeTxtBox.Size = new System.Drawing.Size(296, 20);
            this.projectCodeTxtBox.TabIndex = 81;
            // 
            // clientContractCodetxtBox
            // 
            this.clientContractCodetxtBox.Location = new System.Drawing.Point(71, 143);
            this.clientContractCodetxtBox.Name = "clientContractCodetxtBox";
            this.clientContractCodetxtBox.Size = new System.Drawing.Size(296, 20);
            this.clientContractCodetxtBox.TabIndex = 83;
            // 
            // clientContractCodelbl
            // 
            this.clientContractCodelbl.AutoSize = true;
            this.clientContractCodelbl.Location = new System.Drawing.Point(437, 146);
            this.clientContractCodelbl.Name = "clientContractCodelbl";
            this.clientContractCodelbl.Size = new System.Drawing.Size(95, 13);
            this.clientContractCodelbl.TabIndex = 97;
            this.clientContractCodelbl.Text = "קוד חוזה (הלקוח)";
            // 
            // valueTxtBox
            // 
            this.valueTxtBox.Location = new System.Drawing.Point(71, 169);
            this.valueTxtBox.Name = "valueTxtBox";
            this.valueTxtBox.Size = new System.Drawing.Size(296, 20);
            this.valueTxtBox.TabIndex = 84;
            this.valueTxtBox.Leave += new System.EventHandler(this.valueTxtBox_Leave);
            // 
            // valuelbl
            // 
            this.valuelbl.AutoSize = true;
            this.valuelbl.Location = new System.Drawing.Point(417, 172);
            this.valuelbl.Name = "valuelbl";
            this.valuelbl.Size = new System.Drawing.Size(115, 13);
            this.valuelbl.TabIndex = 96;
            this.valuelbl.Text = "תמורה לא כולל מע\"מ";
            // 
            // yarivContractCodeTxtBox
            // 
            this.yarivContractCodeTxtBox.Location = new System.Drawing.Point(71, 117);
            this.yarivContractCodeTxtBox.Name = "yarivContractCodeTxtBox";
            this.yarivContractCodeTxtBox.Size = new System.Drawing.Size(296, 20);
            this.yarivContractCodeTxtBox.TabIndex = 82;
            // 
            // yarivContractCodeLbl
            // 
            this.yarivContractCodeLbl.AutoSize = true;
            this.yarivContractCodeLbl.Location = new System.Drawing.Point(447, 120);
            this.yarivContractCodeLbl.Name = "yarivContractCodeLbl";
            this.yarivContractCodeLbl.Size = new System.Drawing.Size(85, 13);
            this.yarivContractCodeLbl.TabIndex = 95;
            this.yarivContractCodeLbl.Text = "קוד חוזה (יריב)";
            // 
            // projectNameLbl
            // 
            this.projectNameLbl.AutoSize = true;
            this.projectNameLbl.Location = new System.Drawing.Point(457, 67);
            this.projectNameLbl.Name = "projectNameLbl";
            this.projectNameLbl.Size = new System.Drawing.Size(75, 13);
            this.projectNameLbl.TabIndex = 94;
            this.projectNameLbl.Text = "שם הפרוייקט\r\n";
            // 
            // projectCodeLbl
            // 
            this.projectCodeLbl.AutoSize = true;
            this.projectCodeLbl.Location = new System.Drawing.Point(461, 94);
            this.projectCodeLbl.Name = "projectCodeLbl";
            this.projectCodeLbl.Size = new System.Drawing.Size(71, 13);
            this.projectCodeLbl.TabIndex = 93;
            this.projectCodeLbl.Text = "קוד פרוייקט";
            // 
            // ContractUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueListBox);
            this.Controls.Add(this.addValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valueWithMaamTxtBox);
            this.Controls.Add(this.valueWithMaam);
            this.Controls.Add(this.contractTypelbl);
            this.Controls.Add(this.contractTypeComboBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.signingDatePicker);
            this.Controls.Add(this.endDatelbl);
            this.Controls.Add(this.projectNameComboBox);
            this.Controls.Add(this.startDatelbl);
            this.Controls.Add(this.clientNameComboBox);
            this.Controls.Add(this.clientNamelbl);
            this.Controls.Add(this.btnSaveAddBill);
            this.Controls.Add(this.ClearFieldsBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.signingDatelbl);
            this.Controls.Add(this.projectCodeTxtBox);
            this.Controls.Add(this.clientContractCodetxtBox);
            this.Controls.Add(this.clientContractCodelbl);
            this.Controls.Add(this.valueTxtBox);
            this.Controls.Add(this.valuelbl);
            this.Controls.Add(this.yarivContractCodeTxtBox);
            this.Controls.Add(this.yarivContractCodeLbl);
            this.Controls.Add(this.projectNameLbl);
            this.Controls.Add(this.projectCodeLbl);
            this.Name = "ContractUserControl";
            this.Size = new System.Drawing.Size(656, 514);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox valueListBox;
        private System.Windows.Forms.Button addValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox valueWithMaamTxtBox;
        private System.Windows.Forms.Label valueWithMaam;
        private System.Windows.Forms.Label contractTypelbl;
        private System.Windows.Forms.ComboBox contractTypeComboBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker signingDatePicker;
        private System.Windows.Forms.Label endDatelbl;
        private System.Windows.Forms.ComboBox projectNameComboBox;
        private System.Windows.Forms.Label startDatelbl;
        private System.Windows.Forms.ComboBox clientNameComboBox;
        private System.Windows.Forms.Label clientNamelbl;
        private System.Windows.Forms.Button btnSaveAddBill;
        private System.Windows.Forms.Button ClearFieldsBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label signingDatelbl;
        private System.Windows.Forms.TextBox projectCodeTxtBox;
        private System.Windows.Forms.TextBox clientContractCodetxtBox;
        private System.Windows.Forms.Label clientContractCodelbl;
        private System.Windows.Forms.TextBox valueTxtBox;
        private System.Windows.Forms.Label valuelbl;
        private System.Windows.Forms.TextBox yarivContractCodeTxtBox;
        private System.Windows.Forms.Label yarivContractCodeLbl;
        private System.Windows.Forms.Label projectNameLbl;
        private System.Windows.Forms.Label projectCodeLbl;
    }
}
