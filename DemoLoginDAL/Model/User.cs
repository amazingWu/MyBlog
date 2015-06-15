using DemoLoginDAL.DbHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLoginBean.Models;
using System.Data.SqlClient;

namespace DemoLoginDAL.Model
{
    public partial class User
    {
        public User()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSql.GetMaxID("ID", "User"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSql.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 根据账户名和密码进行判断是否存在
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Exists(string account,string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where Account=@Account and PassWord=@Password");
            SqlParameter[] parameters = {
					new SqlParameter("@Account", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
			};
            parameters[0].Value = account;
            parameters[1].Value = password;
            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DemoLoginBean.Models.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User(");
			strSql.Append("Name,Account,Password,Role)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Account,@Password,@Role)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Account", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@Role", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Account;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.Role;

			object obj = DbHelperSql.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(DemoLoginBean.Models.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Account=@Account,");
			strSql.Append("Password=@Password,");
			strSql.Append("Role=@Role");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Account", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@Role", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Account;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.Role;
			parameters[4].Value = model.ID;

			int rows=DbHelperSql.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSql.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSql.ExecuteSql(strSql.ToString());
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
		public DemoLoginBean.Models.User GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,Account,Password,Role from Users ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			DemoLoginBean.Models.User model=new DemoLoginBean.Models.User();
			DataSet ds=DbHelperSql.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public DemoLoginBean.Models.User GetModel(string account,string password)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Account,Password,Role from Users ");
            strSql.Append(" where Account=@Account and PassWord=@Password");
            SqlParameter[] parameters = {
					new SqlParameter("@Account", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
			};
            parameters[0].Value = account;
            parameters[1].Value = password;
            DemoLoginBean.Models.User model = new DemoLoginBean.Models.User();
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
		public DemoLoginBean.Models.User DataRowToModel(DataRow row)
		{
			DemoLoginBean.Models.User model=new DemoLoginBean.Models.User();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Account"]!=null)
				{
					model.Account=row["Account"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["Role"]!=null && row["Role"].ToString()!="")
				{
					model.Role=int.Parse(row["Role"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name,Account,Password,Role ");
			strSql.Append(" from Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSql.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,Name,Account,Password,Role ");
			strSql.Append(" from Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSql.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Users T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSql.Query(strSql.ToString());
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
