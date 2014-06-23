using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;

namespace UI.Service
{
    /// <summary>
    /// ViewCustomLostsWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ViewCustomLostsWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 此方法用于分页查询客户报警信息
        /// </summary>
        /// <param name="pIndex">当前页</param>
        /// <param name="pSize">每页显示数据</param>
        /// <returns></returns>
        [WebMethod]
        public Dictionary<string, object> CustomLostsFinAll(string pIndex, string pSize)
        {
            return ViewCustomLostsBLL.VCLFindAll("view_CustomLosts", "CLID", "*", "", " CLDate desc ", StringDisposeBLL.StrToInt(pIndex), Convert.ToInt32(pSize));
        }

        /// <summary>
        /// 此方法用于根据流失用户id查询流失措施
        /// </summary>
        /// <param name="clID"></param>
        /// <returns></returns>
        [WebMethod]
        public List<Measures> MeasursFindByCLID(int clID)
        {
            return ViewCustomLostsBLL.MeasursFindByCLID(clID);
        }

        /// <summary>
        /// 此方法用于添加流失措施
        /// </summary>
        /// <param name="clID"></param>
        /// <param name="mDesc"></param>
        /// <returns></returns>
        [WebMethod]
        public bool MeasuresAddNew(int clID, string mDesc)
        {
            return ViewCustomLostsBLL.MeasuresAddNew(clID, mDesc);
        }

        /// <summary>
        /// 此方法用于客户流失成功
        /// </summary>
        /// <param name="clid"></param>
        /// <param name="clReason"></param>
        /// <returns></returns>
        [WebMethod]
        public bool CustomLostsSuccess(int clid ,string clReason)
        {
            return CustomLostsBLL.CustomLostsSuccess(clid,clReason);
        }
    }
}
