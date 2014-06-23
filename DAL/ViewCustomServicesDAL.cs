using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ViewCustomServicesDAL
    {
        /// <summary>
        /// 调用存储过程查询出服务分配模块需要显示的相关信息
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static List<ViewCustomServices> GetAll(CommonPage page)
        {
            List<ViewCustomServices> list = new List<ViewCustomServices>();

            string sql = "PagingProc";
            List<SqlParameter> paras = new List<SqlParameter>()
            {
                new SqlParameter("@TbName",page.TbName),
                new SqlParameter("@KeyFile",page.KeyFile),
                new SqlParameter("@ShowFile",page.ShowFile),
                new SqlParameter("@Where",page.Where),
                new SqlParameter("@OrderBy",page.OrderBy),
                new SqlParameter("@PIndex",page.PIndex),
                new SqlParameter("@PSize",page.PSize)
            };
            try
            {
                using (SqlDataReader sr = DBHelp.ExecuteReaderProc(sql, paras))
                {
                    while (sr.Read()) {
                        ViewCustomServices u = new ViewCustomServices();
                        u.CSID = Convert.ToInt32(sr["CSID"].ToString());
                        u.CSCreateDate = sr["CSCreateDate"].ToString();
                        u.CSTitle = sr["CSTitle"].ToString();
                        u.CusName = sr["CusName"].ToString();
                        u.STName = sr["STName"].ToString();
                        u.UserName = sr["UserName"].ToString();
                        u.STID = Convert.ToInt32(sr["STID"].ToString());
                        u.CusID = sr["CusID"].ToString();
                        u.CSState = Convert.ToInt32(sr["CSState"].ToString());
                        u.CSDesc = sr["CSDesc"].ToString();
                        u.CSCreateID = Convert.ToInt32(sr["CSCreateID"]);
                        if (sr["CSDueID"] != null)
                        {
                            u.CSDueID = Convert.ToInt32(sr["CSDueID"]);
                        }
                        if (sr["CSDueDate"] != null)
                        {
                            u.CSDueDate = sr["CSDueDate"].ToString();
                        }
                        if (sr["CSDeal"] != null)
                        {
                            u.CSDeal = sr["CSDeal"].ToString();
                        }
                        if (sr["CSDealDate"] != null)
                        {
                            u.CSDealDate = sr["CSDealDate"].ToString();
                        }
                        if (sr["CSResult"] != null)
                        {
                            u.CSResult = sr["CSResult"].ToString();
                        }
                        if (sr["CSSatisfy"] != null)
                        {
                            u.CSSatisfy = StringDisposeDAL.StrToInt(sr["CSSatisfy"].ToString());
                        }
                        list.Add(u);
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询总记录数
        /// </summary>
        /// <param name="Types"></param>
        /// <returns></returns>
        public static int GetCount(string Types) {
            string sql = "select count(*) from ViewCustomServices where 1=1 ";
            if (Types == "处理")
            {
                sql += " and CSDueID in (select CSDueID from CustomServices)";
            }else if (Types == "反馈")
            {
                sql += " and CSDealDate>0";
            }
            else if (Types == "分配") {
                sql += " and 1=1 ";
            }
            else
            {
                sql += " and CSState=4 " + Types;
            }
            return Convert.ToInt32(DBHelp.ExecuteSingle(sql,null));
        }

        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ViewCustomServices SelectById(string id)
        {
            ViewCustomServices u = null;
            string sql = "select * from ViewCustomServices where CSID=@CSID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@CSID",id));
            using (SqlDataReader sr = DBHelp.ExecuteReader(sql, list)) {
                if (sr.Read())
                {
                    u = new ViewCustomServices();
                    u.CSID = Convert.ToInt32(sr["CSID"]);
                    u.CSCreateDate = sr["CSCreateDate"].ToString();
                    u.CSTitle = sr["CSTitle"].ToString();
                    u.CusName = sr["CusName"].ToString();
                    u.STName = sr["STName"].ToString();
                    u.UserName = sr["UserName"].ToString();
                    u.STID = Convert.ToInt32(sr["STID"]);
                    u.CusID = sr["CusID"].ToString();
                    u.CSState = Convert.ToInt32(sr["CSState"]);
                    u.CSDesc = sr["CSDesc"].ToString();
                    u.CSCreateID = Convert.ToInt32(sr["CSCreateID"]);
                    u.CSDueID = Convert.ToInt32(sr["CSDueID"]);
                    u.CSDueDate = sr["CSDueDate"].ToString();
                    if (sr["CSDeal"].ToString() != "")
                    {
                        u.CSDeal = sr["CSDeal"].ToString();
                    }
                    if (sr["CSDealDate"].ToString() != "")
                    {
                        u.CSDealDate = sr["CSDealDate"].ToString();
                    }
                    if (sr["CSResult"].ToString() != "")
                    {
                        u.CSResult = sr["CSResult"].ToString();
                    }
                    if (sr["CSSatisfy"].ToString() != "")
                    {
                        u.CSSatisfy = Convert.ToInt32(sr["CSSatisfy"]);
                    }
                }
            }
            return u;
        }
    }
}
