namespace Billing.InsertData
{
    partial class ClientUserControl
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
            this.addClientType = new System.Windows.Forms.Button();
            this.clientCodeTxtBox = new System.Windows.Forms.TextBox();
            this.ClientCodelbl = new System.Windows.Forms.Label();
            this.ClientTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ClientTypelbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.btnSaveAndAddProj = new System.Windows.Forms.Button();
            this.ClearFieldsBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.emailLbl = new System.Windows.Forms.Label();
            this.phoneTxtBox = new System.Windows.Forms.TextBox();
            this.phoneLbl = new System.Windows.Forms.Label();
            this.ClientAddressTxtBox = new System.Windows.Forms.TextBox();
            this.clientAddressLbl = new System.Windows.Forms.Label();
            this.clientNameTxtBox = new System.Windows.Forms.TextBox();
            this.clientNamelbl = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addClientType
            // 
            this.addClientType.Location = new System.Drawing.Point(189, 400);
            this.addClientType.Name = "addClientType";
            this.addClientType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addClientType.Size = new System.Drawing.Size(126, 23);
            this.addClientType.TabIndex = 118;
            this.addClientType.Text = "הוסף סוג לקוח";
            this.addClientType.UseVisualStyleBackColor = true;
            this.addClientType.Click += new System.EventHandler(this.addClientType_Click);
            // 
            // clientCodeTxtBox
            // 
            this.clientCodeTxtBox.Enabled = false;
            this.clientCodeTxtBox.Location = new System.Drawing.Point(161, 82);
            this.clientCodeTxtBox.Name = "clientCodeTxtBox";
            this.clientCodeTxtBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientCodeTxtBox.Size = new System.Drawing.Size(177, 20);
            this.clientCodeTxtBox.TabIndex = 104;
            // 
            // ClientCodelbl
            // 
            this.ClientCodelbl.AutoSize = true;
            this.ClientCodelbl.Location = new System.Drawing.Point(344, 85);
            this.ClientCodelbl.Name = "ClientCodelbl";
            this.ClientCodelbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientCodelbl.Size = new System.Drawing.Size(55, 13);
            this.ClientCodelbl.TabIndex = 117;
            this.ClientCodelbl.Text = "קוד לקוח";
            // 
            // ClientTypeComboBox
            // 
            this.ClientTypeComboBox.FormattingEnabled = true;
            this.ClientTypeComboBox.Location = new System.Drawing.Point(161, 47);
            this.ClientTypeComboBox.Name = "ClientTypeComboBox";
            this.ClientTypeComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientTypeComboBox.Size = new System.Drawing.Size(177, 21);
            this.ClientTypeComboBox.TabIndex = 102;
            this.ClientTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ClientTypeComboBox_SelectedIndexChanged);
            // 
            // ClientTypelbl
            // 
            this.ClientTypelbl.AutoSize = true;
            this.ClientTypelbl.Location = new System.Drawing.Point(345, 50);
            this.ClientTypelbl.Name = "ClientTypelbl";
            this.ClientTypelbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientTypelbl.Size = new System.Drawing.Size(54, 13);
            this.ClientTypelbl.TabIndex = 116;
            this.ClientTypelbl.Text = "סוג לקוח";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(189, 363);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cancelBtn.Size = new System.Drawing.Size(126, 23);
            this.cancelBtn.TabIndex = 115;
            this.cancelBtn.Text = "ביטול";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // btnSaveAndAddProj
            // 
            this.btnSaveAndAddProj.Location = new System.Drawing.Point(189, 289);
            this.btnSaveAndAddProj.Name = "btnSaveAndAddProj";
            this.btnSaveAndAddProj.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaveAndAddProj.Size = new System.Drawing.Size(126, 23);
            this.btnSaveAndAddProj.TabIndex = 112;
            this.btnSaveAndAddProj.Text = "שמור והוסף פרוייקט";
            this.btnSaveAndAddProj.UseVisualStyleBackColor = true;
            this.btnSaveAndAddProj.Click += new System.EventHandler(this.btnSaveAndAddProj_Click);
            // 
            // ClearFieldsBtn
            // 
            this.ClearFieldsBtn.Location = new System.Drawing.Point(189, 326);
            this.ClearFieldsBtn.Name = "ClearFieldsBtn";
            this.ClearFieldsBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClearFieldsBtn.Size = new System.Drawing.Size(126, 23);
            this.ClearFieldsBtn.TabIndex = 114;
            this.ClearFieldsBtn.Text = "נקה";
            this.ClearFieldsBtn.UseVisualStyleBackColor = true;
            this.ClearFieldsBtn.Click += new System.EventHandler(this.ClearFieldsBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(189, 252);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveBtn.Size = new System.Drawing.Size(126, 23);
            this.saveBtn.TabIndex = 111;
            this.saveBtn.Text = "שמור";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.Location = new System.Drawing.Point(162, 218);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.emailTxtBox.Size = new System.Drawing.Size(177, 20);
            this.emailTxtBox.TabIndex = 109;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(355, 221);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.emailLbl.Size = new System.Drawing.Size(44, 13);
            this.emailLbl.TabIndex = 113;
            this.emailLbl.Text = "אימייל";
            // 
            // phoneTxtBox
            // 
            this.phoneTxtBox.Location = new System.Drawing.Point(162, 150);
            this.phoneTxtBox.Name = "phoneTxtBox";
            this.phoneTxtBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.phoneTxtBox.Size = new System.Drawing.Size(177, 20);
            this.phoneTxtBox.TabIndex = 106;
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Location = new System.Drawing.Point(361, 153);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.phoneLbl.Size = new System.Drawing.Size(38, 13);
            this.phoneLbl.TabIndex = 110;
            this.phoneLbl.Text = "טלפון";
            // 
            // ClientAddressTxtBox
            // 
            this.ClientAddressTxtBox.Location = new System.Drawing.Point(163, 184);
            this.ClientAddressTxtBox.Name = "ClientAddressTxtBox";
            this.ClientAddressTxtBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientAddressTxtBox.Size = new System.Drawing.Size(177, 20);
            this.ClientAddressTxtBox.TabIndex = 108;
            // 
            // clientAddressLbl
            // 
            this.clientAddressLbl.AutoSize = true;
            this.clientAddressLbl.Location = new System.Drawing.Point(359, 187);
            this.clientAddressLbl.Name = "clientAddressLbl";
            this.clientAddressLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientAddressLbl.Size = new System.Drawing.Size(40, 13);
            this.clientAddressLbl.TabIndex = 107;
            this.clientAddressLbl.Text = "כתובת";
            // 
            // clientNameTxtBox
            // 
            this.clientNameTxtBox.Location = new System.Drawing.Point(162, 116);
            this.clientNameTxtBox.Name = "clientNameTxtBox";
            this.clientNameTxtBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientNameTxtBox.Size = new System.Drawing.Size(177, 20);
            this.clientNameTxtBox.TabIndex = 105;
            // 
            // clientNamelbl
            // 
            this.clientNamelbl.AutoSize = true;
            this.clientNamelbl.Location = new System.Drawing.Point(347, 119);
            this.clientNamelbl.Name = "clientNamelbl";
            this.clientNamelbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientNamelbl.Size = new System.Drawing.Size(52, 13);
            this.clientNamelbl.TabIndex = 103;
            this.clientNamelbl.Text = "שם לקוח";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(307, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(33, 13);
            this.titleLabel.TabIndex = 119;
            this.titleLabel.Text = "לקוח";
            // 
            // ClientUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.addClientType);
            this.Controls.Add(this.clientCodeTxtBox);
            this.Controls.Add(this.ClientCodelbl);
            this.Controls.Add(this.ClientTypeComboBox);
            this.Controls.Add(this.ClientTypelbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.btnSaveAndAddProj);
            this.Controls.Add(this.ClearFieldsBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.emailTxtBox);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.phoneTxtBox);
            this.Controls.Add(this.phoneLbl);
            this.Controls.Add(this.ClientAddressTxtBox);
            this.Controls.Add(this.clientAddressLbl);
            this.Controls.Add(this.clientNameTxtBox);
            this.Controls.Add(this.clientNamelbl);
            this.Name = "ClientUserControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(571, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addClientType;
        private System.Windows.Forms.TextBox clientCodeTxtBox;
        private System.Windows.Forms.Label ClientCodelbl;
        private System.Windows.Forms.ComboBox ClientTypeComboBox;
        private System.Windows.Forms.Label ClientTypelbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button btnSaveAndAddProj;
        private System.Windows.Forms.Button ClearFieldsBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.TextBox phoneTxtBox;
        private System.Windows.Forms.Label phoneLbl;
        private System.Windows.Forms.TextBox ClientAddressTxtBox;
        private System.Windows.Forms.Label clientAddressLbl;
        private System.Windows.Forms.TextBox clientNameTxtBox;
        private System.Windows.Forms.Label clientNamelbl;
        private System.Windows.Forms.Label titleLabel;
    }
}
