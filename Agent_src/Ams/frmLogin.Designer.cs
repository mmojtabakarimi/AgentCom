namespace AgentCom
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAgentPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAgentNumber = new System.Windows.Forms.TextBox();
            this.chkLoginServerName = new System.Windows.Forms.CheckBox();
            this.txtLoginServerName = new System.Windows.Forms.TextBox();
            this.chkLoginServerIP = new System.Windows.Forms.CheckBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.frmLoginVersion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoginUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.epLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.pxDatabaseStatus = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDatabaseStart = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxDatabaseStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(142, 393);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "تاييد";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(37, 393);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "لغو ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "شماره:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.chkLoginServerName);
            this.groupBox2.Controls.Add(this.txtLoginServerName);
            this.groupBox2.Controls.Add(this.chkLoginServerIP);
            this.groupBox2.Controls.Add(this.txtServerPort);
            this.groupBox2.Controls.Add(this.txtServerIP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 182);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAgentPhone);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtAgentNumber);
            this.groupBox3.Location = new System.Drawing.Point(6, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 52);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "اپراتور";
            // 
            // txtAgentPhone
            // 
            this.txtAgentPhone.Location = new System.Drawing.Point(10, 19);
            this.txtAgentPhone.Name = "txtAgentPhone";
            this.txtAgentPhone.Size = new System.Drawing.Size(67, 23);
            this.txtAgentPhone.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "تلفن:";
            // 
            // txtAgentNumber
            // 
            this.txtAgentNumber.Location = new System.Drawing.Point(124, 19);
            this.txtAgentNumber.Name = "txtAgentNumber";
            this.txtAgentNumber.Size = new System.Drawing.Size(49, 23);
            this.txtAgentNumber.TabIndex = 0;
            // 
            // chkLoginServerName
            // 
            this.chkLoginServerName.AutoSize = true;
            this.chkLoginServerName.Location = new System.Drawing.Point(151, 26);
            this.chkLoginServerName.Name = "chkLoginServerName";
            this.chkLoginServerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLoginServerName.Size = new System.Drawing.Size(84, 20);
            this.chkLoginServerName.TabIndex = 5;
            this.chkLoginServerName.Text = "نام سرور :";
            this.chkLoginServerName.UseVisualStyleBackColor = true;
            this.chkLoginServerName.CheckedChanged += new System.EventHandler(this.chkLoginServerName_CheckedChanged);
            // 
            // txtLoginServerName
            // 
            this.txtLoginServerName.ForeColor = System.Drawing.Color.Red;
            this.txtLoginServerName.Location = new System.Drawing.Point(6, 22);
            this.txtLoginServerName.Name = "txtLoginServerName";
            this.txtLoginServerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLoginServerName.Size = new System.Drawing.Size(144, 23);
            this.txtLoginServerName.TabIndex = 6;
            // 
            // chkLoginServerIP
            // 
            this.chkLoginServerIP.AutoSize = true;
            this.chkLoginServerIP.Location = new System.Drawing.Point(157, 64);
            this.chkLoginServerIP.Name = "chkLoginServerIP";
            this.chkLoginServerIP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLoginServerIP.Size = new System.Drawing.Size(75, 20);
            this.chkLoginServerIP.TabIndex = 4;
            this.chkLoginServerIP.Text = "IP سرور:";
            this.chkLoginServerIP.UseVisualStyleBackColor = true;
            this.chkLoginServerIP.CheckedChanged += new System.EventHandler(this.chkLoginServerIP_CheckedChanged);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(68, 95);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(85, 23);
            this.txtServerPort.TabIndex = 0;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(41, 62);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServerIP.Size = new System.Drawing.Size(110, 23);
            this.txtServerIP.TabIndex = 0;
            this.txtServerIP.Text = "192.168.1.55";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "پورت :";
            // 
            // frmLoginVersion
            // 
            this.frmLoginVersion.AutoSize = true;
            this.frmLoginVersion.Location = new System.Drawing.Point(78, 79);
            this.frmLoginVersion.Name = "frmLoginVersion";
            this.frmLoginVersion.Size = new System.Drawing.Size(0, 16);
            this.frmLoginVersion.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "ورژن  :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoginUsername);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLoginPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.frmLoginVersion);
            this.groupBox1.Location = new System.Drawing.Point(9, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 100);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtLoginUsername.Location = new System.Drawing.Point(71, 18);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLoginUsername.Size = new System.Drawing.Size(83, 24);
            this.txtLoginUsername.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 21);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "نام کاربری :";
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtLoginPassword.Location = new System.Drawing.Point(71, 51);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLoginPassword.Size = new System.Drawing.Size(83, 24);
            this.txtLoginPassword.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 53);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "رمز ورود :";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(53, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 58);
            this.label5.TabIndex = 18;
            this.label5.Text = "براي ورود به سيستم ، ابتدا نام کاربري و رمز عبور خود را وارد نموده ، سپس گزینه تا" +
                "ييد را انتخاب نمایید.";
            // 
            // epLogin
            // 
            this.epLogin.ContainerControl = this;
            // 
            // pxDatabaseStatus
            // 
            this.pxDatabaseStatus.Image = global::AgentCom.Properties.Resources.stoped;
            this.pxDatabaseStatus.Location = new System.Drawing.Point(31, 167);
            this.pxDatabaseStatus.Name = "pxDatabaseStatus";
            this.pxDatabaseStatus.Size = new System.Drawing.Size(50, 43);
            this.pxDatabaseStatus.TabIndex = 6;
            this.pxDatabaseStatus.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AgentCom.Properties.Resources.icons8_database_administrator_40;
            this.pictureBox2.Location = new System.Drawing.Point(153, 167);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 43);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnDatabaseStart
            // 
            this.btnDatabaseStart.Location = new System.Drawing.Point(87, 175);
            this.btnDatabaseStart.Name = "btnDatabaseStart";
            this.btnDatabaseStart.Size = new System.Drawing.Size(60, 23);
            this.btnDatabaseStart.TabIndex = 4;
            this.btnDatabaseStart.Text = "start";
            this.btnDatabaseStart.UseVisualStyleBackColor = true;
            this.btnDatabaseStart.Click += new System.EventHandler(this.btnDatabaseStart_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 428);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnDatabaseStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pxDatabaseStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ورو به سيستم ";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Enter += new System.EventHandler(this.frmLogin_Enter);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxDatabaseStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLoginUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkLoginServerIP;
        private System.Windows.Forms.TextBox txtAgentNumber;
        private System.Windows.Forms.Label frmLoginVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider epLogin;
        private System.Windows.Forms.CheckBox chkLoginServerName;
        private System.Windows.Forms.TextBox txtLoginServerName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAgentPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pxDatabaseStatus;
        private System.Windows.Forms.Button btnDatabaseStart;
    }
}