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
            if (start == "MainWindow") form = new MainForm();
            if (start == "DebugWindow") form = new DebugForm();
            if (form == null) form = new DebugForm();
            //图标
            form.Icon = Confing.Gatway.GetIcon("ICON");
            //标题
            form.Text = Confing.Gatway.Get("Title");
            //打开窗体
            Application.Run(form);
           

        }
    }
}
