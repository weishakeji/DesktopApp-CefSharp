using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
/*
    产品推荐：《微厦在线学习系统》

    “在线视频学习、在线试题练习、在线同步考试”紧密相联，    
    形成“学、练、考”于一体的在线教育系统。

    可私有化部署，对接支付宝支付、微信支付，收益全掌控；
    多终端支持，电脑、手机、微信、APP、微信小程序，全都有；

    永久授权，一次购买，终身使用；
*/
namespace DesktopApp.LoginFunction
{
    /// <summary>
    /// 登录信息，当设置保存密码时，在本地记录的账号与密码信息
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 是否为当前登录账号
        /// </summary>
        public bool Current { get; set; }
        public LoginInfo() { }
        public LoginInfo(string user, string pw)
        {
            this.User = user;
            this.Password = pw;
        }

        //配置文件路径
        private static string xmlPath = System.Environment.CurrentDirectory + "\\LoginInfo.xml";
        private static XmlDocument xmlDoc = null;
        /// <summary>
        /// 创建XML文档对象
        /// </summary>
        /// <returns></returns>
        private static XmlDocument Create()
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
                XmlNode root = xmlDoc.CreateElement("LoginInfo");
                xmlDoc.AppendChild(root);
            }
            return xmlDoc;
        }
        /// <summary>
        /// 获取登录信息列表
        /// </summary>
        /// <returns></returns>
        public static List<LoginInfo> GetList()
        {
            XmlDocument xmlDoc = LoginInfo.Create();
            XmlNode root = xmlDoc.SelectSingleNode("LoginInfo");
            List<LoginInfo> list = new List<LoginInfo>();
            foreach (XmlNode node in root.ChildNodes)
            {
                LoginInfo info = new LoginInfo();
                //账号
                XmlNode nodeUser = node.SelectSingleNode("user");
                if (nodeUser != null) info.User = nodeUser.InnerText;
                //密码
                XmlNode nodePw = node.SelectSingleNode("pw");
                if (nodePw != null) info.Password = nodePw.InnerText;
                list.Add(info);
            }
            return list;
        }
        /// <summary>
        /// 根据登录名获取对象
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static LoginInfo Get(string user)
        {
            LoginInfo info = null;
            List<LoginInfo> list = GetList();
            for (int j = 0; j < list.Count; j++)
            {
                if (user.Equals(list[j].User, StringComparison.CurrentCultureIgnoreCase))
                {
                    info = list[j];                    
                    break;
                }
            }
            return info;
        }
        /// <summary>
        /// 是否自动登录
        /// </summary>
        public static bool AutoLogin
        {
            get
            {
                XmlDocument xmlDoc = LoginInfo.Create();
                XmlElement root = (XmlElement)xmlDoc.SelectSingleNode("LoginInfo");
                string autologin=root.GetAttribute("autologin");
                return "true".Equals(autologin, StringComparison.CurrentCultureIgnoreCase);
            }
        }
        /// <summary>
        /// 是否保存密码
        /// </summary>
        public static bool SavePw
        {
            get
            {
                XmlDocument xmlDoc = LoginInfo.Create();
                XmlElement root = (XmlElement)xmlDoc.SelectSingleNode("LoginInfo");
                string savepw = root.GetAttribute("savepw");
                return "true".Equals(savepw, StringComparison.CurrentCultureIgnoreCase);
            }
        }
        /// <summary>
        /// 第一个登录信息
        /// </summary>
        public static LoginInfo First
        {
            get
            {
                List<LoginInfo> list = GetList();
                if (list.Count <= 0) return null;
                return list[0];
            }
        }
        /// <summary>
        /// 保存登录账号
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pw"></param>
        public static void Set(string user, string pw)
        {
            LoginInfo info = null;
            List<LoginInfo> list = GetList();
            for (int j = 0; j < list.Count; j++)
            {
                LoginInfo i = list[j];
                if (user.Equals(i.User, StringComparison.CurrentCultureIgnoreCase))
                {
                    info = i;
                    info.Password = pw;
                    list.RemoveAt(j);
                    break;
                }
            }
            if (info != null) list.Insert(0, info);
            if (info == null) list.Insert(0, new LoginInfo(user, pw));
            //保存到xml
            XmlDocument xmlDoc = LoginInfo.Create();
            XmlNode root = xmlDoc.SelectSingleNode("LoginInfo");
            //删除原有，重建
            foreach (XmlNode x in root.ChildNodes) root.RemoveChild(x);
            for (int j = 0; j < list.Count; j++)
            {
                LoginInfo i = list[j];
                XmlNode xmlItem = xmlDoc.CreateElement("item");
                //账号
                XmlNode nodeUser = xmlDoc.CreateElement("user");
                nodeUser.InnerText = i.User;
                xmlItem.AppendChild(nodeUser);
                //密码
                XmlNode nodePw = xmlDoc.CreateElement("pw");
                nodePw.InnerText = i.Password;
                xmlItem.AppendChild(nodePw);
                //
                root.AppendChild(xmlItem);
            }
            xmlDoc.Save(xmlPath);
        }
        /// <summary>
        /// 设置自动登录，是否保存密码
        /// </summary>
        /// <param name="isAutologin"></param>
        /// <param name="isSavepw"></param>
        public static void Set(bool isAutologin,bool isSavepw)
        {
            XmlDocument xmlDoc = LoginInfo.Create();
            XmlElement root = (XmlElement)xmlDoc.SelectSingleNode("LoginInfo");
            root.SetAttribute("autologin", isAutologin.ToString());
            root.SetAttribute("savepw", isSavepw.ToString());
            xmlDoc.Save(xmlPath);
        }
    }
}
