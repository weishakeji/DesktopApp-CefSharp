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
        }
        
        #region 调试
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBrowser_CheckedChanged(object sender, EventArgs e)
        {
            this.panelBrowserMobile.Enabled = radioBroswerMobile.Checked;
        }
        #endregion

        #region 底部按钮，确定与关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Confing.Gatway.Record(this);
        }
        #endregion
        #region 主界面事件
        /// <summary>
        /// 选择主图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectICON_Click(object sender, EventArgs e)
        {
            //声明允许的后缀名
            string[] limitExt = new string[] { "*.gif", "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.ico" };
            OpenFileDialog fileDialog = new OpenFileDialog();
            string str = string.Format("图片文件({0})|{1}|All files(*.*)| *.*", string.Join(",", limitExt), string.Join(";", limitExt));
            fileDialog.Filter = str;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                if (!((IList<string>)limitExt).Contains("*" + extension))
                {
                    MessageBox.Show(string.Format("只能选择{0}格式的图片！", string.Join("、", limitExt)).Replace("*.", ""));
                }
                else
                {
                    Image source = Image.FromFile(fileDialog.FileName);
                    this.picICON.Image = source;
                }
            }
        }
        #endregion
    }
}
