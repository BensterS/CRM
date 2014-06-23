using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CustomersDAL
    {
        /// <summary>
        /// 获取客户编号
        /// </summary>
        /// <returns>返回客户编号</returns>
        public static string GetCusID()
        {
            string sql = "pro_CustomerID";
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter para = new SqlParameter("@CustomerID", SqlDbType.VarChar, 20);
            para.Direction = ParameterDirection.Output;

            list.Add(para);
            DBHelp.ExecuteReaderProc(sql, list);
            string customerID = para.Value.ToString();
            return customerID;
        }

        /// <summary>
        /// 此方法用于添加新的客户信息
        /// </summary>
        /// <param name="obj">新的客户对象</param>
        /// <returns></returns>
        public static bool CustomerAddNew(Customers obj){
            List<SqlParameter> list =new List<SqlParameter> {
                new SqlParameter("@CusID",obj.CusID),
                new SqlParameter("@UserID",obj.UserID),
                new SqlParameter("@CusName",obj.CusName),
                new SqlParameter("@CusAddress",""),
                new SqlParameter("@CusZip",""),
                new SqlParameter("@CusFax",""),
                new SqlParameter("@CusWebsite",""),
                new SqlParameter("@CusLicenceNo",""),
                new SqlParameter("@CusChieftain",""),
                //new SqlParameter("@CusBankroll",0),
                //new SqlParameter("@CusTurnover",0),
                new SqlParameter("@CusBank",""),
                new SqlParameter("@CusBankNo",""),
                new SqlParameter("@CusLocalTaxNo",""),
                new SqlParameter("@CusNationalTaxNo",""),
                //new SqlParameter("@CusDate","getdate()"),
                new SqlParameter("@CusState",1)
            };
            string sql = @"insert into Customers values
                                (
                                    @CusID,
                                    @UserID,
                                    @CusName,
                                    @CusAddress, 
                                    @CusZip, 
                                    @CusFax, 
                                    @CusWebsite, 
                                    @CusLicenceNo, 
                                    @CusChieftain, 
                                    0, 
                                    0, 
                                    @CusBank, 
                                    @CusBankNo, 
                                    @CusLocalTaxNo, 
                                    @CusNationalTaxNo, 
                                    getdate(), 
                                    @CusState
                                )";
            return DBHelp.ExecuteCUD(sql, list)>0;
        }

        /// <summary>
        /// 此方法用于修改客户信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool CustomerEdit(Customers obj)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@CusAddress",obj.CusAddress),
                new SqlParameter("@CusZip",obj.CusZip),
                new SqlParameter("@CusFax",obj.CusFax),
                new SqlParameter("@CusWebsite",obj.CusWebsite),
                new SqlParameter("@CusLicenceNo",obj.CusLicenceNo),
                new SqlParameter("@CusChieftain",obj.CusChieftain),
                new SqlParameter("@CusBankroll",obj.CusBankroll),
                new SqlParameter("@CusTurnover",obj.CusTurnover),
                new SqlParameter("@CusBank",obj.CusBank),
                new SqlParameter("@CusBankNo",obj.CusBankNo),
                new SqlParameter("@CusLocalTaxNo",obj.CusLocalTaxNo),
                new SqlParameter("@CusNationalTaxNo",obj.CusNationalTaxNo),
                new SqlParameter("@CusID",obj.CusID)
            };
            string sql = @"update Customers set 
                                                CusAddress=@CusAddress ,
                                                CusZip=@CusZip ,
                                                CusFax=@CusFax ,
                                                CusWebsite=@CusWebsite ,
                                                CusLicenceNo=@CusLicenceNo ,
                                                CusChieftain=@CusChieftain ,
                                                CusBankroll=@CusBankroll ,
                                                CusTurnover=@CusTurnover ,
                                                CusBank=@CusBank ,
                                                CusBankNo=@CusBankNo ,
                                                CusLocalTaxNo=@CusLocalTaxNo ,
                                                CusNationalTaxNo=@CusNationalTaxNo 
                                                where CusID=@CusID ";
            return DBHelp.ExecuteCUD(sql, list) > 0;
        }

        /// <summary>
        /// 此方法用于更改用户状态
        /// </summary>
        /// <param name="CusID"></param>
        /// <returns></returns>
        public static bool CustomChangeState(string CusID)
        {
            return DBHelp.ExecuteCUD("update Customers set CusState=2 where CusID=@CusID", new List<SqlParameter> { new SqlParameter("@CusID", CusID) }) > 0;
        }

        /// <summary>
        /// 此方法用于返回所有的客户编号和姓名
        /// </summary>
        /// <returns></returns>
        public static List<Customers> CustomersFindCusID()
        {
            using(SqlDataReader sdr=DBHelp.ExecuteReader("select cusid,cusname from Customers",null))
            {
                List<Customers> list=new List<Customers> ();
                while(sdr.Read())
                {
                    Customers obj=new Customers ();
                    obj.CusID=sdr["CusID"].ToString();
                    obj.CusName=sdr["CusName"].ToString();
                    list.Add(obj);
                }
                return list;
            }
        }
    }
}
