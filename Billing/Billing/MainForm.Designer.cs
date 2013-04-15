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
            this.AddDataTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAddBill = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.btnAddContract = new System.Windows.Forms.Button();
            this.EditDataTab = new System.Windows.Forms.TabPage();
            this.searchSplit = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.searchTxtBox = new System.Windows.Forms.TextBox();
            this.searchLbl = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.TabPage();
            this.maamBtn = new System.Windows.Forms.Button();
            this.maamSettingsTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.DBPathTxt = new System.Windows.Forms.TextBox();
            this.DBPathFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.billsPathBtn = new System.Windows.Forms.Button();
            this.billsPathTxt = new System.Windows.Forms.TextBox();
            this.billsFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.AddDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.EditDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchSplit)).BeginInit();
            this.searchSplit.Panel2.SuspendLayout();
            this.searchSplit.SuspendLayout();
            this.Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AddDataTab);
            this.tabControl1.Controls.Add(this.EditDataTab);
            this.tabControl1.Controls.Add(this.Settings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1100, 762);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // AddDataTab
            // 
            this.AddDataTab.AutoScroll = true;
            this.AddDataTab.BackColor = System.Drawing.SystemColors.Control;
            this.AddDataTab.Controls.Add(this.splitContainer1);
            this.AddDataTab.Location = new System.Drawing.Point(4, 22);
            this.AddDataTab.Name = "AddDataTab";
            this.AddDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.AddDataTab.Size = new System.Drawing.Size(1092, 736);
            this.AddDataTab.TabIndex = 0;
            this.AddDataTab.Text = "הוספת לקוחות, פרוייקטים, חוזים וחשבונות";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.btnAddBill);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddClient);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddProject);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddContract);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1086, 730);
            this.splitContainer1.SplitterDistance = 940;
            this.splitContainer1.TabIndex = 8;
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
            // EditDataTab
            // 
            this.EditDataTab.BackColor = System.Drawing.SystemColors.Control;
            this.EditDataTab.Controls.Add(this.searchSplit);
            this.EditDataTab.Location = new System.Drawing.Point(4, 22);
            this.EditDataTab.Name = "EditDataTab";
            this.EditDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.EditDataTab.Size = new System.Drawing.Size(1092, 736);
            this.EditDataTab.TabIndex = 1;
            this.EditDataTab.Text = "עריכה וחיפוש";
            // 
            // searchSplit
            // 
            this.searchSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchSplit.Location = new System.Drawing.Point(3, 3);
            this.searchSplit.Name = "searchSplit";
            // 
            // searchSplit.Panel1
            // 
            this.searchSplit.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // searchSplit.Panel2
            // 
            this.searchSplit.Panel2.Controls.Add(this.listBox1);
            this.searchSplit.Panel2.Controls.Add(this.searchTxtBox);
            this.searchSplit.Panel2.Controls.Add(this.searchLbl);
            this.searchSplit.Panel2.Controls.Add(this.searchBtn);
            this.searchSplit.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.searchSplit.Size = new System.Drawing.Size(1086, 730);
            this.searchSplit.SplitterDistance = 706;
            this.searchSplit.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(16, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(309, 446);
            this.listBox1.TabIndex = 4;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // searchTxtBox
            // 
            this.searchTxtBox.Location = new System.Drawing.Point(97, 13);
            this.searchTxtBox.Name = "searchTxtBox";
            this.searchTxtBox.Size = new System.Drawing.Size(192, 20);
            this.searchTxtBox.TabIndex = 1;
            // 
            // searchLbl
            // 
            this.searchLbl.AutoSize = true;
            this.searchLbl.Location = new System.Drawing.Point(295, 16);
            this.searchLbl.Name = "searchLbl";
            this.searchLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.searchLbl.Size = new System.Drawing.Size(33, 13);
            this.searchLbl.TabIndex = 0;
            this.searchLbl.Text = "חפש:";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(16, 11);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "חפש";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.billsPathBtn);
            this.Settings.Controls.Add(this.billsPathTxt);
            this.Settings.Controls.Add(this.maamBtn);
            this.Settings.Controls.Add(this.maamSettingsTxt);
            this.Settings.Controls.Add(this.button1);
            this.Settings.Controls.Add(this.DBPathTxt);
            this.Settings.Location = new System.Drawing.Point(4, 22);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Settings.Size = new System.Drawing.Size(1092, 736);
            this.Settings.TabIndex = 2;
            this.Settings.Text = "הגדרות";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // maamBtn
            // 
            this.maamBtn.Enabled = false;
            this.maamBtn.Location = new System.Drawing.Point(381, 55);
            this.maamBtn.Name = "maamBtn";
            this.maamBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.maamBtn.Size = new System.Drawing.Size(162, 23);
            this.maamBtn.TabIndex = 3;
            this.maamBtn.Text = "שנה מע\"מ";
            this.maamBtn.UseVisualStyleBackColor = true;
            this.maamBtn.Click += new System.EventHandler(this.maamBtn_Click);
            // 
            // maamSettingsTxt
            // 
            this.maamSettingsTxt.Location = new System.Drawing.Point(9, 57);
            this.maamSettingsTxt.Name = "maamSettingsTxt";
            this.maamSettingsTxt.Size = new System.Drawing.Size(366, 20);
            this.maamSettingsTxt.TabIndex = 2;
            this.maamSettingsTxt.TextChanged += new System.EventHandler(this.maamSettingsTxt_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 26);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "בחר נתיב DB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DBPathTxt
            // 
            this.DBPathTxt.Location = new System.Drawing.Point(9, 28);
            this.DBPathTxt.Name = "DBPathTxt";
            this.DBPathTxt.Size = new System.Drawing.Size(366, 20);
            this.DBPathTxt.TabIndex = 0;
            // 
            // billsPathBtn
            // 
            this.billsPathBtn.Location = new System.Drawing.Point(381, 84);
            this.billsPathBtn.Name = "billsPathBtn";
            this.billsPathBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.billsPathBtn.Size = new System.Drawing.Size(162, 23);
            this.billsPathBtn.TabIndex = 5;
            this.billsPathBtn.Text = "בחר נתיב למסמכי חשבונות";
            this.billsPathBtn.UseVisualStyleBackColor = true;
            this.billsPathBtn.Click += new System.EventHandler(this.billsPathBtn_Click);
            // 
            // billsPathTxt
            // 
            this.billsPathTxt.Location = new System.Drawing.Point(9, 86);
            this.billsPathTxt.Name = "billsPathTxt";
            this.billsPathTxt.Size = new System.Drawing.Size(366, 20);
            this.billsPathTxt.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1100, 762);
            this.Controls.Add(this.tabControl1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "יריב הנדסה";
            this.tabControl1.ResumeLayout(false);
            this.AddDataTab.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.EditDataTab.ResumeLayout(false);
            this.searchSplit.Panel2.ResumeLayout(false);
            this.searchSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchSplit)).EndInit();
            this.searchSplit.ResumeLayout(false);
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
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
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchTxtBox;
        private System.Windows.Forms.SplitContainer searchSplit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox DBPathTxt;
        private System.Windows.Forms.OpenFileDialog DBPathFileDialog;
        private System.Windows.Forms.TextBox maamSettingsTxt;
        private System.Windows.Forms.Button maamBtn;
        private System.Windows.Forms.Button billsPathBtn;
        private System.Windows.Forms.TextBox billsPathTxt;
        private System.Windows.Forms.FolderBrowserDialog billsFolderDialog;
    }
}