using DemoLoginDAL.DbHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoginDAL.Model
{
    public partial class Title
    {
        public Title()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSql.GetMaxID("ID", "Titles");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Titles");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DemoLoginBean.Models.Title model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Titles(");
            strSql.Append("tName,tTime,tUserID,tContent)");
            strSql.Append(" values (");
            strSql.Append("@tName,@tTime,@tUserID,@tContent)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@tName", SqlDbType.VarChar,100),
					new SqlParameter("@tTime", SqlDbType.DateTime),
					new SqlParameter("@tUserID", SqlDbType.Int,4),
					new SqlParameter("@tContent", SqlDbType.Text)};
            parameters[0].Value = model.tName;
            parameters[1].Value = model.tTime;
            parameters[2].Value = model.tUserID;
            parameters[3].Value = model.tContent;

            object obj = DbHelperSql.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DemoLoginBean.Models.Title model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Titles set ");
            strSql.Append("tName=@tName,");
            strSql.Append("tTime=@tTime,");
           // strSql.Append("tUserID=@tUserID,");
            strSql.Append("tContent=@tContent");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@tName", SqlDbType.VarChar,100),
					new SqlParameter("@tTime", SqlDbType.DateTime),
			//		new SqlParameter("@tUserID", SqlDbType.Int,4),
					new SqlParameter("@tContent", SqlDbType.Text),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.tName;
            parameters[1].Value = model.tTime;
         //   parameters[2].Value = model.tUserID;
            parameters[2].Value = model.tContent;
            parameters[3].Value = model.ID;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Titles ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Titles where ID in ("+IDlist+")");//DELETE FROM TestTable WHERE ID IN (1, 3, 54, 68)  --sql2008下运行通过
            int rows = DbHelperSql.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DemoLoginBean.Models.Title GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  top 1 T.ID,T.tName,T.tTime,T.tUserID,T.tContent,U.Name as uName from Titles as T,Users as U");
            strSql.Append(" where T.ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DemoLoginBean.Models.Title model = new DemoLoginBean.Models.Title();
            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DemoLoginBean.Models.Title DataRowToModel(DataRow row)
        {
            DemoLoginBean.Models.Title model = new DemoLoginBean.Models.Title();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["tName"] != null)
                {
                    model.tName = row["tName"].ToString();
                }
                if (row["tTime"] != null && row["tTime"].ToString() != "")
                {
                    model.tTime = DateTime.Parse(row["tTime"].ToString());
                }
                if (row["tUserID"] != null && row["tUserID"].ToString() != "")
                {
                    model.tUserID = int.Parse(row["tUserID"].ToString());
                }
                if (row["tContent"] != null)
                {
                    model.tContent = row["tContent"].ToString();
                }
                if (row["uName"] != null)
                {
                    model.uName = row["uName"].ToString();
                }
                
            }
            return model;
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Titles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSql.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPageAiticle(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            if (string.IsNullOrEmpty(orderby))
            {
                orderby = "desc";
            }
            strSql.AppendFormat(@"select t.ID,t.tName,t.tTime,t.tContent,t.tUserID,u.Name as uName from Users AS u,
                                                        (
                                                        SELECT * FROM
                                                        (
                                                        SELECT ROW_NUMBER()OVER(order by T.tTime {0})AS Row,T.* from Titles T
                                                        )TT WHERE TT.Row between {1} and {2}
                                                        )AS t 
                                                        where t.tUserID=u.ID", orderby, startIndex, endIndex);
            return DbHelperSql.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}
