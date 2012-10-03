namespace Billing
{
    partial class BillForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clientNameComboBox = new System.Windows.Forms.ComboBox();
            this.clientNamelbl = new System.Windows.Forms.Label();
            this.billSequenceInContractTxtBox = new System.Windows.Forms.TextBox();
            this.clientContractCodelbl = new System.Windows.Forms.Label();
            this.valuelbl = new System.Windows.Forms.Label();
            this.projectCodeLbl = new System.Windows.Forms.Label();
            this.billNumberTxtBox = new System.Windows.Forms.TextBox();
            this.yarivContractCodeLbl = new System.Windows.Forms.Label();
            this.totalToPayTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maamTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.billStatusComboBox = new System.Windows.Forms.ComboBox();
            this.contractCodeComboBox = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.ClearFieldsBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.valueComboBox = new System.Windows.Forms.ComboBox();
            this.lastBillTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.totalWithMaamTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clientNameComboBox
            // 
            this.clientNameComboBox.FormattingEnabled = true;
            this.clientNameComboBox.Location = new System.Drawing.Point(84, 6);
            this.clientNameComboBox.Name = "clientNameComboBox";
            this.clientNameComboBox.Size = new System.Drawing.Size(296, 21);
            this.clientNameComboBox.TabIndex = 1;
            this.clientNameComboBox.SelectedIndexChanged += new System.EventHandler(this.clientNameComboBox_SelectedIndexChanged);
            // 
            // clientNamelbl
            // 
            this.clientNamelbl.AutoSize = true;
            this.clientNamelbl.Location = new System.Drawing.Point(481, 9);
            this.clientNamelbl.Name = "clientNamelbl";
            this.clientNamelbl.Size = new System.Drawing.Size(59, 13);
            this.clientNamelbl.TabIndex = 73;
            this.clientNamelbl.Text = "שם הלקוח";
            // 
            // billSequenceInContractTxtBox
            // 
            this.billSequenceInContractTxtBox.Location = new System.Drawing.Point(84, 85);
            this.billSequenceInContractTxtBox.Name = "billSequenceInContractTxtBox";
            this.billSequenceInContractTxtBox.Size = new System.Drawing.Size(296, 20);
            this.billSequenceInContractTxtBox.TabIndex = 4;
            // 
            // clientContractCodelbl
            // 
            this.clientContractCodelbl.AutoSize = true;
            this.clientContractCodelbl.Location = new System.Drawing.Point(410, 88);
            this.clientContractCodelbl.Name = "clientContractCodelbl";
            this.clientContractCodelbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientContractCodelbl.Size = new System.Drawing.Size(133, 13);
            this.clientContractCodelbl.TabIndex = 72;
            this.clientContractCodelbl.Text = "מספר חשבון חלקי בחוזה";
            // 
            // valuelbl
            // 
            this.valuelbl.AutoSize = true;
            this.valuelbl.Location = new System.Drawing.Point(461, 114);
            this.valuelbl.Name = "valuelbl";
            this.valuelbl.Size = new System.Drawing.Size(82, 13);
            this.valuelbl.TabIndex = 71;
            this.valuelbl.Text = "חישוב התמורה";
            // 
            // projectCodeLbl
            // 
            this.projectCodeLbl.AutoSize = true;
            this.projectCodeLbl.Location = new System.Drawing.Point(487, 36);
            this.projectCodeLbl.Name = "projectCodeLbl";
            this.projectCodeLbl.Size = new System.Drawing.Size(53, 13);
            this.projectCodeLbl.TabIndex = 68;
            this.projectCodeLbl.Text = "קוד חוזה";
            // 
            // billNumberTxtBox
            // 
            this.billNumberTxtBox.Location = new System.Drawing.Point(84, 59);
            this.billNumberTxtBox.Name = "billNumberTxtBox";
            this.billNumberTxtBox.Size = new System.Drawing.Size(296, 20);
            this.billNumberTxtBox.TabIndex = 3;
            this.billNumberTxtBox.TextChanged += new System.EventHandler(this.billNumberTxtBox_TextChanged);
            this.billNumberTxtBox.Leave += new System.EventHandler(this.billNumberTxtBox_Leave);
            // 
            // yarivContractCodeLbl
            // 
            this.yarivContractCodeLbl.AutoSize = true;
            this.yarivContractCodeLbl.Location = new System.Drawing.Point(441, 62);
            this.yarivContractCodeLbl.Name = "yarivContractCodeLbl";
            this.yarivContractCodeLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.yarivContractCodeLbl.Size = new System.Drawing.Size(102, 13);
            this.yarivContractCodeLbl.TabIndex = 70;
            this.yarivContractCodeLbl.Text = "מספר חשבון (יריב)";
            // 
            // totalToPayTxtBox
            // 
            this.totalToPayTxtBox.Location = new System.Drawing.Point(84, 164);
            this.totalToPayTxtBox.Name = "totalToPayTxtBox";
            this.totalToPayTxtBox.Size = new System.Drawing.Size(296, 20);
            this.totalToPayTxtBox.TabIndex = 7;
            this.totalToPayTxtBox.TextChanged += new System.EventHandler(this.totalToPayTxtBox_TextChanged);
            this.totalToPayTxtBox.Enter += new System.EventHandler(this.totalToPayTxtBox_Enter);
            this.totalToPayTxtBox.Leave += new System.EventHandler(this.totalToPayTxtBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(467, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "סכום החשבון";
            // 
            // maamTxtBox
            // 
            this.maamTxtBox.Location = new System.Drawing.Point(84, 190);
            this.maamTxtBox.Name = "maamTxtBox";
            this.maamTxtBox.Size = new System.Drawing.Size(296, 20);
            this.maamTxtBox.TabIndex = 8;
            this.maamTxtBox.TextChanged += new System.EventHandler(this.maamTxtBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "המע\"מ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "סטטוס";
            // 
            // billStatusComboBox
            // 
            this.billStatusComboBox.FormattingEnabled = true;
            this.billStatusComboBox.Location = new System.Drawing.Point(84, 242);
            this.billStatusComboBox.Name = "billStatusComboBox";
            this.billStatusComboBox.Size = new System.Drawing.Size(296, 21);
            this.billStatusComboBox.TabIndex = 10;
            // 
            // contractCodeComboBox
            // 
            this.contractCodeComboBox.FormattingEnabled = true;
            this.contractCodeComboBox.Location = new System.Drawing.Point(84, 33);
            this.contractCodeComboBox.Name = "contractCodeComboBox";
            this.contractCodeComboBox.Size = new System.Drawing.Size(296, 21);
            this.contractCodeComboBox.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(121, 276);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "ביטול";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ClearFieldsBtn
            // 
            this.ClearFieldsBtn.Location = new System.Drawing.Point(202, 276);
            this.ClearFieldsBtn.Name = "ClearFieldsBtn";
            this.ClearFieldsBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearFieldsBtn.TabIndex = 12;
            this.ClearFieldsBtn.Text = "נקה";
            this.ClearFieldsBtn.UseVisualStyleBackColor = true;
            this.ClearFieldsBtn.Click += new System.EventHandler(this.ClearFieldsBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(283, 276);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "שמור";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // valueComboBox
            // 
            this.valueComboBox.FormattingEnabled = true;
            this.valueComboBox.Location = new System.Drawing.Point(84, 111);
            this.valueComboBox.Name = "valueComboBox";
            this.valueComboBox.Size = new System.Drawing.Size(296, 21);
            this.valueComboBox.TabIndex = 5;
            // 
            // lastBillTxtBox
            // 
            this.lastBillTxtBox.Location = new System.Drawing.Point(84, 138);
            this.lastBillTxtBox.Name = "lastBillTxtBox";
            this.lastBillTxtBox.Size = new System.Drawing.Size(296, 20);
            this.lastBillTxtBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(474, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "חשבון קודם";
            // 
            // totalWithMaamTextBox
            // 
            this.totalWithMaamTextBox.Location = new System.Drawing.Point(84, 216);
            this.totalWithMaamTextBox.Name = "totalWithMaamTextBox";
            this.totalWithMaamTextBox.Size = new System.Drawing.Size(296, 20);
            this.totalWithMaamTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "סכום החשבון כולל מע\"מ";
            // 
            // errorsLabel
            // 
            this.errorsLabel.AutoSize = true;
            this.errorsLabel.Location = new System.Drawing.Point(35, 302);
            this.errorsLabel.Name = "errorsLabel";
            this.errorsLabel.Padding = new System.Windows.Forms.Padding(100, 10, 100, 10);
            this.errorsLabel.Size = new System.Drawing.Size(200, 33);
            this.errorsLabel.TabIndex = 94;
            this.errorsLabel.Visible = false;
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 445);
            this.Controls.Add(this.errorsLabel);
            this.Controls.Add(this.totalWithMaamTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lastBillTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.valueComboBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.ClearFieldsBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.contractCodeComboBox);
            this.Controls.Add(this.billStatusComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maamTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalToPayTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientNameComboBox);
            this.Controls.Add(this.clientNamelbl);
            this.Controls.Add(this.billSequenceInContractTxtBox);
            this.Controls.Add(this.clientContractCodelbl);
            this.Controls.Add(this.valuelbl);
            this.Controls.Add(this.billNumberTxtBox);
            this.Controls.Add(this.yarivContractCodeLbl);
            this.Controls.Add(this.projectCodeLbl);
            this.Name = "BillForm";
            this.Text = "BillForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox clientNameComboBox;
        private System.Windows.Forms.Label clientNamelbl;
        private System.Windows.Forms.TextBox billSequenceInContractTxtBox;
        private System.Windows.Forms.Label clientContractCodelbl;
        private System.Windows.Forms.Label valuelbl;
        private System.Windows.Forms.Label projectCodeLbl;
        private System.Windows.Forms.TextBox billNumberTxtBox;
        private System.Windows.Forms.Label yarivContractCodeLbl;
        private System.Windows.Forms.TextBox totalToPayTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox maamTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox billStatusComboBox;
        private System.Windows.Forms.ComboBox contractCodeComboBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button ClearFieldsBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox valueComboBox;
        private System.Windows.Forms.TextBox lastBillTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox totalWithMaamTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label errorsLabel;
    }
}