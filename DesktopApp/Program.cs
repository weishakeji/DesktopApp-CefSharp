using System;
using System.Collections.Generic;
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
            if(start== "MainWindow") Application.Run(new MainForm());
            if (start == "DebugWindow") Application.Run(new DebugForm());
            //Application.Run(new MainForm());
           

        }
    }
}
