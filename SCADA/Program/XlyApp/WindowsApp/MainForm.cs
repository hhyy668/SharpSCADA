using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace WindowsApp
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            int threadId = Thread.CurrentThread.ManagedThreadId;
            textEdit1.Text = threadId.ToString(); //将主线程ID显示在文本框中 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(delegate() { myrun("abc", "ddd"); });
            thread.Start();
        }

        private void myrun(string a,string b)
        {
            //MessageBox.Show(a);
            //MessageBox.Show(b);
            Main f2 = new Main();
            f2.Show();

        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            MessageBox.Show(threadId.ToString());
            MessageBox.Show("你好");
        }




        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Thread thread2 = new Thread(threadPro);//创建新线程  
            thread2.Start();
        }
        public void threadPro()
        {
            MethodInvoker MethInvo = new MethodInvoker(ShowForm2);
            BeginInvoke(MethInvo);
        }
        public void ShowForm2()
        {
            Main f2 = new Main();
            f2.Show();
        }  


        //progressBar1；label1；textBox1；button1；


        private delegate void SetPos(int ipos,string vinfo);//代理

        //第三步：进度条值更新函数（参数必须跟声明的代理参数一样）

        private void SetTextMesssage(int ipos,string vinfo)
        {
            if (this.InvokeRequired)
            {
                SetPos setpos = new SetPos(SetTextMesssage);
                this.Invoke(setpos, new object[] { ipos,vinfo });
            }
            else
            {
                this.label1.Text = ipos.ToString() + "/1000";
                this.progressBar1.Value = Convert.ToInt32(ipos);
                this.textBox1.AppendText(vinfo);
            }
        }

        //第四步：函数实现

        private void button1_Click(object sender, EventArgs e)
        {
            Thread fThread = new Thread(new ThreadStart(SleepT));
            fThread.Start();
        }

        //第五步：新的线程执行函数：

        private void SleepT()
        {
            for (int i = 0; i < 500; i++)
            {
                System.Threading.Thread.Sleep(10);
                SetTextMesssage(100*i/500,i.ToString()+"\r\n");
            }
        }
    }
}