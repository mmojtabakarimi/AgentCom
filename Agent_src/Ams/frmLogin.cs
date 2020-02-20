using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.ServiceProcess;
using System.Diagnostics;


namespace AgentCom
{
    public partial class frmLogin : Form
    {
        cDatabseConnection cDB;
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }   
        

        public frmLogin()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fa-IR");  
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ee)
            {

            }
            finally
            {
                Application.Exit();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            epLogin.Clear();
            if ((txtLoginUsername.Text == "")||(txtLoginUsername.Text !="1"))
            {
                //label3.Text = "Please enter Valid Username";
               epLogin.SetError(txtLoginUsername, "لطفا نام کاربری صحیح وارد نمایید");
                return;
            }
            if ((txtLoginPassword.Text == "") || (txtLoginPassword.Text != "1"))
            {
               // label4.Text = "Please enter Valid Password";
                epLogin.SetError(txtLoginPassword, "لطفا رمز عبور صحیح وارد نمایید");
                return;
          
            }




            RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
            regkey = Registry.LocalMachine.OpenSubKey(@"Software\AgentCom", true);

                    regkey.SetValue("ServerIP", (string)txtServerIP.Text);
                    regkey.SetValue("ServerPort", (string)txtServerPort.Text);
                    regkey.SetValue("AgentNumber", (string)txtAgentNumber.Text);
                    regkey.SetValue("AgentPhone", (string)txtAgentPhone.Text);
                    CGlobal.DBServerName = txtLoginServerName.Text;
                    CGlobal.AgentNumber = this.txtAgentNumber.Text;
                    CGlobal.AgentPhone = this.txtAgentPhone.Text;

                    if (chkLoginServerName.Checked)
                    {
                        if (regkey != null)
                        {
                            regkey.SetValue("ServerName", (string)txtLoginServerName.Text);
                           
                        }
                    }
           
            
            CGlobal.btnApplyPressed = true;

            this.Close();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (this.chkLoginServerIP.Checked == false)
                this.txtServerIP.Enabled = false;

            if (this.chkLoginServerName.Checked == false)
                txtLoginServerName.Enabled = false;
            RegistryKey regkey;/* new Microsoft.Win32 Registry Key */

            regkey = Registry.LocalMachine.OpenSubKey(@"Software\AgentCom");
            if (regkey == null)
            {
                //                regkey = Registry.LocalMachine.OpenSubKey(@"Software",RegistryKeyPermissionCheck.ReadWriteSubTree,System.Security.AccessControl.RegistryRights.FullControl);
                regkey = Registry.LocalMachine.CreateSubKey(@"Software\AgentCom");//,RegistryKeyPermissionCheck.ReadWriteSubTree);
                regkey.SetValue("ServerName", (string)"");
                regkey.SetValue("ServerIP", (string)"");
                regkey.SetValue("ServerPort", (string)"1024");
                regkey.SetValue("AgentNumber", (string)"");
                regkey.SetValue("AgentPhone", (string)"");
                this.txtServerIP.Text = (string)regkey.GetValue("ServerIP");
                this.txtServerPort.Text = "1024";
                this.txtAgentNumber.Text = "";
            }
            else
            {
                this.txtServerIP.Text = (string)regkey.GetValue("ServerIP");
                this.txtServerPort.Text = (string)regkey.GetValue("ServerPort");
                this.txtAgentNumber.Text = (string)regkey.GetValue("AgentNumber");
                this.txtLoginServerName.Text = (string)regkey.GetValue("ServerName");
                this.txtAgentPhone.Text = (string)regkey.GetValue("AgentPhone");


                //frmMain.CGlobal.ServerName = txtLoginServerName.Text;
            }
            Registry.LocalMachine.Flush();
            regkey.Close();

            CGlobal.btnApplyPressed = false;
            frmLoginVersion.Text = AssemblyVersion;
            CeckMySQLStatus();

            

        }
        private void CeckMySQLStatus()
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                if (process.ProcessName == "mysqld")
                {
                    Console.WriteLine("Process Name: {0}, Responding: {1}", process.ProcessName, process.Responding);
                    if (process.Responding == true)
                    {
                        pxDatabaseStatus.Image = global::AgentCom.Properties.Resources.started;
                        btnDatabaseStart.Text = "Stop";
                        CGlobal.mySQLStatus = true;
                        cDB = new cDatabseConnection();
                        cDB.MySqlConnectionTest();
                        return;
                    }
                    else
                    {
                        pxDatabaseStatus.Image = global::AgentCom.Properties.Resources.stoped;
                        btnDatabaseStart.Text = "Start";
                        CGlobal.mySQLStatus =false;
                        return;
                    }
                }
                
            }
            pxDatabaseStatus.Image = global::AgentCom.Properties.Resources.stoped;
            btnDatabaseStart.Text = "Start";
            CGlobal.mySQLStatus = false;
            return;

        }
        private void mySQLStartStop()
        {
            try
            {
                if (!CGlobal.mySQLStatus)
                {
                   /* Process mysqlCMD = new Process();
                    mysqlCMD.StartInfo.FileName = Environment.CurrentDirectory + "\\mysql-server\\bin\\mysqld.exe";
                    mysqlCMD.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // This is to hide the black CMD window
                    mysqlCMD.Start();*/
                    restartService("MySQL80", "Start", 1000);

                }
                else
                {
                    /*Process mysqlCMD = new Process();
                    mysqlCMD.StartInfo.FileName = Environment.CurrentDirectory + "\\mysql-server\\bin\\mysqladmin.exe";
                    mysqlCMD.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // This is to hide the black CMD window
                    mysqlCMD.StartInfo.Arguments = "--user=root shutdown";
                    mysqlCMD.Start();*/
                    restartService("MySQL80", "Stop", 1000);

                }
              //  System.Threading.Thread.Sleep(2000);
                CeckMySQLStatus();
            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.Message.ToString() + Environment.CurrentDirectory + "\\mysql-server\\bin\\mysqld.exe");
            }
            finally
            {

            }
        }
        private bool restartService(String serviceName, String state, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            if (state == "Start")
            {
                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    return true;
                }
                catch
                {
                    // ...
                }


            }
            else if(state=="Stop")
            {
                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    return true;
                }
                catch
                {
                    // ...
                }
            }
            return false;
        }

        private void chkLoginServerIP_CheckedChanged(object sender, EventArgs e)
        {
            txtServerIP.Enabled = chkLoginServerIP.Checked;
        }

        private void chkLoginServerName_CheckedChanged(object sender, EventArgs e)
        {
            txtLoginServerName.Enabled = chkLoginServerName.Checked;
        }

        private void frmLogin_Enter(object sender, EventArgs e)
        {
            btnOk_Click( sender, e);
        }

        private void btnDatabaseStart_Click(object sender, EventArgs e)
        {
                mySQLStartStop();
        }



    }
}
