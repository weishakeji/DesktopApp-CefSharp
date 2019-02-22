using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    public class Browser
    {
        private Browser() { }
        /// <summary>
        /// 生成浏览器对象
        /// </summary>
        /// <returns></returns>
        public static ChromiumWebBrowser Generate(string url)
        {
            ChromiumWebBrowser browser;

            //设置
            var setting = new CefSettings();
            string useragent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            setting.UserAgent = useragent + string.Format(" Weishakeji - DeskApp({0})", Handler.Client.CPUCode);
            setting.Locale = "zh-CN";
            setting.AcceptLanguageList = "zh-CN";

            Cef.Initialize(setting);
            if (string.IsNullOrEmpty(url))
                browser = new ChromiumWebBrowser();
            else
                browser = new ChromiumWebBrowser(url);
            return browser;
        }
        /// <summary>
        /// 生成浏览器对象
        /// </summary>
        /// <returns></returns>
        public static ChromiumWebBrowser Generate()
        {
            return Generate(string.Empty);
        }
    }
}
