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
    public class InternalNetwork
    {
        private Socket i_mainSocket;
        public AsyncCallback i_pfnCallBack;
        private IAsyncResult i_result;
        private  int iPort = 1371;
        public static System.Net.IPAddress ipAddrHost = new System.Net.IPAddress(new byte[] { 192, 168, 1, 255 });        
        public InternalNetwork()
        {

        }
        public class iSocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[256];
        }
        public bool InitInternalNetwork()
        {

            //***************  server

            i_mainSocket = new Socket(AddressFamily.InterNetwork,
                                      SocketType.Dgram,
                                      ProtocolType.Udp);


            IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, iPort);

            i_mainSocket.Bind(ipLocal);




            WaitForData();


            return true;
        }
        public void WaitForData()
        {

            try
            {
                if (i_pfnCallBack == null)
                {
                    i_pfnCallBack = new AsyncCallback(OniDataReceived);
                }

                iSocketPacket theSocPkt = new iSocketPacket();
                theSocPkt.thisSocket = i_mainSocket;
                // Start listening to the data asynchronously
                i_result = i_mainSocket.BeginReceive(theSocPkt.dataBuffer,
                                                        0, theSocPkt.dataBuffer.Length,
                                                        SocketFlags.None,
                                                        i_pfnCallBack,
                                                        theSocPkt);

            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }


        }

        private void OniDataReceived(IAsyncResult asyn)
        {
            try
            {
                iSocketPacket socketData = (iSocketPacket)asyn.AsyncState;

                int iRx = 0;
              
                CGlobal.iReceivedPackets.Enqueue(socketData.dataBuffer);
                // Continue the waiting for data on the Socket
                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOniDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }


        public void SendUdpData(ref byte[] byData)
        {
            IPEndPoint ipLocal = new IPEndPoint(ipAddrHost, iPort);
            i_mainSocket.SendTo(byData, ipLocal);//

        }


    }

}
