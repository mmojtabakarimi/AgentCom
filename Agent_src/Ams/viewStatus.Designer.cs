namespace AgentCom
{
    partial class viewStatus
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvExtension = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAnalogTrunk = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDigitalTrunk = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalogTrunk)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDigitalTrunk)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvExtension);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(420, 662);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "خطوط داخلی";
            // 
            // dgvExtension
            // 
            this.dgvExtension.AllowUserToAddRows = false;
            this.dgvExtension.AllowUserToDeleteRows = false;
            this.dgvExtension.AllowUserToResizeColumns = false;
            this.dgvExtension.AllowUserToResizeRows = false;
            this.dgvExtension.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtension.Location = new System.Drawing.Point(6, 17);
            this.dgvExtension.Name = "dgvExtension";
            this.dgvExtension.RowHeadersVisible = false;
            this.dgvExtension.Size = new System.Drawing.Size(408, 639);
            this.dgvExtension.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAnalogTrunk);
            this.groupBox2.Location = new System.Drawing.Point(430, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(299, 662);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "خطوط شهری";
            // 
            // dgvAnalogTrunk
            // 
            this.dgvAnalogTrunk.AllowUserToAddRows = false;
            this.dgvAnalogTrunk.AllowUserToDeleteRows = false;
            this.dgvAnalogTrunk.AllowUserToResizeColumns = false;
            this.dgvAnalogTrunk.AllowUserToResizeRows = false;
            this.dgvAnalogTrunk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalogTrunk.Location = new System.Drawing.Point(6, 17);
            this.dgvAnalogTrunk.Name = "dgvAnalogTrunk";
            this.dgvAnalogTrunk.RowHeadersVisible = false;
            this.dgvAnalogTrunk.Size = new System.Drawing.Size(287, 639);
            this.dgvAnalogTrunk.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDigitalTrunk);
            this.groupBox3.Location = new System.Drawing.Point(732, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(340, 662);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ترانک دیجیتال";
            // 
            // dgvDigitalTrunk
            // 
            this.dgvDigitalTrunk.AllowUserToAddRows = false;
            this.dgvDigitalTrunk.AllowUserToDeleteRows = false;
            this.dgvDigitalTrunk.AllowUserToResizeColumns = false;
            this.dgvDigitalTrunk.AllowUserToResizeRows = false;
            this.dgvDigitalTrunk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDigitalTrunk.Location = new System.Drawing.Point(6, 17);
            this.dgvDigitalTrunk.Name = "dgvDigitalTrunk";
            this.dgvDigitalTrunk.RowHeadersVisible = false;
            this.dgvDigitalTrunk.Size = new System.Drawing.Size(328, 639);
            this.dgvDigitalTrunk.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // viewStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 663);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "viewStatus";
            this.Text = "مشاهده وضعیت";
            this.Load += new System.EventHandler(this.viewStatus_Load);
            this.Activated += new System.EventHandler(this.viewStatus_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.viewStatus_FormClosed);
            this.Resize += new System.EventHandler(this.viewStatus_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalogTrunk)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDigitalTrunk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvExtension;
        private System.Windows.Forms.DataGridView dgvAnalogTrunk;
        private System.Windows.Forms.DataGridView dgvDigitalTrunk;
        private System.Windows.Forms.Timer timer1;
    }
}