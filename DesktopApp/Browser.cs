using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// <param name="url">网址</param>
        /// <returns></returns>
        public static ChromiumWebBrowser Generate(string url)
        {
            //初始化Cef设置
            var setting = new CefSettings();
            string useragent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            setting.UserAgent = useragent + string.Format(" Weishakeji - DeskApp({0})", Handler.Client.CPUCode);
            setting.Locale = "zh-CN";
            setting.AcceptLanguageList = "zh-CN";
            if (!Cef.IsInitialized) Cef.Initialize(setting);

            ChromiumWebBrowser browser;
            if (string.IsNullOrEmpty(url))
                browser = new ChromiumWebBrowser();
            else
                browser = new ChromiumWebBrowser(url);
            //事件
            //当浏览器标题变动时
            browser.TitleChanged += Browser_TitleChanged;
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

        #region 事件
        public static void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            //当前浏览器对象
            ChromiumWebBrowser cwb = (ChromiumWebBrowser)sender;
            System.Windows.Forms.Form form = null;
            System.Windows.Forms.Control parent = cwb.Parent;
            while(!(parent is System.Windows.Forms.Form)){
                parent = cwb.Parent;
            }
            form = (System.Windows.Forms.Form)parent;
            //= cwb.Parent;
            //传递过来的js函数
            string title = e.Title;
            if (title.IndexOf("@") >= 0)
                title = title.Substring(title.IndexOf("@") + 1);
            //
            
            JsEvent.Window window = new JsEvent.Window(form);
            Type type = window.GetType();
            //获取方法名与参数集合
            string methodName = title;
            string[] parameters = null;
            if (title.IndexOf(":") >= 0)
            {
                methodName = title.Substring(title.IndexOf("@") + 1, title.IndexOf(":"));
                string strpara = title.Substring(title.IndexOf(":") + 1);
                parameters = strpara.Split(',');
            }
            //获取当前对象的所在方法
            MethodInfo[] info = type.GetMethods();
            for (int i = 0; i < info.Length; i++)
            {
                var md = info[i];
                //如果传递的方法名与对象中的方法名相同
                if (md.Name == methodName)
                {
                    ParameterInfo[] paramInfos = md.GetParameters();
                    if (paramInfos.Length == (parameters == null ? 0 : parameters.Length))
                    {
                        md.Invoke(window, parameters);
                        break;
                    }
                }
            }
        }
        #endregion
    }
}