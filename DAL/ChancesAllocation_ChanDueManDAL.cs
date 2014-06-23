using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ChancesAllocation_ChanDueManDAL
    {
        /// <summary>
        /// 此方法用于查询所有的销售机会分配人
        /// </summary>
        /// <returns></returns>
        public static List<ChancesAllocation_ChanDueMan> ChancesAllocation_ChanDueManDALFindAll()
        {
            using (SqlDataReader sdr = DBHelp.ExecuteReader("select * from ChancesAllocation_ChanDueMan", null))
            {
                List<ChancesAllocation_ChanDueMan> list = list = new List<ChancesAllocation_ChanDueMan>();
                while(sdr.Read())
                {
                    ChancesAllocation_ChanDueMan obj = new ChancesAllocation_ChanDueMan();
                    obj.ChanDueMan = StringDisposeDAL.StrToInt(sdr["ChanDueMan"] != null ? sdr["ChanDueMan"].ToString() : "0");
                    obj.UserName = sdr["UserName"].ToString();
                    list.Add(obj);
                }
                return list;
            }
        }
    }
}
