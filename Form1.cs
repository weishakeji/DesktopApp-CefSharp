using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            //if (System.IO.File.Exists(url))
            //{
            //    this.webKitBrowser1.Navigate(url);
            //}
            //this.webKitBrowser1.Url = new System.Uri(url, System.UriKind.Absolute);
            this.webKitBrowser.Navigate("http://localhost:85/Default.aspx");
            webKitBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
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

        
    }
}
