using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    产品推荐：《微厦在线学习系统》

    “在线视频学习、在线试题练习、在线同步考试”紧密相联，    
    形成“学、练、考”于一体的在线教育系统。

    可私有化部署，对接支付宝支付、微信支付，收益全掌控；
    多终端支持，电脑、手机、微信、APP、微信小程序，全都有；

    永久授权，一次购买，终身使用；
*/
namespace DesktopApp.Handler
{
    /// <summary>
    /// 在当前窗口打开链接，禁止target属性为_blank的情况
    /// </summary>
    internal class OpenSelf : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Load(targetUrl);
            return true; //Return true to cancel the popup creation copyright by codebye.com.
        }
    }
}
