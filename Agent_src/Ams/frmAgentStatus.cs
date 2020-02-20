
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
using Excel = Microsoft.Office.Interop.Excel;
using Workbook = Microsoft.Office.Interop.Excel.Workbook;



namespace AgentCom
{
    public partial class frmAgentStatus : Form
    {
        private DataSet dsAgent = new DataSet();
        private byte tblType;
        cDatabseConnection cDB;
        private string Message1 = "";
        private string sheetName;

        public frmAgentStatus(byte type)
        {
            tblType = type;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (tblType == 3)
            {
                MakeSpeedDialFile();
            }
            Close();

        }

        private void frmAgentStatus_Load(object sender, EventArgs e)
        {
            cDB = new cDatabseConnection();
            this.ContextMenuStrip = null;
            fdaFarsi.SelectedDateTime = System.DateTime.Now;
            switch (tblType)
            {
                case 0:
                    this.Text = "مشاهده گزارش اپراتور";
                    dgvAgentRefresh();
                    sheetName = "Agent";
                break;
                case 1:
                    this.Text = "مشاهده تماسهای از دست رفته";
                     dgvMissedCallRefresh();
                break;
                case 2:
                       this.Text = "مشاهده تماسهای پاسخ داده شده";
                       dgvAnsweredCallRefresh();
                       
                break;
                case 3:
                        this.Text = "مشاهده شماره گیری سریع";
                        dgvSpeedDailRefresh();
                        cmnSpeedDial.Enabled = true;
                        this.ContextMenuStrip = this.cmnSpeedDial;
                        sheetName = "speedDial";
                    break;
            }
            


        }
        public void dgvAgentRefresh()
        {

            cDatabseConnection dbTemp = new cDatabseConnection();
            dsAgent = dbTemp.Refresh("tblAgent", "Agent_DB");


            dgvAgent.DataSource = dsAgent.Tables[0];
        }
        public void dgvMissedCallRefresh()
        {
            string str = string.Format("[date]='{0}{1}{2}'", fdaFarsi.SelectedDateTime.Day.ToString().PadLeft(2, '0'), fdaFarsi.SelectedDateTime.Month.ToString().PadLeft(2, '0'), fdaFarsi.SelectedDateTime.Year.ToString().PadLeft(4, '0'));
            //MessageBox.Show(str);
            cDatabseConnection dbTemp = new cDatabseConnection();
            dsAgent = dbTemp.SelectData("tblCTAMissedCalls", str);
            dgvAgent.DataSource = dsAgent.Tables[0];

            dgvAgent.Columns[0].Width = 60;
            dgvAgent.Columns[1].Width = 80;
            dgvAgent.Columns[1].Visible = false;
            dgvAgent.Columns[2].Width = 160;
            dgvAgent.Columns[3].Width = 80;
            dgvAgent.Columns[4].Width = 100;
            dgvAgent.Columns[5].Visible = false;
            for (int i = 0; i < 5; i++)
                this.dgvAgent.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAgent.Columns[0].HeaderText = "ردیف";
            dgvAgent.Columns[2].HeaderText = "شماره تلفن";
            dgvAgent.Columns[3].HeaderText = "نوع";
            dgvAgent.Columns[4].HeaderText = "زمان";
            for (int i = 0; i < dgvAgent.RowCount; i++)
                dgvAgent.Rows[i].Cells[0].Value = i.ToString();




        }
        public void dgvAnsweredCallRefresh()
        {
            string str = string.Format("[date]='{0}{1}{2}'", fdaFarsi.SelectedDateTime.Day.ToString().PadLeft(2, '0'), fdaFarsi.SelectedDateTime.Month.ToString().PadLeft(2, '0'), fdaFarsi.SelectedDateTime.Year.ToString().PadLeft(4, '0'));
          //  MessageBox.Show(str);
            cDatabseConnection dbTemp = new cDatabseConnection();
            dsAgent = dbTemp.SelectData("tblCTAAnsweredCalls", str);
            dgvAgent.DataSource = dsAgent.Tables[0];

            dgvAgent.Columns[0].Width = 60;
            dgvAgent.Columns[1].Width = 80;
            dgvAgent.Columns[1].Visible = false;
            dgvAgent.Columns[2].Width = 160;
            dgvAgent.Columns[3].Width = 80;
            dgvAgent.Columns[4].Width = 100;
            dgvAgent.Columns[5].Visible = false;
            for(int i=0;i<5;i++)
                this.dgvAgent.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAgent.Columns[0].HeaderText = "ردیف";
            dgvAgent.Columns[2].HeaderText = "شماره تلفن";
            dgvAgent.Columns[3].HeaderText = "نوع";
            dgvAgent.Columns[4].HeaderText = "زمان";
            for (int i = 0; i < dgvAgent.RowCount; i++)
                dgvAgent.Rows[i].Cells[0].Value = i.ToString();
            lblCount.Text = dgvAgent.RowCount.ToString();

        }
        public void dgvSpeedDailRefresh()
        {

            cDatabseConnection dbTemp = new cDatabseConnection();
            dsAgent = dbTemp.Refresh("tblSpeedDial", "Agent_DB");
            DataTable dt = new DataTable();

            dt.Columns.Add("ردیف");
            dt.Columns.Add("کد");
            dt.Columns.Add("تلفن");
            dt.Columns.Add("نام");
            DataRow dd;
            int idex = 0;

            foreach (DataRow dr in dsAgent.Tables[0].Rows)
            {
                dd = dt.NewRow();
                dd["ردیف"] = (idex++).ToString();
                dd["کد"] = dr["speedIndex"].ToString().Trim();

                dd["تلفن"] = dr["phone"].ToString().Trim();
                dd["نام"] = dr["name"].ToString().Trim();
                dt.Rows.Add(dd);
            }


            this.dgvAgent.DataSource = dt;
            this.dgvAgent.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvAgent.RightToLeft = RightToLeft.Yes;
            this.dgvAgent.Columns["ردیف"].Width =50;
            this.dgvAgent.Columns["کد"].Width = 80;
            this.dgvAgent.Columns["تلفن"].Width = 150;
            this.dgvAgent.Columns["نام"].Width = 150;
            lblCount.Text = dgvAgent.RowCount.ToString();

        }

        private void tslAddNumber_Click(object sender, EventArgs e)
        {
            frmAddSpeedDial frmspd = new frmAddSpeedDial();
            
            frmspd.ShowDialog();
            if (CGlobal.btnApplyPressed)
            {
                if (cDB.InsertSpeedDial(CGlobal.speedIndex, CGlobal.speedPhone,CGlobal.speedName,  ref Message1))
                {
                    byte[] toBytes = Encoding.UTF8.GetBytes(Message1);
                   CGlobal.iSendPackets.Enqueue(toBytes);

                          
                    SendAdminAddSpeedDialPacket (CGlobal.speedIndex,CGlobal.speedPhone, (byte)OperatorTypeSetMessage.AddSpeedDial);
                }
                else
                {
                    //transaction is not ok
                }
                dgvSpeedDailRefresh();
            }


        }

        private void tslDeleteNumber_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < dgvAgent.Rows.Count; index++)
            {
                if (dgvAgent.Rows[index].Selected)
                {
                    CGlobal.speedIndex = dgvAgent.Rows[index].Cells[1].Value.ToString().Trim().TrimEnd().TrimStart();
                    CGlobal.speedPhone = dgvAgent.Rows[index].Cells[2].Value.ToString().Trim().TrimEnd().TrimStart();

                    if (cDB.DeletSpeedDial(CGlobal.speedIndex, CGlobal.speedPhone, ref Message1))
                    {
                        
                        byte[] toBytes = Encoding.UTF8.GetBytes(Message1);
                        CGlobal.iSendPackets.Enqueue(toBytes);
 
                        SendAdminAddSpeedDialPacket (CGlobal.speedIndex,CGlobal.speedPhone ,(byte)OperatorTypeSetMessage.DelSpeedDial);
                    }
                    else
                    {
                        //transaction is not ok
                    }
                    dgvSpeedDailRefresh();

                    return;
                }
            }
            MessageBox.Show("Please select one row");

        }
        private void SendAdminAddSpeedDialPacket(string speedIndex,string phone,byte cmd)
        {

            byte[] Tx = new byte[25];
            byte indx = 0;
          
            if (phone.Length > 12)
                return;

            //Add Speed dial
            Tx[0] = (byte)QueueType.ADMQueue;
            Tx[1] = (byte)AdminPortType.OperatorType;
            Tx[2] = (byte)OperatorTypeSetMessage.Answer;
            Tx[3] = 0x00;//Send packet with message pool
            //Genarate Info feild of packet
            Tx[4] = cmd;

            indx = 5;
            Tx[indx++] = 0;// byte.Parse(speedIndex.Substring(0, 1));
            Tx[indx++] = byte.Parse(speedIndex.Substring(1, 1));
            Tx[indx++] = byte.Parse(speedIndex.Substring(2, 1));
            Tx[indx++] = byte.Parse(speedIndex.Substring(3, 1));
            Tx[indx++] = 0xff;
            Tx[indx++] = (byte)phone.Length;
            for (int i = 0; i < phone.Length; i++)
            {
                Tx[indx++] = byte.Parse(phone.Substring(i, 1));

            }
            Tx[indx++] = (byte)(0x0f);
            Tx[indx++] = (byte)('$');

            CGlobal.SendPackets.Enqueue(Tx);

        }
        private void MakeSpeedDialFile()
        {
            StreamWriter sw;
            string folderName = "C:\\Agent_LOG\\";
            string fileName;
           
                    fileName = folderName + "s_tel.cfg" ;

                    if (!Directory.Exists(folderName))
                        Directory.CreateDirectory(folderName);


                    if (File.Exists(fileName))
                    {
                        sw = new StreamWriter(File.Open((fileName), FileMode.Create, FileAccess.Write));
                    }
                    else
                    {
                        sw = new StreamWriter(fileName);
                    }

                    
                    for (int i = 0; i < dgvAgent.Rows.Count-1; i++)
                    {    sw.Write(dgvAgent.Rows[i].Cells[1].Value.ToString().Trim() );
                        sw.WriteLine("\r");
                    }
                    sw.Close();

               
        }

        private void btnAgentReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "";
            // set filters - this can be done in properties as well
            savefile.Filter = "Text files (*.xls)|*.xls|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                ExportDataSetToExcel(savefile.FileName,sheetName);
            }
        }

       
        private void ExportDataSetToExcel(string fileName,string sName)
        {

            cDatabseConnection dbTemp = new cDatabseConnection();
            dsAgent = dbTemp.Refresh("tbl" + sName , "Agent_DB");


            DataTable dtDataTable1 = dsAgent.Tables[0];

            try
            {
                Microsoft.Office.Interop.Excel._Application ExcelApp = new Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                Excel._Worksheet workSheet = (Excel.Worksheet)ExcelApp.ActiveSheet;
                for (int j = 1; j < dtDataTable1.Columns.Count + 1; j++)
                {
                    workSheet.Cells[1, j] = dtDataTable1.Columns[j - 1].ColumnName;
                }


                for (int k = 0; k < dtDataTable1.Rows.Count; k++)
                {
                    for (int l = 0; l < dtDataTable1.Columns.Count; l++)
                    {
                        workSheet.Cells[k + 2, l + 1] = dtDataTable1.Rows[k].ItemArray[l].ToString().Trim().TrimEnd().TrimStart();

                    }
                }
                workSheet.Name = sName;
                // workSheet.Cells.AutoFit();

                workSheet.Columns.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                Excel.Range cellsRange = null;
                Excel.Range columsRange = null;
                cellsRange = workSheet.Cells;
                cellsRange.Cells.NumberFormat = "##############";


                ExcelApp.ActiveWorkbook.SaveCopyAs(fileName);
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
                MessageBox.Show("Data Exported Successfully");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (tblType)
            {
                case 0:
                    this.Text = "مشاهده گزارش اپراتور";
                    dgvAgentRefresh();
                    sheetName = "Agent";
                    break;
                case 1:
                    this.Text = "مشاهده تماسهای از دست رفته";
                    dgvMissedCallRefresh();
                    break;
                case 2:
                    this.Text = "مشاهده تماسهای پاسخ داده شده";
                    dgvAnsweredCallRefresh();

                    break;
                case 3:
                    this.Text = "مشاهده شماره گیری سریع";
                    dgvSpeedDailRefresh();
                    cmnSpeedDial.Enabled = true;
                    this.ContextMenuStrip = this.cmnSpeedDial;
                    sheetName = "speedDial";
                    break;
            }
        }

     


    }
}
