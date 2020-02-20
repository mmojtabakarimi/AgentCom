using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;




namespace AgentCom
{
    public class Network 
    {
        public static System.Net.Sockets.Socket sSocket;
        private Socket m_mainSocket, m_mainSocketStatus;
        const int MAX_CLIENTS = 10;
        /*
        //server
        public AsyncCallback pfnWorkerCallBack;
        public static Socket[] m_workerSocket = new Socket[10];
        private int m_clientCount = 0;
        */
        //client
        public Socket m_clientSocket;
        byte[] m_dataBuffer = new byte[10];
        IAsyncResult m_result,m_resultStatus;
        public AsyncCallback m_pfnCallBack, m_pfnCallBackStatus;
        


  
        public static System.Net.IPAddress ipAddr1 = new System.Net.IPAddress(new byte[] { 192, 168, 0, 16 });
        public static System.Net.IPEndPoint endIp1 = new System.Net.IPEndPoint(ipAddr1, 888);
        public static System.Net.IPAddress ipAddr = new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 });
        public static System.Net.IPAddress ipAddrHost = new System.Net.IPAddress(new byte[] { 192, 168, 1, 255 });
        public static System.Net.IPEndPoint endIp = new System.Net.IPEndPoint(ipAddr, 2300);
        int CtiPort = 1370;  
        public Network()
        {
        }
        public class SocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[32];
        }

        public bool InitNetwork()
        {
            //***************  server
            
            m_mainSocket = new Socket(AddressFamily.InterNetwork,
                                      SocketType.Dgram,
                                      ProtocolType.Udp);


            IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, CtiPort);

            m_mainSocket.Bind(ipLocal);
  



           WaitForData();


            return true;
        }
        // This the call back function which will be invoked when the socket
        // detects any client writing of data on the stream  
        //UDP PORT FROM SYSTEM
        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket socketData = (SocketPacket)asyn.AsyncState;

                int iRx = 0;
                // Complete the BeginReceive() asynchronous call by EndReceive() method
                // which will return the number of characters written to the stream 
                // by the client
                /*iRx = socketData.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(socketData.dataBuffer,
                                         0, iRx, chars, 0);
                //System.String szData = new System.String(chars);
                //richTextBoxReceivedMsg.AppendText(szData);*/
                //frmPortSt1.ReceivedPackets.Enqueue(socketData.dataBuffer);   will be add in future for show port state
                CGlobal.ReceivedPackets.Enqueue(socketData.dataBuffer);
                // Continue the waiting for data on the Socket
                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
        public void WaitForData()
        {

            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }

                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.thisSocket = m_mainSocket;
                // Start listening to the data asynchronously
                m_result = m_mainSocket.BeginReceive(theSocPkt.dataBuffer,
                                                        0, theSocPkt.dataBuffer.Length,
                                                        SocketFlags.None,
                                                        m_pfnCallBack,
                                                        theSocPkt);

            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

        }

        public void SendUdpData(ref byte[] byData)
        {
            IPEndPoint ipLocal = new IPEndPoint(ipAddrHost, CtiPort);
            m_mainSocket.SendTo(byData, ipLocal);//

        }

//CTI TCP Method 
//        public bool InitNetwork()
//        {

//            //ipx_clientSocket = new Socket(AddressFamily.Ipx, SocketType.Dgram, ProtocolType.Ipx);
//            //IPAddress.
//            //ipx_clientSocket.Bind(endIp);



//            /*
//            //***************  server
//            int port = 1024;
//            m_mainSocket = new Socket(AddressFamily.InterNetwork,
//                                      SocketType.Stream,
//                                      ProtocolType.Tcp);

//            IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, port);

//            m_mainSocket.Bind(ipLocal);
//            // Start listening...
//            m_mainSocket.Listen(4);
//            // Create the call back for any client connections...
//            m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
//            return true;*/

//            //****************  client
//            try
//            {
//                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//                // Cet the remote IP address
//                IPAddress ip = IPAddress.Parse("192.168.1.55");
//                int iPortNo = 1024;
//                // Create the end point 
//                IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);
//                // Connect to the remote host
//                m_clientSocket.Connect(ipEnd);
//                if (m_clientSocket.Connected)
//                {

//                    //    UpdateControls(true);
//                    //Wait for data asynchronously 
//                    WaitForData();
//                }

//                return true;
//            }
//            catch (SocketException se)
//            {
//                string str;
//                str = "\nConnection failed, is the server running?\n" + se.Message;
//                MessageBox.Show(str);
//                //UpdateControls(false);
//                return false;
//            }

//        }
//        // This is the call back function, which will be invoked when a client is connected
//       /* public void OnClientConnect(IAsyncResult asyn)
//        {
//            try
//            {
//                // Here we complete/end the BeginAccept() asynchronous call
//                // by calling EndAccept() - which returns the reference to
//                // a new Socket object
//                m_workerSocket[m_clientCount] = m_mainSocket.EndAccept(asyn);
//                // Let the worker Socket do the further processing for the 
//                // just connected client
//                WaitForData(m_workerSocket[m_clientCount]);
//                // Now increment the client count
//                ++m_clientCount;
//                // Display this client connection as a status message on the GUI	
//                String str = String.Format("Client # {0} connected", m_clientCount);
//               // frmMain.rtxtDebugBox.Text = str;

//                // Since the main Socket is now free, it can go back and wait for
//                // other clients who are attempting to connect
//                m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
//            }
//            catch (ObjectDisposedException)
//            {
//                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
//            }
//            catch (SocketException se)
//            {
//                MessageBox.Show(se.Message);
//            }

//        }
//        public class SocketPacket
//        {
//            public System.Net.Sockets.Socket m_currentSocket;
//            public byte[] dataBuffer = new byte[1];
//        }
//        // Start waiting for data from the client
//        public void WaitForData(System.Net.Sockets.Socket soc)
//        {
//            try
//            {
//                if (pfnWorkerCallBack == null)
//                {
//                    // Specify the call back function which is to be 
//                    // invoked when there is any write activity by the 
//                    // connected client
//                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
//                }
//                SocketPacket theSocPkt = new SocketPacket();
//                theSocPkt.m_currentSocket = soc;
//                // Start receiving any data written by the connected client
//                // asynchronously
//                soc.BeginReceive(theSocPkt.dataBuffer, 0,
//                                   theSocPkt.dataBuffer.Length,
//                                   SocketFlags.None,
//                                   pfnWorkerCallBack,
//                                   theSocPkt);
//            }
//            catch (SocketException se)
//            {
//                MessageBox.Show(se.Message);
//            }

//        }
//        */
//        // This the call back function which will be invoked when the socket
//        // detects any client writing of data on the stream
//        public void OnDataReceived(IAsyncResult asyn)
//        {
//            try
//            {
//                SocketPacket socketData = (SocketPacket)asyn.AsyncState;
//                byte[] DataCopy = new byte[] { };
//                int iRx = 0;
//                iRx = socketData.thisSocket.EndReceive(asyn);
//                /*
//                // Complete the BeginReceive() asynchronous call by EndReceive() method
//                // which will return the number of characters written to the stream 
//                // by the client
                
                
//                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
//                int charLen = d.GetChars(socketData.dataBuffer,
//                                         0, iRx, chars, 0);
//                System.String szData = new System.String(chars);
//                //richTextBoxReceivedMsg.AppendText(szData);
//                frmMain.ReceivedPackets.Enqueue(szData);
//                // Continue the waiting for data on the Socket*/
//                 byte[] rxdata = new byte[1024];
//                 rxdata = socketData.dataBuffer;
//                 DataCopy = new Byte[40];
//                 for (int indx = 0; indx < 40; indx++)
//                     DataCopy[indx] = rxdata[indx];
         
//                CGlobal.ReceivedPackets.Enqueue(DataCopy);

//                WaitForData();//socketData.thisSocket);
//            }
//            catch (ObjectDisposedException)
//            {
//                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
//            }
//            catch (SocketException se)
//            {
//                MessageBox.Show(se.Message);
//            }
//        }

//// client   method

//        public void WaitForData()
//        {
//            try
//            {
//                if (m_pfnCallBack == null)
//                {
//                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
//                }
//                SocketPacket theSocPkt = new SocketPacket();
//                theSocPkt.thisSocket = m_clientSocket;
//                // Start listening to the data asynchronously
//                m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
//                                                        0, theSocPkt.dataBuffer.Length,
//                                                        SocketFlags.None,
//                                                        m_pfnCallBack,
//                                                        theSocPkt);

//            }
//            catch (SocketException se)
//            {
//                MessageBox.Show(se.Message);
//            }

//        }

//        public bool SendData(ref byte[] byData)
//        {

//            if (m_clientSocket != null)
//            {
//                if (m_clientSocket.Connected)
//                {
//                    m_clientSocket.Send(byData);
//                }
//                return true;

//            }
//            return false;



//        }

        public bool InitStatusNetwork()
        {
            //***************  server
            int port = 807;
            m_mainSocketStatus = new Socket(AddressFamily.InterNetwork,
                                      SocketType.Dgram,
                                      ProtocolType.Udp);


            IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, port);

            m_mainSocketStatus.Bind(ipLocal);


            WaitForStatusData();


            return true;
        }

        public void WaitForStatusData()
        {

            try
            {
                if (m_pfnCallBackStatus == null)
                {
                    m_pfnCallBackStatus = new AsyncCallback(OnDataReceivedStatus);
                }

                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.thisSocket = m_mainSocketStatus;
                // Start listening to the data asynchronously
                m_resultStatus = m_mainSocketStatus.BeginReceive(theSocPkt.dataBuffer,
                                                        0, theSocPkt.dataBuffer.Length,
                                                        SocketFlags.None,
                                                        m_pfnCallBackStatus,
                                                        theSocPkt);

            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

        }
        // This the call back function which will be invoked when the socket
        // detects any client writing of data on the stream  
        //UDP PORT FROM SYSTEM
        public void OnDataReceivedStatus(IAsyncResult asyn)
        {
            try
            {
                SocketPacket socketData = (SocketPacket)asyn.AsyncState;

                int iRx = 0;
                // Complete the BeginReceive() asynchronous call by EndReceive() method
                // which will return the number of characters written to the stream 
                // by the client
                /*iRx = socketData.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(socketData.dataBuffer,
                                         0, iRx, chars, 0);
                //System.String szData = new System.String(chars);
                //richTextBoxReceivedMsg.AppendText(szData);*/
                //frmPortSt1.ReceivedPackets.Enqueue(socketData.dataBuffer);   will be add in future for show port state
                CGlobal.StatusPackets.Enqueue(socketData.dataBuffer);
                // Continue the waiting for data on the Socket
                WaitForStatusData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceivedStatus: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

  

    }

}
