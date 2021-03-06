﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    
    public class INI
    {
        
        //配置文件路径
        private static string iniPath = System.Environment.CurrentDirectory + "\\Confing.ini";
        //键值对
        private static Dictionary<string, string> dic = new Dictionary<string, string>();

        public static string Read(string key)
        {
            if (dic.Count <= 0) dic = Analyze();
            string val = string.Empty;
            //对键值对进行遍历
            foreach (KeyValuePair<string, string> kv in dic)
            {
                if (key.Equals(kv.Key, StringComparison.CurrentCultureIgnoreCase))
                {
                    val = kv.Value;
                    break;
                }                
            }
            return val;
        }
        /// <summary>
        /// 解析配置文件
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> Analyze()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string iniContext = File.ReadAllText(iniPath);

            foreach (string s in iniContext.Split('\r'))
            {
                if (string.IsNullOrWhiteSpace(s)) continue;
                string line = s.Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;
                if(line.StartsWith("//")) continue;
                if (line.StartsWith("[")) continue;
                //解析行
                if (line.IndexOf("=") > -1)
                {
                    string key = line.Substring(0, line.IndexOf("=")).Trim();                    
                    string val = line.Substring(line.IndexOf("=") + 1).Trim();
                    if (val.StartsWith("\"")) val = val.Substring(1);
                    if (val.EndsWith("\"")) val = val.Substring(0, val.Length-1);
                    if (dic.ContainsKey("key"))
                    {
                        dic[key] = val;
                    }
                    else
                    {
                        dic.Add(key, val);
                    }
                }
            }
            return dic;
        }
    }
}
