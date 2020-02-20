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
    public partial class frmAddSpeedDial : Form
    {
        public frmAddSpeedDial()
        {
            InitializeComponent();
            CGlobal.btnApplyPressed = false;
            for(int index = 7000;index<8000;index++)
                cmbSpeedDialHead.Items.Add(index);
            cmbSpeedDialHead.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                CGlobal.speedIndex = cmbSpeedDialHead.Text.ToString();
                CGlobal.speedPhone = txtPhoneNumebr.Text.Trim().TrimStart().TrimEnd();
                CGlobal.speedName = txtSpeedName.Text.Trim();
            }
            catch (Exception ee)
            {

            }

            CGlobal.btnApplyPressed = true;
            Close();
        }

    
    }
}
