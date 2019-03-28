using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Setup
{
    public partial class SetupForm : Form
    {        
        public SetupForm()
        {
            InitializeComponent();
            this.Icon = Setup.Properties.Resources.appicon;
            Confing.Gatway.Restore(this);
            this.picICON.Parent = this.tabBase;
        }        

        #region 底部按钮，确定与关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Confing.Gatway.Record(this);
            //MessageBox.Show("保存成功！");
            lbShow.Visible = true;
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lbShow.Visible = false;
        }
        #endregion

        #region 基础设置的界面方法
        /// <summary>
        /// 选择主图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectICON_Click(object sender, EventArgs e)
        {
            //声明允许上传的图片的后缀名
            string[] limitImgExt = new string[] { "*.ico" };
            OpenFileDialog fileDialog = new OpenFileDialog();
            string str = string.Format("图标文件({0})|{1}|All files(*.*)| *.*", string.Join(",", limitImgExt), string.Join(";", limitImgExt));
            fileDialog.Filter = str;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                if (!((IList<string>)limitImgExt).Contains("*" + extension))
                {
                    MessageBox.Show(string.Format("只能选择{0}格式的图片！", string.Join("、", limitImgExt)).Replace("*.", ""));
                }
                else
                {
                    Image source = Image.FromFile(fileDialog.FileName);
                    this.picICON.Image = source;
                    this.picICON.Enabled = true;
                }
            }
        }
        #endregion

        #region 主窗体界面的方法

        #endregion

        #region 关于我们的方法
        /// <summary>
        /// 预览关于我们的效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAboutShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //宽高
            int width, height;
            int.TryParse(tbAboutWidth.Text, out width);
            int.TryParse(tbAboutHeight.Text, out height);
            //构建窗体
            AboutForm aboutForm = new AboutForm();
            if (width > 0 && height > 0) aboutForm.Size = new Size(width, height);
            //背景图
            aboutForm.BackgroundImage = this.pictureAboutBgPic.Image;
            //文本内容
            aboutForm.ContextText = tbAboutContext.Text;
            aboutForm.ShowDialog();
            aboutForm.Focus();
        }
        private void btnSelectAboutBg_Click(object sender, EventArgs e)
        {
            //声明允许上传的图片的后缀名
            string[] limitImgExt = new string[] { "*.gif", "*.jpg", "*.jpeg", "*.png", "*.bmp" };
            OpenFileDialog fileDialog = new OpenFileDialog();
            string str = string.Format("图片文件({0})|{1}|All files(*.*)| *.*", string.Join(",", limitImgExt), string.Join(";", limitImgExt));
            fileDialog.Filter = str;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                if (!((IList<string>)limitImgExt).Contains("*" + extension))
                {
                    MessageBox.Show(string.Format("只能选择{0}格式的图片！", string.Join("、", limitImgExt)).Replace("*.", ""));
                }
                else
                {
                    Image source = Image.FromFile(fileDialog.FileName);
                    this.pictureAboutBgPic.Image = source;
                    this.pictureAboutBgPic.Enabled = true;
                }
            }
        }
        private void pictureAboutBgPic_EnabledChanged(object sender, EventArgs e)
        {
            Image source = this.pictureAboutBgPic.Image;
            if (source != null)
            {
                lbAboutBgWh.Text = string.Format("{0}×{1} 像素", source.Width, source.Height);
            }
        }
        #endregion

        #region 调试界面的方法
        private void rbDebugMobile_CheckedChanged(object sender, EventArgs e)
        {
            panelBrowserMobile.Enabled = this.rbDebugMobile.Checked;
        }

        private void btnSelectDebugIndex_Click(object sender, EventArgs e)
        {
            //声明允许上传的后缀名
            string[] limitImgExt = new string[] { "*.htm", "*.html" };
            OpenFileDialog fileDialog = new OpenFileDialog();
            string str = string.Format("网页文件({0})|{1}|All files(*.*)| *.*", string.Join(",", limitImgExt), string.Join(";", limitImgExt));
            fileDialog.Filter = str;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                if (!((IList<string>)limitImgExt).Contains("*" + extension))
                {
                    MessageBox.Show(string.Format("只能选择{0}格式的网页文件！", string.Join("、", limitImgExt)).Replace("*.", ""));
                }
                else
                {
                    tbDebugCustom.Text = fileDialog.FileName;
                }
            }
        }
        #endregion

        #region 登录界面的方法
        private void btnSelectLoginBg_Click(object sender, EventArgs e)
        {
            //声明允许上传的图片的后缀名
            string[] limitImgExt = new string[] { "*.gif", "*.jpg", "*.jpeg", "*.png", "*.bmp" };
            OpenFileDialog fileDialog = new OpenFileDialog();
            string str = string.Format("图片文件({0})|{1}|All files(*.*)| *.*", string.Join(",", limitImgExt), string.Join(";", limitImgExt));
            fileDialog.Filter = str;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                if (!((IList<string>)limitImgExt).Contains("*" + extension))
                {
                    MessageBox.Show(string.Format("只能选择{0}格式的图片！", string.Join("、", limitImgExt)).Replace("*.", ""));
                }
                else
                {                    
                    Image source = Image.FromFile(fileDialog.FileName);
                    this.pictureLoginBg.Image = source;
                    this.pictureLoginBg.Enabled = true;
                }
            }
        }

        private void pictureLoginBg_EnabledChanged(object sender, EventArgs e)
        {
            Image source = this.pictureLoginBg.Image;
            if (source != null)
            {
                lbLoginBgInfo.Text = string.Format("图片实际像素:{0}×{1} 像素", source.Width, source.Height);
            }
        }


        #endregion


    }
}
