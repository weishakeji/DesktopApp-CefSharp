using System;
using System.Collections.Generic;
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
namespace DesktopApp.LoginFunction
{
    /// <summary>
    /// 
    /// </summary>
    public class Other_login : ILogin
    {
        public LoginFunction.Result Access(string name, string pw)
        {
            return new Result(false, 1, "只是测试一下", null);
        }
        /// <summary>
        /// 登录成功后，要主窗体要打开的网页地址
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Gourl(string name)
        {
            return string.Empty;
        }
    }
}
