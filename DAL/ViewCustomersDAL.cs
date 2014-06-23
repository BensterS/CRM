using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ViewCustomersDAL
    {
        /// <summary>
        /// 使用分页技术查询所有客户信息
        /// </summary>
        /// <param name="page">参数列集合</param>
        /// <returns>返回查询结果集</returns>
        public static List<ViewCustomers> ViewCustomerFindAll(CommonPage page)
        {
            List<ViewCustomers> list = new List<ViewCustomers>();

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
            try
            {
                using (SqlDataReader sdr = DBHelp.ExecuteReaderProc(sql, paras))
                {
                    while (sdr.Read())
                    {
                        ViewCustomers obj = new ViewCustomers();
                        obj.CusID = sdr["CusID"].ToString();
                        obj.UserID = Convert.ToInt32(sdr["UserID"].ToString());
                        obj.CusName = sdr["CusName"].ToString();
                        obj.UserName = sdr["UserName"].ToString();
                        obj.CusDate = sdr["CusDate"].ToString();
                        obj.CusAddress = sdr["CusAddress"].ToString();
                        obj.CusZip = sdr["CusZip"].ToString();
                        obj.CusFax = sdr["CusFax"].ToString();
                        obj.CusWebsite = sdr["CusWebsite"].ToString();
                        obj.CusLicenceNo = sdr["CusLicenceNo"].ToString();
                        obj.CusChieftain = sdr["CusChieftain"].ToString();
                        obj.CusBankroll = Convert.ToInt32(sdr["CusBankroll"].ToString());
                        obj.CusTurnover = Convert.ToInt32(sdr["CusTurnover"].ToString());
                        obj.CusLocalTaxNo = sdr["CusLocalTaxNo"].ToString();
                        obj.CusBank = sdr["CusBank"].ToString();
                        obj.CusBankNo = sdr["CusBankNo"].ToString();
                        obj.CusLocalTaxNo = sdr["CusLocalTaxNo"].ToString();
                        obj.CusNationalTaxNo = sdr["CusNationalTaxNo"].ToString();
                        obj.CusState = Convert.ToInt32(sdr["CusState"].ToString());
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

        /// <summary>
        /// 根据客户id查询客户信息
        /// </summary>
        /// <param name="cusID"></param>
        /// <returns></returns>
        public static ViewCustomers CustomerFindById(string cusID)
        {
            using (SqlDataReader sdr = DBHelp.ExecuteReader("select * from view_Customers where cusid=@CusID", new List<SqlParameter> { new SqlParameter("@CusID",cusID)}))
            {
                ViewCustomers obj = null;
                if (sdr.Read())
                {
                    obj = new ViewCustomers();
                    obj.CusID = sdr["CusID"].ToString();
                    obj.UserID = Convert.ToInt32(sdr["UserID"].ToString());
                    obj.CusName = sdr["CusName"].ToString();
                    obj.UserName = sdr["UserName"].ToString();
                    obj.CusDate = sdr["CusDate"].ToString();
                    obj.CusAddress = sdr["CusAddress"].ToString();
                    obj.CusZip = sdr["CusZip"].ToString();
                    obj.CusFax = sdr["CusFax"].ToString();
                    obj.CusWebsite = sdr["CusWebsite"].ToString();
                    obj.CusLicenceNo = sdr["CusLicenceNo"].ToString();
                    obj.CusChieftain = sdr["CusChieftain"].ToString();
                    obj.CusBankroll = Convert.ToInt32(sdr["CusBankroll"].ToString());
                    obj.CusTurnover = Convert.ToInt32(sdr["CusTurnover"].ToString());
                    obj.CusLocalTaxNo = sdr["CusLocalTaxNo"].ToString();
                    obj.CusBank = sdr["CusBank"].ToString();
                    obj.CusBankNo = sdr["CusBankNo"].ToString();
                    obj.CusLocalTaxNo = sdr["CusLocalTaxNo"].ToString();
                    obj.CusNationalTaxNo = sdr["CusNationalTaxNo"].ToString();
                    obj.CusState = Convert.ToInt32(sdr["CusState"].ToString());
                }
                return obj;
            }
        }


    }
}
