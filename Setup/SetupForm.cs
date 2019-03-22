using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
