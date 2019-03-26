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
        #endregion
        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Icon = DesktopApp.Properties.Resources.appicon;
            InitializeComponent();

        }
        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            //初始
            string appPath = System.Environment.CurrentDirectory;
            string url = appPath + "\\..\\WebPage\\test.html";
            //browser = Browser.Generate(url);
            browser = Browser.Generate("http://www.168fff.cn");
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
            if(IsEnableLoad)
                browser.DownloadHandler = new Handler.Download();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitBrowser();
        }
    }
}
