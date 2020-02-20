namespace AgentCom
{
    partial class frmAdvanceSetting
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblDatabaseVersion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAttachDatabase = new System.Windows.Forms.Button();
            this.tbnRefresh = new System.Windows.Forms.Button();
            this.chklstDatabse = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tbInsertDtu = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSumDtuRecord = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDtuRecorcCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.prgDtu = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDtuName = new System.Windows.Forms.Label();
            this.btnDtuInsertStart = new System.Windows.Forms.Button();
            this.btnDeleteDtu = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.chklstDtuFile = new System.Windows.Forms.CheckedListBox();
            this.tbSyncDatabseAndSystem = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnStartSyncDb = new System.Windows.Forms.Button();
            this.btnSelectCfgFile = new System.Windows.Forms.Button();
            this.btnDeselectfile = new System.Windows.Forms.Button();
            this.chklstCfgFileList = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tbInsertDtu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbSyncDatabseAndSystem.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(5, 565);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "خروج";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tbInsertDtu);
            this.tabControl1.Controls.Add(this.tbSyncDatabseAndSystem);
            this.tabControl1.Location = new System.Drawing.Point(-1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 561);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblDatabaseVersion);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btnAttachDatabase);
            this.tabPage1.Controls.Add(this.tbnRefresh);
            this.tabPage1.Controls.Add(this.chklstDatabse);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(689, 532);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "مدیریت بانکهای اطلاعاتی";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblDatabaseVersion
            // 
            this.lblDatabaseVersion.AutoSize = true;
            this.lblDatabaseVersion.Location = new System.Drawing.Point(466, 328);
            this.lblDatabaseVersion.Name = "lblDatabaseVersion";
            this.lblDatabaseVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDatabaseVersion.Size = new System.Drawing.Size(0, 16);
            this.lblDatabaseVersion.TabIndex = 6;
            this.lblDatabaseVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(564, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "ورژن بانک اطلاعاتی :";
            // 
            // btnAttachDatabase
            // 
            this.btnAttachDatabase.Location = new System.Drawing.Point(505, 269);
            this.btnAttachDatabase.Name = "btnAttachDatabase";
            this.btnAttachDatabase.Size = new System.Drawing.Size(170, 25);
            this.btnAttachDatabase.TabIndex = 4;
            this.btnAttachDatabase.Text = "جایگزینی بانک اطلاعاتی ...";
            this.btnAttachDatabase.UseVisualStyleBackColor = true;
            // 
            // tbnRefresh
            // 
            this.tbnRefresh.Location = new System.Drawing.Point(505, 300);
            this.tbnRefresh.Name = "tbnRefresh";
            this.tbnRefresh.Size = new System.Drawing.Size(166, 25);
            this.tbnRefresh.TabIndex = 3;
            this.tbnRefresh.Text = "بروز رسانی ";
            this.tbnRefresh.UseVisualStyleBackColor = true;
            // 
            // chklstDatabse
            // 
            this.chklstDatabse.FormattingEnabled = true;
            this.chklstDatabse.Location = new System.Drawing.Point(501, 55);
            this.chklstDatabse.Name = "chklstDatabse";
            this.chklstDatabse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chklstDatabse.Size = new System.Drawing.Size(170, 202);
            this.chklstDatabse.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "لیست بانکهای در حال کار :";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(678, 532);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "مدیریت سرور";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox2);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btnSend);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage3.Size = new System.Drawing.Size(678, 532);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ارسال اطلاعات به سریال پورت";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(110, 80);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(301, 160);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "RxData :";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(436, 26);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 25);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tx Data:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(110, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(301, 23);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tbInsertDtu
            // 
            this.tbInsertDtu.Controls.Add(this.groupBox1);
            this.tbInsertDtu.Controls.Add(this.btnDeleteDtu);
            this.tbInsertDtu.Controls.Add(this.btnSelectFile);
            this.tbInsertDtu.Controls.Add(this.chklstDtuFile);
            this.tbInsertDtu.Location = new System.Drawing.Point(4, 25);
            this.tbInsertDtu.Name = "tbInsertDtu";
            this.tbInsertDtu.Padding = new System.Windows.Forms.Padding(3);
            this.tbInsertDtu.Size = new System.Drawing.Size(678, 532);
            this.tbInsertDtu.TabIndex = 3;
            this.tbInsertDtu.Text = "وارد کردن شارژینگ";
            this.tbInsertDtu.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSumDtuRecord);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblDtuRecorcCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.prgDtu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblDtuName);
            this.groupBox1.Controls.Add(this.btnDtuInsertStart);
            this.groupBox1.Location = new System.Drawing.Point(6, 368);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 145);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblSumDtuRecord
            // 
            this.lblSumDtuRecord.AutoSize = true;
            this.lblSumDtuRecord.Location = new System.Drawing.Point(31, 56);
            this.lblSumDtuRecord.Name = "lblSumDtuRecord";
            this.lblSumDtuRecord.Size = new System.Drawing.Size(0, 16);
            this.lblSumDtuRecord.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "تعداد کل رکوردها :";
            // 
            // lblDtuRecorcCount
            // 
            this.lblDtuRecorcCount.AutoSize = true;
            this.lblDtuRecorcCount.Location = new System.Drawing.Point(437, 48);
            this.lblDtuRecorcCount.Name = "lblDtuRecorcCount";
            this.lblDtuRecorcCount.Size = new System.Drawing.Size(0, 16);
            this.lblDtuRecorcCount.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "تعداد رکورد:";
            // 
            // prgDtu
            // 
            this.prgDtu.Location = new System.Drawing.Point(20, 82);
            this.prgDtu.Name = "prgDtu";
            this.prgDtu.Size = new System.Drawing.Size(550, 23);
            this.prgDtu.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(519, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "نام فایل :";
            // 
            // lblDtuName
            // 
            this.lblDtuName.AutoSize = true;
            this.lblDtuName.Location = new System.Drawing.Point(20, 33);
            this.lblDtuName.Name = "lblDtuName";
            this.lblDtuName.Size = new System.Drawing.Size(0, 16);
            this.lblDtuName.TabIndex = 2;
            // 
            // btnDtuInsertStart
            // 
            this.btnDtuInsertStart.Location = new System.Drawing.Point(576, 82);
            this.btnDtuInsertStart.Name = "btnDtuInsertStart";
            this.btnDtuInsertStart.Size = new System.Drawing.Size(75, 23);
            this.btnDtuInsertStart.TabIndex = 0;
            this.btnDtuInsertStart.Text = "شـروع";
            this.btnDtuInsertStart.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDtu
            // 
            this.btnDeleteDtu.Location = new System.Drawing.Point(34, 339);
            this.btnDeleteDtu.Name = "btnDeleteDtu";
            this.btnDeleteDtu.Size = new System.Drawing.Size(109, 23);
            this.btnDeleteDtu.TabIndex = 2;
            this.btnDeleteDtu.Text = "حذف فـایل";
            this.btnDeleteDtu.UseVisualStyleBackColor = true;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(146, 339);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(118, 23);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "انتخاب فایل ...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            // 
            // chklstDtuFile
            // 
            this.chklstDtuFile.FormattingEnabled = true;
            this.chklstDtuFile.Location = new System.Drawing.Point(14, 6);
            this.chklstDtuFile.Name = "chklstDtuFile";
            this.chklstDtuFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chklstDtuFile.Size = new System.Drawing.Size(658, 310);
            this.chklstDtuFile.TabIndex = 0;
            // 
            // tbSyncDatabseAndSystem
            // 
            this.tbSyncDatabseAndSystem.Controls.Add(this.groupBox2);
            this.tbSyncDatabseAndSystem.Controls.Add(this.btnSelectCfgFile);
            this.tbSyncDatabseAndSystem.Controls.Add(this.btnDeselectfile);
            this.tbSyncDatabseAndSystem.Controls.Add(this.chklstCfgFileList);
            this.tbSyncDatabseAndSystem.Location = new System.Drawing.Point(4, 25);
            this.tbSyncDatabseAndSystem.Name = "tbSyncDatabseAndSystem";
            this.tbSyncDatabseAndSystem.Size = new System.Drawing.Size(678, 532);
            this.tbSyncDatabseAndSystem.TabIndex = 4;
            this.tbSyncDatabseAndSystem.Text = "همزمانی دیتابیس با سیستم";
            this.tbSyncDatabseAndSystem.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnStartSyncDb);
            this.groupBox2.Location = new System.Drawing.Point(6, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(666, 145);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 16);
            this.label11.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(437, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 16);
            this.label12.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 82);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(550, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(519, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "نام فایل :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 16);
            this.label13.TabIndex = 2;
            // 
            // btnStartSyncDb
            // 
            this.btnStartSyncDb.Location = new System.Drawing.Point(576, 82);
            this.btnStartSyncDb.Name = "btnStartSyncDb";
            this.btnStartSyncDb.Size = new System.Drawing.Size(75, 23);
            this.btnStartSyncDb.TabIndex = 0;
            this.btnStartSyncDb.Text = "شـروع";
            this.btnStartSyncDb.UseVisualStyleBackColor = true;
            // 
            // btnSelectCfgFile
            // 
            this.btnSelectCfgFile.Location = new System.Drawing.Point(495, 267);
            this.btnSelectCfgFile.Name = "btnSelectCfgFile";
            this.btnSelectCfgFile.Size = new System.Drawing.Size(119, 23);
            this.btnSelectCfgFile.TabIndex = 2;
            this.btnSelectCfgFile.Text = "انتخاب فایل..";
            this.btnSelectCfgFile.UseVisualStyleBackColor = true;
            // 
            // btnDeselectfile
            // 
            this.btnDeselectfile.Location = new System.Drawing.Point(414, 267);
            this.btnDeselectfile.Name = "btnDeselectfile";
            this.btnDeselectfile.Size = new System.Drawing.Size(75, 23);
            this.btnDeselectfile.TabIndex = 1;
            this.btnDeselectfile.Text = "حذف فایل";
            this.btnDeselectfile.UseVisualStyleBackColor = true;
            // 
            // chklstCfgFileList
            // 
            this.chklstCfgFileList.FormattingEnabled = true;
            this.chklstCfgFileList.Location = new System.Drawing.Point(3, 3);
            this.chklstCfgFileList.Name = "chklstCfgFileList";
            this.chklstCfgFileList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chklstCfgFileList.Size = new System.Drawing.Size(645, 220);
            this.chklstCfgFileList.TabIndex = 0;
            // 
            // frmAdvanceSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 600);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAdvanceSetting";
            this.Text = "تنظیمات پیشرفته";
            this.Load += new System.EventHandler(this.frmAdvanceSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tbInsertDtu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbSyncDatabseAndSystem.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblDatabaseVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAttachDatabase;
        private System.Windows.Forms.Button tbnRefresh;
        private System.Windows.Forms.CheckedListBox chklstDatabse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tbInsertDtu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSumDtuRecord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDtuRecorcCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar prgDtu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDtuName;
        private System.Windows.Forms.Button btnDtuInsertStart;
        private System.Windows.Forms.Button btnDeleteDtu;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.CheckedListBox chklstDtuFile;
        private System.Windows.Forms.TabPage tbSyncDatabseAndSystem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnStartSyncDb;
        private System.Windows.Forms.Button btnSelectCfgFile;
        private System.Windows.Forms.Button btnDeselectfile;
        private System.Windows.Forms.CheckedListBox chklstCfgFileList;
    }
}