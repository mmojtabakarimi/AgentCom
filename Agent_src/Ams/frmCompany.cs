using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;


namespace AgentCom
{
    public partial class frmCompany : Form
    {
        private string oPassWord = "agent2500";
        private string oUserName = "agent_db";
        private string oDataBaseName = "Master";
        private string oServerName = CGlobal.DBServerName;//@"MOJTABAKARIMI\SQLS2000";
        public frmCompany()
        {
            InitializeComponent();
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.Arguments = "";
            proc.EnableRaisingEvents = false;
            //proc.StartInfo.WorkingDirectory =Application.StartupPath+"\\upgrade";//"E:\\Consoleutility\\bin\\Debug\\upgrade"; 
            string fileName = Application.StartupPath;
            DialogResult result = MessageBox.Show("آیا تغییرات روی دیتابیس اعمال گردد؟", "بروز رسانی دیتابیس", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            if (result == DialogResult.Yes)
            {

                if (File.Exists("upgrade\\ResulSqlUpg.txt") == true)
                    File.Delete("upgrade\\ResulSqlUpg.txt");


                fileName += "\\Upgrade\\upgradeDatabse1.bat";

                proc.StartInfo.WorkingDirectory = Application.StartupPath + "\\upgrade";
                proc.StartInfo.FileName = fileName;
                proc.Start();
             
                proc.WaitForExit();
                Application.DoEvents();

                if (resultCehck("upgrade\\ResulSqlUpg.txt") == true)
                {
                    MessageBox.Show("عملیات بروز رسانی با موفقیت انجام گردید", "بروز رسانی دیتابیس", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
                else
                {
                    MessageBox.Show("عملیات بروز رسانی با موفقیت انجام نگردید", "بروز رسانی دیتابیس", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
                proc.Close();
            }

        }
        private bool resultCehck(string resultFile)
        {
            string input;
            StreamReader srReadLine = new StreamReader((System.IO.Stream)File.OpenRead(resultFile), System.Text.Encoding.UTF8);
            srReadLine.BaseStream.Seek(0, SeekOrigin.Begin);


            input = srReadLine.ReadToEnd();
            if (input.IndexOf("SUCCESSFULL") > 0)
            {
                srReadLine.Close();
                return true;
            }
            srReadLine.Close();
            return false;
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            SqlConnection dataConnection = new SqlConnection();
            string connectionString = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3};",
                                                                   oPassWord, oUserName, oDataBaseName, oServerName);
            dataConnection.ConnectionString = connectionString;
            SqlCommand datacommand = new SqlCommand();
            datacommand.CommandText = string.Format("sp_helpdb");
            datacommand.Connection = dataConnection;
            SqlDataAdapter dataAdaptor = new SqlDataAdapter(datacommand.CommandText, dataConnection);

            try
            {
                dataConnection.Open();
                SqlDataReader dataReader = datacommand.ExecuteReader();

                while (dataReader.Read())
                {
                   /// MessageBox.Show(dataReader.GetString(0));
                    if ((dataReader.GetString(0)) == "Agent_DB") 
                    {
                        this.txtDatabaseName.Text=dataReader.GetString(0);
                        break;
                    }
                }
                dataReader.Close();

            }
            catch (SqlException ee)
            {
                MessageBox.Show(string.Format("Error accessing database:{0}", ee.Message));
            }
            finally
            {
                dataConnection.Close();

            }

            SqlConnection dataConnection1 = new SqlConnection();
            string connectionString1 = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3};",
                                                                   oPassWord, oUserName, "Agent_DB", oServerName);
            dataConnection1.ConnectionString = connectionString1;
            SqlCommand datacommand1 = new SqlCommand();
            datacommand1.CommandText = string.Format("Select * from viewdatabaseversion");
            datacommand1.Connection = dataConnection1;
            SqlDataAdapter dataAdaptor1 = new SqlDataAdapter(datacommand1.CommandText, dataConnection1);

            try
            {
                dataConnection1.Open();
                SqlDataReader dataReader1 = datacommand1.ExecuteReader();

                while (dataReader1.Read())
                {
                    //MessageBox.Show(dataReader1.GetString(0));
                    txtDatabaseVersion.Text = dataReader1.GetString(0).Trim();
                }
                dataReader1.Close();

            }
            catch (SqlException ee)
            {
                //MessageBox.Show(string.Format("Error accessing database:{0}", ee.Message));
                //lblDatabaseVersion.Text = "ورژن دیتابیس با سیستم مطابقت ندارد";
                //lblDatabaseVersion.ForeColor = Color.Red;
            }
            finally
            {
                dataConnection1.Close();

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
