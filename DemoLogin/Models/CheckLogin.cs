using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DemoLogin.Models
{
    public class CheckLogin
    {
        public readonly static CheckLogin Instance = new CheckLogin();
        public static DemoLoginBLL.ModelBll.UserBll userbll = new DemoLoginBLL.ModelBll.UserBll();

        /// <summary>
        /// 模拟验证用户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>F:\ceshi\FromCheckDemo\Demo\Models\CheckLogin.cs
        /// <returns></returns>
        public bool Login(string UserName, string PassWord)
        {
            return userbll.Exists(UserName, PassWord);
        }

        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        /// <returns></returns>
        public DemoLoginBean.Models.User GetUser()
        {
            if (HttpContext.Current.Request.IsAuthenticated)//是否通过身份验证
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];//获取cookie
                FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密
                return SerializeHelper.Instance.JsonDeserialize<DemoLoginBean.Models.User>(Ticket.UserData);//反序列化
            }
            return null;
        }
    }
}