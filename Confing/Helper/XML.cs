using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Confing.Helper
{
    /// <summary>
    /// 操作XML辅助类
    /// </summary>
    public class XML
    {
        //配置文件路径
        private static string xmlPath = System.Environment.CurrentDirectory + "\\Setup.xml";
        private static XmlDocument xmlDoc = null;
        /// <summary>
        /// 创建XML文档对象
        /// </summary>
        /// <returns></returns>
        public static XmlDocument Create()
        {
            if (xmlDoc != null) return xmlDoc;
            xmlDoc = new XmlDocument();
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
            return xmlDoc;
        }
        /// <summary>
        /// 将Winfrom信息写入到xml
        /// </summary>
        /// <param name="form"></param>
        public static void Write(Form form)
        {
            XmlDocument xmlDoc = Helper.XML.Create();
            XmlNode confing = xmlDoc.SelectSingleNode("Confing");
            //创建配置项的主节点，即窗体中的TabPage部分
            List<TabPage> pages = Helper.WinForm.GetChilds<TabPage>(form);
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
                List<Control> controls = Helper.WinForm.GetChilds<Control>(p);
                foreach (Control c in controls)
                {
                    if (c is Label) continue;
                    if (c is Button) continue;
                    //用控件名创建节点
                    XmlNode xmlItem = xmlPage.SelectSingleNode(c.Name);
                    if (xmlItem == null) xmlItem = xmlDoc.CreateElement(c.Name);
                    //获输入框的取值
                    if (c is TextBox) xmlItem.InnerText = ((TextBox)c).Text;
                    //复选框
                    if (c is CheckBox) xmlItem.InnerText = ((CheckBox)c).Checked.ToString();
                    //单选框
                    if (c is RadioButton) xmlItem.InnerText = ((RadioButton)c).Checked.ToString();
                    //如果单选框组
                    if (c is Panel) xmlItem.InnerText = Helper.WinForm.GetRadioButton((Panel)c);
                    //如果是图片
                    if(c is PictureBox)
                    {
                        Image image = ((PictureBox)c).Image;
                        if (image != null)
                        {
                            for(int i=0;i< xmlItem.ChildNodes.Count;i++)
                                xmlItem.RemoveChild(xmlItem.ChildNodes[i]);                           
                            XmlCDataSection cddata = xmlDoc.CreateCDataSection(ToBase64(image));
                            xmlItem.AppendChild(cddata);
                        }
                    }
                    xmlPage.AppendChild(xmlItem);
                }
                Helper.XML.Save();
            }
        }
        /// <summary>
        /// 保存xml配置文件
        /// </summary>
        public static void Save()
        {
            xmlDoc.Save(xmlPath);
        }
        #region 图片的处理
        /// <summary>
        /// 图片文件转Base64
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string ToBase64(Image img)
        {
            string base64 = string.Empty;
            Image image = (Image)img.Clone();
            using (Bitmap bmp = (Bitmap)image)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arr = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(arr, 0, (int)ms.Length);
                    ms.Close();
                    base64 = Convert.ToBase64String(arr);
                }
                bmp.Dispose();
            }
            return base64;
        }
        /// <summary>
        /// Base64字符串转图片对象
        /// </summary>
        /// <param name="base64string"></param>
        /// <returns></returns>
        public static Image FromBase64(string base64string)
        {
            byte[] b = Convert.FromBase64String(base64string);
            Bitmap bitmap = null;
            using (MemoryStream ms = new MemoryStream(b))
            {
                bitmap = new Bitmap(ms);
                ms.Dispose();
            }
            return bitmap;
        }
        #endregion
    }
}
