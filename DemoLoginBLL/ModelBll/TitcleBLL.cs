using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoginBLL.ModelBll
{
    public class TitcleBLL
    {
        DemoLoginDAL.Model.Title title = new DemoLoginDAL.Model.Title();
        public List<DemoLoginBean.Models.Title> GetListByPageAiticle(string strWhere, string orderby, int startIndex, int endIndex)
        {
            List<DemoLoginBean.Models.Title> array = new List<DemoLoginBean.Models.Title>();
            DataSet ds = title.GetListByPageAiticle(strWhere, orderby, startIndex, endIndex);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DemoLoginBean.Models.Title _title = title.DataRowToModel(dr);
                array.Add(_title);
            }
            return array;
        }
        public int Add(DemoLoginBean.Models.Title model)
        {
             return title.Add(model);

        }
        public DemoLoginBean.Models.Title GetModel(int ID)
        {
            return title.GetModel(ID);
        }
        public int GetRecordCount(string strWhere)
        {
            return title.GetRecordCount(strWhere);
        }
        //删除
        public bool Delete(int ID)
        {
            return title.Delete(ID);
        }
        //批量删除
        public bool DeleteList(string IDlist)
        {
            return title.DeleteList(IDlist);
        }

        public bool Update(DemoLoginBean.Models.Title model)
        {
            return title.Update(model);
        }
    }
}
