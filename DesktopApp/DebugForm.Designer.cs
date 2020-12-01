namespace DesktopApp
{
    partial class DebugForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.urlStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolBtnShowCode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolBtnDebut = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.urlStrip,
            this.toolBtnShowCode,
            this.toolBtnDebut});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // urlStrip
            // 
            this.urlStrip.Name = "urlStrip";
            this.urlStrip.Size = new System.Drawing.Size(874, 17);
            this.urlStrip.Spring = true;
            this.urlStrip.Text = "toolStripStatusLabel1";
            this.urlStrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolBtnShowCode
            // 
            this.toolBtnShowCode.Name = "toolBtnShowCode";
            this.toolBtnShowCode.Size = new System.Drawing.Size(32, 17);
            this.toolBtnShowCode.Text = "源码";
            this.toolBtnShowCode.ToolTipText = "网页Html代码";
            this.toolBtnShowCode.Click += new System.EventHandler(this.toolBtnShowCode_Click);
            // 
            // toolBtnDebut
            // 
            this.toolBtnDebut.Name = "toolBtnDebut";
            this.toolBtnDebut.Size = new System.Drawing.Size(32, 17);
            this.toolBtnDebut.Text = "调试";
            this.toolBtnDebut.Click += new System.EventHandler(this.toolBtnDebut_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.statusStrip1);
            this.Name = "DebugForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DebugForm";
            this.Load += new System.EventHandler(this.DebugForm_Load);
            this.Shown += new System.EventHandler(this.DebugForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel urlStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolBtnShowCode;
        private System.Windows.Forms.ToolStripStatusLabel toolBtnDebut;
    }
}

