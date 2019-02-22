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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitBrowser();
        }
        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            //设置
            var setting = new CefSettings();
            string useragent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            //setting.UserAgent = useragent + string.Format(" Weishakeji - DeskApp({0})", getCpu());
            setting.Locale = "zh-CN";
            setting.AcceptLanguageList = "zh-CN";

            Cef.Initialize(setting);
            //初始
            string appPath = System.Environment.CurrentDirectory;
            //string url = appPath + "\\..\\..\\..\\WebPage\\test.html";
            //browser = new ChromiumWebBrowser(url);
            browser = new ChromiumWebBrowser("http://www.168fff.cn");
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
