using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class PlansDAL
    {
        /// <summary>
        /// 此方法用于添加开发计划
        /// </summary>
        /// <param name="chanId">销售机会id</param>
        /// <param name="planContent">开发计划</param>
        /// <returns></returns>
        public static int PlansAddNew(int chanId, string planContent)
        { 
            string sql=@"insert into Plans values('GUID'+convert(varchar(8),getdate(),112)+	case when len(datename(hh,getdate()))=1 then '0'+datename(hh,getdate()) else datename(hh,getdate()) end
																 +	case when len(datename(mi,getdate()))=1 then '0'+datename(mi,getdate()) else datename(mi,getdate()) end
																 +	case when len(datename(ss,getdate()))=1 then '0'+datename(ss,getdate()) else datename(ss,getdate()) end
																 +	case when len(datename(ms,getdate()))=1 then '00'+datename(ms,getdate()) when len(datename(ms,getdate()))=2 then '0'+datename(ms,getdate()) else datename(ms,getdate()) end
						,@chanId,getdate(),@planContent,null,'')";
            return DBHelp.ExecuteCUD(sql, new List<SqlParameter> { new SqlParameter("@chanId", chanId), new SqlParameter("@planContent", planContent) });
        }

        /// <summary>
        /// 此方法用于添加执行计划
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="planResultContent"></param>
        /// <returns></returns>
        public static int PlanResultAddNew(string planId, string planResultContent)
        {
            string sql = "update plans set PlanResultDate=getdate(),PlanResult=@PlanResult where planid=@planid";
            return DBHelp.ExecuteCUD(sql, new List<SqlParameter> { new SqlParameter("@PlanResult", planResultContent), new SqlParameter("@planid", planId) });
        }

        /// <summary>
        /// 此方法用于根据id查询客户开发计划信息
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public static List<Model.Plans> PlanFindByID(int chanid)
        {
            string sql = "select * from plans where chanid=@chanid";
            using (SqlDataReader sdr = DBHelp.ExecuteReader(sql, new List<SqlParameter> { new SqlParameter("@chanid", chanid) }))
            {
                List<Model.Plans> list = new List<Model.Plans>();
                while (sdr.Read())
                {
                    Model.Plans obj = new Model.Plans();
                    obj.PlanID=sdr["PlanID"].ToString();
                    obj.ChanID=Convert.ToInt32(sdr["ChanID"].ToString());
                    obj.PlanDate=sdr["PlanDate"].ToString();
                    obj.PlanContent=sdr["PlanContent"].ToString();
                    if (sdr["PlanResultDate"] == null)
                    {
                        return null;
                    }
                    obj.PlanResultDate = sdr["PlanResultDate"].ToString();
                    obj.PlanResult=sdr["PlanResult"].ToString();
                    list.Add(obj);
                }
                return list;
            }
        }
    }
}
