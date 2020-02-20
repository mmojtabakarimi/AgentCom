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
    public partial class frmAddNumber : Form
    {
        public frmAddNumber()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UInt64 phonenumber=0;
            try
            {
                phonenumber = UInt64.Parse(txtPhoneNumber.Text.Trim().ToString());
            }
            catch (Exception ee)
            {
                MessageBox.Show("شماره وارد شده صحیح نمی باشد ", "خطــا ", MessageBoxButtons.OK, MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
            }
            finally
            {
                CGlobal.addPhonenumber = phonenumber.ToString();
                CGlobal.btnApplyPressed = true;

            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddNumber_Load(object sender, EventArgs e)
        {
            CGlobal.btnApplyPressed = false;
        }
    }
}
