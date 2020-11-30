﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
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
    /// 操作XML辅助类
    /// </summary>
    public class XML
    {
        //加密的密钥
        public static string EncryptKey = "information";
        //配置文件路径
        private static string xmlPath = System.Environment.CurrentDirectory + "\\Confing.xml";
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
        #region 将setupform记录到xml
        /// <summary>
        /// 将Winfrom信息写入到xml
        /// </summary>
        /// <param name="form"></param>
        public static void Write(Form form)
        {
            XmlDocument xmlDoc = Helper.XML.Create();
            XmlNode config = xmlDoc.SelectSingleNode("Confing");
            XmlAttribute attr = xmlDoc.CreateAttribute("key");
            attr.Value = "weishakeji";
            config.Attributes.Append(attr);

            //创建配置项的主节点，即窗体中的TabPage部分
            List<TabPage> pages = Helper.WinForm.GetChilds<TabPage>(form);
            foreach (TabPage p in pages)
            {
                string name = p.Name;
                XmlNode xmlPage = config.SelectSingleNode(name);
                if (xmlPage == null)
                {
                    xmlPage = xmlDoc.CreateElement(name);
                    config.AppendChild(xmlPage);
                }
                //每个主配置项目的子项
                xmlPage = config.SelectSingleNode(name);
                List<Control> controls = Helper.WinForm.GetChilds<Control>(p);
                foreach (Control c in controls)
                {
                    if (c is Label) continue;
                    if (c is Button) continue;
                    //用控件名创建节点
                    XmlNode xmlItem = xmlPage.SelectSingleNode(c.Name);
                    if (xmlItem == null) xmlItem = xmlDoc.CreateElement(c.Name);
                    //获输入框的取值
                    if (c is TextBox)
                    {
                        TextBox tb = (TextBox)c;
                        if (tb.Multiline) {
                            for (int i = 0; i < xmlItem.ChildNodes.Count; i++)
                                xmlItem.RemoveChild(xmlItem.ChildNodes[i]);
                            XmlCDataSection cddata = xmlDoc.CreateCDataSection(tb.Text);
                            xmlItem.AppendChild(cddata);
                        }
                        else
                        {
                            xmlItem.InnerText = tb.Text;                            
                        }
                    }
                    //复选框
                    if (c is CheckBox)                  
                        xmlItem.InnerText = ((CheckBox)c).Checked.ToString();                 
                    //单选框
                    if (c is RadioButton) 
                        xmlItem.InnerText = ((RadioButton)c).Checked.ToString();
                    //如果单选框组
                    if (c is Panel) 
                        xmlItem.InnerText = Helper.WinForm.GetRadioButton((Panel)c);
                    //如果是图片
                    if (c is PictureBox)
                    {
                        PictureBox picbox = ((PictureBox)c);
                        if (picbox.Enabled)
                        {
                            for (int i = 0; i < xmlItem.ChildNodes.Count; i++)
                                xmlItem.RemoveChild(xmlItem.ChildNodes[i]);
                            string txt = ToBase64(picbox.Image);
                            txt= Helper.DataConvert.EncryptForDES(txt, EncryptKey);
                            XmlCDataSection cddata = xmlDoc.CreateCDataSection(txt);
                            xmlItem.AppendChild(cddata);
                        }
                    }
                    else
                    {
                        //加密后存储
                        xmlItem.InnerText = Helper.DataConvert.EncryptForDES(xmlItem.InnerText, EncryptKey);
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
        #endregion

        #region 将记录还原到setupform
        /// <summary>
        /// 将配置信息读取出来，并设置setupform窗体的各控件状态
        /// </summary>
        /// <param name="form"></param>
        public static void Read(Form form)
        {
            XmlDocument xmlDoc = Helper.XML.Create();
            //XmlNode confing = xmlDoc.SelectSingleNode("Confing");
            //获取选项卡工作区域
            List<TabPage> pages = Helper.WinForm.GetChilds<TabPage>(form);
            foreach (TabPage p in pages)
            {
                //读取选项卡区域的记录
                XmlNode xmlTabpage = xmlDoc.SelectSingleNode("Confing/" + p.Name);
                if (xmlTabpage == null) continue;
                foreach (XmlNode node in xmlTabpage.ChildNodes)
                {
                    List<Control> controls = Helper.WinForm.GetChilds<Control>(p);
                    //解密
                    string txt = Helper.DataConvert.DecryptForDES(node.InnerText, EncryptKey);
                    foreach (Control c in controls)
                    {
                        if (node.Name != c.Name) continue;
                        //获输入框的取值
                        if (c is TextBox) 
                            ((TextBox)c).Text = txt;
                        //复选框
                        if (c is CheckBox) 
                            ((CheckBox)c).Checked = Convert.ToBoolean(txt);
                        //单选框
                        if (c is RadioButton) ((RadioButton)c).Checked = Convert.ToBoolean(txt);
                        //如果是图片
                        if (c is PictureBox)
                        {
                            Image image = FromBase64(txt);
                            if (image != null) ((PictureBox)c).Image = image;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 控件名称为作键值，获取具体的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Read(string key)
        {
            string val = string.Empty;
            //创建xml文件对象，遍历节点
            XmlDocument xmlDoc = Helper.XML.Create();
            XmlNode config = xmlDoc.SelectSingleNode("Confing");
            foreach (XmlNode tabpage in config.ChildNodes)
            {
                foreach (XmlNode node in tabpage.ChildNodes)
                {
                    string name = TrimName(node.Name);
                    if (key.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        val = node.InnerText;
                        break;
                    }
                }
                if (!string.IsNullOrWhiteSpace(val)) break;
            }
            return Helper.DataConvert.DecryptForDES(val, EncryptKey);
        }
        /// <summary>
        /// 控件名称为作键值，获取具体的值
        /// </summary>
        /// <param name="tabpage">setupform中的选项卡名称，xml作为配置项目的节点</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Read(string tabpage, string key)
        {
            string val = string.Empty;
            //创建xml文件对象，遍历节点
            XmlDocument xmlDoc = Helper.XML.Create();
            XmlNode config = xmlDoc.SelectSingleNode("Confing");
            foreach (XmlNode tab in config.ChildNodes)
            {
                if (tabpage.Equals(TrimName(tab.Name), StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach (XmlNode node in tab.ChildNodes)
                    {
                        string name = TrimName(node.Name);
                        if (key.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                        {
                            val = node.InnerText;
                            break;
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(val)) break;
            }
            return Helper.DataConvert.DecryptForDES(val, EncryptKey);
        }
        #endregion

        #region 图片的处理
        /// <summary>
        /// 图片文件转Base64
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string ToBase64(Image img)
        {
            if (img == null) return string.Empty;
            string base64 = string.Empty;
            Image image = (Image)img.Clone();
            using (Bitmap bmp = (Bitmap)image)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
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
            if (string.IsNullOrWhiteSpace(base64string)) return null;
            try
            {
                byte[] b = Convert.FromBase64String(base64string);
                Bitmap bitmap = null;
                using (MemoryStream ms = new MemoryStream(b))
                {
                    bitmap = new Bitmap(ms);
                    ms.Dispose();
                    ms.Close();
                }
                return bitmap;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Base64字符串转图片对象
        /// </summary>
        /// <param name="base64string"></param>
        /// <param name="format">图片格式 支持 jpg|bmp|gif|png</param>
        /// <returns></returns>
        public static Image FromBase64(string base64string, string format)
        {
            //临时文件
            string tmFile = string.Format("{0}/{1}.{2}", Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMddHHmmssfff"), format);
            try
            {
                byte[] arr = Convert.FromBase64String(base64string);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                if (format.ToLower() == "jpg") bmp.Save(tmFile, ImageFormat.Jpeg);
                Image img = Image.FromFile(tmFile);
                System.IO.File.Delete(tmFile);
                return img;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        /// <summary>
        /// 修减控件的名称，去除前面的小写字母
        /// </summary>
        /// <param name="controlName">控件名称</param>
        /// <returns></returns>
        public static string TrimName(string controlName)
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
