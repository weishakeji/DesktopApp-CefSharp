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
            //
            string appPath = System.Environment.CurrentDirectory;
            string url = appPath + "\\..\\..\\WebPage\\test.html";
            if (System.IO.File.Exists(url))
            {
                this.webBrowser1.Navigate(url);
            }
            this.webBrowser1.Url = new System.Uri(url, System.UriKind.Absolute);
            //this.webBrowser1.Navigate("http://www.168fff.cn");
        }
    }
}
