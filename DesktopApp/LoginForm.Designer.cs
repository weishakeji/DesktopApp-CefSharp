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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cbAutoLogin = new System.Windows.Forms.CheckBox();
            this.cbSavePw = new System.Windows.Forms.CheckBox();
            this.linkRegister = new System.Windows.Forms.LinkLabel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.linkDirectaccess = new System.Windows.Forms.LinkLabel();
            this.lbClose = new System.Windows.Forms.Label();
            this.linkFindPw = new System.Windows.Forms.LinkLabel();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(84, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "账号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(84, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码：";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(133, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 26);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(132, 109);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(203, 26);
            this.textBox2.TabIndex = 7;
            // 
            // cbAutoLogin
            // 
            this.cbAutoLogin.AutoSize = true;
            this.cbAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoLogin.Location = new System.Drawing.Point(133, 142);
            this.cbAutoLogin.Name = "cbAutoLogin";
            this.cbAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.cbAutoLogin.TabIndex = 8;
            this.cbAutoLogin.Text = "自动登录";
            this.cbAutoLogin.UseVisualStyleBackColor = false;
            // 
            // cbSavePw
            // 
            this.cbSavePw.AutoSize = true;
            this.cbSavePw.BackColor = System.Drawing.Color.Transparent;
            this.cbSavePw.Location = new System.Drawing.Point(211, 142);
            this.cbSavePw.Name = "cbSavePw";
            this.cbSavePw.Size = new System.Drawing.Size(72, 16);
            this.cbSavePw.TabIndex = 9;
            this.cbSavePw.Text = "记住密码";
            this.cbSavePw.UseVisualStyleBackColor = false;
            // 
            // linkRegister
            // 
            this.linkRegister.AutoSize = true;
            this.linkRegister.BackColor = System.Drawing.Color.Transparent;
            this.linkRegister.Location = new System.Drawing.Point(12, 211);
            this.linkRegister.Name = "linkRegister";
            this.linkRegister.Size = new System.Drawing.Size(53, 12);
            this.linkRegister.TabIndex = 10;
            this.linkRegister.TabStop = true;
            this.linkRegister.Text = "在线注册";
            this.linkRegister.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegister_LinkClicked);
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnter.Location = new System.Drawing.Point(133, 164);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(202, 30);
            this.btnEnter.TabIndex = 11;
            this.btnEnter.Text = "登录";
            this.btnEnter.UseVisualStyleBackColor = true;
            // 
            // linkDirectaccess
            // 
            this.linkDirectaccess.AutoSize = true;
            this.linkDirectaccess.BackColor = System.Drawing.Color.Transparent;
            this.linkDirectaccess.Location = new System.Drawing.Point(351, 211);
            this.linkDirectaccess.Name = "linkDirectaccess";
            this.linkDirectaccess.Size = new System.Drawing.Size(101, 12);
            this.linkDirectaccess.TabIndex = 12;
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
            this.linkFindPw.Location = new System.Drawing.Point(71, 211);
            this.linkFindPw.Name = "linkFindPw";
            this.linkFindPw.Size = new System.Drawing.Size(53, 12);
            this.linkFindPw.TabIndex = 14;
            this.linkFindPw.TabStop = true;
            this.linkFindPw.Text = "找回密码";
            this.linkFindPw.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkFindPw.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFindPw_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(464, 232);
            this.Controls.Add(this.linkFindPw);
            this.Controls.Add(this.lbClose);
            this.Controls.Add(this.linkDirectaccess);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.linkRegister);
            this.Controls.Add(this.cbSavePw);
            this.Controls.Add(this.cbAutoLogin);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTitle);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox cbAutoLogin;
        private System.Windows.Forms.CheckBox cbSavePw;
        private System.Windows.Forms.LinkLabel linkRegister;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.LinkLabel linkDirectaccess;
        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.LinkLabel linkFindPw;
    }
}

