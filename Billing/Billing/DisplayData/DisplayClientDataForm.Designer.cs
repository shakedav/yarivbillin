namespace Billing.DisplayData
{
    partial class DisplayClientDataForm
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
            this.ClientsDataGrid = new System.Windows.Forms.DataGridView();
            this.clientNamelbl = new System.Windows.Forms.Label();
            this.ClientNamesComboBox = new System.Windows.Forms.ComboBox();
            this.clientTypeTxtBox = new System.Windows.Forms.TextBox();
            this.ClientCodelbl = new System.Windows.Forms.Label();
            this.ClientTypelbl = new System.Windows.Forms.Label();
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.emailLbl = new System.Windows.Forms.Label();
            this.phoneTxtBox = new System.Windows.Forms.TextBox();
            this.phoneLbl = new System.Windows.Forms.Label();
            this.ClientAddressTxtBox = new System.Windows.Forms.TextBox();
            this.clientAddressLbl = new System.Windows.Forms.Label();
            this.clientCodeTxtBox = new System.Windows.Forms.TextBox();
            this.getContractsBtn = new System.Windows.Forms.Button();
            this.getProjectsBtn = new System.Windows.Forms.Button();
            this.getBillsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGrid)).BeginInit();
            this.SuspendLayout();
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
            this.ClientsDataGrid.Location = new System.Drawing.Point(12, 145);
            this.ClientsDataGrid.Name = "ClientsDataGrid";
            this.ClientsDataGrid.ReadOnly = true;
            this.ClientsDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientsDataGrid.Size = new System.Drawing.Size(853, 196);
            this.ClientsDataGrid.TabIndex = 2;
            // 
            // clientNamelbl
            // 
            this.clientNamelbl.AutoSize = true;
            this.clientNamelbl.Location = new System.Drawing.Point(814, 15);
            this.clientNamelbl.Name = "clientNamelbl";
            this.clientNamelbl.Size = new System.Drawing.Size(52, 13);
            this.clientNamelbl.TabIndex = 3;
            this.clientNamelbl.Text = "שם לקוח";
            // 
            // ClientNamesComboBox
            // 
            this.ClientNamesComboBox.FormattingEnabled = true;
            this.ClientNamesComboBox.Location = new System.Drawing.Point(609, 12);
            this.ClientNamesComboBox.Name = "ClientNamesComboBox";
            this.ClientNamesComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientNamesComboBox.Size = new System.Drawing.Size(199, 21);
            this.ClientNamesComboBox.TabIndex = 74;
            this.ClientNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.ClientNamesComboBox_SelectedIndexChanged);
            this.ClientNamesComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClientNamesComboBox_MouseClick);
            // 
            // clientTypeTxtBox
            // 
            this.clientTypeTxtBox.Location = new System.Drawing.Point(443, 12);
            this.clientTypeTxtBox.Name = "clientTypeTxtBox";
            this.clientTypeTxtBox.Size = new System.Drawing.Size(100, 20);
            this.clientTypeTxtBox.TabIndex = 87;
            // 
            // ClientCodelbl
            // 
            this.ClientCodelbl.AutoSize = true;
            this.ClientCodelbl.Location = new System.Drawing.Point(382, 15);
            this.ClientCodelbl.Name = "ClientCodelbl";
            this.ClientCodelbl.Size = new System.Drawing.Size(55, 13);
            this.ClientCodelbl.TabIndex = 86;
            this.ClientCodelbl.Text = "קוד לקוח";
            // 
            // ClientTypelbl
            // 
            this.ClientTypelbl.AutoSize = true;
            this.ClientTypelbl.Location = new System.Drawing.Point(549, 15);
            this.ClientTypelbl.Name = "ClientTypelbl";
            this.ClientTypelbl.Size = new System.Drawing.Size(54, 13);
            this.ClientTypelbl.TabIndex = 84;
            this.ClientTypelbl.Text = "סוג לקוח";
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.Location = new System.Drawing.Point(180, 39);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.Size = new System.Drawing.Size(199, 20);
            this.emailTxtBox.TabIndex = 83;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(393, 42);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(44, 13);
            this.emailLbl.TabIndex = 82;
            this.emailLbl.Text = "אימייל";
            // 
            // phoneTxtBox
            // 
            this.phoneTxtBox.Location = new System.Drawing.Point(443, 39);
            this.phoneTxtBox.Name = "phoneTxtBox";
            this.phoneTxtBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTxtBox.TabIndex = 81;
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Location = new System.Drawing.Point(565, 42);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.Size = new System.Drawing.Size(38, 13);
            this.phoneLbl.TabIndex = 80;
            this.phoneLbl.Text = "טלפון";
            // 
            // ClientAddressTxtBox
            // 
            this.ClientAddressTxtBox.Location = new System.Drawing.Point(609, 42);
            this.ClientAddressTxtBox.Name = "ClientAddressTxtBox";
            this.ClientAddressTxtBox.Size = new System.Drawing.Size(199, 20);
            this.ClientAddressTxtBox.TabIndex = 79;
            // 
            // clientAddressLbl
            // 
            this.clientAddressLbl.AutoSize = true;
            this.clientAddressLbl.Location = new System.Drawing.Point(826, 45);
            this.clientAddressLbl.Name = "clientAddressLbl";
            this.clientAddressLbl.Size = new System.Drawing.Size(40, 13);
            this.clientAddressLbl.TabIndex = 78;
            this.clientAddressLbl.Text = "כתובת";
            // 
            // clientCodeTxtBox
            // 
            this.clientCodeTxtBox.Location = new System.Drawing.Point(314, 12);
            this.clientCodeTxtBox.Name = "clientCodeTxtBox";
            this.clientCodeTxtBox.Size = new System.Drawing.Size(62, 20);
            this.clientCodeTxtBox.TabIndex = 88;
            // 
            // getContractsBtn
            // 
            this.getContractsBtn.Location = new System.Drawing.Point(790, 77);
            this.getContractsBtn.Name = "getContractsBtn";
            this.getContractsBtn.Size = new System.Drawing.Size(75, 23);
            this.getContractsBtn.TabIndex = 89;
            this.getContractsBtn.Text = "הצג חוזים";
            this.getContractsBtn.UseVisualStyleBackColor = true;
            this.getContractsBtn.Click += new System.EventHandler(this.getContractsBtn_Click);
            // 
            // getProjectsBtn
            // 
            this.getProjectsBtn.Location = new System.Drawing.Point(676, 77);
            this.getProjectsBtn.Name = "getProjectsBtn";
            this.getProjectsBtn.Size = new System.Drawing.Size(108, 23);
            this.getProjectsBtn.TabIndex = 90;
            this.getProjectsBtn.Text = "הצג פרוייקטים";
            this.getProjectsBtn.UseVisualStyleBackColor = true;
            this.getProjectsBtn.Click += new System.EventHandler(this.getProjectsBtn_Click);
            // 
            // getBillsBtn
            // 
            this.getBillsBtn.Location = new System.Drawing.Point(562, 77);
            this.getBillsBtn.Name = "getBillsBtn";
            this.getBillsBtn.Size = new System.Drawing.Size(108, 23);
            this.getBillsBtn.TabIndex = 91;
            this.getBillsBtn.Text = "הצג חשבונות";
            this.getBillsBtn.UseVisualStyleBackColor = true;
            // 
            // DisplayClientDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 353);
            this.Controls.Add(this.getBillsBtn);
            this.Controls.Add(this.getProjectsBtn);
            this.Controls.Add(this.getContractsBtn);
            this.Controls.Add(this.clientCodeTxtBox);
            this.Controls.Add(this.clientTypeTxtBox);
            this.Controls.Add(this.ClientCodelbl);
            this.Controls.Add(this.ClientTypelbl);
            this.Controls.Add(this.emailTxtBox);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.phoneTxtBox);
            this.Controls.Add(this.phoneLbl);
            this.Controls.Add(this.ClientAddressTxtBox);
            this.Controls.Add(this.clientAddressLbl);
            this.Controls.Add(this.ClientNamesComboBox);
            this.Controls.Add(this.clientNamelbl);
            this.Controls.Add(this.ClientsDataGrid);
            this.Name = "DisplayClientDataForm";
            this.Text = "DisplayClientDataForm";
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ClientsDataGrid;
        private System.Windows.Forms.Label clientNamelbl;
        private System.Windows.Forms.ComboBox ClientNamesComboBox;
        private System.Windows.Forms.TextBox clientTypeTxtBox;
        private System.Windows.Forms.Label ClientCodelbl;
        private System.Windows.Forms.Label ClientTypelbl;
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.TextBox phoneTxtBox;
        private System.Windows.Forms.Label phoneLbl;
        private System.Windows.Forms.TextBox ClientAddressTxtBox;
        private System.Windows.Forms.Label clientAddressLbl;
        private System.Windows.Forms.TextBox clientCodeTxtBox;
        private System.Windows.Forms.Button getContractsBtn;
        private System.Windows.Forms.Button getProjectsBtn;
        private System.Windows.Forms.Button getBillsBtn;
    }
}