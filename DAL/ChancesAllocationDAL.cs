using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class ChancesAllocationDAL
    {
        /// <summary>
        /// 使用分页技术查询所有数据
        /// </summary>
        /// <param name="page">参数列集合</param>
        /// <returns>返回查询结果集</returns>
        public static List<ChancesAllocation> ChancesAllocationFindAll(CommonPage page)
        {
            List<ChancesAllocation> list = new List<ChancesAllocation>();

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
                        ChancesAllocation obj = new ChancesAllocation();
                        obj.ChanID = Convert.ToInt32(sdr["chanID"].ToString());
                        obj.ChanName = sdr["chanName"].ToString();
                        obj.ChanLinkMan = sdr["ChanLinkMan"].ToString();
                        obj.ChanLinkTel = sdr["ChanLinkTel"].ToString();
                        obj.ChanTitle = sdr["ChanTitle"].ToString();
                        obj.ChanCreateDate = sdr["ChanCreateDate"] != null ? sdr["ChanCreateDate"].ToString() : "";
                        obj.ChanDueMan = StringDisposeDAL.StrToInt(sdr["ChanDueMan"] != null ? sdr["ChanDueMan"].ToString() : "0");
                        obj.UserName = sdr["UserName"].ToString();
                        obj.ChanState = Convert.ToInt32(sdr["ChanState"].ToString());
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
    }
}
