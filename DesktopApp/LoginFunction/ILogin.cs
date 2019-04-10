using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    public interface ILogin
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">账号</param>
        /// <param name="pw">密码（方法没有对密码加密，这里最好提供加密后的密码）</param>
        /// <returns></returns>
        LoginFunction.Result Access(string name, string pw);
        /// <summary>
        /// 登录成功后，在主窗体要打开的网页地址
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string Gourl(string name);
    }
}
