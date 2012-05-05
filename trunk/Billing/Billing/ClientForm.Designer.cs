namespace Billing
{
    partial class ClientForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClientsDataGrid = new System.Windows.Forms.DataGridView();
            this.clientNamelbl = new System.Windows.Forms.Label();
            this.clientNameTxtBox = new System.Windows.Forms.TextBox();
            this.ClientAddressTxtBox = new System.Windows.Forms.TextBox();
            this.clientAddressLbl = new System.Windows.Forms.Label();
            this.phoneTxtBox = new System.Windows.Forms.TextBox();
            this.phoneLbl = new System.Windows.Forms.Label();
            this.projectNameTxtBox = new System.Windows.Forms.TextBox();
            this.projectNameLbl = new System.Windows.Forms.Label();
            this.projectCodeTxtBox = new System.Windows.Forms.TextBox();
            this.projectCodeLbl = new System.Windows.Forms.Label();
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.emailLbl = new System.Windows.Forms.Label();
            this.projectCodeInviterTxtBox = new System.Windows.Forms.TextBox();
            this.projectCodeInviterLbl = new System.Windows.Forms.Label();
            this.projectNameInviterTxtBox = new System.Windows.Forms.TextBox();
            this.projectNameInviterLbl = new System.Windows.Forms.Label();
            this.contactManTxtBox = new System.Windows.Forms.TextBox();
            this.contactManLbl = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.ClearFieldsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1059, 10);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ClientsDataGrid
            // 
            this.ClientsDataGrid.AllowUserToAddRows = false;
            this.ClientsDataGrid.AllowUserToDeleteRows = false;
            this.ClientsDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ClientsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsDataGrid.Location = new System.Drawing.Point(12, 198);
            this.ClientsDataGrid.Name = "ClientsDataGrid";
            this.ClientsDataGrid.ReadOnly = true;
            this.ClientsDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientsDataGrid.Size = new System.Drawing.Size(1060, 252);
            this.ClientsDataGrid.TabIndex = 1;
            // 
            // clientNamelbl
            // 
            this.clientNamelbl.AutoSize = true;
            this.clientNamelbl.Location = new System.Drawing.Point(1020, 9);
            this.clientNamelbl.Name = "clientNamelbl";
            this.clientNamelbl.Size = new System.Drawing.Size(52, 13);
            this.clientNamelbl.TabIndex = 2;
            this.clientNamelbl.Text = "שם לקוח";
            // 
            // clientNameTxtBox
            // 
            this.clientNameTxtBox.Location = new System.Drawing.Point(914, 6);
            this.clientNameTxtBox.Name = "clientNameTxtBox";
            this.clientNameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.clientNameTxtBox.TabIndex = 3;
            // 
            // ClientAddressTxtBox
            // 
            this.ClientAddressTxtBox.Location = new System.Drawing.Point(914, 42);
            this.ClientAddressTxtBox.Name = "ClientAddressTxtBox";
            this.ClientAddressTxtBox.Size = new System.Drawing.Size(100, 20);
            this.ClientAddressTxtBox.TabIndex = 5;
            // 
            // clientAddressLbl
            // 
            this.clientAddressLbl.AutoSize = true;
            this.clientAddressLbl.Location = new System.Drawing.Point(1020, 45);
            this.clientAddressLbl.Name = "clientAddressLbl";
            this.clientAddressLbl.Size = new System.Drawing.Size(40, 13);
            this.clientAddressLbl.TabIndex = 4;
            this.clientAddressLbl.Text = "כתובת";
            // 
            // phoneTxtBox
            // 
            this.phoneTxtBox.Location = new System.Drawing.Point(914, 79);
            this.phoneTxtBox.Name = "phoneTxtBox";
            this.phoneTxtBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTxtBox.TabIndex = 7;
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Location = new System.Drawing.Point(1020, 82);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.Size = new System.Drawing.Size(38, 13);
            this.phoneLbl.TabIndex = 6;
            this.phoneLbl.Text = "טלפון";
            // 
            // projectNameTxtBox
            // 
            this.projectNameTxtBox.Location = new System.Drawing.Point(714, 79);
            this.projectNameTxtBox.Name = "projectNameTxtBox";
            this.projectNameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.projectNameTxtBox.TabIndex = 13;
            // 
            // projectNameLbl
            // 
            this.projectNameLbl.AutoSize = true;
            this.projectNameLbl.Location = new System.Drawing.Point(820, 82);
            this.projectNameLbl.Name = "projectNameLbl";
            this.projectNameLbl.Size = new System.Drawing.Size(75, 13);
            this.projectNameLbl.TabIndex = 12;
            this.projectNameLbl.Text = "שם הפרוייקט\r\n";
            // 
            // projectCodeTxtBox
            // 
            this.projectCodeTxtBox.Enabled = false;
            this.projectCodeTxtBox.Location = new System.Drawing.Point(714, 42);
            this.projectCodeTxtBox.Name = "projectCodeTxtBox";
            this.projectCodeTxtBox.Size = new System.Drawing.Size(100, 20);
            this.projectCodeTxtBox.TabIndex = 11;
            // 
            // projectCodeLbl
            // 
            this.projectCodeLbl.AutoSize = true;
            this.projectCodeLbl.Location = new System.Drawing.Point(820, 45);
            this.projectCodeLbl.Name = "projectCodeLbl";
            this.projectCodeLbl.Size = new System.Drawing.Size(71, 13);
            this.projectCodeLbl.TabIndex = 10;
            this.projectCodeLbl.Text = "קוד פרוייקט";
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.Location = new System.Drawing.Point(714, 6);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.Size = new System.Drawing.Size(100, 20);
            this.emailTxtBox.TabIndex = 9;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(820, 9);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(44, 13);
            this.emailLbl.TabIndex = 8;
            this.emailLbl.Text = "אימייל";
            // 
            // projectCodeInviterTxtBox
            // 
            this.projectCodeInviterTxtBox.Location = new System.Drawing.Point(438, 79);
            this.projectCodeInviterTxtBox.Name = "projectCodeInviterTxtBox";
            this.projectCodeInviterTxtBox.Size = new System.Drawing.Size(100, 20);
            this.projectCodeInviterTxtBox.TabIndex = 19;
            // 
            // projectCodeInviterLbl
            // 
            this.projectCodeInviterLbl.AutoSize = true;
            this.projectCodeInviterLbl.Location = new System.Drawing.Point(544, 82);
            this.projectCodeInviterLbl.Name = "projectCodeInviterLbl";
            this.projectCodeInviterLbl.Size = new System.Drawing.Size(135, 13);
            this.projectCodeInviterLbl.TabIndex = 18;
            this.projectCodeInviterLbl.Text = "קוד פרוייקט אצל המזמין";
            // 
            // projectNameInviterTxtBox
            // 
            this.projectNameInviterTxtBox.Location = new System.Drawing.Point(438, 42);
            this.projectNameInviterTxtBox.Name = "projectNameInviterTxtBox";
            this.projectNameInviterTxtBox.Size = new System.Drawing.Size(100, 20);
            this.projectNameInviterTxtBox.TabIndex = 17;
            // 
            // projectNameInviterLbl
            // 
            this.projectNameInviterLbl.AutoSize = true;
            this.projectNameInviterLbl.Location = new System.Drawing.Point(544, 45);
            this.projectNameInviterLbl.Name = "projectNameInviterLbl";
            this.projectNameInviterLbl.Size = new System.Drawing.Size(132, 13);
            this.projectNameInviterLbl.TabIndex = 16;
            this.projectNameInviterLbl.Text = "שם פרוייקט אצל המזמין";
            // 
            // contactManTxtBox
            // 
            this.contactManTxtBox.Location = new System.Drawing.Point(438, 6);
            this.contactManTxtBox.Name = "contactManTxtBox";
            this.contactManTxtBox.Size = new System.Drawing.Size(100, 20);
            this.contactManTxtBox.TabIndex = 15;
            // 
            // contactManLbl
            // 
            this.contactManLbl.AutoSize = true;
            this.contactManLbl.Location = new System.Drawing.Point(544, 9);
            this.contactManLbl.Name = "contactManLbl";
            this.contactManLbl.Size = new System.Drawing.Size(106, 13);
            this.contactManLbl.TabIndex = 14;
            this.contactManLbl.Text = "איש קשר בפרוייקט";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(697, 135);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 20;
            this.saveBtn.Text = "שמור";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // ClearFieldsBtn
            // 
            this.ClearFieldsBtn.Location = new System.Drawing.Point(616, 135);
            this.ClearFieldsBtn.Name = "ClearFieldsBtn";
            this.ClearFieldsBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearFieldsBtn.TabIndex = 21;
            this.ClearFieldsBtn.Text = "נקה";
            this.ClearFieldsBtn.UseVisualStyleBackColor = true;
            this.ClearFieldsBtn.Click += new System.EventHandler(this.ClearFieldsBtn_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 462);
            this.Controls.Add(this.ClearFieldsBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.projectCodeInviterTxtBox);
            this.Controls.Add(this.projectCodeInviterLbl);
            this.Controls.Add(this.projectNameInviterTxtBox);
            this.Controls.Add(this.projectNameInviterLbl);
            this.Controls.Add(this.contactManTxtBox);
            this.Controls.Add(this.contactManLbl);
            this.Controls.Add(this.projectNameTxtBox);
            this.Controls.Add(this.projectNameLbl);
            this.Controls.Add(this.projectCodeTxtBox);
            this.Controls.Add(this.projectCodeLbl);
            this.Controls.Add(this.emailTxtBox);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.phoneTxtBox);
            this.Controls.Add(this.phoneLbl);
            this.Controls.Add(this.ClientAddressTxtBox);
            this.Controls.Add(this.clientAddressLbl);
            this.Controls.Add(this.clientNameTxtBox);
            this.Controls.Add(this.clientNamelbl);
            this.Controls.Add(this.ClientsDataGrid);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClientForm";
            this.RightToLeftLayout = true;
            this.Text = "לקוח";
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView ClientsDataGrid;
        private System.Windows.Forms.Label clientNamelbl;
        private System.Windows.Forms.TextBox clientNameTxtBox;
        private System.Windows.Forms.TextBox ClientAddressTxtBox;
        private System.Windows.Forms.Label clientAddressLbl;
        private System.Windows.Forms.TextBox phoneTxtBox;
        private System.Windows.Forms.Label phoneLbl;
        private System.Windows.Forms.TextBox projectNameTxtBox;
        private System.Windows.Forms.Label projectNameLbl;
        private System.Windows.Forms.TextBox projectCodeTxtBox;
        private System.Windows.Forms.Label projectCodeLbl;
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.TextBox projectCodeInviterTxtBox;
        private System.Windows.Forms.Label projectCodeInviterLbl;
        private System.Windows.Forms.TextBox projectNameInviterTxtBox;
        private System.Windows.Forms.Label projectNameInviterLbl;
        private System.Windows.Forms.TextBox contactManTxtBox;
        private System.Windows.Forms.Label contactManLbl;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button ClearFieldsBtn;
    }
}