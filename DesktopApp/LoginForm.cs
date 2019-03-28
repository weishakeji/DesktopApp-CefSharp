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
        #region 属性
        /// <summary>
        /// 框体的标题
        /// </summary>
        public string Title { get; set; }

        #endregion
        public LoginForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Title))
                this.Text = this.lbTitle.Text = Title;
            //是否显示标题
            lbTitle.Visible= Confing.Gatway.GetBoolean("IsLoginTitle");
            //是否显示"自动登录"、"保存密码"
            cbAutoLogin.Visible = cbSavePw.Visible = Confing.Gatway.GetBoolean("IsAutoLongin");
            if (!cbAutoLogin.Visible) btnEnter.Top -= 20;
            //是否显示“注册”链接
            linkRegister.Visible= Confing.Gatway.GetBoolean("IsShowRegister");
            //是否显示“找回密码”链接
            linkFindPw.Visible = Confing.Gatway.GetBoolean("IsShowFindPw");
            //是否允许直接登录
            linkDirectaccess.Visible = Confing.Gatway.GetBoolean("IsDirectaccess");
        }
        #region 关闭按钮相关
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
        #endregion

        
    }
}
