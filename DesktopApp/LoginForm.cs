using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// <summary>
        /// 默认的注册链接
        /// </summary>
        public string DefRegisterUrl
        {
            get
            {
                string url = Confing.Gatway.Get("ApiRegister");
                return string.IsNullOrEmpty(url) ? Confing.Gatway.GetAPI("ApiRegister") : url;
            }
        }
        /// <summary>
        /// 默认的找回密码的链接
        /// </summary>
        public string DefFindPwUrl
        {
            get
            {
                string url = Confing.Gatway.Get("ApiFindPw");
                return string.IsNullOrEmpty(url) ? Confing.Gatway.GetAPI("ApiFindPw") : url;
            }
        }
        /// <summary>
        /// 默认登录接口地址
        /// </summary>
        public string DefLoginUrl
        {
            get
            {
                string url = Confing.Gatway.Get("ApiLogin");
                return string.IsNullOrEmpty(url) ? Confing.Gatway.GetAPI("ApiLogin") : url;
            }
        }
        #endregion
        public LoginForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Setup(this);
        }
        /// <summary>
        /// 构建登录窗
        /// </summary>
        /// <returns></returns>
        void Setup(LoginForm form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;    //屏幕中央打开
            form.TopMost = true;    //最上层
            form.FormBorderStyle = FormBorderStyle.None;    //无边框
            //背景图
            Image mainbg = Confing.Gatway.GetImage("LoginBg", "jpg");
            if (mainbg != null) form.BackgroundImage = mainbg;
            //标题
            form.Title = Confing.Gatway.Get("LoginTitle");
            if (string.IsNullOrWhiteSpace(form.Title)) form.Title = Confing.Gatway.Get("Title");

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

        #region 链接按钮事件
        /// <summary>
        /// 直接访问
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkDirectaccess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form main = new MainForm();
            main.Show();
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkFindPw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form main = new MainForm(DefFindPwUrl);
            main.Show();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form main = new MainForm(DefRegisterUrl);
            main.Show();
        }
        #endregion


    }
}
