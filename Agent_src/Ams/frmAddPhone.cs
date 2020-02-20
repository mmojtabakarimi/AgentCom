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
    public partial class frmAddPhone : Form
    {
        public frmAddPhone(String  caption)
        {
            InitializeComponent();
            CGlobal.btnApplyPressed = false;
            this.Text = caption;
        }

        public  frmAddPhone(String caption,int Index, String Name, String Number,String description,int  autoIndex)
        {
            InitializeComponent();
            CGlobal.btnApplyPressed = false;
            this.Text = caption;

           txtName.Text = Name;
            txtPhoneNumebr.Text = Number;
            txtPhoneBookJob.Text = description;
            aiLbl.Text = autoIndex.ToString();


        }
        private void frmAddPhone_Load(object sender, EventArgs e)
        {
           // cmbPhoneType.SelectedIndex = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CGlobal.btnApplyPressed = false;
            Close();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CGlobal.phoneBookName = txtName.Text;// +txtFamilyName.Text;
            CGlobal.phoneBookNumber = txtPhoneNumebr.Text.TrimStart().TrimEnd().Trim();
            CGlobal.phoneBookType = "1"; // cmbPhoneType.Items[cmbPhoneType.SelectedIndex].ToString();
            CGlobal.phoneBookJob = txtPhoneBookJob.Text;


            //CGlobal.phoneBookDescription = txtPhoneBookDescription.Text;
            CGlobal.btnApplyPressed = true;
            Close();
        }



    }
}
