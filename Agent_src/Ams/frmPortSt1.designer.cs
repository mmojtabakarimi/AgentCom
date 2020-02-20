namespace AgentCom
{
    partial class frmPortSt1
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
            this.dgvSub = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSub)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSub
            // 
            this.dgvSub.AllowUserToAddRows = false;
            this.dgvSub.AllowUserToDeleteRows = false;
            this.dgvSub.AllowUserToResizeColumns = false;
            this.dgvSub.AllowUserToResizeRows = false;
            this.dgvSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSub.Location = new System.Drawing.Point(-2, 27);
            this.dgvSub.Name = "dgvSub";
            this.dgvSub.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvSub.Size = new System.Drawing.Size(362, 442);
            this.dgvSub.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPortSt1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 505);
            this.Controls.Add(this.dgvSub);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmPortSt1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "مشاهده وضعیت";
            this.Load += new System.EventHandler(this.frmPortSt1_Load);
            this.Activated += new System.EventHandler(this.frmPortSt1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPortSt1_FormClosed);
            this.Resize += new System.EventHandler(this.frmPortSt1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSub)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSub;
        private System.Windows.Forms.Timer timer1;
    }
}