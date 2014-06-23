using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class OrdersBLL
    {
        /// <summary>
        ///此方法用于添加新的订单 
        /// </summary>
        /// <param name="obj">新的订单对象</param>
        /// <returns></returns>
        public static bool OrderAddNew(Orders obj)
        {
            return OrdersDAL.OrderAddNew(obj);
        }
    }
}
