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
        //配置文件路径
        static string xmlPath = System.Environment.CurrentDirectory+"\\Setup.xml";
        /// <summary>
        /// 将设置项记录到本地
        /// </summary>
        /// <param name="form"></param>
        public static void Record(System.Windows.Forms.Form form)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (System.IO.File.Exists(xmlPath))
            {
                xmlDoc.Load(xmlPath);               
            }
            else
            {
                //创建类型声明节点    
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
                xmlDoc.AppendChild(node);
                //创建根节点    
                XmlNode root = xmlDoc.CreateElement("Confing");
                xmlDoc.AppendChild(root);
            }
            XmlNode confing = xmlDoc.SelectSingleNode("Confing");
            //创建配置项的主节点，即窗体中的TabPage部分
            List<TabPage> pages = GetChilds<TabPage>(form);
            foreach (TabPage p in pages)
            {
                string name = p.Name;
                XmlNode xmlPage = confing.SelectSingleNode(name);
                if (xmlPage == null)
                {
                    xmlPage = xmlDoc.CreateElement(name);
                    confing.AppendChild(xmlPage);
                }
                //每个主配置项目的子项
                xmlPage = confing.SelectSingleNode(name);
                List<Control> controls = GetChilds<Control>(p);
                foreach (Control c in controls)
                {
                    if (c is Label) continue;
                    //if (c is Panel) continue;
                    if (c is Button) continue;
                    string cname = c.Name;
                    XmlNode xmlItem = xmlPage.SelectSingleNode(cname);
                    if (xmlItem == null)
                    {
                        xmlItem = xmlDoc.CreateElement(cname);
                        xmlItem.InnerText = "xxx";
                        xmlPage.AppendChild(xmlItem);
                    }
                    else
                    {
                        xmlItem.InnerText = "yyy";
                    }

                }
                //int count = pages.Count;
                xmlDoc.Save(xmlPath);
            }
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
        #region 私有方法
        /// <summary>
        /// 获取某一类子控件
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
                if (c is T)
                    list.Add((T)c);
                if (c.Controls.Count > 0)
                    GetChilds<T>(c, list);
            }
            return list;
        }
        private static List<T> GetChilds<T>(Control control) where T : Control
        {
            return GetChilds<T>(control, null);
        }
        /// <summary>
        /// 修减控件的名称，去除前面的小写字母
        /// </summary>
        /// <param name="controlName">控件名称</param>
        /// <returns></returns>
        private static string Trim(string controlName)
        {
            bool isCapital = false;
            StringBuilder sb = new StringBuilder();
            foreach (char c in controlName)
            {
                if (!isCapital && (c >= 'A' && c <= 'Z'))
                {
                    isCapital = true;
                }
                if (isCapital) sb.Append(c);
            }
            return sb.ToString();
        }
        #endregion
    }
}
