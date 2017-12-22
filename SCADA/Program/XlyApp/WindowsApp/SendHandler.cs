using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace WindowsApp
{
    public class SendHandler
    {
        public delegate void MyInvoke(string str);
        private MainAppForm form;
        public SendHandler(MainAppForm mainForm)
        {
            form = mainForm;
        }
        public void SendMsgHander(int funCode, string[] args) 
        {
            if (funCode == 0x01) { send01(args); };
            if (funCode == 0x02) { send02(args); };
            if (funCode == 0x03) { send03(args); };
            if (funCode == 0x04) { send04(args); };
            if (funCode == 0x05) { send05(args); };
            if (funCode == 0x06) { send06(args); };
            if (funCode == 0x0F) { send0F(args); };
            if (funCode == 0x10) { send10(args); };
        }

        private void send01(string[] args)
        {
            byte[] data = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x01, 0x00, 0x00, 0x00, 0x20 };
            //byte[] data1 = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x01, 0x00, 0x00, 0x00, 0x08 };
            form.client.Send(data);
            //form.client.Send(data1);
        }
        
        private void send02(string[] args)
        {
            byte[] data = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x02, 0x00, 0xC5, 0x00, 0x16 };
            form.client.Send(data);
        }

        private void send03(string[] args)
        {
            byte[] data = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x00, 0x6C, 0x00, 0x03 };
            form.client.Send(data);
        }
        private void send04(string[] args)
        {
            byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x01, 0x04, 0x00, 0x30, 0x00, 0x01 };
            //byte[] data = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x04, 0x00, 0x00, 0x00, 0x64 };
            form.client.Send(data);
        }
        private void send05(string[] args)
        {
            byte[] data = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x05, 0x00, 0xAD, 0xFF, 0x00 };
            form.client.Send(data);
        }

        private void send06(string[] args)
        {
            byte[] data = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x06, 0x00, 0x01, 0x00, 0x08 };
            form.client.Send(data);
        }

        private void send0F(string[] args)
        {
            byte[] data = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x09, 0x01, 0x0F, 0x00, 0x14, 0x00, 0x0A, 0x02, 0xCD, 0x01 };
            form.client.Send(data);
        }
        private void send10(string[] args)
        {
            byte[] data = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x0B, 0x01, 0x10, 0x00, 0x02, 0x00, 0x02, 0x04, 0x00, 0x0A, 0x01, 0x02 };
            form.client.Send(data);
        }     
    }
}
