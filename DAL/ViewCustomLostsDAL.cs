using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class ViewCustomLostsDAL
    {
        /// <summary>
        /// 使用分页技术查询所有客户流失信息
        /// </summary>
        /// <param name="page">参数列集合</param>
        /// <returns>返回查询结果集</returns>
        public static List<ViewCustomLosts> VCLFindAll(CommonPage page)
        {
            List<ViewCustomLosts> list = new List<ViewCustomLosts>();

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
                using (SqlDataReader sdr = DBHelp.ExecuteReaderProc(sql, paras))
                {
                    while (sdr.Read())
                    {
                        ViewCustomLosts obj = new ViewCustomLosts();
                        obj.CLID = Convert.ToInt32(sdr["CLID"].ToString());
                        obj.CusID = sdr["CusID"].ToString();
                        obj.CLOrderDate = sdr["CLOrderDate"].ToString();
                        obj.CLDate = sdr["CLDate"].ToString();
                        obj.CLEnterDate = sdr["CLEnterDate"].ToString();
                        obj.CLReason = sdr["CLReason"].ToString();
                        obj.CLState = Convert.ToInt32(sdr["CLState"].ToString());
                        obj.CusName = sdr["CusName"].ToString();
                        list.Add(obj);
                    }
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static List<>
    }
}
