using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class ViewCustomersBLL
    {
        /// <summary>
        /// 使用分页技术查询所有客户数据
        /// </summary>
        /// <param name="page">参数列集合</param>
        /// <returns>返回查询结果集</returns>
        public static Dictionary<string, object> ViewCustomerFindAll(string tBName, string keyFile, string showFile, string where, string orderBy, int pIndex, int pSize)
        {
            int count = PagingDAL.GetCount(tBName, where);
            int pageCount = count % pSize == 0 ? count / pSize : count / pSize + 1;
            pIndex = pIndex <= 0 ? 1 : pIndex;
            pIndex = pIndex > pageCount ? pageCount : pIndex;
            CommonPage page = new CommonPage(tBName, keyFile, showFile, where, orderBy, pIndex, pSize);

            Dictionary<string, object> dt = new Dictionary<string, object>();
            dt.Add("list", ViewCustomersDAL.ViewCustomerFindAll(page));
            dt.Add("count", count);
            dt.Add("pageCount", pageCount);
            dt.Add("pIndex", pIndex);
            return dt;
        }

        /// <summary>
        /// 根据客户id查询客户信息
        /// </summary>
        /// <param name="cusID"></param>
        /// <returns></returns>
        public static ViewCustomers CustomerFindById(string cusID)
        {
            return ViewCustomersDAL.CustomerFindById(cusID);
        }

        /// <summary>
        /// 此方法用于修改客户信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool CustomerEdit(Customers obj)
        {
            return CustomersBLL.CustomerEdit(obj);
        }
    }
}
