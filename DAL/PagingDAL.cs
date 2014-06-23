using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class PagingDAL
    {
        /// <summary>
        /// 此方法用于查询该表格的总数居条数
        /// </summary>
        /// <param name="tBName">要查询的表格名</param>
        /// <param name="where">条件</param>
        /// <returns>总条数</returns>
        public static int GetCount(string tBName,string where) 
        {
            string sql = "select count(*) from "+tBName+" where 1=1 "+where;
            List<SqlParameter> list = new List<SqlParameter> 
            {
                new SqlParameter("@tbName",tBName),
                new SqlParameter("@where",where)
            };
            return Convert.ToInt32(DBHelp.ExecuteSingle(sql, list));
        }
    }
}
