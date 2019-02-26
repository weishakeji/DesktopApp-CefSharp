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
        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            InitBrowser();
        }
        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            //初始
            string appPath = System.Environment.CurrentDirectory;
            string url = appPath + "\\..\\WebPage\\test.html";
            browser = Browser.Generate(url);
            //browser = new ChromiumWebBrowser("http://www.168fff.cn");
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

            //browser.FrameLoadEnd += Browser_FrameLoadEnd;
            //browser.TitleChanged += Browser_TitleChanged;

            //是否在当前窗体打开链接
            browser.LifeSpanHandler = new Handler.OpenSelf();
            //禁止右键菜单
            browser.MenuHandler = new Handler.ContextMenu();
            //文件下载
            browser.DownloadHandler = new Handler.Download();
        }
    }
}
