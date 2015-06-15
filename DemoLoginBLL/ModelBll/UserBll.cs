using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoginBLL.ModelBll
{
    public class UserBll
    {
        DemoLoginDAL.Model.User user = new DemoLoginDAL.Model.User();
        public bool Exists(int ID)
        {
            return user.Exists(ID);
        }
        public bool Exists(string account,string password)
        {
            return user.Exists(account,password);
        }
        public DemoLoginBean.Models.User GetModel(string account, string password)
        {
            return user.GetModel(account,password);
        }
    }
}
