using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Confing
{
    public class Gatway
    {
        /// <summary>
        /// 将设置项记录到本地
        /// </summary>
        /// <param name="form"></param>
        public static void Record(System.Windows.Forms.Form form)
        {
            List<TabPage> pages = GetChilds<TabPage>(form);

            int count = pages.Count;
        }
        /// <summary>
        /// 将设置项重现到配置界面中
        /// </summary>
        /// <param name="form"></param>
        public static void Fill(System.Windows.Forms.Form form)
        {
        }

        #region 私有方法
        /// <summary>
        /// 获取子控件
        /// </summary>
        /// <typeparam name="T">子控件的类型</typeparam>
        /// <param name="control">当前控件</param>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<T> GetChilds<T>(Control control, List<T> list)
            where T : Control
        {
            if (list == null) list = new List<T>();
            foreach (System.Windows.Forms.Control c in control.Controls)
            {
                if (c is T) list.Add((T)c);
                if (c.Controls.Count > 0) GetChilds<T>(c, list);
            }
            return list;
        }
        private static List<T> GetChilds<T>(Control control) where T : Control
        {
            return GetChilds<T>(control, null);
        }
        #endregion
    }
}
