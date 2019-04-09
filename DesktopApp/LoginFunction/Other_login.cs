using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
