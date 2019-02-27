using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace DesktopApp
{
    public partial class AboutForm : Form
    {
        public ChromiumWebBrowser browser;
        public AboutForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            InitForm();
        }

        public void InitForm()
        {
            //初始
            string appPath = System.Environment.CurrentDirectory;
            string url = appPath + "\\Setup\\about.html";
            browser = Browser.Generate(url);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }
        
    }
}
