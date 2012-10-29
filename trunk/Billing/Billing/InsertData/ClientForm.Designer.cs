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
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.emailLbl = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.ClearFieldsBtn = new System.Windows.Forms.Button();
            this.btnSaveAndAddProj = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.ClientTypelbl = new System.Windows.Forms.Label();
            this.ClientTypeComboBox = new System.Windows.Forms.ComboBox();
            this.clientCodeTxtBox = new System.Windows.Forms.TextBox();
            this.ClientCodelbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 10);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ClientsDataGrid
            // 
            this.ClientsDataGrid.AllowUserToAddRows = false;
            this.ClientsDataGrid.AllowUserToDeleteRows = false;
            this.ClientsDataGrid.AllowUserToResizeColumns = false;
            this.ClientsDataGrid.AllowUserToResizeRows = false;
            this.ClientsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ClientsDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ClientsDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ClientsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ClientsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsDataGrid.Location = new System.Drawing.Point(12, 198);
            this.ClientsDataGrid.Name = "ClientsDataGrid";
            this.ClientsDataGrid.ReadOnly = true;
            this.ClientsDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientsDataGrid.Size = new System.Drawing.Size(760, 252);
            this.ClientsDataGrid.TabIndex = 100;
            // 
            // clientNamelbl
            // 
            this.clientNamelbl.AutoSize = true;
            this.clientNamelbl.Location = new System.Drawing.Point(278, 9);
            this.clientNamelbl.Name = "clientNamelbl";
            this.clientNamelbl.Size = new System.Drawing.Size(52, 13);
            this.clientNamelbl.TabIndex = 2;
            this.clientNamelbl.Text = "שם לקוח";
            // 
            // clientNameTxtBox
            // 
            this.clientNameTxtBox.Location = new System.Drawing.Point(336, 6);
            this.clientNameTxtBox.Name = "clientNameTxtBox";
            this.clientNameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.clientNameTxtBox.TabIndex = 3;
            // 
            // ClientAddressTxtBox
            // 
            this.ClientAddressTxtBox.Location = new System.Drawing.Point(526, 6);
            this.ClientAddressTxtBox.Name = "ClientAddressTxtBox";
            this.ClientAddressTxtBox.Size = new System.Drawing.Size(199, 20);
            this.ClientAddressTxtBox.TabIndex = 5;
            // 
            // clientAddressLbl
            // 
            this.clientAddressLbl.AutoSize = true;
            this.clientAddressLbl.Location = new System.Drawing.Point(468, 9);
            this.clientAddressLbl.Name = "clientAddressLbl";
            this.clientAddressLbl.Size = new System.Drawing.Size(40, 13);
            this.clientAddressLbl.TabIndex = 4;
            this.clientAddressLbl.Text = "כתובת";
            // 
            // phoneTxtBox
            // 
            this.phoneTxtBox.Location = new System.Drawing.Point(336, 33);
            this.phoneTxtBox.Name = "phoneTxtBox";
            this.phoneTxtBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTxtBox.TabIndex = 4;
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Location = new System.Drawing.Point(278, 36);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.Size = new System.Drawing.Size(38, 13);
            this.phoneLbl.TabIndex = 6;
            this.phoneLbl.Text = "טלפון";
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.Location = new System.Drawing.Point(526, 36);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.emailTxtBox.Size = new System.Drawing.Size(199, 20);
            this.emailTxtBox.TabIndex = 6;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(468, 39);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(44, 13);
            this.emailLbl.TabIndex = 8;
            this.emailLbl.Text = "אימייל";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(15, 71);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "שמור";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // ClearFieldsBtn
            // 
            this.ClearFieldsBtn.Location = new System.Drawing.Point(248, 71);
            this.ClearFieldsBtn.Name = "ClearFieldsBtn";
            this.ClearFieldsBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearFieldsBtn.TabIndex = 9;
            this.ClearFieldsBtn.Text = "נקה";
            this.ClearFieldsBtn.UseVisualStyleBackColor = true;
            this.ClearFieldsBtn.Click += new System.EventHandler(this.ClearFieldsBtn_Click);
            // 
            // btnSaveAndAddProj
            // 
            this.btnSaveAndAddProj.Location = new System.Drawing.Point(96, 71);
            this.btnSaveAndAddProj.Name = "btnSaveAndAddProj";
            this.btnSaveAndAddProj.Size = new System.Drawing.Size(146, 23);
            this.btnSaveAndAddProj.TabIndex = 8;
            this.btnSaveAndAddProj.Text = "שמור והוסף פרוייקט";
            this.btnSaveAndAddProj.UseVisualStyleBackColor = true;
            this.btnSaveAndAddProj.Click += new System.EventHandler(this.btnSaveAndAddProj_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(329, 71);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "ביטול";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ClientTypelbl
            // 
            this.ClientTypelbl.AutoSize = true;
            this.ClientTypelbl.Location = new System.Drawing.Point(12, 9);
            this.ClientTypelbl.Name = "ClientTypelbl";
            this.ClientTypelbl.Size = new System.Drawing.Size(54, 13);
            this.ClientTypelbl.TabIndex = 72;
            this.ClientTypelbl.Text = "סוג לקוח";
            // 
            // ClientTypeComboBox
            // 
            this.ClientTypeComboBox.FormattingEnabled = true;
            this.ClientTypeComboBox.Location = new System.Drawing.Point(72, 6);
            this.ClientTypeComboBox.Name = "ClientTypeComboBox";
            this.ClientTypeComboBox.Size = new System.Drawing.Size(175, 21);
            this.ClientTypeComboBox.TabIndex = 1;
            this.ClientTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ClientTypeComboBox_SelectedIndexChanged);
            // 
            // clientCodeTxtBox
            // 
            this.clientCodeTxtBox.Enabled = false;
            this.clientCodeTxtBox.Location = new System.Drawing.Point(70, 33);
            this.clientCodeTxtBox.Name = "clientCodeTxtBox";
            this.clientCodeTxtBox.Size = new System.Drawing.Size(177, 20);
            this.clientCodeTxtBox.TabIndex = 2;
            // 
            // ClientCodelbl
            // 
            this.ClientCodelbl.AutoSize = true;
            this.ClientCodelbl.Location = new System.Drawing.Point(12, 36);
            this.ClientCodelbl.Name = "ClientCodelbl";
            this.ClientCodelbl.Size = new System.Drawing.Size(55, 13);
            this.ClientCodelbl.TabIndex = 74;
            this.ClientCodelbl.Text = "קוד לקוח";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
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
            this.Controls.Add(this.ClientsDataGrid);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClientForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
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
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button ClearFieldsBtn;
        private System.Windows.Forms.Button btnSaveAndAddProj;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label ClientTypelbl;
        private System.Windows.Forms.ComboBox ClientTypeComboBox;
        private System.Windows.Forms.TextBox clientCodeTxtBox;
        private System.Windows.Forms.Label ClientCodelbl;
    }
}