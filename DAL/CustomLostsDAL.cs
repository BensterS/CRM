using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class CustomLostsDAL
    {
        /// <summary>
        /// 此方法用于成功流失
        /// </summary>
        /// <param name="clID"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static bool CustomLostsSuccess(int clID, string Content)
        {
            return DBHelp.ExecuteCUD("update customLosts set CLEnterDate=getdate(),CLReason=@CLReason,clstate=3 where clid=@clid",
                                        new List<SqlParameter>
                                        {
                                            new SqlParameter("@CLReason",Content),
                                            new SqlParameter("@clid",clID)
                                        }
                )>0;
        }

        public static string CustomLostsFindCusID(int clid)
        {
            return DBHelp.ExecuteSingle("select cusid from CustomLosts where clid=@clid", new List<SqlParameter> { new SqlParameter("@clid", clid) }).ToString();
        }
    }
}
