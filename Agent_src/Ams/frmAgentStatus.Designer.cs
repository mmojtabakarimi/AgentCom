namespace AgentCom
{
    partial class frmAgentStatus
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAgent = new System.Windows.Forms.DataGridView();
            this.cmnSpeedDial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tslAddNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.tslDeleteNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAgentReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fdaFarsi = new FarsiLibrary.Win.Controls.FADatePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgent)).BeginInit();
            this.cmnSpeedDial.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "خروج";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.dgvAgent);
            this.groupBox1.Location = new System.Drawing.Point(2, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 378);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dgvAgent
            // 
            this.dgvAgent.AllowUserToAddRows = false;
            this.dgvAgent.AllowUserToDeleteRows = false;
            this.dgvAgent.AllowUserToResizeColumns = false;
            this.dgvAgent.AllowUserToResizeRows = false;
            this.dgvAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgent.Location = new System.Drawing.Point(7, 16);
            this.dgvAgent.Name = "dgvAgent";
            this.dgvAgent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAgent.Size = new System.Drawing.Size(515, 356);
            this.dgvAgent.TabIndex = 0;
            // 
            // cmnSpeedDial
            // 
            this.cmnSpeedDial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslAddNumber,
            this.tslDeleteNumber});
            this.cmnSpeedDial.Name = "cmnSpeedDial";
            this.cmnSpeedDial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmnSpeedDial.Size = new System.Drawing.Size(141, 48);
            // 
            // tslAddNumber
            // 
            this.tslAddNumber.Name = "tslAddNumber";
            this.tslAddNumber.Size = new System.Drawing.Size(140, 22);
            this.tslAddNumber.Text = "افزودن شماره";
            this.tslAddNumber.Click += new System.EventHandler(this.tslAddNumber_Click);
            // 
            // tslDeleteNumber
            // 
            this.tslDeleteNumber.Name = "tslDeleteNumber";
            this.tslDeleteNumber.Size = new System.Drawing.Size(140, 22);
            this.tslDeleteNumber.Text = "حذف شماره";
            this.tslDeleteNumber.Click += new System.EventHandler(this.tslDeleteNumber_Click);
            // 
            // btnAgentReport
            // 
            this.btnAgentReport.Location = new System.Drawing.Point(104, 382);
            this.btnAgentReport.Name = "btnAgentReport";
            this.btnAgentReport.Size = new System.Drawing.Size(105, 26);
            this.btnAgentReport.TabIndex = 2;
            this.btnAgentReport.Text = "گزارش گیری";
            this.btnAgentReport.UseVisualStyleBackColor = true;
            this.btnAgentReport.Click += new System.EventHandler(this.btnAgentReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "تاریخ:";
            // 
            // fdaFarsi
            // 
            this.fdaFarsi.Location = new System.Drawing.Point(360, 388);
            this.fdaFarsi.Name = "fdaFarsi";
            this.fdaFarsi.Size = new System.Drawing.Size(120, 20);
            this.fdaFarsi.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(267, 382);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 26);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(10, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 18);
            this.lblCount.TabIndex = 1;
            // 
            // frmAgentStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 418);
            this.ContextMenuStrip = this.cmnSpeedDial;
            this.ControlBox = false;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fdaFarsi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAgentReport);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAgentStatus";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مشاهده گزارش اپراتور";
            this.Load += new System.EventHandler(this.frmAgentStatus_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgent)).EndInit();
            this.cmnSpeedDial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAgent;
        private System.Windows.Forms.ContextMenuStrip cmnSpeedDial;
        private System.Windows.Forms.ToolStripMenuItem tslAddNumber;
        private System.Windows.Forms.ToolStripMenuItem tslDeleteNumber;
        private System.Windows.Forms.Button btnAgentReport;
        private System.Windows.Forms.Label label1;
        private FarsiLibrary.Win.Controls.FADatePicker fdaFarsi;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCount;
    }
}