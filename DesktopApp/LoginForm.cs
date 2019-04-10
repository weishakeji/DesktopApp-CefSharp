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
            if (!string.IsNullOrWhiteSpace(Title))
                this.Text = this.lbTitle.Text = Title;
            //是否显示标题
            lbTitle.Visible = Confing.Gatway.GetBoolean("IsLoginTitle");
            //标题样式
            string font = Confing.Gatway.Get("LoginTitleFont");  //字体
            if (string.IsNullOrWhiteSpace(font)) font = "幼圆";
            int fontsize = Confing.Gatway.GetInt("LoginTitleSize");  //字号
            if (fontsize <= 0) fontsize = 10;
            bool isBold = Confing.Gatway.GetBoolean("LoginTitleBold");  //粗体
            lbTitle.Font = new Font(font, fontsize, isBold ? FontStyle.Bold : FontStyle.Regular);
            //标题颜色
            string color = Confing.Gatway.Get("LoginTitleColor");
            lbTitle.ForeColor = ColorTranslator.FromHtml(color);
            //是否显示"自动登录"、"保存密码"
            cbAutoLogin.Visible = cbSavePw.Visible = Confing.Gatway.GetBoolean("IsAutoLongin");
            string colorCheck = Confing.Gatway.Get("LoginCheckColor");
            cbAutoLogin.ForeColor = cbSavePw.ForeColor= ColorTranslator.FromHtml(colorCheck);
            //是否显示“注册”链接
            linkRegister.Visible = Confing.Gatway.GetBoolean("IsShowRegister");
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
        private void LoginForm_Load(object sender, EventArgs e)
        {           
            //如果“自动登录”不显示，则确定按钮上移
            if (!cbAutoLogin.Visible) btnEnterLogin.Top -= 20;
            //自动登录与保存密码的状态
            cbAutoLogin.Checked = LoginFunction.LoginInfo.AutoLogin;
            cbSavePw.Checked = LoginFunction.LoginInfo.SavePw;

            pictureUser.Image = DesktopApp.Properties.Resources.user.ToBitmap();
            picturePw.Image= DesktopApp.Properties.Resources.password.ToBitmap();

        }
        private void LoginForm_Shown(object sender, EventArgs e)
        {
            //历史登录记录
            LoginFunction.LoginInfo loginfo = LoginFunction.LoginInfo.First;
            if (loginfo != null)
            {
                tbUser.Text = loginfo.User;
                tbPassword.Text = loginfo.Password;
                //自动登录
                if (cbAutoLogin.Checked)
                {
                    btnEnterLogin_Click(cbAutoLogin, EventArgs.Empty);
                }
            }
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
            if (!this.Visible) return;
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
        /// <summary>
        /// 登录按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnterLogin_Click(object sender, EventArgs e)
        {
            LoginFunction.LoginInfo.Set(cbAutoLogin.Checked,cbSavePw.Checked);
            //生成登录接口对象
            ILogin login = this.ToLogin();
            if (login == null) throw new Exception("登录接口为null，请检查Confing.ini配置项是否正确");
            //验证登录
            LoginFunction.Result result = null;
            //如果来自登录按钮的触发
            try
            {
                if (sender is Button || sender is TextBox)
                {
                    //密码
                    string pw = tbPassword.Text;
                    LoginFunction.LoginInfo loginfo = LoginFunction.LoginInfo.Get(tbUser.Text.Trim());
                    if(loginfo == null || string.IsNullOrWhiteSpace(loginfo.Password) || pw != loginfo.Password)
                        pw = Handler.Client.MD5(tbPassword.Text);
                    else
                        pw = loginfo.Password;
                     result = this.ToLogin().Access(tbUser.Text, pw);
                    if (result.Success && cbSavePw.Checked) LoginFunction.LoginInfo.Set(tbUser.Text, pw);
                    if (result.Success && !cbSavePw.Checked) LoginFunction.LoginInfo.Set(tbUser.Text, string.Empty);
                }
                //如果来自自动登录
                if (sender is CheckBox)
                {
                    LoginFunction.LoginInfo info = LoginFunction.LoginInfo.Get(tbUser.Text.Trim());
                    result = this.ToLogin().Access(info.User, info.Password);
                }
                if (result.Success)
                {
                    string gourl = this.ToLogin().Gourl(tbUser.Text.Trim());
                    this.Hide();
                    Form main = new MainForm(gourl);
                    main.Show();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #region 控件事件
        /// <summary>
        /// 当“自动登录”为选中状态时，“保存密码”也为选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoLogin.Checked) cbSavePw.Checked = true;
        }
        /// <summary>
        /// 当“保存密码”为非选中状态时，“自动登录”自然也不能作为选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSavePw_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbSavePw.Checked) cbAutoLogin.Checked = false;
        }
        /// <summary>
        /// 当在密码输入框回车时，触发登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnEnterLogin_Click(tbPassword, EventArgs.Empty);
            }

        }
        /// <summary>
        /// 当在账号输入框回车时，光标转到密码输入框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if(!string.IsNullOrWhiteSpace(tbUser.Text))
                    tbPassword.Focus();
            }
        }

        #endregion

        
    }
}
