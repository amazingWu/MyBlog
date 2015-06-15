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
    public partial class Tag
    {
        public Tag()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSql.GetMaxID("ID", "Tag"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tags");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSql.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DemoLoginBean.Models.Tag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tags(");
			strSql.Append("Tag1,Tag2,Tag3,Tag4,Tag5,TitleID)");
			strSql.Append(" values (");
			strSql.Append("@Tag1,@Tag2,@Tag3,@Tag4,@Tag5,@TitleID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Tag1", SqlDbType.VarChar,50),
					new SqlParameter("@Tag2", SqlDbType.VarChar,50),
					new SqlParameter("@Tag3", SqlDbType.VarChar,50),
					new SqlParameter("@Tag4", SqlDbType.VarChar,50),
					new SqlParameter("@Tag5", SqlDbType.VarChar,50),
					new SqlParameter("@TitleID", SqlDbType.Int,4)};
			parameters[0].Value = model.Tag1;
			parameters[1].Value = model.Tag2;
			parameters[2].Value = model.Tag3;
			parameters[3].Value = model.Tag4;
			parameters[4].Value = model.Tag5;
			parameters[5].Value = model.TitleID;

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
		public bool Update(DemoLoginBean.Models.Tag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Tags set ");
			strSql.Append("Tag1=@Tag1,");
			strSql.Append("Tag2=@Tag2,");
			strSql.Append("Tag3=@Tag3,");
			strSql.Append("Tag4=@Tag4,");
            strSql.Append("Tag5=@Tag5 where TitleID=@TitleID");
            SqlParameter[] parameters = {
					new SqlParameter("@Tag1", SqlDbType.VarChar,50),
					new SqlParameter("@Tag2", SqlDbType.VarChar,50),
					new SqlParameter("@Tag3", SqlDbType.VarChar,50),
					new SqlParameter("@Tag4", SqlDbType.VarChar,50),
					new SqlParameter("@Tag5", SqlDbType.VarChar,50),
					new SqlParameter("@TitleID", SqlDbType.Int,4)};
			parameters[0].Value = model.Tag1;
			parameters[1].Value = model.Tag2;
			parameters[2].Value = model.Tag3;
			parameters[3].Value = model.Tag4;
			parameters[4].Value = model.Tag5;
			parameters[5].Value = model.TitleID;

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
		public bool Delete(int TitleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tags ");
            strSql.Append(" where TitleID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = TitleID;

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
		public bool DeleteList(string TitleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tags ");
            strSql.Append(" where TitleID in (" + TitleIDlist + ")");
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
        public DemoLoginBean.Models.Tag GetModel(int TitleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Tag1,Tag2,Tag3,Tag4,Tag5,TitleID from Tags");
            strSql.Append(" where TitleID=@TitleID");
			SqlParameter[] parameters = {
					new SqlParameter("@TitleID", SqlDbType.Int,4)
			};
            parameters[0].Value = TitleID;

			DemoLoginBean.Models.Tag model=new DemoLoginBean.Models.Tag();
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
		public DemoLoginBean.Models.Tag DataRowToModel(DataRow row)
		{
			DemoLoginBean.Models.Tag model=new DemoLoginBean.Models.Tag();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Tag1"]!=null)
				{
					model.Tag1=row["Tag1"].ToString();
				}
				if(row["Tag2"]!=null)
				{
					model.Tag2=row["Tag2"].ToString();
				}
				if(row["Tag3"]!=null)
				{
					model.Tag3=row["Tag3"].ToString();
				}
				if(row["Tag4"]!=null)
				{
					model.Tag4=row["Tag4"].ToString();
				}
				if(row["Tag5"]!=null)
				{
					model.Tag5=row["Tag5"].ToString();
				}
				if(row["TitleID"]!=null && row["TitleID"].ToString()!="")
				{
					model.TitleID=int.Parse(row["TitleID"].ToString());
				}
			}
			return model;
		}


		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tags ");
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


		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
