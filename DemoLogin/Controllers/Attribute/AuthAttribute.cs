using DemoLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoLogin.Controllers.Attribute
{
    public class AuthAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 验证权限（action执行前会先执行这里）
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //如果存在身份信息
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ContentResult Content = new ContentResult();
                var uri="/Login/Login";
                Content.Content = string.Format("<script type='text/javascript'>alert('请先登录！');window.location.href='{0}';</script>", uri);
                filterContext.Result = Content;
            }
            else
            {
               
               if (Code < CheckLogin.Instance.GetUser().Role)//验证权限
                {
                    //验证不通过
                    ContentResult Content = new ContentResult();
                    Content.Content = "<script type='text/javascript'>alert('对不起,您没有此权限！');history.go(-1);</script>";
                    filterContext.Result = Content;
                }
            }

        }
    }
}