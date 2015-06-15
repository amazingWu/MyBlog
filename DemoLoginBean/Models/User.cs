using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoginBean.Models
{
    [Serializable]
    public partial class User
    {
        public User()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _account;
        private string _password;
        private int _role;
        /// <summary>
        /// 标示字段
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 账户名
        /// </summary>
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 角色分类
        /// </summary>
        public int Role
        {
            set { _role = value; }
            get { return _role; }
        }
        #endregion Model

    }
}
