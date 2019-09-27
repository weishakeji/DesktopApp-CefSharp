using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

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
