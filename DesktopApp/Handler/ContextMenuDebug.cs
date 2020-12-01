using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
namespace DesktopApp.Handler
{

    internal class ContextMenuDebug : IContextMenuHandler
    {
        public ContextMenuDebug(bool isAboutMenu)
        {
            IsAboutMenu = isAboutMenu;
        }
        /// <summary>
        /// 右键菜单里，是否显示关于我们
        /// </summary>
        public bool IsAboutMenu { get; set; }
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            if (model.Count > 0)
            {
                model.Clear();
            }
            if (IsAboutMenu)
            {
                model.AddItem((CefSharp.CefMenuCommand)222, "源码");
                model.AddItem((CefSharp.CefMenuCommand)223, "调试");
                model.AddItem((CefSharp.CefMenuCommand)224, "刷新");
            }
            
        }


        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            //当前浏览器对象，通过它获取所在的Form窗体
            ChromiumWebBrowser cwb = (ChromiumWebBrowser)browserControl;
            System.Windows.Forms.Form form = null;
            System.Windows.Forms.Control parent = cwb.Parent;
            while (!(parent is System.Windows.Forms.Form))            
                parent = cwb.Parent;            
            form = (System.Windows.Forms.Form)parent;
            //处理右键事件
            int comid = (int)commandId;
            //刷新页面
            if (comid == 222)
                cwb.ViewSource();
            //打开调试窗，F12
            if (comid == 223)            
                cwb.ShowDevTools();
            //刷新页面
            if (comid == 224)
                cwb.Reload();
   
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
           
        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
