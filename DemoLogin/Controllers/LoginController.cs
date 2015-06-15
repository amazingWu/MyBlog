using DemoLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoLogin.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string PassWord)
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(PassWord))
            {
                if (CheckLogin.Instance.Login(UserName, PassWord))
                {
                    DemoLoginBean.Models.User ModelUser = CheckLogin.userbll.GetModel(UserName, PassWord);

                    string UserData = SerializeHelper.Instance.JsonSerialize<DemoLoginBean.Models.User>(ModelUser);//序列化用户实体
                    //保存身份信息
                    FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, UserName, DateTime.Now, DateTime.Now.AddDays(2), false, UserData);
                    HttpCookie Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(Ticket));//加密身份信息，保存至Cookie
                    Response.Cookies.Add(Cookie);
                    return RedirectToAction("Manage","Title");
                }
                else
                {
                    return Content("<script type='text/javascript'>alert('用户名或密码错误，请重新填写！');history.go(-1);</script>");

                }
            }
            return Content("<script type='text/javascript'>alert('用户名或密码不能为空，请重新填写！');history.go(-1);</script>");
        }
        //注销登录
        public ActionResult OutLogin()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}
