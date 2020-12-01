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
/*
    产品推荐：《微厦在线学习系统》

    “在线视频学习、在线试题练习、在线同步考试”紧密相联，    
    形成“学、练、考”于一体的在线教育系统。

    可私有化部署，对接支付宝支付、微信支付，收益全掌控；
    多终端支持，电脑、手机、微信、APP、微信小程序，全都有；

    永久授权，一次购买，终身使用；
*/
namespace DesktopApp
{
    public partial class DebugForm : Form
    {
        #region 属性
        //默认页面
        private string _defaultUrl = System.Environment.CurrentDirectory + "\\..\\WebPage\\test.html";
        /// <summary>
        /// 要打开的网页地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 是否自定义调试页
        /// </summary>
        public bool IsCustomUrl { get; set; }
        /// <summary>
        /// 是否模拟手机端
        /// </summary>
        public bool IsMobile { get; set; }
        /// <summary>
        /// 模板的手机端类型，是微信，还是小程序，还是APP
        /// </summary>
        public string MobileType { get; set; }
        #endregion

        public DebugForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.statusStrip1.Renderer =new CustomRenderer();
            Setup(this);
        }
        /// <summary>
        /// 构建调试窗
        /// </summary>
        /// <returns></returns>
        void Setup(DebugForm form)
        {
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
                form.Size = new Size(375 + 14, 667 + 34);
            }          
            
        }
        public ChromiumWebBrowser browser;
        private void DebugForm_Load(object sender, EventArgs e)
        {
            //初始化Cef设置
            var setting = new CefSettings();
            setting.Locale = "zh-CN";
            setting.AcceptLanguageList = "zh-CN";
            string useragent = string.Empty;
            //如果不是手机端，即桌面程序
            if (!IsMobile)
            {
                useragent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";                
            }
            else
            {
                if(this.MobileType== "BrowerWeixin")
                    useragent = "Mozilla/5.0 (iPhone; CPU iPhone OS 11_1_1 like Mac OS X) AppleWebKit/604.3.5 (KHTML, like Gecko) Mobile/15B150 MicroMessenger/6.6.1 NetType/WIFI Language/zh_CN";
                if (this.MobileType == "BrowserMini")
                    useragent = "Mozilla/5.0 (Linux; Android 7.1.1; MI 6 Build/NMF26X; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/57.0.2987.132 MQQBrowser/6.2 TBS/043807 Mobile Safari/537.36 MicroMessenger/6.6.1.1220(0x26060135) NetType/4G Language/zh_CN MicroMessenger/6.6.1.1220(0x26060135) NetType/4G Language/zh_CN miniProgram";
                if (this.MobileType == "BrowserApp")
                    useragent = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_3 like Mac OS X) AppleWebKit/602.1.50 (KHTML, like Gecko) CriOS/56.0.2924.75 Mobile/14E5239e Safari/602.1 apicloud";
            }
            setting.UserAgent = useragent + string.Format(" Weishakeji - DeskApp({0})", Handler.Client.CPUCode);
            if (!Cef.IsInitialized) Cef.Initialize(setting);
            //初始         
            if (IsCustomUrl && !string.IsNullOrWhiteSpace(Url))           
                browser = new ChromiumWebBrowser(Url);            
            else         
                browser = new ChromiumWebBrowser(_defaultUrl);
            
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            //是否在当前窗体打开链接
            browser.LifeSpanHandler = new Handler.OpenSelf();
            //右键菜单
            browser.MenuHandler = new Handler.ContextMenuDebug(true);
            //文件下载
            browser.DownloadHandler = new Handler.Download();
            browser.TitleChanged += Browser.Browser_TitleChanged;
            browser.TitleChanged += Browser_TitleChanged;
            browser.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChanged;
            browser.AddressChanged += Browser_AddressChanged;
        }
        /// <summary>
        /// 当浏览器地址变更时（例如页面跳转了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {           
            urlStrip.Text = e.Address;
            urlStrip.ToolTipText = e.Address;
        }

        /// <summary>
        /// 浏览器加载初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            if (e.IsBrowserInitialized)
            {
                //是否打开调试窗口
                bool isShowDev = Confing.Gatway.GetBoolean("DebugHelper");
                if (isShowDev)
                {
                    ChromiumWebBrowser cwb = (ChromiumWebBrowser)sender;
                    cwb.ShowDevTools();
                }
            }
        }

        private void DebugForm_Shown(object sender, EventArgs e)
        {
            
        }
        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            //当前浏览器对象
            ChromiumWebBrowser cwb = (ChromiumWebBrowser)sender;
            System.Windows.Forms.Form form = null;
            System.Windows.Forms.Control parent = cwb.Parent;
            while (!(parent is System.Windows.Forms.Form))
            {
                parent = cwb.Parent;
            }
            form = (System.Windows.Forms.Form)parent;
            //
            string title = e.Title;
            form.Text = title+" - 功能调试";
        }

        /// <summary>
        /// 查看源码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnShowCode_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = this.browser; 
            browser.GetSourceAsync().ContinueWith(taskHtml =>
            {
                var html = taskHtml.Result;
            });
            IFrame frame = browser.GetMainFrame();          
            string t = frame.Name;
            frame.ViewSource(); 
        }
        /// <summary>
        /// 打开调试窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnDebut_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser cwb = this.browser;
            cwb.ShowDevTools();
        }
    }
    public class CustomRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item is ToolStripStatusLabel)
                TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont,
                    e.TextRectangle, e.TextColor, Color.Transparent,
                    e.TextFormat | TextFormatFlags.EndEllipsis);
            else
                base.OnRenderItemText(e);
        }
    }
}
