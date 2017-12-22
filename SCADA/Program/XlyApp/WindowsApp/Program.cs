using System;
using System.Linq;
using System.Windows.Forms;


namespace WindowsApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Easy4net.Context.Session session = Easy4net.Context.SessionFactory.GetSession("SqlServerString");//SQLiteString此处指定程序默认数据库连接，如后续程序中不明确指定时便使用此处的连接

            Application.Run(new MainAppForm());

        }
    }
}
