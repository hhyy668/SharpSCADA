using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsApp
{
    public class PLCHelper : IDisposable
    {
        private string strHostIP;
        private string strPort;
        public Socket client;
        public bool Connected = false;
        public Thread MyThread;
        public Dictionary<int, string> itemValues = new Dictionary<int, string>();
        private string msg = "";
        ReceiveHandler receiveHandler;
        public PLCHelper(string strHostIP, string strPort, int UpdateRate)
        {
            this.strHostIP = strHostIP;
            this.strPort = strPort;
            if (!ConnectServer(strHostIP, strPort))
                return;
            //Connected = true;
            receiveHandler = new ReceiveHandler();
        } 

        /// <summary>  
        /// 连接到服务器  
        /// </summary>  
        /// <param name="strHostIP"></param>  
        /// <param name="strHostName"></param>  
        /// <returns></returns>  
        private bool ConnectServer(string strHostIP, string strPort)
        {
            try
            {
                byte[] data = new byte[1024];

                string ipadd = strHostIP.Trim();//将服务器IP地址存放在字符串 ipadd中
                int port = Convert.ToInt32(strPort.Trim());//将端口号强制为32位整型，存放在port中

                //创建一个套接字 

                IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipadd), port);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


                //将套接字与远程服务器地址相连
                client.Connect(ie);
                Connected = true;

                ThreadStart myThreaddelegate = new ThreadStart(ReceiveMsg);
                MyThread = new Thread(myThreaddelegate);
                MyThread.Start();
                //timerend.Enabled = true;
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void ReceiveMsg()
        {
            while (true)
            {
                byte[] data = new byte[1024];
                client.Receive(data);
                int length = data[5];
                Byte[] datashow = new byte[length + 6];
                for (int i = 0; i <= length + 5; i++)
                    datashow[i] = data[i];
                string stringdata = BitConverter.ToString(datashow);//把数组转换成16进制字符串
                //在线程里以安全方式调用控件

                if (itemValues.ContainsKey(data[7]))
                    itemValues[data[7]] = stringdata;
                else
                    itemValues.Add(data[7], stringdata);
                
                receiveHandler.MsgHander(data[7], stringdata);
            }
        }

      
        public void Dispose()
        {
            if (client != null)
            {
                client.Disconnect(true);
                client = null;
            }
            Connected = false;
        }
    }

}