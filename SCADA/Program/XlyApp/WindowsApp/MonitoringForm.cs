using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Easy4net.Common;


namespace WindowsDemo
{
    public partial class MonitoringForm : DevExpress.XtraEditors.XtraForm
    {
        public MonitoringForm()
        {
            InitializeComponent();
        }
        OPCHelper oPCHelper;


        private void Form1_Load(object sender, EventArgs e)
        {
            IPHostEntry IPHost = Dns.Resolve(Environment.MachineName);
            string strIP;
            strIP = IPHost.AddressList[0].ToString();
            oPCHelper = new OPCHelper(strIP, "Mitsubishi.MXOPC.6", 10);
            oPCHelper.AddItems("Q02HE.", new string[] { "Start", "Stop", "Start2", "Pump1", "Pump2", "Num1", "Num2", "Num3", "Num4", "INT266", "INT268", "INT270", "INT272" });
            //oPCHelper.AddItems("Q02HE.", new string[] { "Num1", "Num2", "Num3", "Num4" });
            //oPCHelper.AddItems("Q02HE.", new string[] { "INT266", "INT268", "INT270", "INT272" });

 
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (oPCHelper.Connected)
            {
                string str1, str2;
                str1 = oPCHelper.GetItemValues(new string[] { "Pump1" })[0];
                str2 = oPCHelper.GetItemValue("Pump2");
                btn_Pump1.BackColor = str1 != null && str1.ToLower() == "true" ? Color.Green : Color.Gray;
                btn_Pump2.BackColor = str2 != null && str2.ToLower() == "true" ? Color.Green : Color.Gray;

                string str3, str4, str5;
                str3 = oPCHelper.GetItemValues(new string[] { "Start" })[0];
                str4 = oPCHelper.GetItemValues(new string[] { "Start2" })[0];
                str5 = oPCHelper.GetItemValues(new string[] { "Stop" })[0];
                btn_Start.BackColor = str3 != null && str3.ToLower() == "true" ? Color.Green : Color.Gray;
                btn_Start2.BackColor = str4 != null && str4.ToLower() == "true" ? Color.Green : Color.Gray;
                btn_Stop.BackColor = str5 != null && str5.ToLower() == "true" ? Color.Red : Color.Green;

                string[] valuestr = oPCHelper.GetItemValues(new string[] { "Num1", "Num2", "Num3", "Num4", "INT266", "INT268", "INT270", "INT272" });
                txt_RNum1.Text = valuestr[0];
                txt_RNum2.Text = valuestr[1];
                txt_RNum3.Text = valuestr[2];
                txt_RNum4.Text = valuestr[3];
                txt_RNum5.Text = valuestr[4];
                txt_RNum6.Text = valuestr[5];
                txt_RNum7.Text = valuestr[6];
                txt_RNum8.Text = valuestr[7];
                txtmsg.Text = oPCHelper.GetMsg();
            }
        }


        private void btn_Start_MouseDown(object sender, MouseEventArgs e)
        {
            oPCHelper.AsyncWrite(new string[] { "Start" }, new string[] { "1" });
        }


        private void btn_Start_MouseUp(object sender, MouseEventArgs e)
        {
            oPCHelper.AsyncWrite(new string[] { "Start" }, new string[] { "0" });
        }


        private void btn_Stop_MouseDown(object sender, MouseEventArgs e)
        {
            oPCHelper.AsyncWrite(new string[] { "Stop" }, new string[] { "1" });
        }


        private void btn_Stop_MouseUp(object sender, MouseEventArgs e)
        {
            oPCHelper.AsyncWrite(new string[] { "Stop" }, new string[] { "0" });
        }


        private void btn_Start2_Click(object sender, EventArgs e)
        {
            if (oPCHelper.Contains("Start2"))
            {
                string str;
                str = oPCHelper.GetItemValues(new string[] { "Start2" })[0];
                if (Convert.ToBoolean(str))
                    oPCHelper.AsyncWrite(new string[] { "Start2" }, new string[] { "0" });
                else
                    oPCHelper.AsyncWrite(new string[] { "Start2" }, new string[] { "1" });
            }


        }


        private void btn_Write_Click(object sender, EventArgs e)
        {
            //oPCHelper.SyncWrite(new string[] { "Num1", "Num2", "Num3", "Num4" }, new string[] { txt_WNum1.Text, txt_WNum2.Text, txt_WNum3.Text, txt_WNum4.Text });
            oPCHelper.AsyncWrite(new string[] { "Num1", "Num2", "Num3", "Num4" }, new string[] { txt_WNum1.Text, txt_WNum2.Text, txt_WNum3.Text, txt_WNum4.Text });
            //oPCHelper.AsyncWrite("Num1", txt_WNum1.Text);
            //oPCHelper.AsyncWrite("Num2", txt_WNum2.Text);
            //oPCHelper.AsyncWrite("Num3", txt_WNum3.Text);
            //oPCHelper.AsyncWrite("Num4", txt_WNum4.Text);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            oPCHelper.Dispose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Start_Click(object sender, EventArgs e)
        {

        }
    }
}
