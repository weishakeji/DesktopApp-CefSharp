using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

/*
    产品推荐：《微厦在线学习系统》

    “在线视频学习、在线试题练习、在线同步考试”紧密相联，    
    形成“学、练、考”于一体的在线教育系统。

    可私有化部署，对接支付宝支付、微信支付，收益全掌控；
    多终端支持，电脑、手机、微信、APP、微信小程序，全都有；

    永久授权，一次购买，终身使用；
*/
namespace DesktopApp.JsEvent
{
    public class Window
    {
        public System.Windows.Forms.Form Form { get; set; }

        public Window(System.Windows.Forms.Form form)
        {
            this.Form = form;
        }
        #region 窗体大小控制
        /// <summary>
        /// 窗体最大化
        /// </summary>
        public void window_max()
        {
            //this.InvokeRequired
            this.Form.WindowState = FormWindowState.Maximized;
        }
        /// <summary>
        /// 窗体最小化
        /// </summary>
        public void window_min()
        {
            this.Form.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 还原到默认窗体
        /// </summary>
        public void window_normal()
        {
            if (this.Form.FormBorderStyle == FormBorderStyle.None)
            {
                this.Form.FormBorderStyle = FormBorderStyle.Fixed3D;
            }
            this.Form.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// 窗口全屏
        /// </summary>
        public void window_full()
        {
            this.Form.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.Form.WindowState = FormWindowState.Maximized;    //最大化窗体 
        }
        /// <summary>
        /// 窗口全屏或回到默认窗体
        /// </summary>
        public void window_toggle()
        {
            if (this.Form.WindowState == FormWindowState.Maximized)
            {
                this.Form.FormBorderStyle = FormBorderStyle.Fixed3D;     //设置窗体为无边框样式
                this.Form.WindowState = FormWindowState.Normal;    //最大化窗体 
            }
            else
            {
                this.Form.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
                this.Form.WindowState = FormWindowState.Maximized;    //最大化窗体 
            }
        }
        /// <summary>
        /// 窗体居中
        /// </summary>
        public void window_center()
        {
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;//高度
            //这里需要再减去窗体本身的宽度和高度的一半
            this.Form.Location = new Point((xWidth - this.Form.Width) / 2, (yHeight - this.Form.Height) / 2);
            this.Form.Show();
        }
        /// <summary>
        /// 设置窗体大小
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void window_size(string width, string height)
        {
            int w = this.Form.Width;
            int h = this.Form.Height;
            int.TryParse(width, out w);
            int.TryParse(height, out h);
            this.Form.Size = new Size(w, h);
        }
        /// <summary>
        /// 设置窗体到最顶层
        /// </summary>
        public void window_focus()
        {
            this.Form.TopMost = true;
            this.Form.Focus();
        }
        /// <summary>
        /// 取消窗体最顶层的设置
        /// </summary>
        public void window_blur()
        {
            this.Form.TopMost = false;
            this.Form.Focus();
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        public void window_close()
        {
            this.Form.Close();
            Application.Exit();
        }
        /// <summary>
        /// 关闭窗体和应用
        /// </summary>
        public void window_exit()
        {
            this.Form.Close();
            Application.Exit();
        }
        /// <summary>
        /// 弹出消息
        /// </summary>
        /// <param name="alert"></param>
        public void message(string alert)
        {
            MessageBox.Show(alert);
        }
        #endregion
    }
}
