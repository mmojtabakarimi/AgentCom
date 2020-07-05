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
    public partial class viewStatus : Form
    {
        private DataSet dsAnalogTrunk = new DataSet();
        private DataSet dsDigitalTrunk = new DataSet();
        private DataSet dsExtension = new DataSet();
     
        public viewStatus()
        {
            InitializeComponent();
        }

        private void viewStatus_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                CGlobal.FocousFlag = false;
            if ((this.WindowState == FormWindowState.Normal) || (this.WindowState == FormWindowState.Maximized))
                CGlobal.FocousFlag = true;

        }


        private void viewStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            CGlobal.FocousFlag = false;
        }

        private void viewStatus_Activated(object sender, EventArgs e)
        {
            CGlobal.FocousFlag = true;
        }

        public void dgvExtensionRefresh()
        {

            cDatabseConnection dbTemp = new cDatabseConnection();
            dsExtension = dbTemp.Refresh("tblLineData", "Agent_Db");


            DataTable dt = new DataTable();
            dt.Columns.Add("تلفن");
            dt.Columns.Add("شلف");
            dt.Columns.Add("اسلات");
            dt.Columns.Add("پورت");
            dt.Columns.Add("وضعیت");
            dt.Columns.Add("مخاطب");

            byte nopre, nopp;
            nopre = 1;
            nopp = 3;

            DataRow dd;

            string postDigit = "";
            foreach (DataRow dr in dsExtension.Tables[0].Rows)
            {
                dd = dt.NewRow();
                postDigit = "";

                if (dr["PreDigit"].ToString().Trim() == "")
                    continue;

                dd["تلفن"] = dr["PreDigit"].ToString().Trim().PadLeft(nopre, '0') + dr["Postdigit"].ToString().Trim().PadLeft(nopp, '0');// postDigit;

                dd["اسلات"] = dr["SlotNumber"].ToString().Trim();
                dd["پورت"] = dr["PortNumber"].ToString().Trim();
                dd["شلف"] = dr["ShelfNumber"].ToString().Trim();
                //dd["Class"] = dr["ClassNo"].ToString().Trim();
                dd["وضعیت"] = "آزاد";
                dt.Rows.Add(dd);
            }
            this.dgvExtension.DataSource = dt;
            this.dgvExtension.Columns["تلفن"].Width = 60;
            this.dgvExtension.Columns["شلف"].Width = 40;
            this.dgvExtension.Columns["اسلات"].Width = 40;
            this.dgvExtension.Columns["پورت"].Width = 40;
            this.dgvExtension.Columns["مخاطب"].Width = 90;
            this.dgvExtension.Columns["وضعیت"].Width = 110;

            this.dgvExtension.Columns["شلف"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvExtension.Columns["اسلات"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvExtension.Columns["پورت"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvExtension.Columns["وضعیت"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvExtension.Columns["مخاطب"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }
        void dgvExtensionRefresh_state()
        {
            int state;
            string baprty;


            cDatabseConnection dbTemp = new cDatabseConnection();
            dsExtension = dbTemp.Refresh("tblLineData", "Agent_Db");

            for (int indx = 0; indx < dgvExtension.Rows.Count; indx++)
            {  
 
                try
                {
                    state = Int32.Parse(dsExtension.Tables[0].Rows[indx]["Linestate"].ToString().Trim());
                    baprty = dsExtension.Tables[0].Rows[indx]["bparty"].ToString().Trim();

                }
                
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);

                    return;
                }

                dgvExtension.Rows[indx].Cells["مخاطب"].Value = baprty;
                switch (state)
                {
                    case 0:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = "آزاد";
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.White;
                       
                        break;
                    case 2:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = "شماره گیری";
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Red;
                        break;
                    case 8:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = "منتطر مکالمه";
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Red;
                        break;
                    case 3:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = "زنگ خوردن";
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Red;
                        break;
                    case 6:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = "منتطر قطع";
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Red;
                        break;
                    case 5:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = "مکالمه";
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Green;
                        break;
                    case 13:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = "مکالمه ترانک";
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Green;
                        break;
                    case 40:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = "صف اپراتور";
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Green;
                        break;
                    case 16:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = "هولد";
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Green;
                        break;
                    case 41:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = "اپراتور";
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Green;
                        break;
                    default:
                        dgvExtension.Rows[indx].Cells["وضعیت"].Value = string.Format(" ({0})  مشغول", state);
                        dgvExtension.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Yellow;
                        break;

                }
            }
        }
    

        private void dgvDigitalTrunkrefresh()
        {
            //indexScroll = dgvSub.FirstDisplayedScrollingRowIndex;
            int count = 0;
            cDatabseConnection dbTemp = new cDatabseConnection();
            dsDigitalTrunk = dbTemp.Refresh("tblDigitalTrunk", "Agent_Db");


            DataTable dt = new DataTable();
            dt.Columns.Add("ردیف");
            dt.Columns.Add("پورت");
            dt.Columns.Add("وضعیت");
            dt.Columns.Add("مخاطب");

            DataRow dd;

            foreach (DataRow dr in dsDigitalTrunk.Tables[0].Rows)
            {


                if (dr["phone"].ToString().Trim() == "0")
                    continue;
                dd = dt.NewRow();
                count++;
                dd["ردیف"] = count.ToString();
                dd["پورت"] = dr["phone"].ToString().Trim();
                dd["وضعیت"] = Int32.Parse(dr["state"].ToString().Trim());


                dd["مخاطب"] = dr["otheparty"].ToString().Trim();

                dt.Rows.Add(dd);
            }
            this.dgvDigitalTrunk.DataSource = dt;
            dgvDigitalTrunk.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDigitalTrunk.Columns["وضعیت"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDigitalTrunk.Columns["ردیف"].Width = 35;
            this.dgvDigitalTrunk.Columns["پورت"].Width = 75;
            this.dgvDigitalTrunk.Columns["مخاطب"].Width = 105;

            for (int indx = 0; indx < dgvDigitalTrunk.Rows.Count; indx++)
            {

                switch (Int32.Parse(dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value.ToString()))
                {
                    case 0:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = "آزاد";
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.White;
                        break;
                    case 1:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = "شماره گیری";
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Red;
                        break;

                    case 2:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = "مکالمه";
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Green;
                        break;
                    default:

                        break;

                }

            }

        }
        private void dgvDigitalTrunkrefresh_state()
        {
            int state;
            //indexScroll = dgvSub.FirstDisplayedScrollingRowIndex;
            cDatabseConnection dbTemp = new cDatabseConnection();
            dsDigitalTrunk = dbTemp.Refresh("tblDigitalTrunk", "Agent_Db");

            for (int indx = 0; indx < dgvDigitalTrunk.Rows.Count; indx++)
            {
                try
                {
                    state = Int32.Parse(dsDigitalTrunk.Tables[0].Rows[indx]["state"].ToString().Trim());
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);

                    return;
                }
                switch (state)
                {
                    case 0:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = "آزاد";
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.White;
                        dgvDigitalTrunk.Rows[indx].Cells["مخاطب"].Value = dsDigitalTrunk.Tables[0].Rows[indx]["OtheParty"].ToString().Trim();
                        break;
                    case 1:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = "انتظار";
                            dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Red;
                        break;
                    case 4:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = "زنگ میخورد";
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Red;
                        dgvDigitalTrunk.Rows[indx].Cells["مخاطب"].Value = dsDigitalTrunk.Tables[0].Rows[indx]["OtheParty"].ToString().Trim();
                        break;
                    case 5:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = "مکالمه";
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Green;
                        break;
                    case 13:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = "منتظر قطع";
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.DimGray;
                        break;
                    case 15:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = "انتظار";
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Green;
                        break;
                    case 6:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = string.Format("شماره گیری");

                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Yellow;
                        break;
                    case 7 :
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = string.Format("برقراری تماس");

                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Azure;
                        break;
                    default:
                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Value = string.Format(" ({0})  مشغول", state);

                        dgvDigitalTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Yellow;
                        break;

                }
               


            }



        }

        private void dgvAnalogTrunkrefresh()
        {
            //indexScroll = dgvSub.FirstDisplayedScrollingRowIndex;
            cDatabseConnection dbTemp = new cDatabseConnection();
            dsAnalogTrunk = dbTemp.Refresh("tblAnalogTrunk", "Agent_Db");


            DataTable dt = new DataTable();
            dt.Columns.Add("تلفن");
            dt.Columns.Add("وضعیت");
            dt.Columns.Add("مخاطب");

            DataRow dd;

            foreach (DataRow dr in dsAnalogTrunk.Tables[0].Rows)
            {
                if (dr["phone"].ToString().Trim() == "0")
                    continue;
                dd = dt.NewRow();
                dd["تلفن"] = dr["phone"].ToString().Trim();
                dd["وضعیت"] = Int32.Parse(dr["state"].ToString().Trim());


                dd["مخاطب"] = dr["otheparty"].ToString().Trim();

                dt.Rows.Add(dd);
            }
            this.dgvAnalogTrunk.DataSource = dt;
            dgvAnalogTrunk.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAnalogTrunk.Columns["وضعیت"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvAnalogTrunk.Columns["تلفن"].Width = 75;
            this.dgvAnalogTrunk.Columns["مخاطب"].Width = 105;

            for (int indx = 0; indx < dgvAnalogTrunk.Rows.Count; indx++)
            {

                switch (Int32.Parse(dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Value.ToString()))
                {
                    case 0:
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Value = "آزاد";
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.White;
                        break;
                    case 1:
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Value = "شماره گیری";
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Red;
                        break;

                    case 2:
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Value = "مکالمه";
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Green;
                        break;
                    default:

                        break;

                }

            }

        }
        private void dgvAnalogTrunkrefresh_state()
        {
            int state;
            //indexScroll = dgvSub.FirstDisplayedScrollingRowIndex;
            cDatabseConnection dbTemp = new cDatabseConnection();
            dsAnalogTrunk = dbTemp.Refresh("tblAnalogTrunk", "Agent_Db");

            for (int indx = 0; indx < dgvAnalogTrunk.Rows.Count; indx++)
            {
                try
                {
                    state = Int32.Parse(dsAnalogTrunk.Tables[0].Rows[indx]["state"].ToString().Trim());
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);

                    return;
                }
                switch (state)
                {
                    case 0:
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Value = "آزادد";
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.White;
                        break;
                    case 1:
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Value = "شماره گیری";
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Red;
                        break;

                    case 2:
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Value = "مکالمه";
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Green;
                        break;
                    case 16:
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Value = "در صف";
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.DimGray;
                        break;
                    default:
                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Value = string.Format(" ({0})  مشغول", state);

                        dgvAnalogTrunk.Rows[indx].Cells["وضعیت"].Style.BackColor = Color.Yellow;
                        break;

                }
                try
                {
                    if (Int32.Parse(dsAnalogTrunk.Tables[0].Rows[indx]["InOut"].ToString().Trim()) == (Int32)TrunkInOut.Incomming) 
                        dgvAnalogTrunk.Rows[indx].Cells["تلفن"].Style.BackColor = Color.Bisque;
                }
                catch (Exception ee)
                {


                }


            }



        }



        private void viewStatus_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fa-IR"); 
            dgvAnalogTrunkrefresh();
            dgvDigitalTrunkrefresh();
            dgvExtensionRefresh();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dgvAnalogTrunkrefresh_state();
            dgvDigitalTrunkrefresh_state();
            dgvExtensionRefresh_state();
            timer1.Start();
        }


    }
}
