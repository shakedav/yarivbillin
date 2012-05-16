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
            this.button1 = new System.Windows.Forms.Button();
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
            this.ClientsDataGrid.TabIndex = 1;
            // 
            // clientNamelbl
            // 
            this.clientNamelbl.AutoSize = true;
            this.clientNamelbl.Location = new System.Drawing.Point(12, 11);
            this.clientNamelbl.Name = "clientNamelbl";
            this.clientNamelbl.Size = new System.Drawing.Size(52, 13);
            this.clientNamelbl.TabIndex = 2;
            this.clientNamelbl.Text = "שם לקוח";
            // 
            // clientNameTxtBox
            // 
            this.clientNameTxtBox.Location = new System.Drawing.Point(70, 8);
            this.clientNameTxtBox.Name = "clientNameTxtBox";
            this.clientNameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.clientNameTxtBox.TabIndex = 3;
            // 
            // ClientAddressTxtBox
            // 
            this.ClientAddressTxtBox.Location = new System.Drawing.Point(260, 8);
            this.ClientAddressTxtBox.Name = "ClientAddressTxtBox";
            this.ClientAddressTxtBox.Size = new System.Drawing.Size(199, 20);
            this.ClientAddressTxtBox.TabIndex = 5;
            // 
            // clientAddressLbl
            // 
            this.clientAddressLbl.AutoSize = true;
            this.clientAddressLbl.Location = new System.Drawing.Point(202, 11);
            this.clientAddressLbl.Name = "clientAddressLbl";
            this.clientAddressLbl.Size = new System.Drawing.Size(40, 13);
            this.clientAddressLbl.TabIndex = 4;
            this.clientAddressLbl.Text = "כתובת";
            // 
            // phoneTxtBox
            // 
            this.phoneTxtBox.Location = new System.Drawing.Point(70, 35);
            this.phoneTxtBox.Name = "phoneTxtBox";
            this.phoneTxtBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTxtBox.TabIndex = 7;
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Location = new System.Drawing.Point(12, 38);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.Size = new System.Drawing.Size(38, 13);
            this.phoneLbl.TabIndex = 6;
            this.phoneLbl.Text = "טלפון";
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.Location = new System.Drawing.Point(260, 38);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.Size = new System.Drawing.Size(199, 20);
            this.emailTxtBox.TabIndex = 9;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(202, 41);
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
            this.saveBtn.TabIndex = 20;
            this.saveBtn.Text = "שמור";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // ClearFieldsBtn
            // 
            this.ClearFieldsBtn.Location = new System.Drawing.Point(248, 71);
            this.ClearFieldsBtn.Name = "ClearFieldsBtn";
            this.ClearFieldsBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearFieldsBtn.TabIndex = 21;
            this.ClearFieldsBtn.Text = "נקה";
            this.ClearFieldsBtn.UseVisualStyleBackColor = true;
            this.ClearFieldsBtn.Click += new System.EventHandler(this.ClearFieldsBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "שמור והוסף פרוייקט";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
    }
}