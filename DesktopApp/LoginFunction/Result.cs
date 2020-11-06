using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    /// 登录返回的状态信息
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 成功后需要转向的地址
        /// </summary>
        public string Goto_url { get; set; }

        public Result(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml)) return;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            //是否成功
            XmlNode nodeSuccess = xmlDoc.SelectSingleNode("xml/success");
            if (nodeSuccess != null) Success = "true".Equals(nodeSuccess.InnerText, StringComparison.CurrentCultureIgnoreCase);
            //状态
            XmlNode nodeState = xmlDoc.SelectSingleNode("xml/state");
            if (nodeState != null) State = Convert.ToInt32(nodeState.InnerText);
            //消息
            XmlNode nodeMsg = xmlDoc.SelectSingleNode("xml/msg");
            if (nodeMsg != null) Message = nodeMsg.InnerText;
            //成功后的转向地址
            XmlNode nodeGourl = xmlDoc.SelectSingleNode("xml/goto_url");
            if (nodeGourl != null) Goto_url = nodeGourl.InnerText;
        }
        public Result(bool success, int state, string msg, string gourl)
        {
            this.Success = success;
            this.State = state;
            this.Message = msg;
            this.Goto_url = gourl;
        }
    }
}
