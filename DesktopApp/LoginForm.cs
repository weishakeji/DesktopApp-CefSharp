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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private Point mousePoint = new Point();
        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            //base.OnMouseDown(e);
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }

        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
