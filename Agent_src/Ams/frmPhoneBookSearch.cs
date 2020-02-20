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
    public partial class frmPhoneBookSearch : Form
    {

        private DataSet dsPhoneBookSearch = new DataSet();
        cDatabseConnection cDB;
        private string Message1 = "";

        public frmPhoneBookSearch()
        {
            InitializeComponent();
            CGlobal.btnApplyPressed = false;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            int indx = 0;
            for ( indx = 0; indx < dgvPhoneBookSearch.RowCount; indx++)
            {
                if (dgvPhoneBookSearch.Rows[indx].Selected)
                {
                    CGlobal.phoneBookSearchPhone = dgvPhoneBookSearch.Rows[indx].Cells[3].Value.ToString();
                    CGlobal.btnApplyPressed = true;
                    Close();
                    break;
                }

            }
            if (indx >= dgvPhoneBookSearch.RowCount)
            {
                CGlobal.btnApplyPressed = false;
                Close();
            }
        }

        private void frmPhoneBookSearch_Load(object sender, EventArgs e)
        {
            dgvPhoneBookSearchRefresh();


        }
        //****************************************
        public void dgvPhoneBookSearchRefresh()
        {
            int count = 0;
            cDatabseConnection dbTemp = new cDatabseConnection();
            dsPhoneBookSearch = dbTemp.Refresh("tblPhoneBook", "Agent_DB");
            DataTable dt = new DataTable();

            dt.Columns.Add("indx");
            dt.Columns.Add("name");
            dt.Columns.Add("job");
            dt.Columns.Add("phone");
            


            DataRow dd;
            foreach (DataRow dr in dsPhoneBookSearch.Tables[0].Rows)
            {
                count++;
                dd = dt.NewRow();
                dd["indx"] = count.ToString();
                dd["name"] = dr["name"].ToString().Trim();
                dd["job"] = dr["job"].ToString().Trim();
                dd["phone"] = dr["numebr"].ToString().Trim();


                dt.Rows.Add(dd);
            }
            lblPhonBookSearch.Text = count.ToString();
            this.dgvPhoneBookSearch.DataSource = dt;
            this.dgvPhoneBookSearch.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhoneBookSearch.Columns["indx"].Width = 40;
            this.dgvPhoneBookSearch.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhoneBookSearch.Columns["indx"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvPhoneBookSearch.Columns["name"].Width = 160;
            this.dgvPhoneBookSearch.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhoneBookSearch.Columns["job"].Width = 160;
            this.dgvPhoneBookSearch.Columns["job"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhoneBookSearch.Columns["phone"].Width = 150;
            this.dgvPhoneBookSearch.Columns["phone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhoneBookSearch.Columns[0].HeaderText = "ردیف";
            this.dgvPhoneBookSearch.Columns[1].HeaderText = "نام";
            this.dgvPhoneBookSearch.Columns[2].HeaderText = "تخصص";
            this.dgvPhoneBookSearch.Columns[3].HeaderText = "تلفن";
            Application.DoEvents();


        }
     /*   public void dgvPhoneBookSearchRefresh1()
        {

            cDatabseConnection dbTemp = new cDatabseConnection();
            dsPhoneBookSearch = dbTemp.Refresh("tblPhoneBook", "Agent_DB");
            dgvPhoneBookSearch.DataSource = dsPhoneBookSearch.Tables[0];

            dgvPhoneBookSearch.Columns[0].Width = 60;
            dgvPhoneBookSearch.Columns[1].Width = 280;
            dgvPhoneBookSearch.Columns[2].Width = 180;
            dgvPhoneBookSearch.Columns[3].Width = 130;

            for (int i = 0; i < 4; i++)
            {
                this.dgvPhoneBookSearch.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            this.dgvPhoneBookSearch.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvPhoneBookSearch.Columns[0].HeaderText = "ردیف";
            dgvPhoneBookSearch.Columns[1].HeaderText = "نام";
            dgvPhoneBookSearch.Columns[2].HeaderText = "تخصص";
            dgvPhoneBookSearch.Columns[3].HeaderText = "تلفن";
            int  indx=0  ;
           
            for (indx = 1; indx <= dgvPhoneBookSearch.RowCount; indx++)
                dgvPhoneBookSearch.Rows[indx - 1].Cells[0].Value = indx.ToString();

            for (indx = 0; indx < dgvPhoneBookSearch.RowCount; indx++)
            {
                string tmp2 = dgvPhoneBookSearch.Rows[indx].Cells[2].Value.ToString();
                string tmp3 = dgvPhoneBookSearch.Rows[indx].Cells[3].Value.ToString();
                dgvPhoneBookSearch.Rows[indx].Cells[2].Value = tmp3;
                dgvPhoneBookSearch.Rows[indx].Cells[3].Value = tmp2;
            }
            lblPhonBookSearch.Text = indx.ToString();
                
            



        }
        */
        private void txtPhoneBookSearch_TextChanged(object sender, EventArgs e)
        {
            String name = txtSearchByName.Text;
            String phone = txtSearchByPhone.Text;
            String job = txtSearchByJob.Text;

            dgvPhoneBookSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           // (dgvPhoneBookSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%' OR phone LIKE '%{1}%' OR job LIKE '%{2}%' ", name, phone, job);
            (dgvPhoneBookSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%' AND  phone LIKE '%{1}%' AND  job LIKE '%{2}%'", name, phone, job);

           

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CGlobal.btnApplyPressed = false;
            Close();
        }

    }
}
