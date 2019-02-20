using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Management;
using Microsoft.Win32;
using System.Threading;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "测试窗体";
            this.webKitBrowser.Dock = DockStyle.Fill;
            //
            string appPath = System.Environment.CurrentDirectory;
            string url = appPath + "\\..\\WebPage\\test.html";
            //string url = appPath + "\\..\\WebPage\\iconfont\\demo_index.html";
            //if (System.IO.File.Exists(url))
            //{
            //    this.webKitBrowser1.Navigate(url);
            //}
            this.webKitBrowser.Url = new System.Uri(url, System.UriKind.Absolute);
            //this.webKitBrowser.Navigate("http://localhost:85/Default.aspx");
            //webKitBrowser.Navigate("https://www.baidu.com");
            //增加useragent信息
            webKitBrowser.UserAgent += string.Format(" Weishakeji-DeskApp({0})", getCpu());
            //事件
            webKitBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
            webKitBrowser.DocumentTitleChanged += DocumentTitleChanged;
        }
        /// <summary>
        /// 页面加载完成的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_DocumentCompleted(object sender, EventArgs e)
        {
            ////调用页面内的js，不要用jquery
            //string jsreslut = this.webBrowser1.StringByEvaluatingJavaScriptFromString("test('哗啦啦')");
            ////调用页面内的js，没有返回值，但可以用jquery
            //webBrowser1.Document.InvokeScriptMethod("func", new object[] { "parameter1","4" });

            //如果超链接target为_blank（即打开新窗口）将无法使用，此处将target属性全去除
            foreach (WebKit.DOM.Node el in webKitBrowser.Document.GetElementsByTagName("a"))
            {
                WebKit.DOM.Element link = (WebKit.DOM.Element)el;
                if (link.Attributes.Length > 0)
                {
                    if (link.HasAttribute("target"))
                        link.SetAttribute("target", "");                   
                }
            }
        }
        public void DocumentTitleChanged(object sender, EventArgs e)
        {
            //传递过来的js函数
            string title = webKitBrowser.DocumentTitle;
            if (title.IndexOf("@") >= 0)
                title = title.Substring(title.IndexOf("@") + 1);
            Type type = this.GetType();
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
                        md.Invoke(this, parameters);
                        break;
                    }
                }
            }
        }
         public void message(string s)
        {
            MessageBox.Show(s);
        }
        #region 窗体大小控制
        /// <summary>
        /// 窗体最大化
        /// </summary>
        public void window_max()
        {
            this.WindowState = FormWindowState.Maximized;
        }
        /// <summary>
        /// 窗体最小化
        /// </summary>
        public void window_min()
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 还原到默认窗体
        /// </summary>
        public void window_normal()
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
            }
            this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// 窗口全屏
        /// </summary>
        public void window_full()
        {
            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;    //最大化窗体 
        }
        /// <summary>
        /// 窗口全屏或回到默认窗体
        /// </summary>
        public void window_toggle()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;     //设置窗体为无边框样式
                this.WindowState = FormWindowState.Normal;    //最大化窗体 
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
                this.WindowState = FormWindowState.Maximized;    //最大化窗体 
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
            this.Location = new Point((xWidth - this.Width) / 2, (yHeight - this.Height) / 2);
            this.Show();
        }
        /// <summary>
        /// 设置窗体大小
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void window_size(string width, string height)
        {
            int w = this.Width;
            int h = this.Height;
            int.TryParse(width, out w);
            int.TryParse(height, out h);
            this.Size = new Size(w, h);
         }
        /// <summary>
        /// 设置窗体到最顶层
        /// </summary>
        public void window_focus()
        {
            this.TopMost = true;
            this.webKitBrowser.Focus();
        }
        /// <summary>
        /// 取消窗体最顶层的设置
        /// </summary>
        public void window_blur()
        {
            this.TopMost = false;
            this.webKitBrowser.Focus();
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        public void window_close()
        {
            this.Close();
        }
        /// <summary>
        /// 关闭窗体和应用
        /// </summary>
        public void window_exit()
        {
            this.Close();
            Application.Exit();
        }
        #endregion

        #region 机器码
        //获得CPU的序列号
        public string getCpu()
        {
            string strCpu = null;
            //取CPU物理串号
            try
            {
                
                ManagementClass myCpu = new ManagementClass("win32_Processor");  //获取系统CPU处理器
                ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
                foreach (ManagementObject myObject in myCpuConnection)
                {
                    if (myObject.Properties["Processorid"] != null)
                    {
                        strCpu = myObject.Properties["Processorid"].Value.ToString();   //获取CPU序列号
                        break;
                    }
                }
            }
            catch { }
            //如果实在取不到
            if (string.IsNullOrWhiteSpace(strCpu))
            {
                strCpu = "notGetCPU";
            }
            return strCpu;
        }
        #endregion
    }
}
