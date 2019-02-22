using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

namespace DesktopApp.Handler
{

    internal class ContextMenu : IContextMenuHandler
    {

        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            if (model.Count > 0)
            {
                model.Clear();
            }
            model.AddItem(CefSharp.CefMenuCommand.Copy,"复制");
            model.AddSeparator();
            model.AddItem(CefSharp.CefMenuCommand.Back, "返回");
            model.AddItem(CefSharp.CefMenuCommand.Forward, "前进");
            model.AddItem(CefSharp.CefMenuCommand.Reload, "刷新");
            model.AddSeparator();
            model.AddItem((CefSharp.CefMenuCommand)221, "关于");

            
        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
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
