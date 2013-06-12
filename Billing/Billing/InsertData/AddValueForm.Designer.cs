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
            this.ValuesCollection = new System.Windows.Forms.TableLayoutPanel();
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
            this.valueComboBox.Size = new System.Drawing.Size(408, 21);
            this.valueComboBox.TabIndex = 72;
            this.valueComboBox.SelectionChangeCommitted += new System.EventHandler(this.valueComboBox_SelectionChangeCommitted);
            // 
            // valuelbl
            // 
            this.valuelbl.AutoSize = true;
            this.valuelbl.Location = new System.Drawing.Point(426, 15);
            this.valuelbl.Name = "valuelbl";
            this.valuelbl.Size = new System.Drawing.Size(82, 13);
            this.valuelbl.TabIndex = 73;
            this.valuelbl.Text = "חישוב התמורה";
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(132, 338);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(75, 23);
            this.selectBtn.TabIndex = 74;
            this.selectBtn.Text = "בחר";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // ValuesCollection
            // 
            this.ValuesCollection.AutoScroll = true;
            this.ValuesCollection.ColumnCount = 5;
            this.ValuesCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesCollection.Location = new System.Drawing.Point(12, 39);
            this.ValuesCollection.Name = "ValuesCollection";
            this.ValuesCollection.RowCount = 2;
            this.ValuesCollection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesCollection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesCollection.Size = new System.Drawing.Size(496, 136);
            this.ValuesCollection.TabIndex = 145;
            // 
            // AddValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 380);
            this.Controls.Add(this.ValuesCollection);
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
        private System.Windows.Forms.TableLayoutPanel ValuesCollection;
    }
}