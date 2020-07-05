using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Resources;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Data.OleDb;
using System.Management;

namespace AgentCom
{
    public partial class frmMain : Form
    {
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public static Network netSocket; //
        
        private AutoResetEvent receive = new AutoResetEvent(false);
        private DataSet dsExtensionHold = new DataSet();
        private DataSet dsExtensionAcdQeue = new DataSet();
        private DataSet dsTrunkHold = new DataSet();
        private DataSet dsTrunkAcdQeue = new DataSet();
        private DataSet dsPhoneBook= new DataSet();
        private DataSet dsAnalogTrunk = new DataSet();
        private DataSet dsAnsweredCall = new DataSet();
        private DataSet dsMissedCall = new DataSet();
        private DataSet dsTemp = new DataSet();

        public static cDatabseConnection cDB;
        private string Message1 = "";
        public byte opertatorState;
        int connectionStateCntr = 20 ;
        private DateTime durationtime;
        private double durationLong = 0;
        int basePid = 2100;//shariati 2100  6000 for erfan
        int trunkHoldcount;
        int extensionHoldCount;
        int trunkAcdQeuecount;
        int extensionAcdCount;
        string operatorAnswerphone;
        string operatorAnswerPid;
        string operatorAnswerPortType;
        bool operatorStartDialFlag;
        public bool debugViewFlag;
        public String extensionPortType = "1";
        public String trunkPortType = "2";
        public byte SoundCntr = 0;
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"medias\1.wav");

        public frmMain()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fa-IR");  
            InitializeComponent();

            
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "AgentCom" + AssemblyVersion;

            this.Focus();
            /*try
            {
                //sp.PlayLooping();
                sp.Play();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }*/
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fa-IR");
            frmLogin frmLog = new frmLogin();
            frmLog.ShowDialog();
            if (CGlobal.btnApplyPressed == true)
            {
                trunkHoldcount = 0;
                extensionHoldCount = 0;
                opertatorState = (byte)(CGlobal.State.Idle);
                trunkAcdQeuecount = 0;
                extensionAcdCount = 0;
                operatorAnswerphone = ""; ;
                operatorAnswerPid = "";
                operatorAnswerPortType = "";
                operatorStartDialFlag = false;
                cDB = new cDatabseConnection();

                cDB.DeletAllData("tblTrunkAcdQeue");
                cDB.DeletAllData("tblTrunkHold");
                cDB.DeletAllData("tblExtensionAcdQeue");
                cDB.DeletAllData("tblExtensionHold");
                cDB.DeletAllData("tblAnsweredCalls");
                cDB.DeletAllData("tblMissedCalls");
                /* byte shelf = 0, slot = 0, port = 0; int i = 0;
                for(shelf=0;shelf<5;shelf++)
                    for(slot=0;slot<32;slot++)
                        for (port = 0; port < 16; port++)
                        {
                            UpdateAnalogExtensionState(shelf, slot, port, 0);
                            ClearAnalogExtensionBparty(shelf, slot, port, "");
                        }
                 */


                lblOperatorNumber.Text = CGlobal.AgentNumber;
                CGlobal.OperatorLoginFlag = false;
                CGlobal.operatorDayNightFlag = true;//true mean day mode if change to false it is night mode
                dgvTrunkAcdQeueRefresh();
                dgvTrunkHoldRefresh();
                dgvExtensionAcdQeueRefresh();
                //   dgvExtensionHoldRefresh();
                dgvPhoneBookRefresh();
                dgvAnsweredCallRefresh();
                dgvMissedCallRefresh();


                // Beep at 5000 Hz for 1 second
                Console.Beep(500, 500);





                if (CGlobal.btnApplyPressed)
                {
                    //Add for interna usage of Agentcom
                    CGlobal.inNetSocket = new InternalNetwork();

                    CGlobal.inNetSocket.InitInternalNetwork();
                    ///InternalNetwork.cs missed 
                    netSocket = new Network();
                    if (netSocket.InitNetwork() == true)
                    {
                        //string str;
                        //str = string.Format("CTI_NMS وصل می باشد \n");
                        //rtxtDebugBox.Text += str;


                        SendDataTimer.Start();
                        tmrLivecheck.Start();

                        debugViewFlag = true;
                        CGlobal.FocousFlag = false;


                    }
                    //else
                    //    rtxtDebugBox.Text = "Kernel connection Error";

                    netSocket.InitStatusNetwork();
                    //frmMain.ActiveForm.WindowState = FormWindowState.Maximized;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                    Application.Exit();
            }else
                Application.Exit();

        }
       
        private void SendDataTimer_Tick(object sender, EventArgs e)
        {
            string phoneNo = "";
            string priCid = "";
            string hex = "";
            byte[] RxData = new byte[256];
            byte[] TxData = new byte[32];
            byte[] iTxData = new byte[256];            
            if (!CGlobal.FocousFlag )
            {
               this.txtOperatorDial.Focus();

           }
            if (CGlobal.SendPackets.Count > 0)
            {
                TxData = (byte[])(CGlobal.SendPackets.Dequeue());

                netSocket.SendUdpData(ref TxData);
                LogRxTxData(TxData,null, 1);

            }
            if (CGlobal.iSendPackets.Count > 0)
            {
                iTxData = (byte[])(CGlobal.iSendPackets.Dequeue());

                CGlobal.inNetSocket.SendUdpData(ref iTxData);
                
                LogRxTxData(iTxData, null, 1);

            }
          /*  else
            {

                byte[] dt = new byte[3];
                dt[0] = (byte)('%');
                dt[1] = (byte)('Y');
                dt[2] = (byte)('$');

                netSocket.SendUdpData(ref dt);
            }*/



            lblTrunkHoldCout.Text = trunkHoldcount.ToString();
            lblTrunkAcdQeueCout.Text = trunkAcdQeuecount.ToString();

            lblExtensionAcdQeueCout.Text = extensionAcdCount.ToString();
            
            lblExtensionHoldCout.Text = extensionHoldCount.ToString();
            
            SoundCntr++;
            if (SoundCntr > 4)
            {
                SoundManager();
                SoundCntr = 0;
            }
            lblOpertorState.Text = ((CGlobal.State)(opertatorState)).ToString();
            if(lblOpertorState.Text ==((CGlobal.State)(0)).ToString())
            {
                lblOpertorState.BackColor = Color.Lime;
            }
            else
            {
                lblOpertorState.BackColor = Color.Red;
            }
            int loop_count = 0;
            while ((CGlobal.iReceivedPackets.Count > 0) &&(loop_count<20))
            {

                RxData = (byte[])(CGlobal.iReceivedPackets.Dequeue());


                string something = Encoding.UTF8.GetString(RxData);
                if (CGlobal.lastInteralTxMessage == something.Trim().Replace("\0",string.Empty))
                {
                    Console.WriteLine("Oh  my packet  come  here" + something);
                }
                else
                {
                    LogRxTxData(RxData, something, 4);
                    cDB.UpdateSqlData(something.Trim(), ref Message1);
                    dgvPhoneBookRefresh();
                }
                loop_count++;
                    

            }
            loop_count = 0;
            while((CGlobal.ReceivedPackets.Count > 0) &&(loop_count<20))
            {

                RxData = (byte[])(CGlobal.ReceivedPackets.Dequeue());

                LogRxTxData(RxData,null, 0);

                phoneNo = "";
                priCid = "";
                hex = "";
                
                if ((RxData[0] == (byte)('A')) && (RxData[1] == (byte)('M')) &&
                    (RxData[2] == (byte)('S')) && (RxData[3] == (byte)(':')) &&
                    (RxData[4] == (byte)('%')))
                    switch (RxData[5])
                    {
                        case (byte)('1'):
                            //operator State 

                            
                            break;
                        case (byte)('b'):
                            //operator State 
                            for (int j = 6; j < 6 + 2; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                phoneNo = hex + phoneNo;


                            }
                            phoneNo = GetNumber(phoneNo);

                            /*string cphoneNo1 = "";
                            for (int j = 11; j < 11 + 6; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                cphoneNo1 = hex + cphoneNo1;


                            }
                            cphoneNo1 = GetNumber1(cphoneNo1);*/

                            UpdateAnalogTrunkState(phoneNo, "0", RxData[19].ToString());
                            Console.WriteLine("port:{0},st:{1} ", phoneNo, RxData[19]);


                            break;
                        case (byte)('c'):
                            //operator State 
                            for (int j = 6; j < 6 + 2; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                phoneNo = hex + phoneNo;


                            }
                            phoneNo = GetNumber(phoneNo);

                            string cphoneNo1 = "";
                            for (int j = 10; j < 10+2; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                cphoneNo1 = hex + cphoneNo1;


                            }
                            cphoneNo1 = GetNumber(cphoneNo1);

                            UpdateAnalogTrunkState(phoneNo, "0", RxData[19].ToString());
                            Console.WriteLine("2port:{0},st:{1} ", phoneNo, RxData[19]);
                            if (RxData[19] == 4)
                               // MessageBox.Show(string.Format("port:{0},st:{1} bpt:{2} ", phoneNo, RxData[19], cphoneNo1));
                                UpdateAnalogTrunkBparty(phoneNo, "0", cphoneNo1);
                            if (RxData[19] == 0)
                                UpdateAnalogTrunkBparty(phoneNo, "0", "");

                            break;
                        case (byte)('2'):
                            break;
                        case (byte)('3'):
                            break;
                        case (byte)('4'):
                            //operator Login/logout
                      
                           
                            
                            for (int j = 6; j < 6+2; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                phoneNo = hex + phoneNo;


                            }
                            phoneNo = GetNumber(phoneNo);
                            //rtxtDebugBox.Text+= phoneNo +"\r\n";
                            //rtxtDebugBox.SelectionStart = rtxtDebugBox.Text.Length;
                            //rtxtDebugBox.ScrollToCaret();
                           // rtxtDebugBox.ScrollToCaret();
                            //rtxtDebugBox.Select(0, rtxtDebugBox.Text.Length);
                            //rtxtDebugBox.ScrollToCaret();
                            DateTime dt = DateTime.Now;
                            if (phoneNo == CGlobal.AgentPhone)
                            {
                                if (RxData[14] == 1)
                                {
                                    btnOperatorState.Text = "وارد شد " + "(" + phoneNo + ")";
                                    btnOperatorState.BackColor = Color.LightGreen;
                                    cDB.InsertAgent(phoneNo, dt.Date.ToString(), dt.TimeOfDay.ToString(), "Login", ref Message1);
                                    CGlobal.OperatorLoginFlag = true;
                                }
                                else
                                {
                                    btnOperatorState.Text = "خارج شد";
                                    btnOperatorState.BackColor = Color.Red;

                                    cDB.InsertAgent(phoneNo, dt.Date.ToLongDateString(), dt.TimeOfDay.ToString(), "Logout", ref Message1);
                                    CGlobal.OperatorLoginFlag = false;

                                }
                            }
                            break;
                        case (byte)('|'):
                            //caller Id
                            for (int j = 6; j < 6 + 2; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                phoneNo = hex + phoneNo;


                            }
                            phoneNo = GetNumber(phoneNo);
                            string cphoneNo = "";
                            for (int j = 11; j < 11 + 6; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                cphoneNo = hex + cphoneNo;


                            }
                            cphoneNo = GetNumber1(cphoneNo);
                            UpdateTrunkAcdQeueRow(phoneNo, cphoneNo, "");
                            break;
                        case (byte)('7'):
                            //call land from pri
                            for (int j = 6; j < 6 + 2; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                phoneNo = hex + phoneNo;


                            }
                            phoneNo = GetNumber(phoneNo);
                            priCid = "";
                            if (RxData[16] == 1)
                            {
                                for (int j = 10; j < 15 ; j++)
                                {
                                    hex = BitConverter.ToString(RxData, j, 1);

                                    priCid =hex +   priCid;
                                   


                                }
                                priCid = GetNumber1(priCid);
                                AddPRITrunkAcdQeueRow(phoneNo, priCid, "");
                            }
                            else
                            {//we must get cid form remove trunk row anfdp ut it into missed call row
                               string misedcid =  RemoveTrunkAcdQeue(phoneNo, "", "");
                                //check if this pid is on hold must clear from there????????????????

                                //add to trunk missedcall
                                //we muset select trunk and find pricid 
                               AddToMissedCallList(misedcid, misedcid, "", "17");
                            //   AddToMissedCallList(phoneNo, phoneNo, "", "17");
                            }

                            trunkAcdQeuecount = (int)(RxData[17]);

                            break;
                        case (byte)('8'):
                            //call land from analog trunk
                            for (int j = 6; j < 6 + 2; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                phoneNo = hex + phoneNo;


                            }
                            phoneNo = GetNumber(phoneNo);
                            if (RxData[16] == 1)
                            {
                                AddTrunkAcdQeueRow(phoneNo, "", "");
                            }
                            else
                            {
                                RemoveTrunkAcdQeue(phoneNo, "", "");
                                //add to trunk missedcall
                                AddToMissedCallList(phoneNo, phoneNo, "","2");
                            }
                            
                            trunkAcdQeuecount = (int)(RxData[17]);

                            break;
                        case (byte)('9'):
                            //call land form extension
                            for (int j = 6; j < 6 + 2; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                phoneNo = hex + phoneNo;


                            }
                            phoneNo = GetNumber(phoneNo);
                            string bphoneNo = "";
                            for (int j = 10; j < 10 + 2; j++)
                            {
                                hex = BitConverter.ToString(RxData, j, 1);

                                bphoneNo = hex + bphoneNo;


                            }
                            bphoneNo = GetNumber(bphoneNo);
                            if (RxData[16] == 1)
                            {
                               // RemoveExtensionHold(phoneNo, bphoneNo, "");
                                AddExtensionAcdQeueRow(phoneNo, bphoneNo, "");
                            }
                            else
                            {
                                RemoveExtensionAcdQeue(phoneNo, bphoneNo, "");
                                AddToMissedCallList(phoneNo, bphoneNo, "","1");
           
                                //add to missed call fro extension
                            }


                            extensionAcdCount = (int)(RxData[17]);

                            break;
                        case (byte)(17):

                            lblConectionState.Text = "ارتباط وصل می باشد";
                            lblConectionState.BackColor = Color.Green;
                            connectionStateCntr = 0;
                            
                            break;
                        default:
                            break;

                    }

                loop_count++;
            }

            
            while (CGlobal.StatusPackets.Count > 0)
            {

                RxData = (byte[])(CGlobal.StatusPackets.Dequeue());
                byte msg = RxData[2];
                string digit = "";
                if ((RxData[0] == 0x01) && (RxData[1] == 0x2d))
                {
                    byte shelfNo = RxData[6];
                    byte slotNo = RxData[7];
                    byte portNo = RxData[8];

                    switch (msg)
                    {
                        case 0x01://line state
                            byte state = RxData[10];
                            UpdateAnalogExtensionState(shelfNo, slotNo, portNo, state);
                            UpdateAnalogExtensionTime(shelfNo, slotNo, portNo, DateTime.Now.ToString("HH:mm:ss"));
                            if ((state == 0) || (state == 41))
                                ClearAnalogExtensionBparty(shelfNo, slotNo, portNo, digit);
                            //if (state == 3) add for show aparty for called party
                            //  updateAnalogExtensionAparty(shelfNo, slotNo, portNo);
                            ///Console.WriteLine("shn:{0},sn:{1},pn:{2} -->st:{3} ", shelfNo, slotNo, portNo, state);
                            break;
                        case 0x0c://line send digit
                            switch (RxData[10])
                            {
                                case 0x0a:
                                    digit = "0";
                                    break;
                                case 0x0b:
                                    digit = "*";
                                    break;
                                case 0x0c:
                                    digit = "#";
                                    break;
                                default:
                                    digit = RxData[10].ToString();
                                    break;

                            }


                            UpdateAnalogExtensionBparty(shelfNo, slotNo, portNo, digit);
                            // Console.WriteLine("shn:{0},sn:{1},pn:{2} -->Digit:{3} ", shelfNo, slotNo, portNo, digit);
                            break;

                        default:
                            break;
                    }

                }
                else
                {

                    Console.WriteLine("{0}", RxData[19]);
                }



            }

            SendDataTimer.Start();


        }

        private void debugWindowToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //if (debugWindowToolStripMenuItem.CheckState == CheckState.Checked)
            //{
            //    label1.Visible = true;
            //    rtxtDebugBox.Visible = true;
                    
            //}
            //else
            //{
            //    label1.Visible = false;
            //    rtxtDebugBox.Visible = false;
            //}
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] Tx = new byte[15];
            byte[] Tx1 = new byte[15];


            byte[] TxData = new byte[1024];
            byte[] TxData1 = new byte[1024];

            byte indx = 0;

            Tx1[0] = (byte)QueueType.ADMQueue;
            Tx1[1] = (byte)AdminPortType.OperatorType;
            Tx1[2] = (byte)OperatorTypeSetMessage.Answer;
            Tx1[3] = 0x00;//Send packet with message pool
            //Genarate Info feild of packet
            Tx1[4] = (byte)OperatorTypeSetMessage.Disconnect;

            indx = 5;
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx1[indx++] = 1;


            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));


            Tx1[indx++] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx1);

            if (CGlobal.OperatorLoginFlag)
            {

                /*Tx[0] = (byte)('%');
                Tx[1] = (byte)('L');
                Tx[2] = 9;  //len of the packet
                */
                Tx[0] = (byte)QueueType.ADMQueue;
                Tx[1] = (byte)AdminPortType.OperatorType;
                Tx[2] = (byte)OperatorTypeSetMessage.Answer;
                Tx[3] = 0x00;//Send packet with message pool
                //Genarate Info feild of packet
                Tx[4] = (byte)OperatorTypeSetMessage.OperatorLogin;

                indx = 5;
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                Tx[indx++] = 1;


                Tx[indx++] = 0;  //logoff
                Tx[indx++] = 0;
                Tx[indx++] = 0;
                Tx[indx++] = 0;


                Tx[indx++] = (byte)('$');

                CGlobal.SendPackets.Enqueue(Tx);


            }



            if (CGlobal.SendPackets.Count > 0)
            {
                TxData = (byte[])(CGlobal.SendPackets.Dequeue());

                netSocket.SendUdpData(ref TxData);
                LogRxTxData(TxData, null, 1);

            }
            if (CGlobal.SendPackets.Count > 0)
            {
                TxData1 = (byte[])(CGlobal.SendPackets.Dequeue());

                netSocket.SendUdpData(ref TxData1);
                LogRxTxData(TxData1, null, 1);

            }
            Application.Exit();
        }

        private void debugWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(debugViewFlag)
                debugViewFlag = false;
            else
                debugViewFlag = true;

        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }

        private void TxtDialKeyPad_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }




        private void tsmAddKey_Click(object sender, EventArgs e)
        {

        }

        private void lsvExtensionState_KeyDown(object sender, KeyEventArgs e)
        {
            //this.txtOperatorDial.Focus();
            //MessageBox.Show(e.KeyCode.ToString());

        }

        private void trvPhoneBook_KeyDown(object sender, KeyEventArgs e)
        {
            //this.txtOperatorDial.Focus();
            //MessageBox.Show(e.KeyCode.ToString());
        }

        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            frmAddNumber frmAddNum = new frmAddNumber();
            frmAddNum.ShowDialog();

          
        }

        private void btnMakeCall_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteNumber_Click(object sender, EventArgs e)
        {
              
           



        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
           

            for (int indx = 0; indx < dgvTrunkAcdQeue.Rows.Count; indx++)
            {
                if (dgvTrunkAcdQeue.Rows[indx].Selected)
                {
                    AnswerPhone(dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), dgvTrunkAcdQeue.Rows[indx].Cells["مخاطب"].Value.ToString());

                    operatorAnswerphone = dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString();
                    operatorAnswerPid = dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString();
                    operatorAnswerPortType = dgvTrunkAcdQeue.Rows[indx].Cells["مخاطب"].Value.ToString();

                    OperatorPanelUpdate(dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), dgvTrunkAcdQeue.Rows[indx].Cells["مخاطب"].Value.ToString());

                    if (trunkAcdQeuecount > 0)
                        trunkAcdQeuecount--;


                    RemoveTrunkAcdQeue(dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), "");
                    break;
                }
            }

            

        }

        //**********************************************************
        //***********************************************************
        public string RemoveTrunkAcdQeue(string pid, string phoneNo, string state)
        {
            string cidmissed = ""; 
             for(int indx = 0 ;indx<dgvTrunkAcdQeue.Rows.Count;indx++)
                 if (dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString().TrimEnd().TrimStart() == pid)
                 {
                     cidmissed = dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString().TrimEnd().TrimStart();
                     break;
                 }

            cDB.DeletTrunkAcdQeue(pid, phoneNo, ref Message1);
            dgvTrunkAcdQeueRefresh(); 
            return cidmissed;
        }
        public void AddTrunkAcdQeueRow(string pid, string phoneNo, string state)
        {

            cDB.InsertTrunkAcdQeue((byte)(1), pid, phoneNo, "2", state, ref Message1);

            dgvTrunkAcdQeueRefresh();
        }
        public void AddPRITrunkAcdQeueRow(string pid, string phoneNo, string state)
        {

            cDB.InsertTrunkAcdQeue((byte)(1), pid, phoneNo, "17", state, ref Message1);

            dgvTrunkAcdQeueRefresh();
        }
        public void UpdateTrunkAcdQeueRow(string pid, string phoneNo, string state)
        {

            cDB.UpadtetTrunkAcdQeue((byte)(1), pid, phoneNo, "2", state, ref Message1);

            dgvTrunkAcdQeueRefresh();
        }
        public void UpdatePRITrunkAcdQeueRow(string pid, string phoneNo, string state)
        {

            cDB.UpadtetTrunkAcdQeue((byte)(1), pid, phoneNo, "17", state, ref Message1);

            dgvTrunkAcdQeueRefresh();
        }        
        //**********
        public void RemoveTrunkHold(string pid, string phoneNo, string state)
        {

            cDB.DeletTrunkHold(pid, phoneNo, ref Message1);
            dgvTrunkHoldRefresh();

            if (trunkHoldcount > 0)
                trunkHoldcount--;
           
        }
        public void AddTrunkHoldRow(string pid, string phoneNo, string state)
        {

            cDB.InsertTrunkHold((byte)(1), pid, phoneNo, state, state, ref Message1);

            dgvTrunkHoldRefresh();

        }
        //************
       /* public void RemoveExtensionHold(string pid, string phoneNo, string state)
        {
            cDB.DeletExtensionHold( pid, phoneNo, ref Message1);
            dgvExtensionHoldRefresh();
            if(extensionHoldCount>0)
                extensionHoldCount--;
        }
        public void AddExtensionHoldRow(string pid, string phoneNo, string state)
        {

            cDB.InsertExtensionHold((byte)(1), pid, phoneNo, "1", state, ref Message1);

            dgvExtensionHoldRefresh();
            extensionHoldCount++;

        }*/
        //************
        public void RemoveExtensionAcdQeue(string pid, string phoneNo, string state)
        {


            cDB.DeletExtensionAcdQeue(pid, phoneNo, ref Message1);
            dgvExtensionAcdQeueRefresh();
        }
        public void AddExtensionAcdQeueRow(string pid, string phoneNo, string state)
        {


            cDB.InsertExtensionAcdQeue((byte)(1), pid, phoneNo, "1", state, ref Message1);
           
            dgvExtensionAcdQeueRefresh();

        }
        public void AddToAnsweredCallListRow(string pid, string phoneNo, string state,string pt)
        {

            state = DateTime.Now.ToString("HH:mm:ss");
            string ddate = DateTime.Now.ToString("ddMMyyyy");
            cDB.InsertExtensionAnsweredCallListRow((byte)(1), pid, phoneNo, pt, state, ref Message1);
            cDB.InsertExtensionCTAAnsweredCallListRow((byte)(1), pid, phoneNo, pt, ddate,state, ref Message1);
            dgvAnsweredCallRefresh();
            

        }
        public void AddToMissedCallList(string pid, string phoneNo, string state,string pt)
        {

            state = DateTime.Now.ToString("HH:mm:ss");
            string ddate = DateTime.Now.ToString("ddMMyyyy");
            cDB.InsertExtensionMissedCallList((byte)(1), pid, phoneNo, pt, state, ref Message1);
            cDB.InsertExtensionCTAMissedCallList((byte)(1), pid, phoneNo, pt, ddate,state, ref Message1);
            dgvMissedCallRefresh();



        }
        //************************************************************
        //************************************************************
        public void PutWaitPhone(string pid, string phoneNo, string portType)
        {

            try
            {
                int len = pid.Length;
                byte[] Tx = new byte[13];
                Tx[0] = (byte)('%');
                Tx[1] = (byte)('W');
                Tx[2] = 9;  //len of the packet
                Tx[3] = byte.Parse(pid.Substring(0, 1));
                Tx[4] = byte.Parse(pid.Substring(1, 1));
                Tx[5] = byte.Parse(pid.Substring(2, 1));
                Tx[6] = byte.Parse(pid.Substring(3, 1));
                Tx[7] = byte.Parse(portType);
                Tx[8] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                Tx[9] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                Tx[10] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                Tx[11] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));


                Tx[12] = (byte)('$');

                CGlobal.SendPackets.Enqueue(Tx);

            }
            catch (Exception ee)
            {
                LogRxTxData(null, "PutWaitPhone"+ ee.Message.ToString(), 3);

            }
            finally
            {


            }

        }
        public void AnswerPhone(string pid, string phoneNo,string portType)
        {
           
            
            int len = pid.Length;
            byte[] Tx = new byte[15];
            byte indx=0;
            
            try
            {
                Tx[0] = (byte)QueueType.ADMQueue;
                Tx[1] = (byte)AdminPortType.OperatorType;
                Tx[2] = (byte)OperatorTypeSetMessage.Answer;
                Tx[3] = 0x00;//Send packet with message pool
                //Genarate Info feild of packet
                Tx[4] = (byte)OperatorTypeSetMessage.Answer;

                indx = 5;
                Tx[indx++] = byte.Parse(pid.Substring(0, 1));
                Tx[indx++] = byte.Parse(pid.Substring(1, 1));
                Tx[indx++] = byte.Parse(pid.Substring(2, 1));
                Tx[indx++] = byte.Parse(pid.Substring(3, 1));

                Tx[indx++] = byte.Parse(portType);


                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));


                Tx[indx++] = (byte)('$');


                CGlobal.SendPackets.Enqueue(Tx);

                opertatorState = (byte)(CGlobal.State.Answer);
            }
            catch (Exception ee)
            {
                
            }
            finally 
            {
            
            }
      }
        private void btnDial_Click(object sender, EventArgs e)
        {
            byte[] Tx = new byte[13];
            txtOperatorDial.BackColor = Color.LightGreen;
            operatorStartDialFlag = true;
            //put operator on hold and start dial number
            if (opertatorState == (byte)(CGlobal.State.Idle))
            {


                Tx[0] = (byte)('%');
                Tx[1] = (byte)('O');
                Tx[2] = 9;  //len of the packet
                Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                Tx[7] = 1;


                Tx[8] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                Tx[9] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                Tx[10] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                Tx[11] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));


                Tx[12] = (byte)('$');

                opertatorState = (byte)(CGlobal.State.WFOffhook_Ack);


            }
            else
            {


                string portType = "2";
                string pid = operatorAnswerPid;
                string dialDigit;
                int len = pid.Length;
                dialDigit = txtOperatorDial.Text;

                Tx[0] = (byte)('%');
                Tx[1] = (byte)('F');
                Tx[2] = 9;  //len of the packet
                Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));
                Tx[7] = byte.Parse(portType);
                Tx[12] = (byte)('$');

            }
                CGlobal.SendPackets.Enqueue(Tx);
        }
       
        public void OperatorPanelUpdate(string pid, string phoneNo, string portType)
        {
            if(portType == "1")
                txtOperatorPanel.Text = phoneNo + "داخلی";
            else
                txtOperatorPanel.Text = phoneNo + "ترانک";

            operatorAnswerphone = phoneNo;
            operatorAnswerPid = pid;
            operatorAnswerPortType =portType;
        }

        //**********************************
        //make valid number
        public string GetNumber(String NumberString)
        {
            string dig,digit="";
            int len = NumberString.Length;
            for (int j = 0; j < len; j++)
            {
                dig = NumberString.Substring(j, 1);
                if (dig == "A")
                    dig = "0";
                if (dig == "a")
                    dig = "0";
                if (dig == "f")
                    break;


                digit += dig;
            }


            return digit;
        }
        //make number visevesa
        public string GetNumber1(String NumberString)
        {
            string dig, digit = "";
            int len = NumberString.Length;
            for (int j = 0; j < len; j++)
            {
                dig = NumberString.Substring(j, 1);
                if (dig == "A")
                    dig = "0";
                if (dig == "a")
                    dig = "0";
                if (dig == "F")
                    continue;


                digit = dig+digit;
            }


            return digit;
        }
        private void btnPutHold_Click(object sender, EventArgs e)
        {
            for (int indx = 0; indx < dgvTrunkAcdQeue.Rows.Count; indx++)
            {
                if (dgvTrunkAcdQeue.Rows[indx].Selected)
                {

                    PutWaitPhone(dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                       dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), dgvTrunkAcdQeue.Rows[indx].Cells["مخاطب"].Value.ToString());

                    AddTrunkHoldRow(dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), "");

                    if (trunkAcdQeuecount > 0)
                        trunkAcdQeuecount--;


                    RemoveTrunkAcdQeue(dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), "");
                    break;
                }
            }


        }

        private void btnRemoveHold_Click(object sender, EventArgs e)
        {

            for (int indx = 0; indx < dgvTrunkHold.Rows.Count; indx++)
            {
                if (dgvTrunkHold.Rows[indx].Selected)
                {
                    AnswerPhone(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), dgvTrunkHold.Rows[indx].Cells["مخاطب"].Value.ToString());



                    OperatorPanelUpdate(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), dgvTrunkHold.Rows[indx].Cells["مخاطب"].Value.ToString());



                    RemoveTrunkHold(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), "");
                    break;
                }
            }

           /* for (int indx = 0; indx < dgvExtensionHold.Rows.Count; indx++)
            {
                if (dgvExtensionHold.Rows[indx].Selected)
                {
                    AnswerPhone(dgvExtensionHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvExtensionHold.Rows[indx].Cells["تلفن"].Value.ToString(), dgvExtensionHold.Rows[indx].Cells["مخاطب"].Value.ToString());



                    OperatorPanelUpdate(dgvExtensionHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvExtensionHold.Rows[indx].Cells["تلفن"].Value.ToString(), dgvExtensionHold.Rows[indx].Cells["مخاطب"].Value.ToString());



                    RemoveExtensionHold(dgvExtensionHold.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvExtensionHold.Rows[indx].Cells["تلفن"].Value.ToString(), "");
                    break;
                }
            }*/


        }
    
 
        private void btnKey7_Click(object sender, EventArgs e)
        {
            if(operatorStartDialFlag)
                txtOperatorDial.Text += "7";
            byte[] Tx = new byte[13];
            Tx[0] = (byte)('%');
            Tx[1] = (byte)('G');
            Tx[2] = 9;  //len of the packet
            Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[7] = 1;


            Tx[8] = (byte)(7);
            Tx[9] = 0;
            Tx[10] = 0;
            Tx[11] = 0;


            Tx[12] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);
        }

        private void btnKey8_Click(object sender, EventArgs e)
        {
            if (operatorStartDialFlag)
                txtOperatorDial.Text += "8";
            byte[] Tx = new byte[13];
            Tx[0] = (byte)('%');
            Tx[1] = (byte)('G');
            Tx[2] = 9;  //len of the packet
            Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[7] = 1;


            Tx[8] = (byte)(8);
            Tx[9] = 0;
            Tx[10] = 0;
            Tx[11] = 0;


            Tx[12] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);
        }

        private void btnKey9_Click(object sender, EventArgs e)
        {
            if (operatorStartDialFlag)
                txtOperatorDial.Text += "9";
            byte[] Tx = new byte[13];
            Tx[0] = (byte)('%');
            Tx[1] = (byte)('G');
            Tx[2] = 9;  //len of the packet
            Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[7] = 1;


            Tx[8] = (byte)(9);
            Tx[9] = 0;
            Tx[10] = 0;
            Tx[11] = 0;


            Tx[12] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);
        }

        private void btnKey4_Click(object sender, EventArgs e)
        {
            if (operatorStartDialFlag)
                txtOperatorDial.Text += "4";
            byte[] Tx = new byte[13];
            Tx[0] = (byte)('%');
            Tx[1] = (byte)('G');
            Tx[2] = 9;  //len of the packet
            Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[7] = 1;


            Tx[8] = (byte)(4);
            Tx[9] = 0;
            Tx[10] = 0;
            Tx[11] = 0;


            Tx[12] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);
        }

        private void btnKey6_Click(object sender, EventArgs e)
        {
            if (operatorStartDialFlag)
                txtOperatorDial.Text += "6";
            byte[] Tx = new byte[13];
            Tx[0] = (byte)('%');
            Tx[1] = (byte)('G');
            Tx[2] = 9;  //len of the packet
            Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[7] = 1;


            Tx[8] = (byte)(6);
            Tx[9] = 0;
            Tx[10] = 0;
            Tx[11] = 0;


            Tx[12] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);
        }

        private void btnKey1_Click(object sender, EventArgs e)
        {
            if (operatorStartDialFlag)
                txtOperatorDial.Text += "1";
            byte[] Tx = new byte[13];
            Tx[0] = (byte)('%');
            Tx[1] = (byte)('G');
            Tx[2] = 9;  //len of the packet
            Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[7] = 1;


            Tx[8] = (byte)(1);
            Tx[9] = 0;
            Tx[10] = 0;
            Tx[11] = 0;


            Tx[12] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);
        }

        private void btnKey2_Click(object sender, EventArgs e)
        {
            if (operatorStartDialFlag)
                txtOperatorDial.Text += "2";
            byte[] Tx = new byte[13];
            Tx[0] = (byte)('%');
            Tx[1] = (byte)('G');
            Tx[2] = 9;  //len of the packet
            Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[7] = 1;


            Tx[8] = 2;
            Tx[9] = 0;
            Tx[10] = 0;
            Tx[11] = 0;


            Tx[12] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);   
        }

        private void btnKey3_Click(object sender, EventArgs e)
        {
            if (operatorStartDialFlag)
                txtOperatorDial.Text += "3";
            byte[] Tx = new byte[13];
            Tx[0] = (byte)('%');
            Tx[1] = (byte)('G');
            Tx[2] = 9;  //len of the packet
            Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[7] = 1;


            Tx[8] = 3;
            Tx[9] = 0;
            Tx[10] = 0;
            Tx[11] = 0;


            Tx[12] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx); 
        }

        private void btnKey0_Click(object sender, EventArgs e)
        {
            if (operatorStartDialFlag)
                txtOperatorDial.Text += "0";
            byte[] Tx = new byte[13];
            Tx[0] = (byte)('%');
            Tx[1] = (byte)('G');
            Tx[2] = 9;  //len of the packet
            Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[7] = 1;


            Tx[8] = 10;
            Tx[9] = 0;
            Tx[10] = 0;
            Tx[11] = 0;


            Tx[12] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);           

        }

        private void btnKey5_Click(object sender, EventArgs e)
        {
            if (operatorStartDialFlag)
                txtOperatorDial.Text += "5";

            byte[] Tx = new byte[13];
            Tx[0] = (byte)('%');
            Tx[1] = (byte)('G');
            Tx[2] = 9;  //len of the packet
            Tx[3] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[4] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[5] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[6] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[7] = 1;


            Tx[8] = (byte)(5);
            Tx[9] = 0;
            Tx[10] = 0;
            Tx[11] = 0;


            Tx[12] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);
        }
        //*******************************************************
        public void dgvAnsweredCallRefresh()
        {

            cDatabseConnection dbTemp = new cDatabseConnection();
            dsAnsweredCall = dbTemp.Refresh("tblAnsweredCalls", "Agent_DB");
            DataTable dt = new DataTable();

            dt.Columns.Add("ردیف");
            //dt.Columns.Add("پورت");
            dt.Columns.Add("تلفن");
            dt.Columns.Add("مخاطب");
            dt.Columns.Add("زمان");
            DataRow dd;
            int idex = 0;

            foreach (DataRow dr in dsAnsweredCall.Tables[0].Rows)
            {
                dd = dt.NewRow();
                dd["ردیف"] = (idex++).ToString();// dr["index"].ToString().Trim();
                dd["تلفن"] = dr["phone"].ToString().Trim();
                if(dr["porttype"].ToString().Trim() == "1")
                    dd["مخاطب"] = "داخلی";
                
                if (dr["porttype"].ToString().Trim() == "2")
                    dd["مخاطب"] = "شهری";

                dd["زمان"] = dr["state"].ToString().Trim();

                dt.Rows.Add(dd);
            }


            this.dgvAnsweredCall.DataSource = dt;
            this.dgvAnsweredCall.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvAnsweredCall.Columns["ردیف"].Width = 30;
            this.dgvAnsweredCall.Columns["تلفن"].Width = 70;
            this.dgvAnsweredCall.Columns["مخاطب"].Width = 80;
            this.dgvAnsweredCall.Columns["زمان"].Width = 70;
            this.dgvAnsweredCall.Columns["ردیف"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvAnsweredCall.Columns["تلفن"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvAnsweredCall.Columns["مخاطب"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvAnsweredCall.Columns["زمان"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvAnsweredCall.RowHeadersVisible = false;
            //if (dgvAnsweredCall.RowCount > 0)
               // dgvAnsweredCall.Rows[0].Selected = true;
        }
        //****************************************
        public void dgvMissedCallRefresh()
        {

            cDatabseConnection dbTemp = new cDatabseConnection();
            dsMissedCall = dbTemp.Refresh("tblMissedCalls", "Agent_DB");
            DataTable dt = new DataTable();

            dt.Columns.Add("ردیف");

            dt.Columns.Add("تلفن");
            dt.Columns.Add("مخاطب");
            dt.Columns.Add("زمان");
            DataRow dd;
            int idex = 0;

            foreach (DataRow dr in dsMissedCall.Tables[0].Rows)
            {
                dd = dt.NewRow();
                dd["ردیف"] = (idex++).ToString();// dr["index"].ToString().Trim();
                dd["تلفن"] = dr["phone"].ToString().Trim();
                if (dr["porttype"].ToString().Trim() == "1")
                    dd["مخاطب"] = "داخلی";

                if ((dr["porttype"].ToString().Trim() == "2")||(dr["porttype"].ToString().Trim() == "17"))
                    dd["مخاطب"] = "شهری";
                dd["زمان"] = dr["state"].ToString().Trim();
                dt.Rows.Add(dd);

            }

            this.dgvMissedCall.DataSource = dt;
            this.dgvMissedCall.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvMissedCall.Columns["ردیف"].Width = 30;
            this.dgvMissedCall.Columns["تلفن"].Width = 70;
            this.dgvMissedCall.Columns["مخاطب"].Width = 80;
            this.dgvMissedCall.Columns["زمان"].Width = 70;

            this.dgvMissedCall.Columns["ردیف"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvMissedCall.Columns["تلفن"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvMissedCall.Columns["مخاطب"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvMissedCall.Columns["زمان"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvMissedCall.RowHeadersVisible = false;
           // if (dgvMissedCall.RowCount > 0)
               // dgvMissedCall.Rows[0].Selected = true;
        }
        //****************************************
        public void dgvPhoneBookRefresh()
        {
            int count = 0;
            cDatabseConnection dbTemp = new cDatabseConnection();
            dsPhoneBook = dbTemp.Refresh("tblPhoneBook", "Agent_DB");
            DataTable dt = new DataTable();

            dt.Columns.Add("ردیف");
            dt.Columns.Add("نام");
            dt.Columns.Add("تخصص");
            dt.Columns.Add("تلفن");

            DataRow dd;
            foreach (DataRow dr in dsPhoneBook.Tables[0].Rows)
            {
                count++;
                dd = dt.NewRow();
                dd["ردیف"] = count.ToString();
                dd["نام"] = dr["name"].ToString().Trim();
                dd["تخصص"] = dr["job"].ToString().Trim();
                dd["تلفن"] = dr["numebr"].ToString().Trim();


                dt.Rows.Add(dd);
                //it  must  be  updated index  colume  in  tale  equal  to  view  index
                cDB.UpdatePhoneBookIndex(dr["id"].ToString().Trim(), count, ref Message1);
            }
            this.lblPhonebookCount.Text = count.ToString();
            this.dgvPhoneBook.DataSource = dt;
            dgvPhoneBook.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhoneBook.Columns["ردیف"].Width = 40;
            this.dgvPhoneBook.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhoneBook.Columns["ردیف"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvPhoneBook.Columns["نام"].Width = 160;
            this.dgvPhoneBook.Columns["نام"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhoneBook.Columns["تخصص"].Width = 160;
            this.dgvPhoneBook.Columns["تخصص"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhoneBook.Columns["تلفن"].Width = 150;
            this.dgvPhoneBook.Columns["تلفن"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
 
            Application.DoEvents();
            /*if (dgvTrunkAcdQeue.RowCount > 0)
                dgvTrunkAcdQeue.Rows[0].Selected = true;*/
            dsPhoneBook = dbTemp.Refresh("tblPhoneBook", "Agent_DB");

        }
         

       //****************************************
        public void dgvTrunkAcdQeueRefresh()
        {

           cDatabseConnection dbTemp = new cDatabseConnection();
           dsTrunkAcdQeue = dbTemp.Refresh("tblTrunkAcdQeue", "Agent_DB");
            DataTable dt = new DataTable();

           // dt.Columns.Add("ردیف");
            dt.Columns.Add("پورت");
            dt.Columns.Add("تلفن");
            dt.Columns.Add("نام");
            dt.Columns.Add("مخاطب");

            DataRow dd;
            foreach (DataRow dr in dsTrunkAcdQeue.Tables[0].Rows)
            {
                dd = dt.NewRow();
                //dd["ردیف"] = dr["index"].ToString().Trim();
                dd["پورت"] = dr["pid"].ToString().Trim();
                dd["تلفن"] = dr["phone"].ToString().Trim();
                dd["نام"] =UpdateFromPhoneBook(dr["phone"].ToString().Trim());// dr["state"].ToString().Trim()
                dd["مخاطب"] = dr["porttype"].ToString().Trim();


                dt.Rows.Add(dd);
             }
        
            this.dgvTrunkAcdQeue.DataSource = dt;
            dgvTrunkAcdQeue.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           // this.dgvTrunkAcdQeue.Columns["ردیف"].Width = 40;
            this.dgvTrunkAcdQeue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvTrunkAcdQeue.Columns["ردیف"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTrunkAcdQeue.Columns["پورت"].Width = 65;
            this.dgvTrunkAcdQeue.Columns["پورت"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTrunkAcdQeue.Columns["تلفن"].Width = 120;
            this.dgvTrunkAcdQeue.Columns["تلفن"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTrunkAcdQeue.Columns["مخاطب"].Width = 65;
            this.dgvTrunkAcdQeue.Columns["مخاطب"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTrunkAcdQeue.Columns["نام"].Width = 120;
            this.dgvTrunkAcdQeue.Columns["نام"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgvTrunkAcdQeue.RowCount > 0)
                dgvTrunkAcdQeue.Rows[0].Selected = true;

        }

        public void dgvTrunkHoldRefresh()
        {

            cDatabseConnection dbTemp = new cDatabseConnection();
            dsTrunkHold = dbTemp.Refresh("tblTrunkHold", "Agent_DB");
            DataTable dt = new DataTable();

            //dt.Columns.Add("ردیف");
            dt.Columns.Add("پورت");
            dt.Columns.Add("تلفن");
            dt.Columns.Add("مخاطب");
            dt.Columns.Add("وضعیت");
            DataRow dd;
            foreach (DataRow dr in dsTrunkHold.Tables[0].Rows)
            {
                dd = dt.NewRow();
              //  dd["ردیف"] = dr["index"].ToString().Trim();
                dd["پورت"] = dr["pid"].ToString().Trim();
                dd["تلفن"] = dr["phone"].ToString().Trim();
                dd["مخاطب"] = dr["porttype"].ToString().Trim();
                dd["وضعیت"] = dr["state"].ToString().Trim();

                dt.Rows.Add(dd);
            }

            this.dgvTrunkHold.DataSource = dt;
            dgvTrunkHold.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvTrunkHold.Columns["ردیف"].Width = 40;
            this.dgvTrunkHold.Columns["پورت"].Width = 65;
            this.dgvTrunkHold.Columns["تلفن"].Width = 120;
            this.dgvTrunkHold.Columns["مخاطب"].Width = 113;
            this.dgvTrunkHold.Columns["وضعیت"].Width = 65;
            if (dgvTrunkHold.RowCount > 0)
                dgvTrunkHold.Rows[0].Selected = true;
        }
        public void dgvExtensionAcdQeueRefresh()
        {

            cDatabseConnection dbTemp = new cDatabseConnection();
            dsExtensionAcdQeue = dbTemp.Refresh("tblExtensionAcdQeue", "Agent_DB");
            DataTable dt = new DataTable();

            //dt.Columns.Add("ردیف");
            dt.Columns.Add("پورت");
            dt.Columns.Add("تلفن");
            dt.Columns.Add("نام");
            dt.Columns.Add("مخاطب");

            DataRow dd;
            int pos = 0;
            foreach (DataRow dr in dsExtensionAcdQeue.Tables[0].Rows)
            {
                dd = dt.NewRow();
              //  dd["ردیف"] = dr["index"].ToString().Trim();
                dd["پورت"] = dr["pid"].ToString().Trim();
                dd["تلفن"] = dr["phone"].ToString().Trim();
                dd["مخاطب"] = dr["porttype"].ToString().Trim();
                dd["نام"] = UpdateFromPhoneBook(dr["phone"].ToString().Trim());// dr["state"].ToString().Trim()
                checkExtensionPeriority(dr["phone"].ToString().Trim(), ref pos);

/*                if (dr["phone"].ToString().Trim() == "2006")
                {
                    if (pos>0)
                        dt.Rows.InsertAt(dd, pos - 1);
                    else
                        dt.Rows.InsertAt(dd, pos);
                }
                else*/
                    dt.Rows.InsertAt(dd, pos);

                pos++;
            }

            this.dgvExtensionAcdQeue.DataSource = dt;
            dgvExtensionAcdQeue.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            //this.dgvExtensionAcdQeue.Columns["ردیف"].Width = 40;
            this.dgvExtensionAcdQeue.Columns["پورت"].Width = 65;
            this.dgvExtensionAcdQeue.Columns["تلفن"].Width = 120;
            this.dgvExtensionAcdQeue.Columns["مخاطب"].Width = 65;
            this.dgvExtensionAcdQeue.Columns["نام"].Width = 120;
            if (dgvExtensionAcdQeue.RowCount > 0)
                dgvExtensionAcdQeue.Rows[0].Selected = true;
        }
       /* public void dgvExtensionHoldRefresh()
        {

            cDatabseConnection dbTemp = new cDatabseConnection();
            dsExtensionHold = dbTemp.Refresh("tblExtensionHold", "Agent_DB");
            DataTable dt = new DataTable();

          //  dt.Columns.Add("ردیف");
            dt.Columns.Add("پورت");
            dt.Columns.Add("تلفن");
            dt.Columns.Add("مخاطب");
            dt.Columns.Add("وضعیت");
            DataRow dd;
            
            foreach (DataRow dr in dsExtensionHold.Tables[0].Rows)
            {
                dd = dt.NewRow();
              //  dd["ردیف"] = dr["index"].ToString().Trim();
               dd["پورت"] = dr["pid"].ToString().Trim();
                dd["تلفن"] = dr["phone"].ToString().Trim();
                dd["مخاطب"] = dr["porttype"].ToString().Trim();
                dd["وضعیت"] = dr["state"].ToString().Trim();

                dt.Rows.Add(dd);

            }
            
            this.dgvExtensionHold.DataSource = dt;
            dgvExtensionHold.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvExtensionHold.Columns["ردیف"].Width = 40;
            this.dgvExtensionHold.Columns["پورت"].Width = 65;
            this.dgvExtensionHold.Columns["تلفن"].Width = 120;
            this.dgvExtensionHold.Columns["مخاطب"].Width = 113;
            this.dgvExtensionHold.Columns["وضعیت"].Width = 65;
            if (dgvExtensionHold.RowCount > 0)
                dgvExtensionHold.Rows[0].Selected = true;
        }*/
        private string UpdateFromPhoneBook(string phoneNo)
        {
            string result = cDB.FindNameByPhoneNo(phoneNo);
            return result;
        }
        //***********************************************
        public bool checkExtensionPeriority(string phoneNumber, ref int pos)
        {
            cDatabseConnection dbTemp = new cDatabseConnection();
            DataSet dsTemp = new DataSet();
            dsTemp = dbTemp.SelectData("tblExtensionPeriority",("phone = " +phoneNumber));

            foreach (DataRow dr in dsTemp.Tables[0].Rows)
            {
                if (dr["phone"].ToString().Trim() == phoneNumber)
                    if (pos > 0)
                        pos--;
                return true;  //true means that exteinsion find 

            }

            return false;




        }
        //*****************************************
        private void tslAgentReportView_Click(object sender, EventArgs e)
        {
            frmAgentStatus frmAgent = new frmAgentStatus(0);
            frmAgent.ShowDialog();

        }
       
        static public void LogRxTxData(byte[] Data,string str ,byte type)
        {
            StreamWriter sw;
            string folderName = "C:\\Agent_LOG\\";
            string fileName;
            switch (type)
            {
                case 0://Log Rx Data

                    fileName = folderName + "RTX" + DateTime.Now.Year.ToString() +
                              DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";

                    if (!Directory.Exists(folderName))
                        Directory.CreateDirectory(folderName);


                    if (File.Exists(fileName))
                    {
                        sw = new StreamWriter(File.Open((fileName), FileMode.Append, FileAccess.Write));
                    }
                    else
                    {
                        sw = new StreamWriter(fileName);
                    }

                    sw.Write("***>>>>>R>: ");
                    for (int i = 0; i < Data.Length; i++)
                        sw.Write(Data[i].ToString() + ",");
                    sw.WriteLine("\r");
                    sw.Close();
                    break;
                case 1: //Log Tx Data

                    fileName = folderName + "RTX" + DateTime.Now.Year.ToString() +
                             DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";

                    if (!Directory.Exists(folderName))
                        Directory.CreateDirectory(folderName);


                    if (File.Exists(fileName))
                    {
                        sw = new StreamWriter(File.Open((fileName), FileMode.Append, FileAccess.Write));
                    }
                    else
                    {
                        sw = new StreamWriter(fileName);
                    }

                    sw.Write("***<T>: ");
                    for (int i = 0; i < Data.Length; i++)
                        sw.Write(Data[i].ToString() + ",");
                    sw.WriteLine("\r");
                    sw.Close();
                    break;
                case 2: //Log Error Data

                    fileName = folderName + "RTX" + DateTime.Now.Year.ToString() +
                             DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";

                    if (!Directory.Exists(folderName))
                        Directory.CreateDirectory(folderName);


                    if (File.Exists(fileName))
                    {
                        sw = new StreamWriter(File.Open((fileName), FileMode.Append, FileAccess.Write));
                    }
                    else
                    {
                        sw = new StreamWriter(fileName);
                    }

                    sw.Write("*ECH: ");
                    for (int i = 0; i < Data.Length; i++)
                        sw.Write(Data[i].ToString() + ",");
                    sw.WriteLine("\r");
                    sw.Close();
                    break;
                case 3: //Log Error Data

                    fileName = folderName + "RTX" + DateTime.Now.Year.ToString() +
                             DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";

                    if (!Directory.Exists(folderName))
                        Directory.CreateDirectory(folderName);


                    if (File.Exists(fileName))
                    {
                        sw = new StreamWriter(File.Open((fileName), FileMode.Append, FileAccess.Write));
                    }
                    else
                    {
                        sw = new StreamWriter(fileName);
                    }

                    sw.Write("*P>>>ECH>>>: ");
                   
                        sw.Write(str);
                    sw.WriteLine("\n\r");
                    sw.Close();
                    break;
                case 4: //Log DB

                    fileName = folderName + "RTX" + DateTime.Now.Year.ToString() +
                             DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";

                    if (!Directory.Exists(folderName))
                        Directory.CreateDirectory(folderName);


                    if (File.Exists(fileName))
                    {
                        sw = new StreamWriter(File.Open((fileName), FileMode.Append, FileAccess.Write));
                    }
                    else
                    {
                        sw = new StreamWriter(fileName);
                    }

                    sw.Write("DB Cmd >>>: ");

                    sw.Write(str);
                    sw.WriteLine("\n\r");
                    sw.Close();
                    break;
                default:
                    break;
            }
        }
    
        private void checkKeyPressed()
        {
            try
            {
                Int32 i;
                i = Int32.Parse(txtOperatorDial.Text);
            }
            catch (Exception ee)
            {
                txtOperatorDial.Text = "";

            }

        }
        private void SoundManager()
        {
            if ((extensionAcdCount > 0) || (trunkAcdQeuecount > 0))
            {
            //    Console.Beep(500, 500);
                try
                {
                    //sp.PlayLooping();
                    sp.Play();
                }
                catch (Exception ee)
                {
                    // MessageBox.Show(ee.Message.ToString());
                }
            }
            else
            {
                try
                {
                    //sp.PlayLooping();
                    sp.Stop();
                }
                catch (Exception ee)
                {
                    // MessageBox.Show(ee.Message.ToString());
                }
            }
        }

        private void RemoveFromHold_Click()
        {

            for (int indx = 0; indx < dgvTrunkHold.Rows.Count; indx++)
            {
                if (dgvTrunkHold.Rows[indx].Selected)
                {
                    AnswerPhone(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), dgvTrunkHold.Rows[indx].Cells["مخاطب"].Value.ToString());



                    OperatorPanelUpdate(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), dgvTrunkHold.Rows[indx].Cells["مخاطب"].Value.ToString());

                    operatorAnswerphone = dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString();
                    operatorAnswerPid = dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString();
                    if(dgvTrunkHold.Rows[indx].Cells["مخاطب"].Value.ToString() == "1")
                        operatorAnswerPortType = extensionPortType;
                    else
                        operatorAnswerPortType = trunkPortType;
                        
                    RemoveTrunkHold(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), "");
                    break;
                }
            }

        }
        private int HoldAnswer()
        {
            //dgvTrunkHold
            for (int indx = 0; indx < dgvTrunkHold.Rows.Count; indx++)
            {
                if (dgvTrunkHold.Rows[indx].Selected)
                {
                    trunkPortType = dgvTrunkHold.Rows[indx].Cells["مخاطب"].Value.ToString().TrimEnd().TrimStart();

                    AnswerPhone(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), trunkPortType);

                    operatorAnswerphone = dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString();
                    operatorAnswerPid = dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString();
                    operatorAnswerPortType = trunkPortType;

                    OperatorPanelUpdate(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), trunkPortType);

                    if (trunkHoldcount  > 0)
                        trunkHoldcount--;

                    CGlobal.operatorCallType = (byte)CGlobal.OperatorCallType.National;
                    CGlobal.operatorDigitCount = 0;
                    RemoveTrunkHold(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), "");
                    return 1;
                }
            }
            return 0;
        }
    
        private int TrunkAnswer()
        {
            for (int indx = 0; indx < dgvTrunkAcdQeue.Rows.Count; indx++)
            {
                if (dgvTrunkAcdQeue.Rows[indx].Selected)
                {
                    trunkPortType = dgvTrunkAcdQeue.Rows[indx].Cells["مخاطب"].Value.ToString().TrimEnd().TrimStart();

                    AnswerPhone(dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), trunkPortType);

                    operatorAnswerphone = dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString();
                    operatorAnswerPid = dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString();
                    operatorAnswerPortType = trunkPortType;

                    OperatorPanelUpdate(dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), trunkPortType);

                    if (trunkAcdQeuecount > 0)
                        trunkAcdQeuecount--;

                    CGlobal.operatorCallType = (byte)CGlobal.OperatorCallType.National;
                    CGlobal.operatorDigitCount = 0;
                    //Add to answered call
                    try
                    {
                        AddToAnsweredCallListRow(dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                                        dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), "", "2");
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }

                    RemoveTrunkAcdQeue(dgvTrunkAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvTrunkAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), "");
                    return 1;
                }
            }
            return 0;
        }
        private void TrunkAnswerFromHold()
        {
            for (int indx = 0; indx < dgvTrunkHold.Rows.Count; indx++)
            {
                if (dgvTrunkHold.Rows[indx].Selected)
                {
                    AnswerPhone(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), trunkPortType);

                    operatorAnswerphone = dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString();
                    operatorAnswerPid = dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString();
                    operatorAnswerPortType = trunkPortType;

                    OperatorPanelUpdate(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), trunkPortType);

                    if (trunkHoldcount > 0)
                        trunkHoldcount--;

                    CGlobal.operatorCallType = (byte)CGlobal.OperatorCallType.National;
                    CGlobal.operatorDigitCount = 0;

                    RemoveTrunkAcdQeue(dgvTrunkHold.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvTrunkHold.Rows[indx].Cells["تلفن"].Value.ToString(), "");
                    break;
                }
            }

        }
        private int ExtensionAnswer()
        {


            for (int indx = 0; indx < dgvExtensionAcdQeue.Rows.Count; indx++)
            {
                if (dgvExtensionAcdQeue.Rows[indx].Selected)
                {
                    AnswerPhone(dgvExtensionAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvExtensionAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), extensionPortType);

                    operatorAnswerphone = dgvExtensionAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString();
                    operatorAnswerPid = dgvExtensionAcdQeue.Rows[indx].Cells["پورت"].Value.ToString();
                    operatorAnswerPortType = extensionPortType;

                    OperatorPanelUpdate(dgvExtensionAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvExtensionAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), extensionPortType);

                    if (extensionAcdCount > 0)
                        extensionAcdCount--;
                    CGlobal.operatorCallType = (byte)CGlobal.OperatorCallType.Internal;
                    CGlobal.operatorDigitCount = 0;
                    //Add to answered call
                    AddToAnsweredCallListRow(dgvExtensionAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvExtensionAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), "","1");
                    
                    RemoveExtensionAcdQeue(dgvExtensionAcdQeue.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvExtensionAcdQeue.Rows[indx].Cells["تلفن"].Value.ToString(), "");

                    //Add top answered call 
                    return 1;
                }
            }
            return 0;
        }
        /*private void ExtensionAnswerFromHold()
        {


            for (int indx = 0; indx < dgvExtensionHold.Rows.Count; indx++)
            {
                if (dgvExtensionHold.Rows[indx].Selected)
                {
                    AnswerPhone(dgvExtensionHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvExtensionHold.Rows[indx].Cells["تلفن"].Value.ToString(), extensionPortType);

                    operatorAnswerphone = dgvExtensionHold.Rows[indx].Cells["تلفن"].Value.ToString();
                    operatorAnswerPid = dgvExtensionHold.Rows[indx].Cells["پورت"].Value.ToString();
                    operatorAnswerPortType = extensionPortType;

                    OperatorPanelUpdate(dgvExtensionHold.Rows[indx].Cells["پورت"].Value.ToString(),
                        dgvExtensionHold.Rows[indx].Cells["تلفن"].Value.ToString(), extensionPortType);

                    if (extensionHoldCount > 0)
                        extensionHoldCount--;
                    CGlobal.operatorCallType = (byte)CGlobal.OperatorCallType.Internal;
                    CGlobal.operatorDigitCount = 0;

                    RemoveExtensionHold(dgvExtensionHold.Rows[indx].Cells["پورت"].Value.ToString(),
                                    dgvExtensionHold.Rows[indx].Cells["تلفن"].Value.ToString(), "");
                    break;
                }
            }
        }*/
        private void SendSlashPacket(string pid, string phone, string portType)
        {//reftan roi khat


        }
        private void SendParkPacket(string pid, string phone, string portType)
        {//hold party and when disc go back to operator


        }
        private void SendDeletePacket(string pid, string phone, string portType)
        {
            // return back hold party

        }
        private void SendAsteriskPacket(string pid, string phone, string portType)
        {
            // redial packet

        }
        private void dialFromPhonbook(string phoneNumber)
        {
            byte[] Tx = new byte[16];
            int indx = 0;

            SendOffhokPacket();
            opertatorState = (byte)(CGlobal.State.WfDail);
            Application.DoEvents();
            
           int len = phoneNumber.Length;
           for (int i = 0; i < len; i++)
           {
               Tx = new byte[16];
               Tx[0] = (byte)QueueType.ADMQueue;
               Tx[1] = (byte)AdminPortType.OperatorType;
               Tx[2] = (byte)OperatorTypeSetMessage.Answer;
               Tx[3] = 0x00;//Send packet with message pool
               //Genarate Info feild of packet
               Tx[4] = (byte)OperatorTypeSetMessage.DialDigit;

               indx = 5;
               Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
               Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
               Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
               Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

               Tx[indx++] = 1;

               if (byte.Parse(phoneNumber.Substring(i, 1)) == 0)
                   Tx[indx++] = 10;
               else
                   Tx[indx++] = byte.Parse(phoneNumber.Substring(i, 1));
               Tx[indx++] = 0;
               Tx[indx++] = 0;
               Tx[indx++] = 0;


               Tx[indx++] = (byte)('$');
               txtOperatorDial.Text += byte.Parse(phoneNumber.Substring(i, 1));
               if (opertatorState == (byte)(CGlobal.State.WfDail))
                   opertatorState = (byte)(CGlobal.State.WfAnswer);


               CGlobal.SendPackets.Enqueue(Tx);
               System.Threading.Thread.Sleep(100);
           }


        }
        private void SendFlashPacket(string pid, string portType)
        {
            byte[] Tx = new byte[15];
            byte indx = 0;
            Tx[0] = (byte)QueueType.ADMQueue;
            Tx[1] = (byte)AdminPortType.OperatorType;
            Tx[2] = (byte)OperatorTypeSetMessage.Answer;
            Tx[3] = 0x00;//Send packet with message pool
            //Genarate Info feild of packet
            Tx[4] = (byte)OperatorTypeSetMessage.Hold;

            indx = 5;
            Tx[indx++] = byte.Parse(pid.Substring(0, 1));
            Tx[indx++] = byte.Parse(pid.Substring(1, 1));
            Tx[indx++] = byte.Parse(pid.Substring(2, 1));
            Tx[indx++] = byte.Parse(pid.Substring(3, 1));
            Tx[indx++] = byte.Parse(portType);
            Tx[indx++] = 1;



            Tx[indx++] = 0;
            Tx[indx++] = 0;
            Tx[indx++] = 0;
            Tx[indx++] = (byte)('$');
            CGlobal.SendPackets.Enqueue(Tx);
        }
        private void SendReverBackPacket(string pid, string portType)
        {
            byte[] Tx = new byte[15];
            byte indx = 0;
            Tx[0] = (byte)QueueType.ADMQueue;
            Tx[1] = (byte)AdminPortType.OperatorType;
            Tx[2] = (byte)OperatorTypeSetMessage.Answer;
            Tx[3] = 0x00;//Send packet with message pool
            //Genarate Info feild of packet
            Tx[4] = (byte)OperatorTypeSetMessage.RevertBack;

            indx = 5;
            Tx[indx++] = byte.Parse(pid.Substring(0, 1));
            Tx[indx++] = byte.Parse(pid.Substring(1, 1));
            Tx[indx++] = byte.Parse(pid.Substring(2, 1));
            Tx[indx++] = byte.Parse(pid.Substring(3, 1));
            Tx[indx++] = byte.Parse(portType);
            Tx[indx++] = 1;



            Tx[indx++] = 0;
            Tx[indx++] = 0;
            Tx[indx++] = 0;
            Tx[indx++] = (byte)('$');
            CGlobal.SendPackets.Enqueue(Tx);
        }

        private void SendAccessTalkParty(string pid, string portType)
        {
            //  / key in right number keypad 
            // for goe beetwen to party talk and agian make call beetween them
            //reftan roie khateh do nafar 
            byte[] Tx = new byte[15];
            byte indx = 0;
            Tx[0] = (byte)QueueType.ADMQueue;
            Tx[1] = (byte)AdminPortType.OperatorType;
            Tx[2] = (byte)OperatorTypeSetMessage.Answer;
            Tx[3] = 0x00;//Send packet with message pool
            //Genarate Info feild of packet
            Tx[4] = (byte)OperatorTypeSetMessage.AccessTalkParty;

            indx = 5;
            string dest_text = "";
            if (txtOperatorDial.Text != "")
                try
                {
                    int dest_pid = int.Parse(txtOperatorDial.Text);
                    dest_pid -= basePid;
                    dest_text = dest_pid.ToString();
                    int len = dest_text.Length;
                    for (int i = 0; i < (4 - len); i++)
                        dest_text = "0" + dest_text;

                    Tx[indx++] = byte.Parse(dest_text.Substring(0, 1));
                    Tx[indx++] = byte.Parse(dest_text.Substring(1, 1));
                    Tx[indx++] = byte.Parse(dest_text.Substring(2, 1));
                    Tx[indx++] = byte.Parse(dest_text.Substring(3, 1));
                    Tx[indx++] = byte.Parse(portType);


                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                    Tx[indx++] = (byte)('$');
                    CGlobal.SendPackets.Enqueue(Tx);
                }
                catch (Exception ee)
                {
                    return;
                }
        }
        private void SendOperatorDiscLinePacket(string pid, string portType)
        {
            //  / key in right number keypad 
            // for goe beetwen to party talk and agian make call beetween them
            //reftan roie khateh do nafar 
            byte[] Tx = new byte[17];
            byte indx = 0;
            Tx[0] = (byte)QueueType.ADMQueue;
            Tx[1] = (byte)AdminPortType.OperatorType;
            Tx[2] = (byte)OperatorTypeSetMessage.Answer;
            Tx[3] = 0x00;//Send packet with message pool
            //Genarate Info feild of packet
            Tx[4] = (byte)OperatorTypeSetMessage.OperatorDiscNumber;

            indx = 5;
            string dest_text = "";
            if (txtOperatorDial.Text != "" )
            try
            {
                int dest_pid = int.Parse(txtOperatorDial.Text);
                dest_pid -= basePid;
                dest_text = dest_pid.ToString();
                int len = dest_text.Length;
                for (int i = 0; i < (4-len); i++)
                    dest_text = "0"+ dest_text;

                Tx[indx++] = byte.Parse(dest_text.Substring(0, 1));
                Tx[indx++] = byte.Parse(dest_text.Substring(1, 1));
                Tx[indx++] = byte.Parse(dest_text.Substring(2, 1));
                Tx[indx++] = byte.Parse(dest_text.Substring(3, 1));
                Tx[indx++] = byte.Parse(portType);
                Tx[indx++] = 1;



                Tx[indx++] = 0;
                Tx[indx++] = 0;
                Tx[indx++] = 0;
                Tx[indx++] = (byte)('$');
                CGlobal.SendPackets.Enqueue(Tx);
            }
            catch (Exception ee)
            {
                return;
            }
        }
        private void SendDisconnectPacket()
        {
            byte[] Tx = new byte[15];
            byte indx = 0;

            Tx[0] = (byte)QueueType.ADMQueue;
            Tx[1] = (byte)AdminPortType.OperatorType;
            Tx[2] = (byte)OperatorTypeSetMessage.Answer;
            Tx[3] = 0x00;//Send packet with message pool
            //Genarate Info feild of packet
            Tx[4] = (byte)OperatorTypeSetMessage.Disconnect;

            indx = 5;
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[indx++] = 1;


            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));


            Tx[indx++] = (byte)('$');
            CGlobal.SendPackets.Enqueue(Tx);
            opertatorState = (byte)(CGlobal.State.Idle);
            OperatorPanelUpdate("", "", "");
            CGlobal.operatorRedialPhoneNumber = txtOperatorDial.Text;
            txtOperatorDial.Text = "";
            txtOperatorDial.BackColor = Color.White;
        }
        private void SendOffhokPacket()
        {
            byte[] Tx = new byte[15];
            byte indx = 0;

            /*Tx[0] = (byte)('%');
                         Tx[1] = (byte)('O');  //offhook
                         Tx[2] = 9;  //len of the packet*/
            Tx[0] = (byte)QueueType.ADMQueue;
            Tx[1] = (byte)AdminPortType.OperatorType;
            Tx[2] = (byte)OperatorTypeSetMessage.Answer;
            Tx[3] = 0x00;//Send packet with message pool
            //Genarate Info feild of packet
            Tx[4] = (byte)OperatorTypeSetMessage.Offhook;

            indx = 5;
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx[indx++] = 1;


            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));


            Tx[indx++] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);
        }
        private void checkForFinishPickup()
        {
            if (txtOperatorDial.Text.Length == 8)
            {
                if (CGlobal.pickupCall)
                {
                    CGlobal.pickupCall = false;
                    System.Threading.Thread.Sleep(2500);
                    SendDigitPacket("#");
                }
            }
        }
        private void SendDigitPacket(string digit)
        {
            byte[] Tx = new byte[15];
            byte indx = 0;
            txtOperatorDial.Text += digit;
            if (opertatorState != (byte)(CGlobal.State.Idle))
            {
                Tx[0] = (byte)QueueType.ADMQueue;
                Tx[1] = (byte)AdminPortType.OperatorType;
                Tx[2] = (byte)OperatorTypeSetMessage.Answer;
                Tx[3] = 0x00;//Send packet with message pool
                //Genarate Info feild of packet
                Tx[4] = (byte)OperatorTypeSetMessage.DialDigit;

                indx = 5;
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));
                Tx[indx++] = 1;
                if (digit == "*")
                    Tx[indx++] = 11;    
                else
                    if (digit == "#")
                        Tx[indx++] = 12;
                    else
                        if (digit == "0")
                            Tx[indx++] = 10;
                        else
                            Tx[indx++] = byte.Parse(digit);


                Tx[indx++] = 0;
                Tx[indx++] = 0;
                Tx[indx++] = 0;


                Tx[indx++] = (byte)('$');
                if (opertatorState == (byte)(CGlobal.State.WfDail))
                    opertatorState = (byte)(CGlobal.State.WfAnswer);


                CGlobal.SendPackets.Enqueue(Tx);

            }

        }
        private void txtOperatorDial_KeyUp(object sender, KeyEventArgs e)
        {
            //e.KeyChar == Keys.D8.
            byte[] Tx = new byte[15];
            byte indx = 0;

            // MessageBox.Show(e.KeyChar.ToString());
            switch (e.KeyValue)
            {
                case 67:  //c for  conferance the call  AccessTalkParty
                    SendAccessTalkParty(CGlobal.AgentNumber, "1");

                    break;
                case 80://p  key for pickup a call
                    SendOffhokPacket();
                    opertatorState = (byte)(CGlobal.State.WfDail);
                    SendDigitPacket("*");
                    SendDigitPacket("9");
                    SendDigitPacket("8");
                    SendDigitPacket("*");
                    CGlobal.pickupCall = true;


                    break;
                case 111:// "/" for acccess to line that is busy
                    //   key in right number keypad 
                    //  for goe beetwen to party talk and agian make call beetween them
                    //  raftan roie khateh do nafar 
                    SendOperatorDiscLinePacket(CGlobal.AgentNumber, "1");


                    break;
                case 8:// BackSpace Key 
                    //for revert back last hold call
                  
                    SendReverBackPacket(CGlobal.AgentNumber, "1");
                    txtOperatorDial.Text = "";
                    RemoveTrunkHold(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                    opertatorState = (byte)(CGlobal.State.Answer);
                    break;
                case 144:// numlock key 

                    //for make system night or day mode

                    break;
                case 106:  // * key in right number key pad    
                        //redial the last number dial by operator
                        OperatorRedial(CGlobal.operatorRedialPhoneNumber );
                    break;

                case 110: //Del key in right number keypad 

                    //for return back hold party to talk with opearator



                    break;

                case 49:
                case 97: 
                            SendDigitPacket("1");
                            CheckValidSpeedDialNumber(txtOperatorDial.Text);
                            checkForFinishPickup();
                    break;
                case 50:
                case 98:
                           SendDigitPacket("2");
                           CheckValidSpeedDialNumber(txtOperatorDial.Text);
                           checkForFinishPickup();

                    break;
                case 51:
                case 99:
                    SendDigitPacket("3");
                    CheckValidSpeedDialNumber(txtOperatorDial.Text);
                    checkForFinishPickup();
                    break;

                case 52:
                case 100:
                    SendDigitPacket("4");
                    CheckValidSpeedDialNumber(txtOperatorDial.Text);
                    checkForFinishPickup(); 
                    break;

                case 53:
                case 101:
                    SendDigitPacket("5");
                    CheckValidSpeedDialNumber(txtOperatorDial.Text);
                    checkForFinishPickup();
                    break;
                case 54:
                case 102:
                    SendDigitPacket("6");
                    CheckValidSpeedDialNumber(txtOperatorDial.Text);
                    checkForFinishPickup();
                    break;
                case 55:
                case 103:
                    SendDigitPacket("7");
                    CheckValidSpeedDialNumber(txtOperatorDial.Text);
                    checkForFinishPickup();
                    break;
                case 56:
                case 104:
                     SendDigitPacket("8");
                    CheckValidSpeedDialNumber(txtOperatorDial.Text);
                    checkForFinishPickup();
                    break;
                case 57:
                case 105:
                    SendDigitPacket("9");
                    CheckValidSpeedDialNumber(txtOperatorDial.Text);
                    checkForFinishPickup();
                
                    break;
                case 48:
                case 96:
                    SendDigitPacket("0");
                    CheckValidSpeedDialNumber(txtOperatorDial.Text);
                    checkForFinishPickup();
                
                    break;
                /*
                  case '*':
                  case '#':

                      break;*/



                case 32:
                    //space
                    
                    txtOperatorDial.BackColor = Color.LightGreen;
                    operatorStartDialFlag = true;
                    
                    switch (opertatorState)
                    {
                        case (byte)(CGlobal.State.Idle):
                            SendOffhokPacket();
                            opertatorState = (byte)(CGlobal.State.WfDail);
                            break;
                        case (byte)(CGlobal.State.Answer):
                        case (byte)(CGlobal.State.Hold):
                          /*  if(operatorAnswerPortType == "1")
                                RemoveExtensionHold(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                            else*/
                                RemoveTrunkHold(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);

                            SendDisconnectPacket();
                            break;
                        case (byte)(CGlobal.State.WfAnswer):
                        case (byte)(CGlobal.State.WfDail):
                            SendDisconnectPacket();
                            CGlobal.pickupCall = false;
                            break;
                        default:
                            return;
                    }

                    break;
                case 13: //right Enter 
                    switch (opertatorState)
                    {
                        case (byte)(CGlobal.State.Idle):
                        case (byte)CGlobal.State.Hold:
                            if (TrunkAnswer() == 1)
                            {
                                opertatorState = (byte)(CGlobal.State.Answer);
                            }
                        break;
                        default:
                            break;
                    }
                    break;

                case 17: //ctrl
                    switch (opertatorState)
                    {
                        case (byte)(CGlobal.State.Idle):
                        case (byte)CGlobal.State.Hold:

                            if (ExtensionAnswer() == 1)
                            {
                                opertatorState = (byte)(CGlobal.State.Answer);
                            }
                            break;
                        /*case (byte)( CGlobal.State.Answer):
                            PutWaitPhone(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                            AddExtensionHoldRow(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                            ExtensionAnswer();
                            break;*/
                        default:
                            break;
                    } break;
                case 27:
                    //Escape 
                   /* if (operatorAnswerPortType == "1")
                        RemoveExtensionHold(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                    else*/
                        RemoveTrunkHold(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                    //RemoveExtensionHold(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                        SendDisconnectPacket();
                    CGlobal.operatorRedialPhoneNumber = txtOperatorDial.Text;
                    txtOperatorDial.Text = "";
                    opertatorState = (byte)(CGlobal.State.Idle);
                    txtOperatorPanel.Text = "";
                    CGlobal.pickupCall = false;
                    break;
                case 107: //+ button
                    switch (opertatorState)
                    {
                        case (byte)(CGlobal.State.WfAnswer):
                            SendFlashPacket(CGlobal.AgentNumber, "1");

                            AddTrunkHoldRow(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                            opertatorState = (byte)(CGlobal.State.Hold);
                            txtOperatorDial.Text = "";
                            break;
                        case (byte)(CGlobal.State.Answer):
                                SendFlashPacket(CGlobal.AgentNumber, "1");
                    
                           // if(operatorAnswerPortType == "1")
                             //   AddExtensionHoldRow(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                            //else
                                AddTrunkHoldRow(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                                opertatorState = (byte)(CGlobal.State.Hold);
                                txtOperatorDial.Text = "";
                           break;
                         default:
                            break;

                    }
                    break;
                case 109://- button  
                    //remove holded party and go back to the answer state 
                    //for revert back last hold call
                    //SendReverBackPacket(CGlobal.AgentNumber, "1");
                    if (HoldAnswer()==1)
                    {
                        txtOperatorDial.Text = "";
                        RemoveTrunkHold(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
                        opertatorState = (byte)(CGlobal.State.Answer);
                    }


                    break;
                default:
                    txtOperatorDial.Text = "";
                    //rtxtDebugBox.Text += "Error in Dialling \r\n";
                    //rtxtDebugBox.SelectionStart = rtxtDebugBox.Text.Length;
                    //rtxtDebugBox.ScrollToCaret();
                    break;


            }
        }

        private void btnOperatorState_Click(object sender, EventArgs e)
        {


            byte[] Tx = new byte[15];
            byte indx = 0;
            if (opertatorState == (byte)(CGlobal.State.Idle))
            {
                if (CGlobal.OperatorLoginFlag)
                {

                    /*Tx[0] = (byte)('%');
                    Tx[1] = (byte)('L');
                    Tx[2] = 9;  //len of the packet
                    */
                    Tx[0] = (byte)QueueType.ADMQueue;
                    Tx[1] = (byte)AdminPortType.OperatorType;
                    Tx[2] = (byte)OperatorTypeSetMessage.Answer;
                    Tx[3] = 0x00;//Send packet with message pool
                    //Genarate Info feild of packet
                    Tx[4] = (byte)OperatorTypeSetMessage.OperatorLogin;

                    indx = 5;
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                    Tx[indx++] = 1;


                    Tx[indx++] = 0;  //logoff
                    Tx[indx++] = 0;
                    Tx[indx++] = 0;
                    Tx[indx++] = 0;


                    Tx[indx++] = (byte)('$');

                    CGlobal.SendPackets.Enqueue(Tx);
                    CGlobal.OperatorLoginFlag = false;

                }
                else
                {
                    /*Tx[0] = (byte)('%');
                    Tx[1] = (byte)('L');
                    Tx[2] = 9;  //len of the packet*/
                    Tx[0] = (byte)QueueType.ADMQueue;
                    Tx[1] = (byte)AdminPortType.OperatorType;
                    Tx[2] = (byte)OperatorTypeSetMessage.Answer;
                    Tx[3] = 0x00;//Send packet with message pool
                    //Genarate Info feild of packet
                    Tx[4] = (byte)OperatorTypeSetMessage.OperatorLogin;
                    indx = 5;
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                    Tx[indx++] = 1;


                    Tx[indx++] = 1;
                    Tx[indx++] = 0;
                    Tx[indx++] = 0;
                    Tx[indx++] = 0;


                    Tx[indx++] = (byte)('$');

                    CGlobal.SendPackets.Enqueue(Tx);
                    CGlobal.OperatorLoginFlag = true;

                }
            }
        }

        private void btnOperatorDayNight_Click(object sender, EventArgs e)
        {
            byte[] Tx = new byte[15];
            byte indx = 0;
            DateTime dt = DateTime.Now;
           
                if (CGlobal.OperatorLoginFlag)
                {
                    if (CGlobal.operatorDayNightFlag)
                    {
                        //change system to  Night mode
                        frmDayNight frmDN = new frmDayNight();
                        frmDN.ShowDialog();

                        if (CGlobal.btnApplyPressed)
                        {
                            Tx[0] = (byte)QueueType.ADMQueue;
                            Tx[1] = (byte)AdminPortType.OperatorType;
                            Tx[2] = (byte)OperatorTypeSetMessage.Answer;
                            Tx[3] = 0x00;//Send packet with message pool
                            //Genarate Info feild of packet
                            Tx[4] = (byte)OperatorTypeSetMessage.NightMode;

                            indx = 5;
                            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                            Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                            Tx[indx++] = 1;


                            Tx[indx++] = byte.Parse(CGlobal.dayNightNumber.Substring(0, 1));
                            Tx[indx++] = byte.Parse(CGlobal.dayNightNumber.Substring(1, 1));
                            Tx[indx++] = byte.Parse(CGlobal.dayNightNumber.Substring(2, 1));
                            Tx[indx++] = byte.Parse(CGlobal.dayNightNumber.Substring(3, 1));


                            Tx[indx++] = (byte)('$');

                            CGlobal.SendPackets.Enqueue(Tx);
                            CGlobal.operatorDayNightFlag = false;
                            cDB.InsertAgent(CGlobal.AgentNumber, dt.Date.ToString(), dt.TimeOfDay.ToString(),( string.Format("NightMode({0})", CGlobal.dayNightNumber)), ref Message1);
                            btnOperatorDayNight.Text = "شب";
                            btnOperatorDayNight.BackColor = Color.Azure;
                        }
                    }
                    else
                    {
                        //change system to  Day mode
                        Tx[0] = (byte)QueueType.ADMQueue;
                        Tx[1] = (byte)AdminPortType.OperatorType;
                        Tx[2] = (byte)OperatorTypeSetMessage.Answer;
                        Tx[3] = 0x00;//Send packet with message pool
                        //Genarate Info feild of packet
                        Tx[4] = (byte)OperatorTypeSetMessage.DayMode;

                        indx = 5;
                        Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                        Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                        Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                        Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                        Tx[indx++] = 1;


                        Tx[indx++] = 0;  //logoff
                        Tx[indx++] = 0;
                        Tx[indx++] = 0;
                        Tx[indx++] = 0;


                        Tx[indx++] = (byte)('$');

                        CGlobal.SendPackets.Enqueue(Tx);
                        CGlobal.operatorDayNightFlag = true;

                        cDB.InsertAgent(CGlobal.AgentNumber, dt.Date.ToString(), dt.TimeOfDay.ToString(), "DayMode", ref Message1);
                        btnOperatorDayNight.Text = "روز";
                        btnOperatorDayNight.BackColor = Color.Violet;

                    }
                }
                
      

        }


        private void tsmAddPhone_Click(object sender, EventArgs e)
        {
            bool result;
            frmAddPhone frmAddPh = new frmAddPhone("اضافه کردن شماره تلفن");
            frmAddPh.ShowDialog();
            if (CGlobal.btnApplyPressed)
            {

                
                result = cDB.InsertPhoneBook(1, CGlobal.phoneBookType, CGlobal.phoneBookName, CGlobal.phoneBookNumber
                 , CGlobal.phoneBookJob, ref Message1);
                dgvPhoneBookRefresh();
                if (result)
                {
                    byte[] toBytes = Encoding.UTF8.GetBytes(Message1);
                    CGlobal.iSendPackets.Enqueue(toBytes);
                    CGlobal.lastInteralTxMessage = Message1;
                    LogRxTxData(toBytes, Message1, 4);
                }
           }
        }

        private void tsmSearch_Click(object sender, EventArgs e)
        {
            CGlobal.FocousFlag = true;
            frmPhoneBookSearch phoneBookSearch = new frmPhoneBookSearch();
            phoneBookSearch.ShowDialog();
            if (CGlobal.btnApplyPressed)
            {

                dialFromPhonbook(CGlobal.phoneBookSearchPhone);

            }



        }

        private void tsmDialPhone_Click(object sender, EventArgs e)
        {
            int count = dgvPhoneBook.RowCount;
            int indx = 0;
            if ((opertatorState == (byte)(CGlobal.State.Idle)) && (CGlobal.OperatorLoginFlag))
            {

                for (indx = 0; indx < dgvPhoneBook.Rows.Count; indx++)
                {
                    if (dgvPhoneBook.Rows[indx].Selected)
                    {

                        dialFromPhonbook(dgvPhoneBook.Rows[indx].Cells["تلفن"].Value.ToString());
                        return;
                    }
                }
            }
        }

        private void tsmDelPhone_Click(object sender, EventArgs e)
        {
            int count = dgvPhoneBook.RowCount;
            int indx = 0;
            bool delFlag = false;
            bool result; 
            DialogResult dg = MessageBox.Show("آیا مایل به ادامه هستید؟", "تــوجه ", MessageBoxButtons.YesNo
                    , MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (dg == DialogResult.No)
                    return;
   
            for (indx = 0; indx < dgvPhoneBook.Rows.Count; indx++)
            {
                if (dgvPhoneBook.Rows[indx].Selected)
                {
                    delFlag = true;
                    result = cDB.DeletPhoneBook(dgvPhoneBook.Rows[indx].Cells["نام"].Value.ToString(),
                                    dgvPhoneBook.Rows[indx].Cells["تلفن"].Value.ToString(), ref Message1);
                    if (result)
                    {
                        byte[] toBytes = Encoding.UTF8.GetBytes(Message1);
                        CGlobal.iSendPackets.Enqueue(toBytes);
                        CGlobal.lastInteralTxMessage = Message1;
                    }

                 }
            }
            dgvPhoneBookRefresh();
            if (!delFlag)
                MessageBox.Show("هیچ شماره ای جهت حذف انتخاب نشده است");
        }

        private void tslStatusView_Click(object sender, EventArgs e)
        {
            CGlobal.FocousFlag = true;
            //frmPortSt1 frmPs = new frmPortSt1();
            //f/rmPs.Show();
            viewStatus frmVS = new viewStatus();
            frmVS.Show();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            CGlobal.FocousFlag = false;
        }

        private void rtxtDebugBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tslOutCall_Click(object sender, EventArgs e)
        {

        }

        private void tslIncallAnswered_Click(object sender, EventArgs e)
        {
            frmAgentStatus frmAgent = new frmAgentStatus(2);
            frmAgent.ShowDialog();
        }

        private void tslInCallMissed_Click(object sender, EventArgs e)
        {
            frmAgentStatus frmAgent = new frmAgentStatus(1);
            frmAgent.ShowDialog();
        }

        private void btnNumlock_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                byte[] Tx = new byte[15];
                byte[] Tx1 = new byte[15];


                byte[] TxData = new byte[1024];
                byte[] TxData1 = new byte[1024];
                

                byte indx = 0;
                if (CGlobal.AgentNumber != null)
                {
                    Tx1[0] = (byte)QueueType.ADMQueue;
                    Tx1[1] = (byte)AdminPortType.OperatorType;
                    Tx1[2] = (byte)OperatorTypeSetMessage.Answer;
                    Tx1[3] = 0x00;//Send packet with message pool
                    //Genarate Info feild of packet
                    Tx1[4] = (byte)OperatorTypeSetMessage.Disconnect;

                    indx = 5;
                    Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                    Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                    Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                    Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                    Tx1[indx++] = 1;


                    Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                    Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                    Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                    Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));


                    Tx1[indx++] = (byte)('$');

                    CGlobal.SendPackets.Enqueue(Tx1);
                }

                if (CGlobal.OperatorLoginFlag)
                {

                    /*Tx[0] = (byte)('%');
                    Tx[1] = (byte)('L');
                    Tx[2] = 9;  //len of the packet
                    */
                    Tx[0] = (byte)QueueType.ADMQueue;
                    Tx[1] = (byte)AdminPortType.OperatorType;
                    Tx[2] = (byte)OperatorTypeSetMessage.Answer;
                    Tx[3] = 0x00;//Send packet with message pool
                    //Genarate Info feild of packet
                    Tx[4] = (byte)OperatorTypeSetMessage.OperatorLogin;

                    indx = 5;
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                    Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                    Tx[indx++] = 1;


                    Tx[indx++] = 0;  //logoff
                    Tx[indx++] = 0;
                    Tx[indx++] = 0;
                    Tx[indx++] = 0;


                    Tx[indx++] = (byte)('$');

                    CGlobal.SendPackets.Enqueue(Tx);


                }
               

     
                if (CGlobal.SendPackets.Count > 0)
                {
                    TxData = (byte[])(CGlobal.SendPackets.Dequeue());

                    netSocket.SendUdpData(ref TxData);
                    LogRxTxData(TxData, null, 1);

                }

                if (CGlobal.SendPackets.Count > 0)
                {
                    TxData1 = (byte[])(CGlobal.SendPackets.Dequeue());

                    netSocket.SendUdpData(ref TxData1);
                    LogRxTxData(TxData1, null, 1);

                }
            }
            catch (IOException ex)
            {
                
            }
        }

        private void tsmEditPhone_Click(object sender, EventArgs e)
        {
            bool result;
            for (int indx = 0; indx < dgvPhoneBook.Rows.Count; indx++)
            {
                

                if (dgvPhoneBook.Rows[indx].Selected)
                {
                    
                    CGlobal.phonebookIndex = int.Parse(dsPhoneBook.Tables[0].Rows[indx]["index"].ToString().Trim());
             //       CGlobal.phonebookType = dsPhoneBook.Tables[0].Rows[indx]["type"].ToString();
                    CGlobal.phonebookName = dsPhoneBook.Tables[0].Rows[indx]["name"].ToString();
                    CGlobal.phonebookNumber = dsPhoneBook.Tables[0].Rows[indx]["Numebr"].ToString();
                   CGlobal.phonebookDescription = dsPhoneBook.Tables[0].Rows[indx]["job"].ToString();
                   CGlobal.phonebookAutoIndex = int.Parse(dsPhoneBook.Tables[0].Rows[indx]["id"].ToString());
                   frmAddPhone frmAddPh = new frmAddPhone("ویرایش  شماره  تلفن ",CGlobal.phonebookIndex, CGlobal.phonebookName, CGlobal.phonebookNumber, CGlobal.phonebookDescription ,CGlobal.phonebookAutoIndex);
                    frmAddPh.ShowDialog();
                    if (CGlobal.btnApplyPressed)
                    {

                        result = cDB.UpdatePhoneBook(CGlobal.phonebookAutoIndex, CGlobal.phoneBookName, CGlobal.phoneBookNumber, CGlobal.phoneBookJob, ref Message1);
                        dgvPhoneBookRefresh();
                        if (result)
                        {
                            byte[] toBytes = Encoding.UTF8.GetBytes(Message1);
                            CGlobal.iSendPackets.Enqueue(toBytes);
                            CGlobal.lastInteralTxMessage = Message1;
                        }
                        else
                        {
                                MessageBox.Show(" ارتباط  با دیتابیس مشکل  دارد   ", "خطا در عملیات ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        }
                    


                    }

                    return;
                }


            }

                MessageBox.Show("هیچ مشترکی انتخاب نشده است", "خطا در عملیات ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

        }

        public void  UpdateAnalogExtensionState(byte shelfNo,byte  slotNo,byte  portNo, byte state)
        {
            cDB.UpadteAnalogExtensionstate(shelfNo, slotNo, portNo, state, ref Message1);
        }
        public void UpdateAnalogExtensionBparty(byte shelfNo,byte  slotNo,byte  portNo, string digit)
        {
            cDB.UpadteAnalogExtensiondigit(shelfNo, slotNo, portNo, digit, ref Message1);
        }
        public void UpdateAnalogExtensionTime(byte shelfNo, byte slotNo, byte portNo, string digit)
        {
            cDB.UpadteAnalogExtensiontime(shelfNo, slotNo, portNo, digit, ref Message1);
        }
        public void ClearAnalogExtensionBparty(byte shelfNo, byte slotNo, byte portNo, string digit)
        {
            cDB.clearAnalogExtensiondigit(shelfNo, slotNo, portNo, digit, ref Message1);
        }
        public void updateAnalogExtensionAparty(byte shelfNo, byte slotNo, byte portNo)
        {
            cDB.updateAnalogExtensionAparty(shelfNo, slotNo, portNo, ref Message1);
        }
        public void UpdateAnalogTrunkState(string port, string phoneNo, string state)
        {

            cDB.UpadteAnalogTrunkstate(port, phoneNo, state, ref Message1);


        }
        public void UpdateAnalogTrunkBparty(string port, string phoneNo, string bParty)
        {

            cDB.UpadteAnalogTrunkBparty(port, phoneNo, bParty, ref Message1);


        }
        private void tsmUpgardaDb_Click(object sender, EventArgs e)
        {
            frmAdvanceSetting frmAS = new frmAdvanceSetting();
            frmAS.ShowDialog();








        }

        private void tslExtensionPeriority_Click(object sender, EventArgs e)
        {

        }

        private void tslExtensionPeriorityAdd_Click(object sender, EventArgs e)
        {

        }

        private void tslExtensionPeriorityEdit_Click(object sender, EventArgs e)
        {

        }

        private void speedDialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgentStatus frmAgent = new frmAgentStatus(3);
            frmAgent.ShowDialog();
        }

        private void tmrLivecheck_Tick(object sender, EventArgs e)
        {
            byte[] Tx = new byte[15];
            byte[] Tx1 = new byte[15];


            byte[] TxData = new byte[1024];
            byte[] TxData1 = new byte[1024];

            byte indx = 0;

            Tx1[0] = (byte)QueueType.ADMQueue;
            Tx1[1] = (byte)AdminPortType.OperatorType;
            Tx1[2] = (byte)OperatorTypeSetMessage.Answer;
            Tx1[3] = 0x00;//Send packet with message pool
            //Genarate Info feild of packet
            Tx1[4] = (byte)OperatorTypeSetMessage.LiveCheckCmd;

            indx = 5;
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

            Tx1[indx++] = 1;


            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
            Tx1[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));


            Tx1[indx++] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx1);
            connectionStateCntr++;
            if (connectionStateCntr > 10)
            {

                lblConectionState.Text = " ارتباط قطع می باشد";
                lblConectionState.BackColor = Color.Red;
                if(CGlobal.soundState)
                    Console.Beep(500, 500);

            }
            //Add for check duration
            if (lblOpertorState.Text != "Idle")
            {
                durationLong += 2;

                lblDuration.Text = durationtime.AddSeconds(durationLong).ToString("mm:ss");
   

            }
            else
            {
                durationLong = 0;
                lblDuration.Text = DateTime.MinValue.ToString("mm:ss");
            }
            /*
            operatorAnswerPid = "278";
            operatorAnswerphone = "2378";
            operatorAnswerPortType = "1";
         // AddExtensionHoldRow(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
            RemoveExtensionHold(operatorAnswerPid, operatorAnswerphone, operatorAnswerPortType);
*/

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutUs frmAbout = new frmAboutUs();

            frmAbout.ShowDialog();

        }

        private void tsMCheckUpdate_Click(object sender, EventArgs e)
        {

            frmUpdateLogin frmUpd = new frmUpdateLogin();
            frmUpd.ShowDialog();
            if (CGlobal.frmCompanyLoginFlag == true)
            {
                frmCompany frmCo = new frmCompany();
                frmCo.ShowDialog();

            }


        }
        private void CheckValidSpeedDialNumber(string phoneNumber)
        {
            if (phoneNumber != "")
            {
               
                dsTemp.Clear();
                dsTemp = cDB.SelectData("tblSpeedDial", ("SpeedIndex = '" + phoneNumber + "'" ));
               if (dsTemp.Tables[0].Rows.Count>0)
               {
                   DataRow dr = dsTemp.Tables[0].Rows[0];
                   txtOperatorPanel.Text = dr[1].ToString().Trim(); 

               }

            }
     


        }

        private void OperatorRedial(string phoneNumber)
        {
            byte[] Tx = new byte[16];
            int indx = 0;
            if (opertatorState == (byte)(CGlobal.State.Idle))
            {
                /*Tx[0] = (byte)('%');
                Tx[1] = (byte)('O');  //offhook
                Tx[2] = 9;  //len of the packet*/
                Tx[0] = (byte)QueueType.ADMQueue;
                Tx[1] = (byte)AdminPortType.OperatorType;
                Tx[2] = (byte)OperatorTypeSetMessage.Answer;
                Tx[3] = 0x00;//Send packet with message pool
                //Genarate Info feild of packet
                Tx[4] = (byte)OperatorTypeSetMessage.Offhook;

                indx = 5;
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                Tx[indx++] = 1;


                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));


                Tx[indx++] = (byte)('$');
                CGlobal.SendPackets.Enqueue(Tx);
                opertatorState = (byte)(CGlobal.State.WfDail);
            }
            
            int len = phoneNumber.Length;
            for (int i = 0; i < len; i++)
            {
                Tx = new byte[16];
                Tx[0] = (byte)QueueType.ADMQueue;
                Tx[1] = (byte)AdminPortType.OperatorType;
                Tx[2] = (byte)OperatorTypeSetMessage.Answer;
                Tx[3] = 0x00;//Send packet with message pool
                //Genarate Info feild of packet
                Tx[4] = (byte)OperatorTypeSetMessage.DialDigit;

                indx = 5;
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(0, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(1, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(2, 1));
                Tx[indx++] = byte.Parse(CGlobal.AgentNumber.Substring(3, 1));

                Tx[indx++] = 1;

                if (byte.Parse(phoneNumber.Substring(i, 1)) ==0)
                    Tx[indx++] = 10;
                else
                    Tx[indx++] = byte.Parse(phoneNumber.Substring(i, 1));
                Tx[indx++] = 0;
                Tx[indx++] = 0;
                Tx[indx++] = 0;


                Tx[indx++] = (byte)('$');
                 txtOperatorDial.Text += byte.Parse(phoneNumber.Substring(i, 1));
                if (opertatorState == (byte)(CGlobal.State.WfDail))
                    opertatorState = (byte)(CGlobal.State.WfAnswer);


                CGlobal.SendPackets.Enqueue(Tx);
                CheckValidSpeedDialNumber(txtOperatorDial.Text);



            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!CGlobal.soundState )
            {
                pictureBox1.Image = global::AgentCom.Properties.Resources.Sound71;
                CGlobal.soundState = true;
            }

            else
            {
                CGlobal.soundState = false;
                pictureBox1.Image = global::AgentCom.Properties.Resources.SoundMute;

            }
        }



        /*
        private void GetSystemInfo()
        {
            System.Management ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");

            ManagementObjectCollection mcCol = mc.GetInstances();

            foreach (ManagementObject mcObj in mcCol)
            {
                Console.WriteLine(mcObj["Caption"].ToString());
                Console.WriteLine(mcObj["MacAddress"].ToString());
            }
        }*/
        private void SaveToCSV(DataGridView DGV)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Output.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Data will be exported and you will be notified when it is ready.");
                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                int columnCount = DGV.ColumnCount;
                string columnNames = "";
                string[] output = new string[DGV.RowCount + 1];
                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += DGV.Columns[i].Name.ToString() + ",";
                }
                output[0] += columnNames;
                for (int i = 1; (i - 1) < DGV.RowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        output[i] += DGV.Rows[i - 1].Cells[j].Value.ToString() + ",";
                    }
                }
                System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
                MessageBox.Show("Your file was generated and its ready for use.");
            }
        }

        private void phoneBookImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToCSV(dgvPhoneBook);
        }
    }
   

}
