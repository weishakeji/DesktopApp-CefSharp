using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
            Helper.XML.Write(form);
        }
        /// <summary>
        /// 将设置项重现到配置界面中
        /// </summary>
        /// <param name="form"></param>
        public static void Fill(System.Windows.Forms.Form form)
        {
        }
        public static string Get(string itemname)
        {
            return string.Empty;
        }
        
    }
}
