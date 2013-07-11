namespace Billing
{
    partial class ClientTypeForm
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clientTypetxtBox = new System.Windows.Forms.TextBox();
            this.ClientCodeTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(303, 87);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "שמור";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "סוג לקוח";
            // 
            // clientTypetxtBox
            // 
            this.clientTypetxtBox.Location = new System.Drawing.Point(200, 9);
            this.clientTypetxtBox.Name = "clientTypetxtBox";
            this.clientTypetxtBox.Size = new System.Drawing.Size(100, 20);
            this.clientTypetxtBox.TabIndex = 2;
            // 
            // ClientCodeTxtBox
            // 
            this.ClientCodeTxtBox.Enabled = false;
            this.ClientCodeTxtBox.Location = new System.Drawing.Point(200, 36);
            this.ClientCodeTxtBox.Name = "ClientCodeTxtBox";
            this.ClientCodeTxtBox.Size = new System.Drawing.Size(100, 20);
            this.ClientCodeTxtBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "קוד לקוח";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(222, 87);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "בטל";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ClientTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 134);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.ClientCodeTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clientTypetxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBtn);
            this.Name = "ClientTypeForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ClientTypeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox clientTypetxtBox;
        private System.Windows.Forms.TextBox ClientCodeTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelBtn;
    }
}