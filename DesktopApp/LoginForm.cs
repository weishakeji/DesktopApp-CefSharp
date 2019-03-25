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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Icon = DesktopApp.Properties.Resources.appicon;
            InitializeComponent();
            InitBrowser();
        }

        public void InitBrowser()
        {
           
        }
    }
}
