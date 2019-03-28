using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace DesktopApp
{
    public partial class MainForm : Form
    {
        #region 属性
        /// <summary>
        /// 是否启用右键菜单
        /// </summary>
        public bool IsRightMenu { get; set; }
        /// <summary>
        /// 右键菜单里，是否显示关于我们
        /// </summary>
        public bool IsAboutMenu { get; set; }
        /// <summary>
        /// 是否允许下载文件
        /// </summary>
        public bool IsEnableLoad { get; set; }
        /// <summary>
        /// 网址路径，不包括主域
        /// </summary>
        public string UrlPath { get; set; }
        #endregion
        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Icon = DesktopApp.Properties.Resources.appicon;
            InitializeComponent();
            //请求路径
            UrlPath = Confing.Gatway.Get("MainUrl");
            Setup(this);
        }
        /// <summary>
        /// 通过网址构建窗体
        /// </summary>
        /// <param name="urlpath">网址路径，不包括域名</param>
        public MainForm(string urlpath) : this()
        {
            if (urlpath.StartsWith("/")) urlpath = urlpath.Substring(1);
            UrlPath = urlpath;            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {            
            InitBrowser();
        }
        /// <summary>
        /// 初始化主窗体的参数
        /// </summary>
        /// <returns></returns>
        void  Setup(MainForm form)
        {
            form.Icon = Confing.Gatway.GetIcon("ICON");     //图标
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
            form.IsRightMenu = Confing.Gatway.GetBoolean("MainEnableRightMenu");
            form.IsAboutMenu = Confing.Gatway.GetBoolean("IsAbout");
            form.IsEnableLoad = Confing.Gatway.GetBoolean("IsEnableLoad");
        }
        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            //主域地址
            string domain = Program.Domain();
            browser = Browser.Generate(domain+this.UrlPath);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

            //browser.FrameLoadEnd += Browser_FrameLoadEnd;
            //browser.TitleChanged += Browser_TitleChanged;

            //是否在当前窗体打开链接
            browser.LifeSpanHandler = new Handler.OpenSelf();
            //禁止右键菜单
            if (!IsRightMenu)
            {
                browser.MenuHandler = new Handler.ContextMenu(IsAboutMenu);
            }
            //文件下载
            if (IsEnableLoad)
                browser.DownloadHandler = new Handler.Download();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
