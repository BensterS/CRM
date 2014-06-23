using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class ViewCustomServicesBLL
    {
        /// <summary>
        /// 调用存储过程查询出服务分配模块需要显示的相关信息
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static List<ViewCustomServices> GetAll(CommonPage page)
        {
            return ViewCustomServicesDAL.GetAll(page);
        }

        /// <summary>
        /// 查询总记录数
        /// </summary>
        /// <param name="Types"></param>
        /// <returns></returns>
        public static int GetCount(string Types)
        {
            return ViewCustomServicesDAL.GetCount(Types);
        }

        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ViewCustomServices SelectById(string id)
        {
            return ViewCustomServicesDAL.SelectById(id);
        }

        /// <summary>
        /// 此方法用于返回所有的客户编号和姓名
        /// </summary>
        /// <returns></returns>
        public static List<Customers> CustomersFindCusID()
        {
            return CustomersBLL.CustomersFindCusID();
        }

        //创建一个服务
        public static int Insert(CustomServices c)
        {
            return CustomServicesBLL.Insert(c);
        }
    }
}
