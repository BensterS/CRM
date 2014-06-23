using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;

namespace UI.Service
{
    /// <summary>
    /// CustomerWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class CustomerWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 此方法用于分页查询销售机会
        /// </summary>
        /// <param name="pIndex">当前页</param>
        /// <param name="pSize">每页显示数据</param>
        /// <returns></returns>
        [WebMethod]
        public Dictionary<string, object> CustomersFindAll(string pIndex, string pSize, string cusName, string cusid)
        {
            return ViewCustomersBLL.ViewCustomerFindAll("view_Customers", "CusID", "*", cusName+cusid, "CusID", StringDisposeBLL.StrToInt(pIndex), Convert.ToInt32(pSize));
        }

        /// <summary>
        /// 根据客户id查询客户信息
        /// </summary>
        /// <param name="cusID"></param>
        /// <returns></returns>
        [WebMethod]
        public ViewCustomers CustomerFindById(string cusID)
        {
            return ViewCustomersBLL.CustomerFindById(cusID);
        }

        /// <summary>
        /// 此方法用于修改客户信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [WebMethod]
        public bool CustomerEdit(Customers obj)
        {
            return ViewCustomersBLL.CustomerEdit(obj);
        }
    }
}
