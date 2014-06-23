using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class ViewPlansDAL
    {
        /// <summary>
        /// 此方法返回所有的开发计划
        /// </summary>
        /// <returns>List<Plans></returns>
        public static List<ViewPlans> PlansFindAll(CommonPage page)
        {
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
            List<ViewPlans> list = new List<ViewPlans>();
            try
            {
                using (SqlDataReader sdr = DBHelp.ExecuteReaderProc(sql, paras))
                {
                    while (sdr.Read())
                    {
                        ViewPlans obj = new ViewPlans
                        (
                            sdr["PlanID"].ToString(),
                            Convert.ToInt32(sdr["ChanID"].ToString()),
                            sdr["PlanDate"].ToString(),
                            sdr["PlanContent"].ToString(),
                            sdr["PlanResultDate"]!=null?sdr["PlanResultDate"].ToString():"",
                            sdr["PlanResult"].ToString(),
                            sdr["chanError"].ToString(),
                            Convert.ToInt32(sdr["ChanState"].ToString())
                        );
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
