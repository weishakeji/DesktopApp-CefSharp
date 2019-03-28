using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CefSharp;

namespace DesktopApp
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
            //判断起始窗体是哪个
            string start = Confing.Gatway.Get("StartWinfow");
            Form form = null;
            if (start == "LoginForm") form = new LoginForm();
            if (start == "MainForm") form = new MainForm();
            if (start == "DebugForm") form = new DebugForm();
            if (form == null) form = new DebugForm();
            //图标
            form.Icon = Confing.Gatway.GetIcon("ICON");
            //标题
            if (string.IsNullOrWhiteSpace(form.Text))
                form.Text = Confing.Gatway.Get("Title");
            //打开窗体
            Application.Run(form);
        }
        /// <summary>
        /// 网络服务地址，是所有要打开的链接的根路径
        /// </summary>
        /// <returns></returns>
        public static string Domain()
        {
            string domain = Confing.Gatway.Get("Domain");
            if (string.IsNullOrWhiteSpace(domain)) return string.Empty;
            if(!(domain.StartsWith("http://")|| domain.StartsWith("https://"))) return string.Empty;
            if (!domain.EndsWith("/")) domain += "/";
            return domain;
        }
    }
}
