namespace DesktopApp
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTitle = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cbAutoLogin = new System.Windows.Forms.CheckBox();
            this.cbSavePw = new System.Windows.Forms.CheckBox();
            this.linkRegister = new System.Windows.Forms.LinkLabel();
            this.btnEnterLogin = new System.Windows.Forms.Button();
            this.linkDirectaccess = new System.Windows.Forms.LinkLabel();
            this.lbClose = new System.Windows.Forms.Label();
            this.linkFindPw = new System.Windows.Forms.LinkLabel();
            this.pictureUser = new System.Windows.Forms.PictureBox();
            this.picturePw = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePw)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Location = new System.Drawing.Point(13, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(47, 12);
            this.lbTitle.TabIndex = 3;
            this.lbTitle.Text = "lbTitle";
            // 
            // tbUser
            // 
            this.tbUser.BackColor = System.Drawing.SystemColors.Window;
            this.tbUser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUser.Location = new System.Drawing.Point(133, 74);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(200, 26);
            this.tbUser.TabIndex = 1;
            this.tbUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUser_KeyPress);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPassword.Location = new System.Drawing.Point(133, 109);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(200, 26);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // cbAutoLogin
            // 
            this.cbAutoLogin.AutoSize = true;
            this.cbAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoLogin.Location = new System.Drawing.Point(136, 142);
            this.cbAutoLogin.Name = "cbAutoLogin";
            this.cbAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.cbAutoLogin.TabIndex = 3;
            this.cbAutoLogin.Text = "自动登录";
            this.cbAutoLogin.UseVisualStyleBackColor = false;
            this.cbAutoLogin.CheckedChanged += new System.EventHandler(this.cbAutoLogin_CheckedChanged);
            // 
            // cbSavePw
            // 
            this.cbSavePw.AutoSize = true;
            this.cbSavePw.BackColor = System.Drawing.Color.Transparent;
            this.cbSavePw.Location = new System.Drawing.Point(214, 142);
            this.cbSavePw.Name = "cbSavePw";
            this.cbSavePw.Size = new System.Drawing.Size(72, 16);
            this.cbSavePw.TabIndex = 4;
            this.cbSavePw.Text = "记住密码";
            this.cbSavePw.UseVisualStyleBackColor = false;
            this.cbSavePw.CheckedChanged += new System.EventHandler(this.cbSavePw_CheckedChanged);
            // 
            // linkRegister
            // 
            this.linkRegister.AutoSize = true;
            this.linkRegister.BackColor = System.Drawing.Color.Transparent;
            this.linkRegister.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkRegister.LinkColor = System.Drawing.Color.Green;
            this.linkRegister.Location = new System.Drawing.Point(12, 211);
            this.linkRegister.Name = "linkRegister";
            this.linkRegister.Size = new System.Drawing.Size(53, 12);
            this.linkRegister.TabIndex = 6;
            this.linkRegister.TabStop = true;
            this.linkRegister.Text = "在线注册";
            this.linkRegister.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegister_LinkClicked);
            // 
            // btnEnterLogin
            // 
            this.btnEnterLogin.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnterLogin.Location = new System.Drawing.Point(133, 164);
            this.btnEnterLogin.Name = "btnEnterLogin";
            this.btnEnterLogin.Size = new System.Drawing.Size(200, 30);
            this.btnEnterLogin.TabIndex = 5;
            this.btnEnterLogin.Text = "登录";
            this.btnEnterLogin.UseVisualStyleBackColor = true;
            this.btnEnterLogin.Click += new System.EventHandler(this.btnEnterLogin_Click);
            // 
            // linkDirectaccess
            // 
            this.linkDirectaccess.AutoSize = true;
            this.linkDirectaccess.BackColor = System.Drawing.Color.Transparent;
            this.linkDirectaccess.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkDirectaccess.LinkColor = System.Drawing.Color.Green;
            this.linkDirectaccess.Location = new System.Drawing.Point(351, 211);
            this.linkDirectaccess.Name = "linkDirectaccess";
            this.linkDirectaccess.Size = new System.Drawing.Size(101, 12);
            this.linkDirectaccess.TabIndex = 8;
            this.linkDirectaccess.TabStop = true;
            this.linkDirectaccess.Text = "不登录，直接访问";
            this.linkDirectaccess.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkDirectaccess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDirectaccess_LinkClicked);
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.BackColor = System.Drawing.Color.Transparent;
            this.lbClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbClose.ForeColor = System.Drawing.Color.Red;
            this.lbClose.Location = new System.Drawing.Point(440, 3);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(25, 16);
            this.lbClose.TabIndex = 13;
            this.lbClose.Text = "×";
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // linkFindPw
            // 
            this.linkFindPw.AutoSize = true;
            this.linkFindPw.BackColor = System.Drawing.Color.Transparent;
            this.linkFindPw.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkFindPw.LinkColor = System.Drawing.Color.Green;
            this.linkFindPw.Location = new System.Drawing.Point(71, 211);
            this.linkFindPw.Name = "linkFindPw";
            this.linkFindPw.Size = new System.Drawing.Size(53, 12);
            this.linkFindPw.TabIndex = 7;
            this.linkFindPw.TabStop = true;
            this.linkFindPw.Text = "找回密码";
            this.linkFindPw.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkFindPw.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFindPw_LinkClicked);
            // 
            // pictureUser
            // 
            this.pictureUser.BackColor = System.Drawing.Color.Transparent;
            this.pictureUser.Location = new System.Drawing.Point(97, 71);
            this.pictureUser.Name = "pictureUser";
            this.pictureUser.Size = new System.Drawing.Size(30, 30);
            this.pictureUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureUser.TabIndex = 14;
            this.pictureUser.TabStop = false;
            // 
            // picturePw
            // 
            this.picturePw.BackColor = System.Drawing.Color.Transparent;
            this.picturePw.Location = new System.Drawing.Point(97, 109);
            this.picturePw.Name = "picturePw";
            this.picturePw.Size = new System.Drawing.Size(30, 30);
            this.picturePw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePw.TabIndex = 15;
            this.picturePw.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(464, 232);
            this.Controls.Add(this.picturePw);
            this.Controls.Add(this.pictureUser);
            this.Controls.Add(this.linkFindPw);
            this.Controls.Add(this.lbClose);
            this.Controls.Add(this.linkDirectaccess);
            this.Controls.Add(this.btnEnterLogin);
            this.Controls.Add(this.linkRegister);
            this.Controls.Add(this.cbSavePw);
            this.Controls.Add(this.cbAutoLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lbTitle);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.CheckBox cbAutoLogin;
        private System.Windows.Forms.CheckBox cbSavePw;
        private System.Windows.Forms.LinkLabel linkRegister;
        private System.Windows.Forms.Button btnEnterLogin;
        private System.Windows.Forms.LinkLabel linkDirectaccess;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.LinkLabel linkFindPw;
        private System.Windows.Forms.PictureBox pictureUser;
        private System.Windows.Forms.PictureBox picturePw;
    }
}

