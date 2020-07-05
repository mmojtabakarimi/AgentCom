using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace AgentCom
{
    public class cDatabseConnection
    {

        private DataSet dsTemp = new DataSet();
        private string oPassWord = "agent2500";
        private string oUserName = "agent_db";
        private string oDataBaseName = "Agent_DB";

        private string oServerName = CGlobal.DBServerName;   //@"MOJTABA-PC\SQLS2000";



        public void MySqlConnectionTest()
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=agent_db;uid=root;pwd=123456@Mk;";
            try
            {
                cnn = new MySqlConnection(connetionString);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString() );
            }
            finally
            {

            }

        }



        public DataSet Refresh(string tblName,string DataBaseName)
        {
            SqlConnection dataConnection = new SqlConnection();
            string connectionString = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3};",
                                                                   oPassWord, oUserName, DataBaseName, oServerName);
            dataConnection.ConnectionString = connectionString;
            SqlCommand datacommand = new SqlCommand();
            if(tblName == "tblPhoneBook")
                datacommand.CommandText = string.Format("Select * from {0} order by [id]", tblName);
            else
                if(tblName == "tblAnalogTrunk")
                    datacommand.CommandText = string.Format("Select * from {0} where portType= {1} order by port", tblName,2);
                else
                    if (tblName == "tblDigitalTrunk")
                        datacommand.CommandText = string.Format("Select * from {0} where portType= {1} order by port", "tblAnalogTrunk", 17);
                    else
                        datacommand.CommandText = string.Format("Select * from {0}", tblName);

            datacommand.Connection = dataConnection;
            SqlDataAdapter dataAdaptor = new SqlDataAdapter(datacommand.CommandText, dataConnection);
            dsTemp.Clear();
            try
            {
                dataConnection.Open();
                SqlDataReader dataReader = datacommand.ExecuteReader();

                while (dataReader.Read())
                {
                    //     MessageBox.Show(string.Format("numberOfPreDigit:{0},preDigit:{1},numberOfPostDigit:{2},minPostdigit:{3},maxPopstDigit:{4}", dataReader.GetInt32(0).ToString(), dataReader.GetInt32(1).ToString(), dataReader.GetInt32(2).ToString(), dataReader.GetInt32(3).ToString(), dataReader.GetInt32(4).ToString()));    


                }
                dataReader.Close();
                dataAdaptor.Fill(dsTemp);


            }
            catch (SqlException ee)
            {
                MessageBox.Show(string.Format("Error accessing database:{0}", ee.Message));
            }
            finally
            {
                dataConnection.Close();

            }
            return dsTemp;
        }
        public DataSet SelectData(string tblName, string param)
        {
            SqlConnection dataConnection = new SqlConnection();
            string connectionString = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3};",
                                                                   oPassWord, oUserName, oDataBaseName, oServerName);
            dataConnection.ConnectionString = connectionString;
            SqlCommand datacommand = new SqlCommand();
            datacommand.CommandText = string.Format("Select * from {0} where {1}", tblName, param);
            datacommand.Connection = dataConnection;
            SqlDataAdapter dataAdaptor = new SqlDataAdapter(datacommand.CommandText, dataConnection);
            dsTemp.Clear();
            try
            {
                dataConnection.Open();
                SqlDataReader dataReader = datacommand.ExecuteReader();

                while (dataReader.Read())
                {
                    //     MessageBox.Show(string.Format("numberOfPreDigit:{0},preDigit:{1},numberOfPostDigit:{2},minPostdigit:{3},maxPopstDigit:{4}", dataReader.GetInt32(0).ToString(), dataReader.GetInt32(1).ToString(), dataReader.GetInt32(2).ToString(), dataReader.GetInt32(3).ToString(), dataReader.GetInt32(4).ToString()));    


                }
                dataReader.Close();
                dataAdaptor.Fill(dsTemp);


            }
            catch (SqlException ee)
            {
                MessageBox.Show(string.Format("Error accessing database:{0}", ee.Message));
            }
            finally
            {
                dataConnection.Close();

            }
            return dsTemp;
        }

        public void DeletAllData(string tblName)
        {
            SqlConnection dataConnection = new SqlConnection();
            string connectionString = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3};",
                                                                   oPassWord, oUserName, oDataBaseName, oServerName);
            dataConnection.ConnectionString = connectionString;
            SqlCommand datacommand = new SqlCommand();
            datacommand.CommandText = string.Format("truncate  table {0}", tblName);
            datacommand.Connection = dataConnection;
            SqlDataAdapter dataAdaptor = new SqlDataAdapter(datacommand.CommandText, dataConnection);
            dsTemp.Clear();
            try
            {
                dataConnection.Open();
                SqlDataReader dataReader = datacommand.ExecuteReader();

                while (dataReader.Read())
                {
                    //     MessageBox.Show(string.Format("numberOfPreDigit:{0},preDigit:{1},numberOfPostDigit:{2},minPostdigit:{3},maxPopstDigit:{4}", dataReader.GetInt32(0).ToString(), dataReader.GetInt32(1).ToString(), dataReader.GetInt32(2).ToString(), dataReader.GetInt32(3).ToString(), dataReader.GetInt32(4).ToString()));    


                }
                dataReader.Close();
                dataAdaptor.Fill(dsTemp);


            }
            catch (SqlException ee)
            {
                MessageBox.Show(string.Format("Error accessing database:{0}", ee.Message));
            }
            finally
            {
                dataConnection.Close();

            }
 
        }


        public DataSet SelectDataAll(string strSql, ref string Message)
        {
            SqlConnection dataConnection = new SqlConnection();
            string connectionString = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3};",
                                                                   oPassWord, oUserName, oDataBaseName, oServerName);
            dataConnection.ConnectionString = connectionString;
            SqlCommand datacommand = new SqlCommand();
            datacommand.CommandText = "EXEC " + strSql;// string.Format("Select * from {0} where {1}", tblName, param);
            datacommand.Connection = dataConnection;
            SqlDataAdapter dataAdaptor = new SqlDataAdapter(datacommand.CommandText, dataConnection);
            dsTemp.Clear();
            try
            {
                dataConnection.Open();
                SqlDataReader dataReader = datacommand.ExecuteReader();


                dataReader.Close();
                dataAdaptor.Fill(dsTemp);


            }
            catch (SqlException ee)
            {
                //MessageBox.Show(string.Format("Error accessing database:{0}", ee.Message));
                Message = ee.Message;
            }
            finally
            {
                dataConnection.Close();

            }
            return dsTemp;
        }
        public bool UpdateData(string TaskName, ref string Message)
        {

            bool Success = true;
            SqlConnection dataConnection = new SqlConnection();
            string connectionString = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3};",
                                                                   oPassWord, oUserName, oDataBaseName, oServerName);
            dataConnection.ConnectionString = connectionString;
            SqlCommand datacommand = new SqlCommand();
            datacommand.CommandText = @"EXEC " + TaskName.ToString().Trim();
            datacommand.Connection = dataConnection;
            try
            {
                dataConnection.Open();
                datacommand.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                Success = false;
                //                Message = "Database Error, Source: " + ee.Source.ToString() + ". Message: " + ee.Message.ToString() + ".";
                Message = ee.Message;
            }
            finally
            {
                if (Success)
                    Message = "تراکنش با موفقیت انجام گرفت";
                dataConnection.Close();
            }
            frmMain.LogRxTxData(null, datacommand.CommandText, 4);
            return Success;
        }

        public bool UpadteAnalogExtensionstate(byte shelfNo, byte slotNo, byte portNo, byte state, ref string Message)
        {
            bool Success = true;
            byte rackNo = 0;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_updateAnalogExtensionState;1 '" +
                        rackNo.ToString() + "','" +
                        shelfNo.ToString() + "','" +
                        slotNo.ToString() + "','" +
                        portNo.ToString() + "','" +
                        state.ToString() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        //update  index  coloumn  of  phonebook  table  equal  with gridview index  column 
        public bool UpdatePhoneBookIndex(string id, int index, ref string Message)
        {
            bool Success = true;

            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_updatePhoneBookIndex;1 '" +
                        id + "','" +
                        index.ToString() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool UpadteAnalogExtensiondigit(byte shelfNo, byte slotNo, byte portNo, string digit, ref string Message)
        {
            bool Success = true;
            byte rackNo = 0;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_updateAnalogExtensiondigit;1 '" +
                        rackNo.ToString() + "','" +
                        shelfNo.ToString() + "','" +
                        slotNo.ToString() + "','" +
                        portNo.ToString() + "','" +
                        digit + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool UpadteAnalogExtensiontime(byte shelfNo, byte slotNo, byte portNo, string digit, ref string Message)
        {
            bool Success = true;
            byte rackNo = 0;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_updateAnalogExtensiontime;1 '" +
                        rackNo.ToString() + "','" +
                        shelfNo.ToString() + "','" +
                        slotNo.ToString() + "','" +
                        portNo.ToString() + "','" +
                        digit + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool clearAnalogExtensiondigit(byte shelfNo, byte slotNo, byte portNo, string digit, ref string Message)
        {
            bool Success = true;
            byte rackNo = 0;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_updateAnalogExtensiondigit;2 '" +
                        rackNo.ToString() + "','" +
                        shelfNo.ToString() + "','" +
                        slotNo.ToString() + "','" +
                        portNo.ToString() + "','" +
                        digit + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool updateAnalogExtensionAparty(byte shelfNo, byte slotNo, byte portNo, ref string Message)
        {
            bool Success = true;
            byte rackNo = 0;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_updateAnalogExtensiondigit;2 '" +
                        rackNo.ToString() + "','" +
                        shelfNo.ToString() + "','" +
                        slotNo.ToString() + "','" +
                        portNo.ToString()  + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool UpadteAnalogTrunkstate(string port, string phone, string state, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_updateAnalogTrunkState;1 '" +
                        
                        port.Trim() + "','" +
                        phone.Trim() + "','" +
                       
                        state.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;

        }
        public bool UpadteAnalogTrunkBparty(string port, string phone, string bParty, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_updateAnalogTrunkbPArty;1 '" +

                        port.Trim() + "','" +
                        phone.Trim() + "','" +

                        bParty.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;

        }
        public bool InsertAgent(string phone, string date, string time, string state, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_insertAgent;1 " +
                        "'" +phone.Trim() + "','" +
                        date.Trim() + "','" +
                        time.ToString() + "'," +
                        "'" + state.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool UpadtetTrunkAcdQeue(byte index, string pid, string phone, string portType, string state, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_updateTrunkAcdQeue;1 " +
                        index + ",'" +
                        pid.Trim() + "','" +
                        phone.Trim() + "','" +
                        portType.ToString() + "'," +
                        "'" + state.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }


        public bool InsertTrunkAcdQeue(byte index,string pid,string phone,string portType,string state,ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {
                    
                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_insertTrunkAcdQeue;1 " +
                        index + ",'" +
                        pid.Trim() + "','" +
                        phone.Trim()+ "','" +
                        portType.ToString() + "'," +
                        "'" + state.Trim() + "'" , ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }

        public bool DeletTrunkAcdQeue(string pid,string phone,ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_deleteTrunkAcdQeue;1 " + "'" + pid.Trim() + "','" +
                        phone.Trim() + "'" , ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }

        public bool InsertTrunkHold( byte index,string pid,string phone,string portType,string state,ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_insertTrunkHold;1 " +
                        index + ",'" +
                        pid.Trim() + "','" +
                        phone.Trim() + "','" +
                        portType.ToString() + "'," +
                        "'" + state.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }

        public bool DeletTrunkHold(string pid,string phone,ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_deleteTrunkHold;1 " + "'" + pid.Trim() + "','" +
                        phone.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }

        //*************************************************
        public bool InsertExtensionAcdQeue(byte index, string pid, string phone, string portType, string state, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_insertExtensionAcdQeue;1 " +
                        index + ",'" +
                        pid.Trim() + "','" +
                        phone.Trim() + "','" +
                        portType.ToString() + "'," +
                        "'" + state.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool InsertExtensionAnsweredCallListRow(byte index, string pid, string phone, string portType, string state, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_insertAnsweredCallList;1 " +
                        index + ",'" +
                        pid.Trim() + "','" +
                        phone.Trim() + "','" +
                        portType.ToString() + "'," +
                        "'" + state.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool InsertExtensionMissedCallList(byte index, string pid, string phone, string portType, string state, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_MissedCallList;1 " +
                        index + ",'" +
                        pid.Trim() + "','" +
                        phone.Trim() + "','" +
                        portType.ToString() + "'," +
                        "'" + state.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool InsertExtensionCTAAnsweredCallListRow(byte index, string pid, string phone, string portType, string date,string state, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_insertCTAAnsweredCallList;1 " +
                        index + ",'" +
                        pid.Trim() + "','" +
                        phone.Trim() + "','" +
                       portType.ToString() + "','" +
                        state.Trim() + "','" +
                        date.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool InsertExtensionCTAMissedCallList(byte index, string pid, string phone, string portType, string date,string state, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_InsertCTAMissedCallList;1 " +
                        index + ",'" +
                        pid.Trim() + "','" +
                        phone.Trim() + "','" +
                        portType.ToString() + "','" +
                        state.Trim() + "','" +
                        date.Trim() +"'" , ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool DeletExtensionAcdQeue(string pid, string phone, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_deleteExtensionAcdQeue;1 " + "'" + pid.Trim() + "','" +
                        phone.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }

        public bool InsertExtensionHold(byte index, string pid, string phone, string portType, string state, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_insertExtensionHold;1 " +
                        index + ",'" +
                        pid.Trim() + "','" +
                        phone.Trim() + "','" +
                        portType.ToString() + "'," +
                        "'" + state.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }

        public bool DeletExtensionHold(string pid, string phone, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_deleteExtensionHold;1 " + "'" + pid.Trim() + "','" +
                        phone.Trim() + "'", ref Message);
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }

        public bool InsertPhoneBook(int index, string type, string name, string phone, string job, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {


                    Success = this.UpdateData(
                        "pr_insertPhoneBook;1 " +
                        index.ToString()+",'" + name.Trim() + "','"+  phone.Trim() +"','"+job.Trim()+"'", ref Message);
                    Message = "pr_insertPhoneBook;1 " + index.ToString() + ",'" + name.Trim() + "','" + phone.Trim() + "','" + job.Trim() + "'";
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool UpdatePhoneBook(int index, string name, string phone, string job, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {


                    Success = this.UpdateData(
                        "pr_insertPhoneBook;2 " +
                        index.ToString() + ",'" + name.Trim() + "','" + phone.Trim() + "','" + job.Trim() + "'", ref Message);
                    Message = "pr_insertPhoneBook;2 " + index.ToString() + ",'" + name.Trim() + "','" + phone.Trim() + "','" +job.Trim()+ "'";
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool DeletPhoneBook(string name, string phone, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_deletePhoneBook;1 " + "'" + name.Trim() + "','" +
                        phone.Trim() + "'", ref Message);
                    Message = "pr_deletePhoneBook;1 " + "'" + name.Trim() + "','" + phone.Trim() + "'"; 
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }


        public bool InsertSpeedDial( string index, string phone,string name  ,ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {
                    if (name == "")
                    {
                        //Set data into databases
                        Success = this.UpdateData(
                            "pr_updateSpeeDial;1 " +
                             "'" + index.Trim() + "','" + phone.Trim() + "', ' '", ref Message);
                        Message = "pr_updateSpeeDial;1 " +"'" + index.Trim() + "','" + phone.Trim() + "', ' '";
                    }
                    else
                    {
                        //Set data into databases
                        Success = this.UpdateData(
                            "pr_updateSpeeDial;1 " +
                             "'" + index.Trim() + "','" + phone.Trim() + "'," + name, ref Message);
                        Message = "pr_updateSpeeDial;1 " +"'" + index.Trim() + "','" + phone.Trim() + "'," + name;
                    }



                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool DeletSpeedDial(string index, string phone, ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {

                    //Set data into databases
                    Success = this.UpdateData(
                        "pr_DeleteSpeeDial;1 " + "'" + index.Trim() + "','" +
                        phone.Trim() + "'", ref Message);
                    Message = "pr_DeleteSpeeDial;1 " + "'" + index.Trim() + "','" + phone.Trim() + "'";
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        public bool UpdateSqlData(string data,ref string Message)
        {
            bool Success = true;
            try
            {
                lock (this)
                {


                    Success = this.UpdateData(data, ref Message);
                    
                }
            }
            catch (Exception ee)
            {
                Success = false;
                //            Message = ee;
            }
            finally
            {
                //               if (!Success)
                //                  logdata.LogError(ID, Route + ">>" + "InsertNumberingData", Message.ToString());
            }
            return Success;
        }
        
        public string FindNameByPhoneNo( string phone)
        {
            string namestr="";
            SqlConnection dataConnection = new SqlConnection();
            string connectionString = string.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3};",
                                                                   oPassWord, oUserName, oDataBaseName, oServerName);
            dataConnection.ConnectionString = connectionString;
            SqlCommand datacommand = new SqlCommand();
            if (phone.Length == 4)
            {
                datacommand.CommandText = string.Format("Select name  from tblPhonebook where numebr LIKE '{0}'", phone);
            }
            else
            {
                datacommand.CommandText = string.Format("Select name  from tblPhonebook where numebr LIKE '%{0}'", phone);
            }
      
            datacommand.Connection = dataConnection;
            SqlDataAdapter dataAdaptor = new SqlDataAdapter(datacommand.CommandText, dataConnection);
            dsTemp.Clear();
            try
            {
                dataConnection.Open();
                SqlDataReader dataReader = datacommand.ExecuteReader();

                while (dataReader.Read())
                {
                    if (dataReader.FieldCount > 0)
                    // MessageBox.Show(string.Format("name:{0}"), dataReader.GetSqlString(0).Value.ToString());
                    {
                        namestr = dataReader.GetString(0);
                    }


                }
                dataReader.Close();
                dataAdaptor.Fill(dsTemp);


            }
            catch (SqlException ee)
            {
                MessageBox.Show(string.Format("Error accessing database:{0}", ee.Message));
            }
            finally
            {
                dataConnection.Close();

            }
            return namestr;
        }
    }
}
        