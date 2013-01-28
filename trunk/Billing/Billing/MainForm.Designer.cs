namespace Billing
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.EditDataTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAddContract = new System.Windows.Forms.Button();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnAddBill = new System.Windows.Forms.Button();
            this.AddDataTab = new System.Windows.Forms.TabPage();
            this.searchLbl = new System.Windows.Forms.Label();
            this.searchTxtBox = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabControl1.SuspendLayout();
            this.EditDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.AddDataTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AddDataTab);
            this.tabControl1.Controls.Add(this.EditDataTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1039, 607);
            this.tabControl1.TabIndex = 0;
            // 
            // EditDataTab
            // 
            this.EditDataTab.BackColor = System.Drawing.SystemColors.Control;
            this.EditDataTab.Controls.Add(this.listView1);
            this.EditDataTab.Controls.Add(this.searchBtn);
            this.EditDataTab.Controls.Add(this.searchTxtBox);
            this.EditDataTab.Controls.Add(this.searchLbl);
            this.EditDataTab.Location = new System.Drawing.Point(4, 22);
            this.EditDataTab.Name = "EditDataTab";
            this.EditDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.EditDataTab.Size = new System.Drawing.Size(1031, 581);
            this.EditDataTab.TabIndex = 1;
            this.EditDataTab.Text = "עריכה וחיפוש";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(8, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.btnAddBill);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddClient);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddProject);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddContract);
            this.splitContainer1.Size = new System.Drawing.Size(1015, 569);
            this.splitContainer1.SplitterDistance = 879;
            this.splitContainer1.TabIndex = 8;
            // 
            // btnAddContract
            // 
            this.btnAddContract.Location = new System.Drawing.Point(15, 74);
            this.btnAddContract.Name = "btnAddContract";
            this.btnAddContract.Size = new System.Drawing.Size(103, 23);
            this.btnAddContract.TabIndex = 6;
            this.btnAddContract.Text = "הוסף חוזה";
            this.btnAddContract.UseVisualStyleBackColor = true;
            this.btnAddContract.Click += new System.EventHandler(this.btnAddContract_Click);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(15, 45);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(103, 23);
            this.btnAddProject.TabIndex = 5;
            this.btnAddProject.Text = "הוסף פרוייקט";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(15, 16);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(103, 23);
            this.btnAddClient.TabIndex = 4;
            this.btnAddClient.Text = "הוסף לקוח";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnAddBill
            // 
            this.btnAddBill.Location = new System.Drawing.Point(15, 103);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(103, 23);
            this.btnAddBill.TabIndex = 7;
            this.btnAddBill.Text = "הוסף חשבון";
            this.btnAddBill.UseVisualStyleBackColor = true;
            this.btnAddBill.Click += new System.EventHandler(this.btnAddBill_Click);
            // 
            // AddDataTab
            // 
            this.AddDataTab.AutoScroll = true;
            this.AddDataTab.BackColor = System.Drawing.SystemColors.Control;
            this.AddDataTab.Controls.Add(this.splitContainer1);
            this.AddDataTab.Location = new System.Drawing.Point(4, 22);
            this.AddDataTab.Name = "AddDataTab";
            this.AddDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.AddDataTab.Size = new System.Drawing.Size(1031, 581);
            this.AddDataTab.TabIndex = 0;
            this.AddDataTab.Text = "הוספת לקוחות, פרוייקטים, חוזים וחשבונות";
            // 
            // searchLbl
            // 
            this.searchLbl.AutoSize = true;
            this.searchLbl.Location = new System.Drawing.Point(988, 13);
            this.searchLbl.Name = "searchLbl";
            this.searchLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.searchLbl.Size = new System.Drawing.Size(33, 13);
            this.searchLbl.TabIndex = 0;
            this.searchLbl.Text = "חפש:";
            // 
            // searchTxtBox
            // 
            this.searchTxtBox.Location = new System.Drawing.Point(790, 10);
            this.searchTxtBox.Name = "searchTxtBox";
            this.searchTxtBox.Size = new System.Drawing.Size(192, 20);
            this.searchTxtBox.TabIndex = 1;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(709, 8);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "חפש";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(361, 10);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listView1.RightToLeftLayout = true;
            this.listView1.Size = new System.Drawing.Size(342, 211);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 607);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.EditDataTab.ResumeLayout(false);
            this.EditDataTab.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.AddDataTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage EditDataTab;
        private System.Windows.Forms.TabPage AddDataTab;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAddBill;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnAddContract;
        private System.Windows.Forms.Label searchLbl;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchTxtBox;
    }
}