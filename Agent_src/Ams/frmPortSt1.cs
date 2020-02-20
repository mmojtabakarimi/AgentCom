using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace AgentCom
{
    public partial class frmPortSt1 : Form
    {
        private DataSet dsSubscriber = new DataSet();
                public static Queue ReceivedPackets = new Queue();
        public frmPortSt1()
        {
            InitializeComponent();
        }

        private void frmPortSt1_Load(object sender, EventArgs e)
        {
            frmSubRefresh();

        }
        public void frmSubRefresh()
        {
            //indexScroll = dgvSub.FirstDisplayedScrollingRowIndex;
            cDatabseConnection dbTemp = new cDatabseConnection();
            dsSubscriber = dbTemp.Refresh("tblLineData", "SystemData");
            int index = 0;
            for (index = 0; index < dgvSub.RowCount - 1; index++)
                if (dgvSub.Rows[index].Selected)
                    break;

            DataTable dt = new DataTable();
            dt.Columns.Add("Phone");
            dt.Columns.Add("Shelf");
            dt.Columns.Add("Slot");
            dt.Columns.Add("Port");
            dt.Columns.Add("State");

            byte nopre, nopp;
            nopre = 1;
            nopp = 3;

            DataRow dd;

            string postDigit = "";
            foreach (DataRow dr in dsSubscriber.Tables[0].Rows)
            {
                dd = dt.NewRow();
                postDigit = "";
      
                if (dr["PreDigit"].ToString().Trim() == "")
                    continue;

                dd["Phone"] = dr["PreDigit"].ToString().Trim().PadLeft(nopre,'0') + dr["Postdigit"].ToString().Trim().PadLeft(nopp,'0');// postDigit;

                dd["Slot"] = dr["SlotNumber"].ToString().Trim();
                        dd["Port"] = dr["PortNumber"].ToString().Trim();
                dd["Shelf"] = dr["ShelfNumber"].ToString().Trim();
                //dd["Class"] = dr["ClassNo"].ToString().Trim();
                dd["State"] = "آزاد";
                dt.Rows.Add(dd);
            }
            this.dgvSub.DataSource = dt;
            this.dgvSub.Columns["Phone"].Width = 60;
            this.dgvSub.Columns["Shelf"].Width = 40;
            this.dgvSub.Columns["Slot"].Width = 50;

            this.dgvSub.Columns["Port"].Width = 60;
            this.dgvSub.Columns["State"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSub.Columns["State"].Width = 90;
           

            timer1.Start();
         }

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] RxData = new byte[1024];
            byte slotNo = 0;
            byte shelfNo = 0;
            byte portNo = 0;
            byte state = 0;
            // Network.sSocket.Receive(RxData);
            while (CGlobal.StatusPackets.Count > 0)
            {

                RxData = (byte[])(CGlobal.StatusPackets.Dequeue());
                if ((RxData[0] == 0x01) && (RxData[1] == 0x2d))
                {
                    shelfNo = RxData[6];
                    slotNo = RxData[7];
                    portNo = RxData[8];
                    state = RxData[10];
                    UpdatePortState(shelfNo, slotNo, portNo, state);
                    ///Console.WriteLine("shn:{0},sn:{1},pn:{2} -->st:{3} ", shelfNo, slotNo, portNo, state);



                }



            }

        }
        void UpdatePortState(byte shn, byte sn, byte pn, byte State)
        {
            int indx=0;
            try
            {
                for (indx = 0; indx < dgvSub.Rows.Count; indx++)
                {
                    if ((byte.Parse(dgvSub.Rows[indx].Cells["Shelf"].Value.ToString().Trim()) == shn) &&
                        (byte.Parse(dgvSub.Rows[indx].Cells["Slot"].Value.ToString().Trim()) == sn) &&
                        (byte.Parse(dgvSub.Rows[indx].Cells["Port"].Value.ToString().Trim()) == pn)
                        )
                    {
                        switch (State)
                        {
                            case 0:
                                dgvSub.Rows[indx].Cells["State"].Value = "آزاد";
                                dgvSub.Rows[indx].Cells["State"].Style.BackColor = Color.White;
                                break;
                            case 2:
                                dgvSub.Rows[indx].Cells["State"].Value = "شماره گیری";
                                dgvSub.Rows[indx].Cells["State"].Style.BackColor = Color.Red;
                                break;
                            case 6:
                                dgvSub.Rows[indx].Cells["State"].Value = "WFOnhook";
                                dgvSub.Rows[indx].Cells["State"].Style.BackColor = Color.Red;
                                break;
                            case 5:
                                dgvSub.Rows[indx].Cells["State"].Value = "مکالمه";
                                dgvSub.Rows[indx].Cells["State"].Style.BackColor = Color.Green;
                                break;
                            case 16:
                                dgvSub.Rows[indx].Cells["State"].Value = "هولد";
                                dgvSub.Rows[indx].Cells["State"].Style.BackColor = Color.Green;
                                break;
                            default:
                                dgvSub.Rows[indx].Cells["State"].Value = string.Format("UN{0}", State);
                                dgvSub.Rows[indx].Cells["State"].Style.BackColor = Color.Yellow;
                                break;

                        }


                        // Console.WriteLine("shn:{0},sn:{1},pn:{2} <<<-->st:{3} ", shn, sn, pn, State);
                        break;
                    }

                }
            }
            catch (Exception ee)
            {



            }
           
        }

        private void frmPortSt1_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
                CGlobal.FocousFlag = false;
            if((this.WindowState == FormWindowState.Normal)||(this.WindowState == FormWindowState.Maximized))
                CGlobal.FocousFlag = true;
        }

        private void frmPortSt1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CGlobal.FocousFlag = false;
        }

        private void frmPortSt1_Activated(object sender, EventArgs e)
        {
            CGlobal.FocousFlag = true;
        }


    }
}

//Insert into Agent_DB.dbo.tblLineData select * from R_SystemData.dbo.tblLineData