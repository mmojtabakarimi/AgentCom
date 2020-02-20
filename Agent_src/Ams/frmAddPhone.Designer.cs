namespace AgentCom
{
    partial class frmAddPhone
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhoneBookJob = new System.Windows.Forms.TextBox();
            this.txtPhoneNumebr = new System.Windows.Forms.MaskedTextBox();
            this.aiLbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام و نام خانوادگی : ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(16, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(135, 23);
            this.txtName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "شماره تلفن :";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(128, 149);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "تایید";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(17, 149);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "خروج";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPhoneBookJob);
            this.groupBox1.Controls.Add(this.txtPhoneNumebr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 139);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "تخصص : ";
            // 
            // txtPhoneBookJob
            // 
            this.txtPhoneBookJob.Location = new System.Drawing.Point(16, 58);
            this.txtPhoneBookJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhoneBookJob.Name = "txtPhoneBookJob";
            this.txtPhoneBookJob.Size = new System.Drawing.Size(135, 23);
            this.txtPhoneBookJob.TabIndex = 4;
            // 
            // txtPhoneNumebr
            // 
            this.txtPhoneNumebr.Location = new System.Drawing.Point(16, 88);
            this.txtPhoneNumebr.Mask = "0000000000000000";
            this.txtPhoneNumebr.Name = "txtPhoneNumebr";
            this.txtPhoneNumebr.Size = new System.Drawing.Size(135, 23);
            this.txtPhoneNumebr.TabIndex = 2;
            // 
            // aiLbl
            // 
            this.aiLbl.AutoSize = true;
            this.aiLbl.Location = new System.Drawing.Point(240, 163);
            this.aiLbl.Name = "aiLbl";
            this.aiLbl.Size = new System.Drawing.Size(0, 16);
            this.aiLbl.TabIndex = 5;
            // 
            // frmAddPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 190);
            this.ControlBox = false;
            this.Controls.Add(this.aiLbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAddPhone";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "اضافه کردن شماره تلفن";
            this.Load += new System.EventHandler(this.frmAddPhone_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtPhoneNumebr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhoneBookJob;
        private System.Windows.Forms.Label aiLbl;

    }
}