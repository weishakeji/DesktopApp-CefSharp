using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
/*
    产品推荐：《微厦在线学习系统》

    “在线视频学习、在线试题练习、在线同步考试”紧密相联，    
    形成“学、练、考”于一体的在线教育系统。

    可私有化部署，对接支付宝支付、微信支付，收益全掌控；
    多终端支持，电脑、手机、微信、APP、微信小程序，全都有；

    永久授权，一次购买，终身使用；
*/
namespace Setup
{
    static class Program
    {
        private static System.Threading.Mutex mutex;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SetupForm());

            mutex = new System.Threading.Mutex(true, "OnlyRun");
            if (mutex.WaitOne(0, false))
            {
                Form form = new SetupForm();
                form.StartPosition = FormStartPosition.CenterScreen;    //屏幕中央打开
                Application.Run(form);
            }
            else
            {
                MessageBox.Show("程序已经在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
