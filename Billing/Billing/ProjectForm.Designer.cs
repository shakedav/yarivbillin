namespace Billing
{
    partial class ProjectForm
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
            this.projectCodeLbl = new System.Windows.Forms.Label();
            this.projectNameLbl = new System.Windows.Forms.Label();
            this.projectCodeInviterTxtBox = new System.Windows.Forms.TextBox();
            this.projectCodeInviterLbl = new System.Windows.Forms.Label();
            this.projectNameInviterTxtBox = new System.Windows.Forms.TextBox();
            this.projectNameInviterLbl = new System.Windows.Forms.Label();
            this.contactManTxtBox = new System.Windows.Forms.TextBox();
            this.contactManLbl = new System.Windows.Forms.Label();
            this.projectCodetxtBox = new System.Windows.Forms.TextBox();
            this.projectNametxtBox = new System.Windows.Forms.TextBox();
            this.projectDescriptiontxtBox = new System.Windows.Forms.TextBox();
            this.projectDescriptionlbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ClearFieldsBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.clientNamelbl = new System.Windows.Forms.Label();
            this.clientNameComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // projectCodeLbl
            // 
            this.projectCodeLbl.AutoSize = true;
            this.projectCodeLbl.Location = new System.Drawing.Point(484, 41);
            this.projectCodeLbl.Name = "projectCodeLbl";
            this.projectCodeLbl.Size = new System.Drawing.Size(71, 13);
            this.projectCodeLbl.TabIndex = 23;
            this.projectCodeLbl.Text = "קוד פרוייקט";
            // 
            // projectNameLbl
            // 
            this.projectNameLbl.AutoSize = true;
            this.projectNameLbl.Location = new System.Drawing.Point(480, 67);
            this.projectNameLbl.Name = "projectNameLbl";
            this.projectNameLbl.Size = new System.Drawing.Size(75, 13);
            this.projectNameLbl.TabIndex = 25;
            this.projectNameLbl.Text = "שם הפרוייקט\r\n";
            // 
            // projectCodeInviterTxtBox
            // 
            this.projectCodeInviterTxtBox.Location = new System.Drawing.Point(89, 117);
            this.projectCodeInviterTxtBox.Name = "projectCodeInviterTxtBox";
            this.projectCodeInviterTxtBox.Size = new System.Drawing.Size(296, 20);
            this.projectCodeInviterTxtBox.TabIndex = 4;
            // 
            // projectCodeInviterLbl
            // 
            this.projectCodeInviterLbl.AutoSize = true;
            this.projectCodeInviterLbl.Location = new System.Drawing.Point(420, 120);
            this.projectCodeInviterLbl.Name = "projectCodeInviterLbl";
            this.projectCodeInviterLbl.Size = new System.Drawing.Size(135, 13);
            this.projectCodeInviterLbl.TabIndex = 31;
            this.projectCodeInviterLbl.Text = "קוד פרוייקט אצל המזמין";
            // 
            // projectNameInviterTxtBox
            // 
            this.projectNameInviterTxtBox.Location = new System.Drawing.Point(90, 143);
            this.projectNameInviterTxtBox.Name = "projectNameInviterTxtBox";
            this.projectNameInviterTxtBox.Size = new System.Drawing.Size(296, 20);
            this.projectNameInviterTxtBox.TabIndex = 5;
            // 
            // projectNameInviterLbl
            // 
            this.projectNameInviterLbl.AutoSize = true;
            this.projectNameInviterLbl.Location = new System.Drawing.Point(423, 146);
            this.projectNameInviterLbl.Name = "projectNameInviterLbl";
            this.projectNameInviterLbl.Size = new System.Drawing.Size(132, 13);
            this.projectNameInviterLbl.TabIndex = 29;
            this.projectNameInviterLbl.Text = "שם פרוייקט אצל המזמין";
            // 
            // contactManTxtBox
            // 
            this.contactManTxtBox.Location = new System.Drawing.Point(87, 91);
            this.contactManTxtBox.Name = "contactManTxtBox";
            this.contactManTxtBox.Size = new System.Drawing.Size(297, 20);
            this.contactManTxtBox.TabIndex = 3;
            // 
            // contactManLbl
            // 
            this.contactManLbl.AutoSize = true;
            this.contactManLbl.Location = new System.Drawing.Point(449, 94);
            this.contactManLbl.Name = "contactManLbl";
            this.contactManLbl.Size = new System.Drawing.Size(106, 13);
            this.contactManLbl.TabIndex = 27;
            this.contactManLbl.Text = "איש קשר בפרוייקט";
            // 
            // projectCodetxtBox
            // 
            this.projectCodetxtBox.Enabled = false;
            this.projectCodetxtBox.Location = new System.Drawing.Point(88, 38);
            this.projectCodetxtBox.Name = "projectCodetxtBox";
            this.projectCodetxtBox.Size = new System.Drawing.Size(296, 20);
            this.projectCodetxtBox.TabIndex = 1;
            // 
            // projectNametxtBox
            // 
            this.projectNametxtBox.Location = new System.Drawing.Point(89, 64);
            this.projectNametxtBox.Name = "projectNametxtBox";
            this.projectNametxtBox.Size = new System.Drawing.Size(297, 20);
            this.projectNametxtBox.TabIndex = 2;
            // 
            // projectDescriptiontxtBox
            // 
            this.projectDescriptiontxtBox.Location = new System.Drawing.Point(89, 169);
            this.projectDescriptiontxtBox.Name = "projectDescriptiontxtBox";
            this.projectDescriptiontxtBox.Size = new System.Drawing.Size(296, 20);
            this.projectDescriptiontxtBox.TabIndex = 6;
            // 
            // projectDescriptionlbl
            // 
            this.projectDescriptionlbl.AutoSize = true;
            this.projectDescriptionlbl.Location = new System.Drawing.Point(465, 169);
            this.projectDescriptionlbl.Name = "projectDescriptionlbl";
            this.projectDescriptionlbl.Size = new System.Drawing.Size(90, 13);
            this.projectDescriptionlbl.TabIndex = 33;
            this.projectDescriptionlbl.Text = "תיאור הפרוייקט";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "שמור והוסף פרוייקט";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ClearFieldsBtn
            // 
            this.ClearFieldsBtn.Location = new System.Drawing.Point(117, 248);
            this.ClearFieldsBtn.Name = "ClearFieldsBtn";
            this.ClearFieldsBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearFieldsBtn.TabIndex = 35;
            this.ClearFieldsBtn.Text = "נקה";
            this.ClearFieldsBtn.UseVisualStyleBackColor = true;
            this.ClearFieldsBtn.Click += new System.EventHandler(this.ClearAllFields);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(350, 248);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 34;
            this.saveBtn.Text = "שמור";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // clientNamelbl
            // 
            this.clientNamelbl.AutoSize = true;
            this.clientNamelbl.Location = new System.Drawing.Point(496, 15);
            this.clientNamelbl.Name = "clientNamelbl";
            this.clientNamelbl.Size = new System.Drawing.Size(59, 13);
            this.clientNamelbl.TabIndex = 38;
            this.clientNamelbl.Text = "שם הלקוח";
            // 
            // clientNameComboBox
            // 
            this.clientNameComboBox.FormattingEnabled = true;
            this.clientNameComboBox.Location = new System.Drawing.Point(90, 12);
            this.clientNameComboBox.Name = "clientNameComboBox";
            this.clientNameComboBox.Size = new System.Drawing.Size(294, 21);
            this.clientNameComboBox.TabIndex = 39;
            this.clientNameComboBox.Click += new System.EventHandler(this.clientNamecomboBox_Click);
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 283);
            this.Controls.Add(this.clientNameComboBox);
            this.Controls.Add(this.clientNamelbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ClearFieldsBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.projectDescriptiontxtBox);
            this.Controls.Add(this.projectDescriptionlbl);
            this.Controls.Add(this.projectNametxtBox);
            this.Controls.Add(this.projectCodetxtBox);
            this.Controls.Add(this.projectCodeInviterTxtBox);
            this.Controls.Add(this.projectCodeInviterLbl);
            this.Controls.Add(this.projectNameInviterTxtBox);
            this.Controls.Add(this.projectNameInviterLbl);
            this.Controls.Add(this.contactManTxtBox);
            this.Controls.Add(this.contactManLbl);
            this.Controls.Add(this.projectNameLbl);
            this.Controls.Add(this.projectCodeLbl);
            this.Name = "ProjectForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "פרוייקט";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label projectCodeLbl;
        private System.Windows.Forms.Label projectNameLbl;
        private System.Windows.Forms.TextBox projectCodeInviterTxtBox;
        private System.Windows.Forms.Label projectCodeInviterLbl;
        private System.Windows.Forms.TextBox projectNameInviterTxtBox;
        private System.Windows.Forms.Label projectNameInviterLbl;
        private System.Windows.Forms.TextBox contactManTxtBox;
        private System.Windows.Forms.Label contactManLbl;
        private System.Windows.Forms.TextBox projectCodetxtBox;
        private System.Windows.Forms.TextBox projectNametxtBox;
        private System.Windows.Forms.TextBox projectDescriptiontxtBox;
        private System.Windows.Forms.Label projectDescriptionlbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ClearFieldsBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label clientNamelbl;
        private System.Windows.Forms.ComboBox clientNameComboBox;
    }
}