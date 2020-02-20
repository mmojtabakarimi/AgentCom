using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgentCom
{
    public partial class frmDayNight : Form
    {
        public frmDayNight()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Int32 Number;
            try
            {
                Number = Int32.Parse(txtDayNightnumber.Text);

            }
            catch (Exception ee)
            {
                MessageBox.Show("شماره وارد شده صحیح نمی باشد", "خطا در عملیات ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;

            }

            CGlobal.dayNightNumber = txtDayNightnumber.Text;
            CGlobal.btnApplyPressed = true;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CGlobal.btnApplyPressed = false;

            this.Close();
        }

        private void frmDayNight_Load(object sender, EventArgs e)
        {
            CGlobal.btnApplyPressed = false;



        }
    }
}
