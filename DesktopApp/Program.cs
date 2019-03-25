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
            if (start == "MainForm")
            {
                //请求页(还没有起作用）
                string mainurl= Confing.Gatway.Get("MainUrl");
                form = new MainForm();
                form.Text = Confing.Gatway.Get("MainTitle");    //标题
                //宽高
                int width = Confing.Gatway.GetInt("MainWidth");
                int height= Confing.Gatway.GetInt("MainHeight");
                if(width>0 && height>0)
                    form.Size = new Size(width, height);
                //是否最大化
                string winstyle = Confing.Gatway.Get("MainStyle");
                if (winstyle == "WinMax") form.WindowState = FormWindowState.Maximized;
                //固定大小
                if (Confing.Gatway.GetBoolean("FixedSize"))               
                    form.FormBorderStyle = FormBorderStyle.FixedSingle;
                //屏幕中央打开
                if (Confing.Gatway.GetBoolean("ScreenCenter"))
                    form.StartPosition = FormStartPosition.CenterScreen;
                //是否显示，关闭按钮、最大化按钮、最小化按钮
                form.ControlBox = Confing.Gatway.GetBoolean("BtnWinClose");
                form.MaximizeBox = Confing.Gatway.GetBoolean("BtnWinMax");
                form.MinimizeBox = Confing.Gatway.GetBoolean("BtnWinMin");
                //是否允许右键菜单,是否显示关于我们，是否允许下载
                MainForm mainform=(MainForm)form;
                mainform.IsRightMenu = Confing.Gatway.GetBoolean("MainEnableRightMenu");
                mainform.IsAboutMenu = Confing.Gatway.GetBoolean("IsAbout");
                mainform.IsEnableLoad = Confing.Gatway.GetBoolean("IsEnableLoad");
            }
            if (start == "DebugForm") form = new DebugForm();
            if (form == null) form = new DebugForm();
            //图标
            form.Icon = Confing.Gatway.GetIcon("ICON");
            //标题
            if(string.IsNullOrWhiteSpace(form.Text))
                form.Text = Confing.Gatway.Get("Title");
            //打开窗体
            Application.Run(form);
           

        }
    }
}
