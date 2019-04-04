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
        /// <param name="pw">密码</param>
        /// <returns></returns>
        string Login(string name, string pw);
    }
}
