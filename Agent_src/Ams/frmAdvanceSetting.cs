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
    public partial class frmAdvanceSetting : Form
    {
        private DataSet dsTemp = new DataSet();
        private DataSet dsTemp1 = new DataSet();
        private string oPassWord = "agent2500";
        private string oUserName = "agent_db";
        private string oDataBaseName = "Master";
        private string oServerName = CGlobal.DBServerName;//@"MOJTABAKARIMI\SQLS2000";


        public frmAdvanceSetting()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdvanceSetting_Load(object sender, EventArgs e)
        {
            SqlConnection dataConnection = new SqlConnection();
            string connectionString = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3};",
                                                                   oPassWord, oUserName, oDataBaseName, oServerName);
            dataConnection.ConnectionString = connectionString;
            SqlCommand datacommand = new SqlCommand();
            datacommand.CommandText = string.Format("sp_helpdb");
            datacommand.Connection = dataConnection;
            SqlDataAdapter dataAdaptor = new SqlDataAdapter(datacommand.CommandText, dataConnection);
            dsTemp.Clear();

            try
            {
                dataConnection.Open();
                SqlDataReader dataReader = datacommand.ExecuteReader();

                while (dataReader.Read())
                {
                    //MessageBox.Show(dataReader.GetString(0));
                    if ((dataReader.GetString(0) == "master") || (dataReader.GetString(0) == "pubs") || (dataReader.GetString(0) == "Northwind")
                            || (dataReader.GetString(0) == "tempdb") || (dataReader.GetString(0) == "msdb") || (dataReader.GetString(0) == "model"))
                        continue;
                    else
                        this.chklstDatabse.Items.Add(dataReader.GetString(0));
                }
                dataReader.Close();
                dataAdaptor.Fill(dsTemp);
            }
            catch (SqlException ee)
            {
                MessageBox.Show(string.Format("Error accessing database:{0}", ee.Message));
                this.Close();
            }
            finally
            {
                dataConnection.Close();

            }

            SqlConnection dataConnection1 = new SqlConnection();
            string connectionString1 = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3};",
                                                                   oPassWord, oUserName, "AgentDb", oServerName);
            dataConnection1.ConnectionString = connectionString1;
            SqlCommand datacommand1 = new SqlCommand();
            datacommand1.CommandText = string.Format("Select * from viewdatabaseversion");
            datacommand1.Connection = dataConnection1;
            SqlDataAdapter dataAdaptor1 = new SqlDataAdapter(datacommand1.CommandText, dataConnection1);
            dsTemp1.Clear();
            try
            {
                dataConnection1.Open();
                SqlDataReader dataReader1 = datacommand1.ExecuteReader();

                while (dataReader1.Read())
                {
                    //MessageBox.Show(dataReader1.GetString(0));
                    lblDatabaseVersion.Text = dataReader1.GetString(0).Trim();
                }
                dataReader1.Close();
                dataAdaptor1.Fill(dsTemp1);
            }
            catch (SqlException ee)
            {
                //MessageBox.Show(string.Format("Error accessing database:{0}", ee.Message));
                lblDatabaseVersion.Text = "ورژن دیتابیس با سیستم مطابقت ندارد";
                lblDatabaseVersion.ForeColor = Color.Red;
            }
            finally
            {
                dataConnection1.Close();

            }




        }
    }
}
