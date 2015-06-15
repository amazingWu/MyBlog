using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoLogin.Models
{
    [Serializable]
    public class Users
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登录帐号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public string Roles { get; set; }
    }
}