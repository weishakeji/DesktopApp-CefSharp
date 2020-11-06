using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CefSharp;
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
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //判断起始窗体是哪个
            string start = Confing.Gatway.Get("StartWinfow");
            Form form = null;
            if (start == "LoginForm") form = new LoginForm();
            if (start == "MainForm") form = new MainForm();
            if (start == "DebugForm") form = new DebugForm();
            if (form == null) form = new DebugForm();
            //图标
            form.Icon = Confing.Gatway.GetIcon("ICON");
            //标题
            if (string.IsNullOrWhiteSpace(form.Text))
                form.Text = Confing.Gatway.Get("Title");
            //打开窗体
            Application.Run(form);
        }
        /// <summary>
        /// 网络服务地址，是所有要打开的链接的根路径
        /// </summary>
        /// <returns></returns>
        public static string Domain()
        {
            string domain = Confing.Gatway.Get("Domain");
            if (string.IsNullOrWhiteSpace(domain)) return string.Empty;
            if(!(domain.StartsWith("http://")|| domain.StartsWith("https://"))) return string.Empty;
            if (!domain.EndsWith("/")) domain += "/";
            return domain;
        }
    }
}
