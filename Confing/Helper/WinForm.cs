using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
    产品推荐：《微厦在线学习系统》

    “在线视频学习、在线试题练习、在线同步考试”紧密相联，    
    形成“学、练、考”于一体的在线教育系统。

    可私有化部署，对接支付宝支付、微信支付，收益全掌控；
    多终端支持，电脑、手机、微信、APP、微信小程序，全都有；

    永久授权，一次购买，终身使用；
*/
namespace Confing.Helper
{
    /// <summary>
    /// 操作Winform相关的辅助类
    /// </summary>
    public class WinForm
    {
        /// <summary>
        /// 获取某某一控件下的所有子控件（包括子级）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <returns></returns>
        public static List<T> GetChilds<T>(Control control) where T : Control
        {
            return GetChilds<T>(control, null);
        }
        /// <summary>
        /// 获取某某一控件下的所有子控件（包括子级）
        /// </summary>
        /// <typeparam name="T">子控件的类型</typeparam>
        /// <param name="control">当前控件</param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> GetChilds<T>(Control control, List<T> list)
            where T : Control
        {
            if (list == null) list = new List<T>();
            foreach (System.Windows.Forms.Control c in control.Controls)
            {
                if (c is T)
                    list.Add((T)c);
                if (c.Controls.Count > 0)
                    GetChilds<T>(c, list);
            }
            return list;
        }
        /// <summary>
        /// 获取一组RadioButton的值
        /// </summary>
        /// <param name="radionpanel"></param>
        /// <returns></returns>
        public static string GetRadioButton(Panel radionpanel)
        {
            string trueName = string.Empty;
            foreach (System.Windows.Forms.Control c in radionpanel.Controls)
            {
                if (!(c is RadioButton)) continue;
                RadioButton rb = (RadioButton)c;
                if (rb.Checked) trueName = rb.Name;
            }
            return TrimName(trueName);
        }
        /// <summary>
        /// 修减控件的名称，去除前面的小写字母
        /// </summary>
        /// <param name="controlName">控件名称</param>
        /// <returns></returns>
        private static string TrimName(string controlName)
        {
            bool isCapital = false;
            StringBuilder sb = new StringBuilder();
            foreach (char c in controlName)
            {
                if (!isCapital && (c >= 'A' && c <= 'Z'))               
                    isCapital = true;              
                if (isCapital) sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
