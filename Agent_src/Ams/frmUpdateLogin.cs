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
    public partial class frmUpdateLogin : Form
    {
        public frmUpdateLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtCompanyLogin.Text == "1234")
            {
                CGlobal.frmCompanyLoginFlag = true;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUpdateLogin_Load(object sender, EventArgs e)
        {
            CGlobal.frmCompanyLoginFlag = false;
        }

    }
}
