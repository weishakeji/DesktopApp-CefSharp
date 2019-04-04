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
        public string Login(string name, string pw)
        {
            return "其它系统的登录方法";
        }
    }
}
