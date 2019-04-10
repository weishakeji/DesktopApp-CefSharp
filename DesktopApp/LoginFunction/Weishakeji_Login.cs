using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesktopApp.LoginFunction
{
    /// <summary>
    /// 微厦科技专用的登录方法
    /// </summary>
    public class Weishakeji_Login : ILogin
    {
        public LoginFunction.Result Access(string name, string pw)
        {
            //主域地址
            string requestUrl = Program.Domain() + DefLoginUrl();
            string appid = Confing.Gatway.Get("APPID");
            /**
             * 	1、示例：http://当前系统的域名/api/sso.ashx?appid=xx&domain=xx&user=xx&action=login|logout&return=xml|json&goto=(url) 
                2、参数说明：
                appid：应用ID
                domain：请求域，请求此调用的来源网站域名,需Url编码
                user：用户账号名
                action：登录还是退出登录（可以为空），默认为login
                return：返回值是xml还是json格式（可以为空），默认为xml格式
                goto：成功后的转向地址（可以为空）,转到首页用/,如果失败将不跳转
             * */
            string query = string.Empty;
            query = getQuery(query, "APPid", appid);
            query = getQuery(query, "action", "verify");
            //请求域,和超管中的单点登录配置项目,要对应
            string domain = Confing.Gatway.Get("RequstDomain"); ; ;
            query = getQuery(query, "domain", System.Web.HttpUtility.UrlEncode(domain.Trim()));
            //账号与密码
            query = getQuery(query, "user", name.Trim());
            //pw= System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pw, "MD5").ToLower();
            query = getQuery(query, "pw", pw);
            requestUrl += "?" + query;
            //获取结果
            try
            {
                string resultXml = Handler.Client.WebResult(requestUrl);
                return new Result(resultXml);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 登录成功后，要主窗体要打开的网页地址
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Gourl(string name)
        {
            //主域地址
            string goUrl = DefLoginUrl();
            string appid = Confing.Gatway.Get("APPID");
            string query = string.Empty;
            query = getQuery(query, "APPid", appid);
            query = getQuery(query, "action", "login");
            //请求域,和超管中的单点登录配置项目,要对应
            string domain = Confing.Gatway.Get("RequstDomain"); ; ;
            query = getQuery(query, "domain", System.Web.HttpUtility.UrlEncode(domain.Trim()));
            //账号
            query = getQuery(query, "user", name.Trim());
            query = getQuery(query, "goto", System.Web.HttpUtility.UrlEncode("/default.ashx"));
            return goUrl + "?" + query;
        }
        #region 私有方法
        /// <summary>
        /// 默认登录接口地址
        /// </summary>
        private string DefLoginUrl()
        {
            string url = Confing.Gatway.GetAPI("ApiLogin");
            if (url.StartsWith("/")) url = url.Substring(1);
            return url;
        }
        /// <summary>
        /// 用于拼接页面的查询字串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string getQuery(string url, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(url)) return key + "=" + value;
            //
            Regex regex = new Regex(@"(?<key>" + key + @")=(?<value>(|.)[^&]*)", RegexOptions.IgnoreCase);
            if (regex.Match(url).Success)
                url = regex.Replace(url, "$2=" + value);
            else
                url += "&" + key + "=" + value;
            return url;
        }
        #endregion
    }
}
