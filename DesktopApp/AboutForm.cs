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
    public partial class AboutForm : Form
    {
        /// <summary>
        /// 要显示的文本内容
        /// </summary>
        public string ContextText { get; set; }
        public AboutForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            InitForm();
        }
        TransTextBox richText = new TransTextBox();
        public void InitForm()
        {
            //图标
            this.Icon = Confing.Gatway.GetIcon("ICON");
            this.TopMost = true;
            //宽高
            int width = Confing.Gatway.GetInt("AboutWidth");
            int height = Confing.Gatway.GetInt("AboutHeight");
            if (width > 0 && height > 0)
                this.Size = new Size(width, height);
            //背景图
            Image mainbg = Confing.Gatway.GetImage("AboutBgPic", "jpg");
            if (mainbg != null) this.BackgroundImage = mainbg;
            //要显示的内容
            this.ContextText = Confing.Gatway.Get("AboutContext");
            richText.BorderStyle = BorderStyle.None;
            this.Controls.Add(richText);
        }
        /// <summary>
        /// 加载关于我们的窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutForm_Load(object sender, EventArgs e)
        {
            //文本区域的位置
            richText.Width = (this.Width - 14) * 90 / 100;
            richText.Height = (this.Height - 34) * 90 / 100;
            richText.Left = (this.Width - 14) * 5 / 100;
            richText.Top = (this.Height - 34) * 5 / 100;
            //设置内容
            if (string.IsNullOrWhiteSpace(ContextText)) return;
            string[] str = ContextText.Split('\r');
            int selectStart = 0;
            foreach (string s in str)
            {
                string line;
                int fontsize = getTextFont(s, out line);
                selectStart = richText.TextLength;
                richText.AppendText(line + Environment.NewLine);
                richText.Select(selectStart, richText.TextLength - 1);
                richText.SelectionFont = new Font(Font.FontFamily, fontsize);
            }
            richText.Select(0, 0);
        }
        /// <summary>
        /// 计算字体大小，根据字符关面的#号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int getTextFont(string str, out string line, double fontsize = 10)
        {
            str = str.Trim();
            //每多一个#，字体放大的倍数
            double multiple = 1.2;
            while (str.StartsWith("#"))
            {
                str = str.Substring(1);
                fontsize *= multiple;
            }
            line = str;
            return (int)fontsize;
        }

    }
}
