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
            if (start == "LoginForm") form = LoginForm();
            if (start == "MainForm") form = MainForm();
            if (start == "DebugForm") form = DebugForm();
            if (form == null) form = DebugForm();
            //图标
            form.Icon = Confing.Gatway.GetIcon("ICON");
            //标题
            if (string.IsNullOrWhiteSpace(form.Text))
                form.Text = Confing.Gatway.Get("Title");
            //打开窗体
            Application.Run(form);
        }
        /// <summary>
        /// 构建登录窗
        /// </summary>
        /// <returns></returns>
        static Form LoginForm()
        {
            LoginForm form = new LoginForm();
            form.StartPosition = FormStartPosition.CenterScreen;    //屏幕中央打开
            form.TopMost = true;    //最上层
            form.FormBorderStyle = FormBorderStyle.None;    //无边框
            //背景图
            Image mainbg = Confing.Gatway.GetImage("LoginBg", "jpg");
            if (mainbg != null) form.BackgroundImage = mainbg;
            //标题
            form.Title = Confing.Gatway.Get("LoginTitle");
            if(string.IsNullOrWhiteSpace(form.Title))form.Title = Confing.Gatway.Get("Title");
            return (Form)form;
        }
        /// <summary>
        /// 构建主窗体
        /// </summary>
        /// <returns></returns>
        static Form MainForm()
        {
            Form form = null;
            //请求页(还没有起作用）
            string mainurl = Confing.Gatway.Get("MainUrl");
            form = new MainForm();
            form.Text = Confing.Gatway.Get("MainTitle");    //标题            
            int width = Confing.Gatway.GetInt("MainWidth"); //宽高
            int height = Confing.Gatway.GetInt("MainHeight");
            if (width > 0 && height > 0)
                form.Size = new Size(width, height);
            //是否最大化
            string winstyle = Confing.Gatway.Get("MainStyle");
            if (winstyle == "WinMax") form.WindowState = FormWindowState.Maximized;
            //固定大小
            if (Confing.Gatway.GetBoolean("FixedSize"))
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
            //无边框
            if (Confing.Gatway.GetBoolean("IsMainBorderNone"))
                form.FormBorderStyle = FormBorderStyle.None;
            //屏幕中央打开
            if (Confing.Gatway.GetBoolean("ScreenCenter"))
                form.StartPosition = FormStartPosition.CenterScreen;
            //打开立即全屏
            if (Confing.Gatway.GetBoolean("IsFillWindow"))
            {
                form.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
                form.WindowState = FormWindowState.Maximized;    //最大化窗体 
            }
            //处于屏幕最上层
            if (Confing.Gatway.GetBoolean("IsMainTopLevel"))
                form.TopMost = true;
            //是否显示，关闭按钮、最大化按钮、最小化按钮
            form.ControlBox = Confing.Gatway.GetBoolean("BtnWinClose");
            form.MaximizeBox = Confing.Gatway.GetBoolean("BtnWinMax");
            form.MinimizeBox = Confing.Gatway.GetBoolean("BtnWinMin");
            //是否允许右键菜单,是否显示关于我们，是否允许下载
            MainForm mainform = (MainForm)form;
            mainform.IsRightMenu = Confing.Gatway.GetBoolean("MainEnableRightMenu");
            mainform.IsAboutMenu = Confing.Gatway.GetBoolean("IsAbout");
            mainform.IsEnableLoad = Confing.Gatway.GetBoolean("IsEnableLoad");
           
            return form;
        }
        /// <summary>
        /// 构建调试窗
        /// </summary>
        /// <returns></returns>
        static Form DebugForm()
        {
            DebugForm form = new DebugForm();
            //默认页还是自定义
            string defaultindex = Confing.Gatway.Get("DebugIndex");
            form.IsCustomUrl = !("DebugDefault".Equals(defaultindex, StringComparison.CurrentCultureIgnoreCase));
            form.Url = Confing.Gatway.Get("DebugCustom");
            //是否是手机端
            string debugBrowser = Confing.Gatway.Get("DebugBrowser");
            form.IsMobile = "DebugMobile".Equals(debugBrowser, StringComparison.CurrentCultureIgnoreCase);
            //模板微信，或小程序
            form.MobileType = Confing.Gatway.Get("BrowserMobile");
            //如果是手机端，则按手机大小显示窗体
            if (form.IsMobile)
            {
                form.Size = new Size(375+14,667+34);
            }
            return (Form)form;
        }
    }
}
