using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    /// <summary>
    /// 自定义RichTextBox
    /// </summary>
    public class TransTextBox: RichTextBox
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadLibrary(string lpFileName);
        public TransTextBox()
        {
            this.Cursor = Cursors.Arrow;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams prams = base.CreateParams;
                if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
                {
                    prams.ExStyle |= 0x020;
                    prams.ClassName = "RICHEDIT50W";
                }
                return prams;
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x7 || m.Msg == 0x201 || m.Msg == 0x202 || m.Msg == 0x203 || m.Msg == 0x204 || m.Msg == 0x205 || m.Msg == 0x206 || m.Msg == 0x0100 || m.Msg == 0x0101)
            {
                return;
            }
            base.WndProc(ref m);
        }
    }
}
