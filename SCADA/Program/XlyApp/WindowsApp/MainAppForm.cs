using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Easy4net.Common;
using Easy4net.Utility;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using Easy4net.Context;
using Business;
using Easy4net.Entity;

namespace WindowsApp
{
    public partial class MainAppForm : Form
    {
        BridgeCraneBLL bridgeCraneBll = Engine.GetProvider<BridgeCraneBLL>();
        //Session session = SessionFactory.GetSession();
        //Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
        private string strHostIP;
        private string strPort;
        public Socket client;
        public bool Connected = false;
        public Thread MyThread;
        public Dictionary<int, string> itemValues = new Dictionary<int, string>();
        public ReceiveHandler receiveHandler;
        public SendHandler sendHandler;
        /// <summary>
        /// 构造函数，初始化连接及发送接受工具类
        /// </summary>
        public MainAppForm()
        {
            InitializeComponent();
            ConnectServer("127.0.0.1", "502");
            receiveHandler = new ReceiveHandler(this);
            sendHandler = new SendHandler(this);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendHandler.SendMsgHander(Convert.ToInt32(comboFunCode.SelectedItem.ToString()), new string[] { "" });
            //int threadId = Thread.CurrentThread.ManagedThreadId;
            //MessageBox.Show(threadId.ToString());
        }


        #region 连接服务器，处理应答
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
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            BridgeCrane model = new BridgeCrane();
            model.BridgeCraneName = "进料行车";
            model.BridgeCraneStatus = 1;
            bridgeCraneBll.Add(model);

            bridgeCraneBll.Delete(1);


        }

        private void btnSend1_Click(object sender, EventArgs e)
        {
            string comd = txtSend.Text.Replace("-","");
            client.Send(ConvertHelper.hexStrToByte(comd));
        }
    }
}
