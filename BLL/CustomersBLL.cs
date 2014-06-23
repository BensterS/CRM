using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class CustomersBLL
    {
        /// <summary>
        /// 此方法用于添加新的客户信息
        /// </summary>
        /// <param name="obj">新的客户对象</param>
        /// <returns></returns>
        public static bool CustomerAddNew(Customers obj){
            return CustomersDAL.CustomerAddNew(obj);
        }

        /// <summary>
        /// 获取客户编号
        /// </summary>
        /// <returns>返回客户编号</returns>
        public static string GetCusID()
        {
            return CustomersDAL.GetCusID();
        }

        /// <summary>
        /// 此方法用于修改客户信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool CustomerEdit(Customers obj)
        {
            return CustomersDAL.CustomerEdit(obj);
        }

        /// <summary>
        /// 此方法用于更改用户状态
        /// </summary>
        /// <param name="CusID"></param>
        /// <returns></returns>
        public static bool CustomChangeState(string CusID)
        {
            return CustomersDAL.CustomChangeState(CusID);
        }

        /// <summary>
        /// 此方法用于返回所有的客户编号和姓名
        /// </summary>
        /// <returns></returns>
        public static List<Customers> CustomersFindCusID()
        {
            return CustomersDAL.CustomersFindCusID();
        }
    }
}
