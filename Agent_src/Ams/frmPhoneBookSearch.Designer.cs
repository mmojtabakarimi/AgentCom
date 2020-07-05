namespace AgentCom
{
    partial class frmPhoneBookSearch
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
            this.btnDial = new System.Windows.Forms.Button();
            this.dgvPhoneBookSearch = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPhonBookSearch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchByName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchByPhone = new System.Windows.Forms.TextBox();
            this.txtSearchByJob = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEditFromSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneBookSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDial
            // 
            this.btnDial.Location = new System.Drawing.Point(2, 388);
            this.btnDial.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDial.Name = "btnDial";
            this.btnDial.Size = new System.Drawing.Size(101, 34);
            this.btnDial.TabIndex = 4;
            this.btnDial.Text = "شماره  گیری";
            this.btnDial.UseVisualStyleBackColor = true;
            this.btnDial.Click += new System.EventHandler(this.btnDial_Click);
            // 
            // dgvPhoneBookSearch
            // 
            this.dgvPhoneBookSearch.AllowUserToAddRows = false;
            this.dgvPhoneBookSearch.AllowUserToDeleteRows = false;
            this.dgvPhoneBookSearch.AllowUserToResizeColumns = false;
            this.dgvPhoneBookSearch.AllowUserToResizeRows = false;
            this.dgvPhoneBookSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhoneBookSearch.Location = new System.Drawing.Point(6, 10);
            this.dgvPhoneBookSearch.Name = "dgvPhoneBookSearch";
            this.dgvPhoneBookSearch.Size = new System.Drawing.Size(720, 352);
            this.dgvPhoneBookSearch.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPhonBookSearch);
            this.groupBox1.Controls.Add(this.dgvPhoneBookSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 368);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblPhonBookSearch
            // 
            this.lblPhonBookSearch.AutoSize = true;
            this.lblPhonBookSearch.Location = new System.Drawing.Point(43, 0);
            this.lblPhonBookSearch.Name = "lblPhonBookSearch";
            this.lblPhonBookSearch.Size = new System.Drawing.Size(15, 16);
            this.lblPhonBookSearch.TabIndex = 6;
            this.lblPhonBookSearch.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "جستجو : ";
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Location = new System.Drawing.Point(320, 386);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.Size = new System.Drawing.Size(223, 23);
            this.txtSearchByName.TabIndex = 9;
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtPhoneBookSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(585, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "نام";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(558, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "شماره تلفن";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(563, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "تخصص";
            // 
            // txtSearchByPhone
            // 
            this.txtSearchByPhone.Location = new System.Drawing.Point(320, 415);
            this.txtSearchByPhone.Name = "txtSearchByPhone";
            this.txtSearchByPhone.Size = new System.Drawing.Size(223, 23);
            this.txtSearchByPhone.TabIndex = 9;
            this.txtSearchByPhone.TextChanged += new System.EventHandler(this.txtPhoneBookSearch_TextChanged);
            // 
            // txtSearchByJob
            // 
            this.txtSearchByJob.Location = new System.Drawing.Point(320, 444);
            this.txtSearchByJob.Name = "txtSearchByJob";
            this.txtSearchByJob.Size = new System.Drawing.Size(223, 23);
            this.txtSearchByJob.TabIndex = 9;
            this.txtSearchByJob.TextChanged += new System.EventHandler(this.txtPhoneBookSearch_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(2, 440);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 34);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEditFromSearch
            // 
            this.btnEditFromSearch.Location = new System.Drawing.Point(170, 409);
            this.btnEditFromSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnEditFromSearch.Name = "btnEditFromSearch";
            this.btnEditFromSearch.Size = new System.Drawing.Size(101, 34);
            this.btnEditFromSearch.TabIndex = 4;
            this.btnEditFromSearch.Text = "ویرایش";
            this.btnEditFromSearch.UseVisualStyleBackColor = true;
            this.btnEditFromSearch.Click += new System.EventHandler(this.btnEditFromSearch_Click);
            // 
            // frmPhoneBookSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 492);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchByJob);
            this.Controls.Add(this.txtSearchByPhone);
            this.Controls.Add(this.txtSearchByName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEditFromSearch);
            this.Controls.Add(this.btnDial);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPhoneBookSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "دفترچه  تلفن";
            this.Load += new System.EventHandler(this.frmPhoneBookSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneBookSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDial;
        private System.Windows.Forms.DataGridView dgvPhoneBookSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPhonBookSearch;
        private System.Windows.Forms.TextBox txtSearchByName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchByPhone;
        private System.Windows.Forms.TextBox txtSearchByJob;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEditFromSearch;
    }
}