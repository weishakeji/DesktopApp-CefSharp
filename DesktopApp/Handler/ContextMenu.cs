﻿using System;
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

    internal class ContextMenu : IContextMenuHandler
    {
        public ContextMenu(bool isAboutMenu)
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
            //model.AddItem(CefSharp.CefMenuCommand.Copy,"复制");
            //model.AddSeparator();
            //model.AddItem(CefSharp.CefMenuCommand.Back, "返回");
            //model.AddItem(CefSharp.CefMenuCommand.Forward, "前进");
            //model.AddItem(CefSharp.CefMenuCommand.Reload, "刷新");
            //model.AddSeparator();
            if (IsAboutMenu)
            {
                model.AddItem((CefSharp.CefMenuCommand)221, "关于");
            }

        }

        //关于我们的窗体
        private AboutForm aboutForm = null;
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
            if (comid == 221)
            {
                if(aboutForm==null || aboutForm.IsDisposed)
                    aboutForm = new AboutForm();                              
                aboutForm.ShowDialog();
                aboutForm.Focus();
            }
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
