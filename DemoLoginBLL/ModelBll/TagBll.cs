using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoginBLL.ModelBll
{
    public  class TagBll
    {
        DemoLoginDAL.Model.Tag tag = new DemoLoginDAL.Model.Tag();
        /// <summary>
        /// 获取单个标签
        /// </summary>
        /// <param name="TitleID"></param>
        /// <returns></returns>
        public DemoLoginBean.Models.Tag GetModel(int TitleID)
        {
            return tag.GetModel(TitleID);
        }
        /// <summary>
        /// 增加标签
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(DemoLoginBean.Models.Tag model)
        {
            //try
            //{
            //    tag.Add(model);
            //    return true;
            //}
            //catch (Exception ee)
            //{
            //    return false;
            //}
            return tag.Add(model);
            
        }
        /// <summary>
        /// 单条删除
        /// </summary>
        /// <param name="TitleID"></param>
        /// <returns></returns>
        public bool Delete(int TitleID)
        {
            return tag.Delete(TitleID);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="TitleIDlist"></param>
        /// <returns></returns>
        public bool DeleteList(string TitleIDlist)
        {
            return tag.DeleteList(TitleIDlist);
        }
        public bool Update(DemoLoginBean.Models.Tag model)
        {
            return tag.Update(model);
        }
    }
}
