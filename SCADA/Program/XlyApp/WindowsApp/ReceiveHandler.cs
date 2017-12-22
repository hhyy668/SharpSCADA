using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsApp
{
    public class ReceiveHandler
    {
        public delegate void MyInvoke(string str);
        private MainAppForm form;
        public ReceiveHandler(MainAppForm mainForm) {
            form = mainForm;
        }
        public  void MsgHander(int funCode, string stringdata) 
        {
            if (funCode == 0x01) { Receive01(stringdata); };
            if (funCode == 0x02) { Receive02(stringdata); };
            if (funCode == 0x03) { Receive03(stringdata); };
            if (funCode == 0x04) { Receive04(stringdata); };
            if (funCode == 0x05) { Receive05(stringdata); };
            if (funCode == 0x06) { Receive06(stringdata); };
            if (funCode == 0x0F) { Receive0F(stringdata); };
            if (funCode == 0x10) { Receive10(stringdata); };
        }

        public void Receive01(string stringdata) {
            //处理接收到的指令

            showMsg(stringdata);
            
           // form.sendHandler.SendMsgHander(2, new string[] { "" });
        }
        public void Receive02(string stringdata)
        {
            //处理接收到的指令

            showMsg(stringdata);
        }
        public void Receive03(string stringdata)
        {
            //处理接收到的指令

            showMsg(stringdata);
        }
        public void Receive04(string stringdata)
        {
            //处理接收到的指令

            showMsg(stringdata);
        }
        public void Receive05(string stringdata)
        {
            //处理接收到的指令

            showMsg(stringdata);
        }
        public void Receive06(string stringdata)
        {
            //处理接收到的指令

            showMsg(stringdata);
        }
        public void Receive0F(string stringdata)
        {
            //处理接收到的指令

            showMsg(stringdata);
        }
        public void Receive10(string stringdata)
        {
            //处理接收到的指令

            showMsg(stringdata);
        }

        public void showMsg(string msg)
        {
            //在线程里以安全方式调用控件
            if (form.txtReceived.InvokeRequired)
            {
                MyInvoke _myinvoke = new MyInvoke(showMsg);
                form.txtReceived.Invoke(_myinvoke, new object[] { msg });
            }
            else
            {
                form.txtReceived.Text = msg + "\r\n"+ form.txtReceived.Text;
            }


        }


    }
}
