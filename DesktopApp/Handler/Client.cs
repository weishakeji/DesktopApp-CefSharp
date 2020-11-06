using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;
using System.Reflection;
using System.Net;
using System.IO;
/*
    产品推荐：《微厦在线学习系统》

    “在线视频学习、在线试题练习、在线同步考试”紧密相联，    
    形成“学、练、考”于一体的在线教育系统。

    可私有化部署，对接支付宝支付、微信支付，收益全掌控；
    多终端支持，电脑、手机、微信、APP、微信小程序，全都有；

    永久授权，一次购买，终身使用；
*/
namespace DesktopApp.Handler
{
    public class Client
    {
        /// <summary>
        /// 获取CPU串号
        /// </summary>
        public static string CPUCode
        {
            get
            {
                string strCpu = null;
                //取CPU物理串号
                try
                {

                    ManagementClass myCpu = new ManagementClass("win32_Processor");  //获取系统CPU处理器
                    ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
                    foreach (ManagementObject myObject in myCpuConnection)
                    {
                        if (myObject.Properties["Processorid"] != null)
                        {
                            strCpu = myObject.Properties["Processorid"].Value.ToString();   //获取CPU序列号
                            break;
                        }
                    }
                }
                catch { }
                //如果实在取不到
                if (string.IsNullOrWhiteSpace(strCpu))
                {
                    strCpu = "notGetCPU";
                }
                return strCpu;
            }
        }

        /// <summary>
        /// 获取网页的返回结果
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns></returns>
        public static string WebResult(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Method = "GET";
            request.MaximumAutomaticRedirections = 3;
            request.Timeout = 0x2710;
            string useragent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            request.UserAgent = useragent + string.Format(" Weishakeji - DeskApp({0})", Handler.Client.CPUCode);
            request.Accept = "*/*";
            request.KeepAlive = true;
            request.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
            Stream responseStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string str = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            return str;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str.Trim(), "MD5").ToLower();
        }
    }
}
