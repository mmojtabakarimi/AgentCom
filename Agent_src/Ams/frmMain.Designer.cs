namespace AgentCom
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.SendDataTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMissedCall = new System.Windows.Forms.DataGridView();
            this.cmnKeyList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddKey = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteKey = new System.Windows.Forms.ToolStripMenuItem();
            this.imgState = new System.Windows.Forms.ImageList(this.components);
            this.cmnPhoneBook = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmDialPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.grpOpertorKeyPad = new System.Windows.Forms.GroupBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnControl = new System.Windows.Forms.Button();
            this.btnDial = new System.Windows.Forms.Button();
            this.txtOperatorDial = new System.Windows.Forms.TextBox();
            this.lblOperatorNumber = new System.Windows.Forms.Label();
            this.txtOperatorPanel = new System.Windows.Forms.TextBox();
            this.btnKey1 = new System.Windows.Forms.Button();
            this.btnRemoveHold = new System.Windows.Forms.Button();
            this.btnKey2 = new System.Windows.Forms.Button();
            this.btnAsterisk = new System.Windows.Forms.Button();
            this.btnKey4 = new System.Windows.Forms.Button();
            this.lblOpertorState = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnKey7 = new System.Windows.Forms.Button();
            this.btnKey6 = new System.Windows.Forms.Button();
            this.btnKey0 = new System.Windows.Forms.Button();
            this.btnPutHold = new System.Windows.Forms.Button();
            this.btnKey8 = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnNumlock = new System.Windows.Forms.Button();
            this.btnSlash = new System.Windows.Forms.Button();
            this.btnKey3 = new System.Windows.Forms.Button();
            this.btnKey5 = new System.Windows.Forms.Button();
            this.btnKey9 = new System.Windows.Forms.Button();
            this.btnOperatorState = new System.Windows.Forms.Button();
            this.lblTrunkAcdQeueCout = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvTrunkAcdQeue = new System.Windows.Forms.DataGridView();
            this.lblExtensionAcdQeueCout = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvExtensionAcdQeue = new System.Windows.Forms.DataGridView();
            this.lblExtensionHoldCout = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvTrunkHold = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTrunkHoldCout = new System.Windows.Forms.Label();
            this.dgvPhoneBook = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPhonebookCount = new System.Windows.Forms.Label();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdvanceSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iVRSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCDSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aCDReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tslIncallAnswered = new System.Windows.Forms.ToolStripMenuItem();
            this.tslInCallMissed = new System.Windows.Forms.ToolStripMenuItem();
            this.tslOutCall = new System.Windows.Forms.ToolStripMenuItem();
            this.tslAgentReportView = new System.Windows.Forms.ToolStripMenuItem();
            this.tslStatusView = new System.Windows.Forms.ToolStripMenuItem();
            this.tslExtensionPeriority = new System.Windows.Forms.ToolStripMenuItem();
            this.tslExtensionPeriorityAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tslExtensionPeriorityEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.speedDialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOperatorDayNight = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvAnsweredCall = new System.Windows.Forms.DataGridView();
            this.lblConectionState = new System.Windows.Forms.Label();
            this.tmrLivecheck = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.phoneBookImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissedCall)).BeginInit();
            this.cmnKeyList.SuspendLayout();
            this.cmnPhoneBook.SuspendLayout();
            this.grpOpertorKeyPad.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrunkAcdQeue)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtensionAcdQeue)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrunkHold)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneBook)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnsweredCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SendDataTimer
            // 
            this.SendDataTimer.Interval = 200;
            this.SendDataTimer.Tick += new System.EventHandler(this.SendDataTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMissedCall);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(18, 457);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(282, 118);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تماسهای از دست رفته";
            // 
            // dgvMissedCall
            // 
            this.dgvMissedCall.AllowUserToAddRows = false;
            this.dgvMissedCall.AllowUserToDeleteRows = false;
            this.dgvMissedCall.AllowUserToResizeColumns = false;
            this.dgvMissedCall.AllowUserToResizeRows = false;
            this.dgvMissedCall.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvMissedCall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMissedCall.Location = new System.Drawing.Point(6, 14);
            this.dgvMissedCall.Name = "dgvMissedCall";
            this.dgvMissedCall.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvMissedCall.Size = new System.Drawing.Size(270, 99);
            this.dgvMissedCall.TabIndex = 2;
            // 
            // cmnKeyList
            // 
            this.cmnKeyList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddKey,
            this.tsmDeleteKey});
            this.cmnKeyList.Name = "cmnKeyList";
            this.cmnKeyList.Size = new System.Drawing.Size(106, 48);
            // 
            // tsmAddKey
            // 
            this.tsmAddKey.Name = "tsmAddKey";
            this.tsmAddKey.Size = new System.Drawing.Size(105, 22);
            this.tsmAddKey.Text = "Add";
            this.tsmAddKey.Click += new System.EventHandler(this.tsmAddKey_Click);
            // 
            // tsmDeleteKey
            // 
            this.tsmDeleteKey.Name = "tsmDeleteKey";
            this.tsmDeleteKey.Size = new System.Drawing.Size(105, 22);
            this.tsmDeleteKey.Text = "Delete";
            // 
            // imgState
            // 
            this.imgState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgState.ImageStream")));
            this.imgState.TransparentColor = System.Drawing.Color.Transparent;
            this.imgState.Images.SetKeyName(0, "ExtFree.gif");
            this.imgState.Images.SetKeyName(1, "CoAccepted.gif");
            this.imgState.Images.SetKeyName(2, "CoBusy.gif");
            this.imgState.Images.SetKeyName(3, "CoDail.gif");
            this.imgState.Images.SetKeyName(4, "CoDisable.gif");
            this.imgState.Images.SetKeyName(5, "CoFree.gif");
            this.imgState.Images.SetKeyName(6, "CoRing.gif");
            this.imgState.Images.SetKeyName(7, "ExtAcceptCo.gif");
            this.imgState.Images.SetKeyName(8, "ExtBusy.gif");
            this.imgState.Images.SetKeyName(9, "ExtDial.gif");
            this.imgState.Images.SetKeyName(10, "ExtDialCo.gif");
            this.imgState.Images.SetKeyName(11, "ExtDisable.gif");
            this.imgState.Images.SetKeyName(12, "ExtIntra.gif");
            this.imgState.Images.SetKeyName(13, "ExtRing.gif");
            // 
            // cmnPhoneBook
            // 
            this.cmnPhoneBook.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnPhoneBook.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddPhone,
            this.tsmDelPhone,
            this.tsmEditPhone,
            this.toolStripSeparator2,
            this.tsmDialPhone,
            this.toolStripSeparator3,
            this.tsmSearch});
            this.cmnPhoneBook.Name = "cmnPhoneBook";
            this.cmnPhoneBook.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmnPhoneBook.Size = new System.Drawing.Size(144, 126);
            // 
            // tsmAddPhone
            // 
            this.tsmAddPhone.Name = "tsmAddPhone";
            this.tsmAddPhone.Size = new System.Drawing.Size(143, 22);
            this.tsmAddPhone.Text = "اضافه کردن";
            this.tsmAddPhone.Click += new System.EventHandler(this.tsmAddPhone_Click);
            // 
            // tsmDelPhone
            // 
            this.tsmDelPhone.Name = "tsmDelPhone";
            this.tsmDelPhone.Size = new System.Drawing.Size(143, 22);
            this.tsmDelPhone.Text = "حذف";
            this.tsmDelPhone.Click += new System.EventHandler(this.tsmDelPhone_Click);
            // 
            // tsmEditPhone
            // 
            this.tsmEditPhone.Name = "tsmEditPhone";
            this.tsmEditPhone.Size = new System.Drawing.Size(143, 22);
            this.tsmEditPhone.Text = "ویرایش";
            this.tsmEditPhone.Click += new System.EventHandler(this.tsmEditPhone_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // tsmDialPhone
            // 
            this.tsmDialPhone.Name = "tsmDialPhone";
            this.tsmDialPhone.Size = new System.Drawing.Size(143, 22);
            this.tsmDialPhone.Text = "شماره گیری";
            this.tsmDialPhone.Click += new System.EventHandler(this.tsmDialPhone_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(140, 6);
            // 
            // tsmSearch
            // 
            this.tsmSearch.Name = "tsmSearch";
            this.tsmSearch.Size = new System.Drawing.Size(143, 22);
            this.tsmSearch.Text = "جستجو....";
            this.tsmSearch.Click += new System.EventHandler(this.tsmSearch_Click);
            // 
            // grpOpertorKeyPad
            // 
            this.grpOpertorKeyPad.Controls.Add(this.lblDuration);
            this.grpOpertorKeyPad.Controls.Add(this.btnControl);
            this.grpOpertorKeyPad.Controls.Add(this.btnDial);
            this.grpOpertorKeyPad.Controls.Add(this.txtOperatorDial);
            this.grpOpertorKeyPad.Controls.Add(this.lblOperatorNumber);
            this.grpOpertorKeyPad.Controls.Add(this.txtOperatorPanel);
            this.grpOpertorKeyPad.Controls.Add(this.btnKey1);
            this.grpOpertorKeyPad.Controls.Add(this.btnRemoveHold);
            this.grpOpertorKeyPad.Controls.Add(this.btnKey2);
            this.grpOpertorKeyPad.Controls.Add(this.btnAsterisk);
            this.grpOpertorKeyPad.Controls.Add(this.btnKey4);
            this.grpOpertorKeyPad.Controls.Add(this.lblOpertorState);
            this.grpOpertorKeyPad.Controls.Add(this.btnDel);
            this.grpOpertorKeyPad.Controls.Add(this.btnKey7);
            this.grpOpertorKeyPad.Controls.Add(this.btnKey6);
            this.grpOpertorKeyPad.Controls.Add(this.btnKey0);
            this.grpOpertorKeyPad.Controls.Add(this.btnPutHold);
            this.grpOpertorKeyPad.Controls.Add(this.btnKey8);
            this.grpOpertorKeyPad.Controls.Add(this.btnEnter);
            this.grpOpertorKeyPad.Controls.Add(this.btnNumlock);
            this.grpOpertorKeyPad.Controls.Add(this.btnSlash);
            this.grpOpertorKeyPad.Controls.Add(this.btnKey3);
            this.grpOpertorKeyPad.Controls.Add(this.btnKey5);
            this.grpOpertorKeyPad.Controls.Add(this.btnKey9);
            this.grpOpertorKeyPad.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOpertorKeyPad.Location = new System.Drawing.Point(18, 84);
            this.grpOpertorKeyPad.Name = "grpOpertorKeyPad";
            this.grpOpertorKeyPad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpOpertorKeyPad.Size = new System.Drawing.Size(282, 367);
            this.grpOpertorKeyPad.TabIndex = 7;
            this.grpOpertorKeyPad.TabStop = false;
            this.grpOpertorKeyPad.Text = "تلفن اپراتور";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.BackColor = System.Drawing.Color.Lime;
            this.lblDuration.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(109, 1);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(49, 18);
            this.lblDuration.TabIndex = 22;
            this.lblDuration.Text = "00:00";
            // 
            // btnControl
            // 
            this.btnControl.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControl.Location = new System.Drawing.Point(10, 314);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(62, 44);
            this.btnControl.TabIndex = 21;
            this.btnControl.Text = "Ctrl";
            this.btnControl.UseVisualStyleBackColor = true;
            // 
            // btnDial
            // 
            this.btnDial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDial.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDial.Location = new System.Drawing.Point(80, 314);
            this.btnDial.Name = "btnDial";
            this.btnDial.Size = new System.Drawing.Size(196, 44);
            this.btnDial.TabIndex = 20;
            this.btnDial.Text = "Space";
            this.btnDial.UseVisualStyleBackColor = true;
            this.btnDial.Click += new System.EventHandler(this.btnDial_Click);
            // 
            // txtOperatorDial
            // 
            this.txtOperatorDial.CausesValidation = false;
            this.txtOperatorDial.Location = new System.Drawing.Point(6, 60);
            this.txtOperatorDial.Multiline = true;
            this.txtOperatorDial.Name = "txtOperatorDial";
            this.txtOperatorDial.ReadOnly = true;
            this.txtOperatorDial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOperatorDial.Size = new System.Drawing.Size(266, 28);
            this.txtOperatorDial.TabIndex = 19;
            this.txtOperatorDial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOperatorDial_KeyUp);
            // 
            // lblOperatorNumber
            // 
            this.lblOperatorNumber.AutoSize = true;
            this.lblOperatorNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorNumber.Location = new System.Drawing.Point(157, 0);
            this.lblOperatorNumber.Name = "lblOperatorNumber";
            this.lblOperatorNumber.Size = new System.Drawing.Size(45, 19);
            this.lblOperatorNumber.TabIndex = 17;
            this.lblOperatorNumber.Text = "2001";
            // 
            // txtOperatorPanel
            // 
            this.txtOperatorPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOperatorPanel.Location = new System.Drawing.Point(5, 29);
            this.txtOperatorPanel.Multiline = true;
            this.txtOperatorPanel.Name = "txtOperatorPanel";
            this.txtOperatorPanel.Size = new System.Drawing.Size(266, 28);
            this.txtOperatorPanel.TabIndex = 6;
            this.txtOperatorPanel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDialKeyPad_KeyDown);
            // 
            // btnKey1
            // 
            this.btnKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey1.Location = new System.Drawing.Point(10, 223);
            this.btnKey1.Name = "btnKey1";
            this.btnKey1.Size = new System.Drawing.Size(63, 44);
            this.btnKey1.TabIndex = 5;
            this.btnKey1.Text = "1";
            this.btnKey1.UseVisualStyleBackColor = true;
            this.btnKey1.Click += new System.EventHandler(this.btnKey1_Click);
            // 
            // btnRemoveHold
            // 
            this.btnRemoveHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveHold.Location = new System.Drawing.Point(213, 95);
            this.btnRemoveHold.Name = "btnRemoveHold";
            this.btnRemoveHold.Size = new System.Drawing.Size(63, 44);
            this.btnRemoveHold.TabIndex = 5;
            this.btnRemoveHold.Text = "-";
            this.btnRemoveHold.UseVisualStyleBackColor = true;
            this.btnRemoveHold.Click += new System.EventHandler(this.btnRemoveHold_Click);
            // 
            // btnKey2
            // 
            this.btnKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey2.Location = new System.Drawing.Point(80, 223);
            this.btnKey2.Name = "btnKey2";
            this.btnKey2.Size = new System.Drawing.Size(63, 44);
            this.btnKey2.TabIndex = 5;
            this.btnKey2.Text = "2";
            this.btnKey2.UseVisualStyleBackColor = true;
            this.btnKey2.Click += new System.EventHandler(this.btnKey2_Click);
            // 
            // btnAsterisk
            // 
            this.btnAsterisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsterisk.Location = new System.Drawing.Point(146, 94);
            this.btnAsterisk.Name = "btnAsterisk";
            this.btnAsterisk.Size = new System.Drawing.Size(63, 44);
            this.btnAsterisk.TabIndex = 5;
            this.btnAsterisk.Text = "*";
            this.btnAsterisk.UseVisualStyleBackColor = true;
            // 
            // btnKey4
            // 
            this.btnKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey4.Location = new System.Drawing.Point(10, 180);
            this.btnKey4.Name = "btnKey4";
            this.btnKey4.Size = new System.Drawing.Size(63, 44);
            this.btnKey4.TabIndex = 5;
            this.btnKey4.Text = "4";
            this.btnKey4.UseVisualStyleBackColor = true;
            this.btnKey4.Click += new System.EventHandler(this.btnKey4_Click);
            // 
            // lblOpertorState
            // 
            this.lblOpertorState.AutoSize = true;
            this.lblOpertorState.BackColor = System.Drawing.Color.Lime;
            this.lblOpertorState.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpertorState.Location = new System.Drawing.Point(1, 1);
            this.lblOpertorState.Name = "lblOpertorState";
            this.lblOpertorState.Size = new System.Drawing.Size(105, 18);
            this.lblOpertorState.TabIndex = 19;
            this.lblOpertorState.Text = "Operator State";
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(146, 269);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(63, 44);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnKey7
            // 
            this.btnKey7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey7.Location = new System.Drawing.Point(10, 137);
            this.btnKey7.Name = "btnKey7";
            this.btnKey7.Size = new System.Drawing.Size(63, 44);
            this.btnKey7.TabIndex = 5;
            this.btnKey7.Text = "7";
            this.btnKey7.UseVisualStyleBackColor = true;
            this.btnKey7.Click += new System.EventHandler(this.btnKey7_Click);
            // 
            // btnKey6
            // 
            this.btnKey6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey6.Location = new System.Drawing.Point(146, 180);
            this.btnKey6.Name = "btnKey6";
            this.btnKey6.Size = new System.Drawing.Size(63, 44);
            this.btnKey6.TabIndex = 5;
            this.btnKey6.Text = "6";
            this.btnKey6.UseVisualStyleBackColor = true;
            this.btnKey6.Click += new System.EventHandler(this.btnKey6_Click);
            // 
            // btnKey0
            // 
            this.btnKey0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey0.Location = new System.Drawing.Point(9, 268);
            this.btnKey0.Name = "btnKey0";
            this.btnKey0.Size = new System.Drawing.Size(134, 44);
            this.btnKey0.TabIndex = 5;
            this.btnKey0.Text = "0";
            this.btnKey0.UseVisualStyleBackColor = true;
            this.btnKey0.Click += new System.EventHandler(this.btnKey0_Click);
            // 
            // btnPutHold
            // 
            this.btnPutHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPutHold.Location = new System.Drawing.Point(213, 137);
            this.btnPutHold.Name = "btnPutHold";
            this.btnPutHold.Size = new System.Drawing.Size(63, 87);
            this.btnPutHold.TabIndex = 5;
            this.btnPutHold.Text = "+";
            this.btnPutHold.UseVisualStyleBackColor = true;
            this.btnPutHold.Click += new System.EventHandler(this.btnPutHold_Click);
            // 
            // btnKey8
            // 
            this.btnKey8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey8.Location = new System.Drawing.Point(80, 137);
            this.btnKey8.Name = "btnKey8";
            this.btnKey8.Size = new System.Drawing.Size(63, 44);
            this.btnKey8.TabIndex = 5;
            this.btnKey8.Text = "8";
            this.btnKey8.UseVisualStyleBackColor = true;
            this.btnKey8.Click += new System.EventHandler(this.btnKey8_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(213, 223);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(63, 89);
            this.btnEnter.TabIndex = 5;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // btnNumlock
            // 
            this.btnNumlock.Location = new System.Drawing.Point(10, 94);
            this.btnNumlock.Name = "btnNumlock";
            this.btnNumlock.Size = new System.Drawing.Size(63, 44);
            this.btnNumlock.TabIndex = 5;
            this.btnNumlock.Text = "Num Lock";
            this.btnNumlock.UseVisualStyleBackColor = true;
            this.btnNumlock.Click += new System.EventHandler(this.btnNumlock_Click);
            // 
            // btnSlash
            // 
            this.btnSlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlash.Location = new System.Drawing.Point(80, 94);
            this.btnSlash.Name = "btnSlash";
            this.btnSlash.Size = new System.Drawing.Size(63, 44);
            this.btnSlash.TabIndex = 5;
            this.btnSlash.Text = "/";
            this.btnSlash.UseVisualStyleBackColor = true;
            // 
            // btnKey3
            // 
            this.btnKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey3.Location = new System.Drawing.Point(146, 223);
            this.btnKey3.Name = "btnKey3";
            this.btnKey3.Size = new System.Drawing.Size(63, 44);
            this.btnKey3.TabIndex = 5;
            this.btnKey3.Text = "3";
            this.btnKey3.UseVisualStyleBackColor = true;
            this.btnKey3.Click += new System.EventHandler(this.btnKey3_Click);
            // 
            // btnKey5
            // 
            this.btnKey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey5.Location = new System.Drawing.Point(80, 180);
            this.btnKey5.Name = "btnKey5";
            this.btnKey5.Size = new System.Drawing.Size(63, 44);
            this.btnKey5.TabIndex = 5;
            this.btnKey5.Text = "5";
            this.btnKey5.UseVisualStyleBackColor = true;
            this.btnKey5.Click += new System.EventHandler(this.btnKey5_Click);
            // 
            // btnKey9
            // 
            this.btnKey9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey9.Location = new System.Drawing.Point(146, 137);
            this.btnKey9.Name = "btnKey9";
            this.btnKey9.Size = new System.Drawing.Size(63, 44);
            this.btnKey9.TabIndex = 5;
            this.btnKey9.Text = "9";
            this.btnKey9.UseVisualStyleBackColor = true;
            this.btnKey9.Click += new System.EventHandler(this.btnKey9_Click);
            // 
            // btnOperatorState
            // 
            this.btnOperatorState.BackColor = System.Drawing.Color.Red;
            this.btnOperatorState.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOperatorState.Location = new System.Drawing.Point(141, 37);
            this.btnOperatorState.Name = "btnOperatorState";
            this.btnOperatorState.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnOperatorState.Size = new System.Drawing.Size(149, 31);
            this.btnOperatorState.TabIndex = 18;
            this.btnOperatorState.Text = "خارج";
            this.btnOperatorState.UseVisualStyleBackColor = false;
            this.btnOperatorState.Click += new System.EventHandler(this.btnOperatorState_Click);
            // 
            // lblTrunkAcdQeueCout
            // 
            this.lblTrunkAcdQeueCout.AutoSize = true;
            this.lblTrunkAcdQeueCout.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrunkAcdQeueCout.Location = new System.Drawing.Point(188, -3);
            this.lblTrunkAcdQeueCout.Name = "lblTrunkAcdQeueCout";
            this.lblTrunkAcdQeueCout.Size = new System.Drawing.Size(27, 19);
            this.lblTrunkAcdQeueCout.TabIndex = 14;
            this.lblTrunkAcdQeueCout.Text = "00";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvTrunkAcdQeue);
            this.groupBox5.Controls.Add(this.lblTrunkAcdQeueCout);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(731, 236);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox5.Size = new System.Drawing.Size(418, 206);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "خطوط شهری در حال زنگ                         ";
            // 
            // dgvTrunkAcdQeue
            // 
            this.dgvTrunkAcdQeue.AllowUserToAddRows = false;
            this.dgvTrunkAcdQeue.AllowUserToDeleteRows = false;
            this.dgvTrunkAcdQeue.AllowUserToResizeColumns = false;
            this.dgvTrunkAcdQeue.AllowUserToResizeRows = false;
            this.dgvTrunkAcdQeue.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvTrunkAcdQeue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrunkAcdQeue.Location = new System.Drawing.Point(4, 18);
            this.dgvTrunkAcdQeue.Name = "dgvTrunkAcdQeue";
            this.dgvTrunkAcdQeue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvTrunkAcdQeue.Size = new System.Drawing.Size(410, 182);
            this.dgvTrunkAcdQeue.TabIndex = 15;
            // 
            // lblExtensionAcdQeueCout
            // 
            this.lblExtensionAcdQeueCout.AutoSize = true;
            this.lblExtensionAcdQeueCout.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtensionAcdQeueCout.Location = new System.Drawing.Point(191, -3);
            this.lblExtensionAcdQeueCout.Name = "lblExtensionAcdQeueCout";
            this.lblExtensionAcdQeueCout.Size = new System.Drawing.Size(27, 19);
            this.lblExtensionAcdQeueCout.TabIndex = 18;
            this.lblExtensionAcdQeueCout.Text = "00";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvExtensionAcdQeue);
            this.groupBox6.Controls.Add(this.lblExtensionAcdQeueCout);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(303, 238);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox6.Size = new System.Drawing.Size(422, 206);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "خطوط داخلی در حال زنگ                         ";
            // 
            // dgvExtensionAcdQeue
            // 
            this.dgvExtensionAcdQeue.AllowUserToAddRows = false;
            this.dgvExtensionAcdQeue.AllowUserToDeleteRows = false;
            this.dgvExtensionAcdQeue.AllowUserToResizeColumns = false;
            this.dgvExtensionAcdQeue.AllowUserToResizeRows = false;
            this.dgvExtensionAcdQeue.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvExtensionAcdQeue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtensionAcdQeue.Location = new System.Drawing.Point(8, 18);
            this.dgvExtensionAcdQeue.Name = "dgvExtensionAcdQeue";
            this.dgvExtensionAcdQeue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvExtensionAcdQeue.Size = new System.Drawing.Size(410, 182);
            this.dgvExtensionAcdQeue.TabIndex = 1;
            // 
            // lblExtensionHoldCout
            // 
            this.lblExtensionHoldCout.AutoSize = true;
            this.lblExtensionHoldCout.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtensionHoldCout.Location = new System.Drawing.Point(201, -3);
            this.lblExtensionHoldCout.Name = "lblExtensionHoldCout";
            this.lblExtensionHoldCout.Size = new System.Drawing.Size(27, 19);
            this.lblExtensionHoldCout.TabIndex = 16;
            this.lblExtensionHoldCout.Text = "00";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dataGridView1);
            this.groupBox7.Controls.Add(this.lblExtensionHoldCout);
            this.groupBox7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(303, 27);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox7.Size = new System.Drawing.Size(422, 206);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "مکالمات جاری                    ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.cmnPhoneBook;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(413, 181);
            this.dataGridView1.TabIndex = 17;
            // 
            // dgvTrunkHold
            // 
            this.dgvTrunkHold.AllowUserToAddRows = false;
            this.dgvTrunkHold.AllowUserToDeleteRows = false;
            this.dgvTrunkHold.AllowUserToResizeColumns = false;
            this.dgvTrunkHold.AllowUserToResizeRows = false;
            this.dgvTrunkHold.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvTrunkHold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrunkHold.Location = new System.Drawing.Point(4, 21);
            this.dgvTrunkHold.Name = "dgvTrunkHold";
            this.dgvTrunkHold.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvTrunkHold.Size = new System.Drawing.Size(410, 182);
            this.dgvTrunkHold.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvTrunkHold);
            this.groupBox4.Controls.Add(this.lblTrunkHoldCout);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(731, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(418, 206);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "خطوط در حال انتظار                     ";
            // 
            // lblTrunkHoldCout
            // 
            this.lblTrunkHoldCout.AutoSize = true;
            this.lblTrunkHoldCout.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrunkHoldCout.Location = new System.Drawing.Point(194, -3);
            this.lblTrunkHoldCout.Name = "lblTrunkHoldCout";
            this.lblTrunkHoldCout.Size = new System.Drawing.Size(27, 19);
            this.lblTrunkHoldCout.TabIndex = 12;
            this.lblTrunkHoldCout.Text = "00";
            // 
            // dgvPhoneBook
            // 
            this.dgvPhoneBook.AllowUserToAddRows = false;
            this.dgvPhoneBook.AllowUserToDeleteRows = false;
            this.dgvPhoneBook.AllowUserToResizeColumns = false;
            this.dgvPhoneBook.AllowUserToResizeRows = false;
            this.dgvPhoneBook.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvPhoneBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhoneBook.ContextMenuStrip = this.cmnPhoneBook;
            this.dgvPhoneBook.Location = new System.Drawing.Point(4, 18);
            this.dgvPhoneBook.Name = "dgvPhoneBook";
            this.dgvPhoneBook.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPhoneBook.Size = new System.Drawing.Size(829, 219);
            this.dgvPhoneBook.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPhonebookCount);
            this.groupBox2.Controls.Add(this.dgvPhoneBook);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(306, 448);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(843, 247);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "دفتر چه تلفن";
            // 
            // lblPhonebookCount
            // 
            this.lblPhonebookCount.AutoSize = true;
            this.lblPhonebookCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhonebookCount.Location = new System.Drawing.Point(573, 0);
            this.lblPhonebookCount.Name = "lblPhonebookCount";
            this.lblPhonebookCount.Size = new System.Drawing.Size(27, 19);
            this.lblPhonebookCount.TabIndex = 16;
            this.lblPhonebookCount.Text = "00";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tsmAdvanceSetting,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.connectToolStripMenuItem.Text = "Server Status";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Connect";
            // 
            // tsmAdvanceSetting
            // 
            this.tsmAdvanceSetting.Name = "tsmAdvanceSetting";
            this.tsmAdvanceSetting.Size = new System.Drawing.Size(152, 22);
            this.tsmAdvanceSetting.Text = "Perefrences";
            this.tsmAdvanceSetting.Click += new System.EventHandler(this.tsmUpgardaDb_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugWindowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // debugWindowToolStripMenuItem
            // 
            this.debugWindowToolStripMenuItem.Checked = true;
            this.debugWindowToolStripMenuItem.CheckOnClick = true;
            this.debugWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.debugWindowToolStripMenuItem.Name = "debugWindowToolStripMenuItem";
            this.debugWindowToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.debugWindowToolStripMenuItem.Text = "Debug Window";
            this.debugWindowToolStripMenuItem.CheckedChanged += new System.EventHandler(this.debugWindowToolStripMenuItem_CheckedChanged);
            this.debugWindowToolStripMenuItem.Click += new System.EventHandler(this.debugWindowToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iVRSettingToolStripMenuItem,
            this.aCDSettingToolStripMenuItem,
            this.aCDReportToolStripMenuItem,
            this.tslAgentReportView,
            this.tslStatusView,
            this.tslExtensionPeriority,
            this.speedDialToolStripMenuItem,
            this.phoneBookImportToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // iVRSettingToolStripMenuItem
            // 
            this.iVRSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.iVRSettingToolStripMenuItem.Name = "iVRSettingToolStripMenuItem";
            this.iVRSettingToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.iVRSettingToolStripMenuItem.Text = "IVR";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // aCDSettingToolStripMenuItem
            // 
            this.aCDSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem1,
            this.propertiesToolStripMenuItem1});
            this.aCDSettingToolStripMenuItem.Name = "aCDSettingToolStripMenuItem";
            this.aCDSettingToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.aCDSettingToolStripMenuItem.Text = "ACD";
            // 
            // reportToolStripMenuItem1
            // 
            this.reportToolStripMenuItem1.Name = "reportToolStripMenuItem1";
            this.reportToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.reportToolStripMenuItem1.Text = "Report";
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.propertiesToolStripMenuItem1.Text = "Properties";
            // 
            // aCDReportToolStripMenuItem
            // 
            this.aCDReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inCallToolStripMenuItem,
            this.tslOutCall});
            this.aCDReportToolStripMenuItem.Name = "aCDReportToolStripMenuItem";
            this.aCDReportToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.aCDReportToolStripMenuItem.Text = "Report";
            // 
            // inCallToolStripMenuItem
            // 
            this.inCallToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslIncallAnswered,
            this.tslInCallMissed});
            this.inCallToolStripMenuItem.Name = "inCallToolStripMenuItem";
            this.inCallToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.inCallToolStripMenuItem.Text = "In Call";
            // 
            // tslIncallAnswered
            // 
            this.tslIncallAnswered.Name = "tslIncallAnswered";
            this.tslIncallAnswered.Size = new System.Drawing.Size(122, 22);
            this.tslIncallAnswered.Text = "Answered";
            this.tslIncallAnswered.Click += new System.EventHandler(this.tslIncallAnswered_Click);
            // 
            // tslInCallMissed
            // 
            this.tslInCallMissed.Name = "tslInCallMissed";
            this.tslInCallMissed.Size = new System.Drawing.Size(122, 22);
            this.tslInCallMissed.Text = "Missed";
            this.tslInCallMissed.Click += new System.EventHandler(this.tslInCallMissed_Click);
            // 
            // tslOutCall
            // 
            this.tslOutCall.Name = "tslOutCall";
            this.tslOutCall.Size = new System.Drawing.Size(112, 22);
            this.tslOutCall.Text = "Out Call";
            this.tslOutCall.Click += new System.EventHandler(this.tslOutCall_Click);
            // 
            // tslAgentReportView
            // 
            this.tslAgentReportView.Name = "tslAgentReportView";
            this.tslAgentReportView.Size = new System.Drawing.Size(164, 22);
            this.tslAgentReportView.Text = "Agents";
            this.tslAgentReportView.Click += new System.EventHandler(this.tslAgentReportView_Click);
            // 
            // tslStatusView
            // 
            this.tslStatusView.Name = "tslStatusView";
            this.tslStatusView.Size = new System.Drawing.Size(164, 22);
            this.tslStatusView.Text = "Status";
            this.tslStatusView.Click += new System.EventHandler(this.tslStatusView_Click);
            // 
            // tslExtensionPeriority
            // 
            this.tslExtensionPeriority.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslExtensionPeriorityAdd,
            this.tslExtensionPeriorityEdit});
            this.tslExtensionPeriority.Name = "tslExtensionPeriority";
            this.tslExtensionPeriority.Size = new System.Drawing.Size(164, 22);
            this.tslExtensionPeriority.Text = "Extension periority";
            this.tslExtensionPeriority.Click += new System.EventHandler(this.tslExtensionPeriority_Click);
            // 
            // tslExtensionPeriorityAdd
            // 
            this.tslExtensionPeriorityAdd.Name = "tslExtensionPeriorityAdd";
            this.tslExtensionPeriorityAdd.Size = new System.Drawing.Size(93, 22);
            this.tslExtensionPeriorityAdd.Text = "Add";
            this.tslExtensionPeriorityAdd.Click += new System.EventHandler(this.tslExtensionPeriorityAdd_Click);
            // 
            // tslExtensionPeriorityEdit
            // 
            this.tslExtensionPeriorityEdit.Name = "tslExtensionPeriorityEdit";
            this.tslExtensionPeriorityEdit.Size = new System.Drawing.Size(93, 22);
            this.tslExtensionPeriorityEdit.Text = "Edit";
            this.tslExtensionPeriorityEdit.Click += new System.EventHandler(this.tslExtensionPeriorityEdit_Click);
            // 
            // speedDialToolStripMenuItem
            // 
            this.speedDialToolStripMenuItem.Name = "speedDialToolStripMenuItem";
            this.speedDialToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.speedDialToolStripMenuItem.Text = "SpeedDial";
            this.speedDialToolStripMenuItem.Click += new System.EventHandler(this.speedDialToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1151, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.tsMCheckUpdate,
            this.toolStripSeparator4,
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // tsMCheckUpdate
            // 
            this.tsMCheckUpdate.Name = "tsMCheckUpdate";
            this.tsMCheckUpdate.Size = new System.Drawing.Size(141, 22);
            this.tsMCheckUpdate.Text = "Check Update";
            this.tsMCheckUpdate.Click += new System.EventHandler(this.tsMCheckUpdate_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(138, 6);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // btnOperatorDayNight
            // 
            this.btnOperatorDayNight.BackColor = System.Drawing.Color.Violet;
            this.btnOperatorDayNight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperatorDayNight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperatorDayNight.Location = new System.Drawing.Point(52, 37);
            this.btnOperatorDayNight.Name = "btnOperatorDayNight";
            this.btnOperatorDayNight.Size = new System.Drawing.Size(84, 31);
            this.btnOperatorDayNight.TabIndex = 20;
            this.btnOperatorDayNight.Text = "روز";
            this.btnOperatorDayNight.UseVisualStyleBackColor = false;
            this.btnOperatorDayNight.Click += new System.EventHandler(this.btnOperatorDayNight_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvAnsweredCall);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(18, 581);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(282, 123);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تماسهای پاسخ داده شده";
            // 
            // dgvAnsweredCall
            // 
            this.dgvAnsweredCall.AllowUserToAddRows = false;
            this.dgvAnsweredCall.AllowUserToDeleteRows = false;
            this.dgvAnsweredCall.AllowUserToResizeColumns = false;
            this.dgvAnsweredCall.AllowUserToResizeRows = false;
            this.dgvAnsweredCall.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvAnsweredCall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnsweredCall.Location = new System.Drawing.Point(6, 15);
            this.dgvAnsweredCall.Name = "dgvAnsweredCall";
            this.dgvAnsweredCall.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAnsweredCall.Size = new System.Drawing.Size(270, 99);
            this.dgvAnsweredCall.TabIndex = 3;
            // 
            // lblConectionState
            // 
            this.lblConectionState.AutoSize = true;
            this.lblConectionState.BackColor = System.Drawing.Color.Red;
            this.lblConectionState.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConectionState.Location = new System.Drawing.Point(1029, 0);
            this.lblConectionState.Name = "lblConectionState";
            this.lblConectionState.Size = new System.Drawing.Size(120, 16);
            this.lblConectionState.TabIndex = 22;
            this.lblConectionState.Text = "ارتباط قطع می باشد";
            // 
            // tmrLivecheck
            // 
            this.tmrLivecheck.Interval = 2000;
            this.tmrLivecheck.Tick += new System.EventHandler(this.tmrLivecheck_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MintCream;
            this.pictureBox1.Image = global::AgentCom.Properties.Resources.Sound71;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 39);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // phoneBookImportToolStripMenuItem
            // 
            this.phoneBookImportToolStripMenuItem.Name = "phoneBookImportToolStripMenuItem";
            this.phoneBookImportToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.phoneBookImportToolStripMenuItem.Text = "PhoneBook Export";
            this.phoneBookImportToolStripMenuItem.Click += new System.EventHandler(this.phoneBookImportToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1151, 692);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOperatorDayNight);
            this.Controls.Add(this.lblConectionState);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnOperatorState);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpOpertorKeyPad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgentCom Ver:1.0.3";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissedCall)).EndInit();
            this.cmnKeyList.ResumeLayout(false);
            this.cmnPhoneBook.ResumeLayout(false);
            this.grpOpertorKeyPad.ResumeLayout(false);
            this.grpOpertorKeyPad.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrunkAcdQeue)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtensionAcdQeue)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrunkHold)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneBook)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnsweredCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer SendDataTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveHold;
        private System.Windows.Forms.Button btnAsterisk;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnKey6;
        private System.Windows.Forms.Button btnPutHold;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnSlash;
        private System.Windows.Forms.Button btnKey5;
        private System.Windows.Forms.Button btnKey9;
        private System.Windows.Forms.Button btnKey3;
        private System.Windows.Forms.Button btnNumlock;
        private System.Windows.Forms.Button btnKey8;
        private System.Windows.Forms.Button btnKey0;
        private System.Windows.Forms.Button btnKey7;
        private System.Windows.Forms.Button btnKey4;
        private System.Windows.Forms.Button btnKey2;
        private System.Windows.Forms.Button btnKey1;
        private System.Windows.Forms.GroupBox grpOpertorKeyPad;
        private System.Windows.Forms.TextBox txtOperatorPanel;
        private System.Windows.Forms.ContextMenuStrip cmnPhoneBook;
        private System.Windows.Forms.ToolStripMenuItem tsmAddPhone;
        private System.Windows.Forms.ToolStripMenuItem tsmDelPhone;
        private System.Windows.Forms.ToolStripMenuItem tsmDialPhone;
        private System.Windows.Forms.ImageList imgState;
        private System.Windows.Forms.ContextMenuStrip cmnKeyList;
        private System.Windows.Forms.ToolStripMenuItem tsmAddKey;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteKey;
        private System.Windows.Forms.Label lblExtensionAcdQeueCout;
        private System.Windows.Forms.Label lblTrunkAcdQeueCout;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblExtensionHoldCout;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgvTrunkHold;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblTrunkHoldCout;
        private System.Windows.Forms.DataGridView dgvTrunkAcdQeue;
        private System.Windows.Forms.DataGridView dgvExtensionAcdQeue;
        private System.Windows.Forms.DataGridView dgvPhoneBook;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblOperatorNumber;
        private System.Windows.Forms.Button btnOperatorState;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iVRSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCDSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aCDReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tslAgentReportView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox txtOperatorDial;
        private System.Windows.Forms.Button btnDial;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label lblOpertorState;
        private System.Windows.Forms.Button btnOperatorDayNight;
        private System.Windows.Forms.ToolStripMenuItem tslStatusView;
        private System.Windows.Forms.ToolStripMenuItem inCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tslIncallAnswered;
        private System.Windows.Forms.ToolStripMenuItem tslInCallMissed;
        private System.Windows.Forms.ToolStripMenuItem tslOutCall;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.ToolStripMenuItem tsmEditPhone;
        private System.Windows.Forms.ToolStripMenuItem tsmAdvanceSetting;
        private System.Windows.Forms.ToolStripMenuItem tslExtensionPeriority;
        private System.Windows.Forms.ToolStripMenuItem tslExtensionPeriorityAdd;
        private System.Windows.Forms.ToolStripMenuItem tslExtensionPeriorityEdit;
        private System.Windows.Forms.DataGridView dgvMissedCall;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvAnsweredCall;
        private System.Windows.Forms.ToolStripMenuItem speedDialToolStripMenuItem;
        private System.Windows.Forms.Label lblConectionState;
        private System.Windows.Forms.Timer tmrLivecheck;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsMCheckUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblPhonebookCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem phoneBookImportToolStripMenuItem;
    }
}

