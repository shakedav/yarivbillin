namespace Billing.InsertData
{
    partial class AddValueForm
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
            this.valueComboBox = new System.Windows.Forms.ComboBox();
            this.valuelbl = new System.Windows.Forms.Label();
            this.selectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // valueComboBox
            // 
            this.valueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.valueComboBox.FormattingEnabled = true;
            this.valueComboBox.Location = new System.Drawing.Point(12, 12);
            this.valueComboBox.Name = "valueComboBox";
            this.valueComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.valueComboBox.Size = new System.Drawing.Size(296, 21);
            this.valueComboBox.TabIndex = 72;
            // 
            // valuelbl
            // 
            this.valuelbl.AutoSize = true;
            this.valuelbl.Location = new System.Drawing.Point(329, 15);
            this.valuelbl.Name = "valuelbl";
            this.valuelbl.Size = new System.Drawing.Size(82, 13);
            this.valuelbl.TabIndex = 73;
            this.valuelbl.Text = "חישוב התמורה";
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(204, 63);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(75, 23);
            this.selectBtn.TabIndex = 74;
            this.selectBtn.Text = "בחר";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // AddValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 98);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.valueComboBox);
            this.Controls.Add(this.valuelbl);
            this.Name = "AddValueForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "הוסף תמורה";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox valueComboBox;
        private System.Windows.Forms.Label valuelbl;
        private System.Windows.Forms.Button selectBtn;
    }
}