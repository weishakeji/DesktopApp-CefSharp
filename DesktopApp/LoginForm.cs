using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
                return Confing.Gatway.GetAPI("ApiRegister");
            }
        }
        /// <summary>
        /// 默认的找回密码的链接
        /// </summary>
        public string DefFindPwUrl
        {
            get
            {
                return Confing.Gatway.GetAPI("ApiFindPw");
            }
        }
        /// <summary>
        /// 默认登录接口地址
        /// </summary>
        public string DefLoginUrl
        {
            get
            {
                string url= Confing.Gatway.GetAPI("ApiLogin");
                if (url.StartsWith("/")) url = url.Substring(1);
                return url;
            }
        }
        #endregion
        public LoginForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Setup(this);
        }
        #region 初始化窗体各项设置
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
            lbTitle.Visible = Confing.Gatway.GetBoolean("IsLoginTitle");
            //标题样式
            string font= Confing.Gatway.Get("LoginTitleFont");  //字体
            if (string.IsNullOrWhiteSpace(font)) font = "幼圆";
            int fontsize= Confing.Gatway.GetInt("LoginTitleSize");  //字号
            if (fontsize <= 0) fontsize = 10;
            bool isBold = Confing.Gatway.GetBoolean("LoginTitleBold");  //粗体
            lbTitle.Font = new Font(font, fontsize, isBold ? FontStyle.Bold : FontStyle.Regular);
            //标题颜色
            string color= Confing.Gatway.Get("LoginTitleColor");
            lbTitle.ForeColor = ColorTranslator.FromHtml(color);
            //是否显示"自动登录"、"保存密码"
            cbAutoLogin.Visible = cbSavePw.Visible = Confing.Gatway.GetBoolean("IsAutoLongin");
            if (!cbAutoLogin.Visible) btnEnterLogin.Top -= 20;
            //是否显示“注册”链接
            linkRegister.Visible= Confing.Gatway.GetBoolean("IsShowRegister");
            //是否显示“找回密码”链接
            linkFindPw.Visible = Confing.Gatway.GetBoolean("IsShowFindPw");
            //是否允许直接登录
            linkDirectaccess.Visible = Confing.Gatway.GetBoolean("IsDirectaccess");
            //链接颜色
            linkRegister.ForeColor = linkFindPw.ForeColor =
                linkDirectaccess.ForeColor = ColorTranslator.FromHtml(Confing.Gatway.Get("LoginLinkColor"));
            linkRegister.LinkColor = linkFindPw.LinkColor =
               linkDirectaccess.LinkColor = ColorTranslator.FromHtml(Confing.Gatway.Get("LoginLinkColor"));
        }
        #endregion

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

        /// <summary>
        /// 一个简单的IOC方法,用于采用不同的登录方法，具体在confing.ini中ApiFucntion节点设置
        /// </summary>
        /// <returns></returns>
        public ILogin ToLogin()
        {
            string classname = Confing.Gatway.GetAPI("Login");
            string fullName = string.Format("DesktopApp.LoginFunction.{0}", classname);  //命名空间.类型名
            object ect = Assembly.Load("DesktopApp").CreateInstance(fullName);//加载程序集，创建程序集里面的 命名空间.类型名 实例
            ILogin func = ect as ILogin;
            return func;
        }
        private void btnEnterLogin_Click(object sender, EventArgs e)
        {
            ILogin login = this.ToLogin();
            if (login == null) throw new Exception("登录接口为null，请检查Confing.ini配置项是否正确");
            //
          
            string result = this.ToLogin().Login(tbUser.Text, tbPassword.Text);
        }
    }
}
