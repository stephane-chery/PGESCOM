using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace PGESCOM
{
    class CmySoc_Station
    {
        private string in_stIP = "", in_Port = "", in_msg = "", in_tag1 = "", in_tag2 = "";
        Socket mySocClient_Mgr;
        AsyncCallback myAsyncCallBack;
        IAsyncResult myAsynResult;
        string TCPreceivedTXT = "";
        public string[] ERmsg = new string[5];

        public CmySoc_Station(string x_stIP, string x_port, string x_msg)
        {
            in_Port = x_port;
            in_stIP = x_stIP;
            in_msg = x_msg;
            Connect_To_Station();
        }

        private void Connect_To_Station()
        {
            try
            {
                mySocClient_Mgr = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress _ip = IPAddress.Parse(in_stIP);
                int _intport = Convert.ToInt16(in_Port);
                IPEndPoint myIPendP = new IPEndPoint(_ip, _intport);
                mySocClient_Mgr.Connect(myIPendP);
                sent_station(in_msg);
                mySocClient_Mgr.Disconnect(false);
                mySocClient_Mgr.Close();

                //if (sent_station("STOP"))
                //WaitData(mySocClient_Mgr);
            }
            catch (SocketException se)
            {
                ERmsg[0] = se.Message;
                MessageBox.Show("Connect_To_Station ..." + se.Message);
               //btnOK.Enabled = true;
            }
        }

        private bool sent_station(string msg)
        {
            try
            {
                Object objData = msg;
                byte[] dataByte = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                mySocClient_Mgr.Send(dataByte);
            }
            catch (SocketException se)
            {
                ERmsg[1] = se.Message;
                MessageBox.Show("sent_station..." + se.Message);
                return false;
            }
            return true;
        }

        private void WaitData(Socket _soc)
        {
            try
            {
                if (myAsyncCallBack == null) myAsyncCallBack = new AsyncCallback(ONDataReceived);
                CSocPket mySocPket = new CSocPket();
                mySocPket.thissocket = _soc;
                _soc.BeginReceive(mySocPket.DataBuf, 0, mySocPket.DataBuf.Length, SocketFlags.None, myAsyncCallBack, mySocPket);
            }
            catch (SocketException se)
            {
                ERmsg[2] = se.Message;
                MessageBox.Show("WaitData(): socketException: " + se.Message);
            }
        }

        private class CSocPket
        {
            public Socket thissocket;
            public byte[] DataBuf = new byte[1];
        }

        private void ONDataReceived(IAsyncResult myIasync)
        {
            try
            {
                CSocPket myCSocID = (CSocPket)myIasync.AsyncState;
                int irx = 0;
                irx = myCSocID.thissocket.EndReceive(myIasync);
                char[] chars = new char[irx + 1];
                System.Text.Decoder dcod = System.Text.Encoding.UTF8.GetDecoder();
                int charlen = dcod.GetChars(myCSocID.DataBuf, 0, irx, chars, 0);
                String szData = new String(chars);
                TCPreceivedTXT = szData;

                WaitData(mySocClient_Mgr);
                MessageBox.Show("Data Received= " + TCPreceivedTXT);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n ONConnect(): socket has been closed \n");
            }
            catch (SocketException se)
            {
                ERmsg[3] = se.Message;
                MessageBox.Show("socket exception: " + se.Message);
            }
        }

        public void closeAllSoc()
        {
            mySocClient_Mgr.Disconnect(true);
            this.mySocClient_Mgr.Close();
        }
    }
}