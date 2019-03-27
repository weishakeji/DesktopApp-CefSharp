namespace Setup
{
    partial class AboutForm
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
            this.richText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richText
            // 
            this.richText.BackColor = System.Drawing.Color.White;
            this.richText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richText.Enabled = false;
            this.richText.Location = new System.Drawing.Point(38, 34);
            this.richText.Margin = new System.Windows.Forms.Padding(30);
            this.richText.Name = "richText";
            this.richText.ReadOnly = true;
            this.richText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richText.Size = new System.Drawing.Size(256, 267);
            this.richText.TabIndex = 1;
            this.richText.Text = "";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 360);
            this.Controls.Add(this.richText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " 关于";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richText;
    }
}

