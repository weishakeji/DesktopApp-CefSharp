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
            this.webKitBrowser1.Dock = DockStyle.Fill;
            //
            string appPath = System.Environment.CurrentDirectory;
            string url = appPath + "\\..\\WebPage\\test.html";
            if (System.IO.File.Exists(url))
            {
                this.webKitBrowser1.Navigate(url);
            }
            this.webKitBrowser1.Url = new System.Uri(url, System.UriKind.Absolute);
            //this.webKitBrowser1.Navigate("http://www.168fff.cn");
            webKitBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        private void webBrowser1_DocumentCompleted(object sender, EventArgs e)
        {
            ////调用页面内的js，不要用jquery
            //string jsreslut = this.webBrowser1.StringByEvaluatingJavaScriptFromString("test('哗啦啦')");
            ////调用页面内的js，没有返回值，但可以用jquery
            //webBrowser1.Document.InvokeScriptMethod("func", new object[] { "parameter1","4" });
            string text = webKitBrowser1.DocumentText;
        }
    }
}
