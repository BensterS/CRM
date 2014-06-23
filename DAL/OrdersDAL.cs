using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class OrdersDAL
    {

        /// <summary>
        ///此方法用于添加新的订单 
        /// </summary>
        /// <param name="obj">新的订单对象</param>
        /// <returns></returns>
        public static bool OrderAddNew(Orders obj)
        {
            return DBHelp.ExecuteCUD("insert into orders values(@CusID,getdate())", 
                new List<SqlParameter> { 
                    new SqlParameter("@CusID", obj.CusID)/*, new SqlParameter("@OrderDate", obj.OrderDate) */
                })>0;
        }
    }
}
