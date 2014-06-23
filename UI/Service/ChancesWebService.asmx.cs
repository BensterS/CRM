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
    /// ChancesWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ChancesWebService : System.Web.Services.WebService
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
        public Dictionary<string, object> ChancesFindAll(string pIndex, string pSize)
        {
            return ChancesBLL.ChancesFindAll("chances", "chanID", "*", "", "chanID", StringDisposeBLL.StrToInt(pIndex), Convert.ToInt32(pSize));
        }

        /// <summary>
        /// 此方法用于根据id删除销售机会
        /// </summary>
        /// <param name="ChanID"></param>
        /// <returns></returns>
        [WebMethod]
        public int ChancesDel(int ChanID)
        {
            return ChancesBLL.ChancesDel(ChanID) ? 1 : 0;
        }

        /// <summary>
        /// 此方法用于根据id查询销售机会
        /// </summary>
        /// <param name="chanId"></param>
        /// <returns></returns>
        [WebMethod]
        public Chances ChancesFindById(int chanId)
        {
            return ChancesBLL.ChanFindById(chanId);
        }

        /// <summary>
        /// 此方法用于添加销售机会
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [WebMethod (enableSession:true)]
        public int ChancesAddNew(Chances obj)
        {
            object userid = Session["UserID"];
            obj.ChanCreateMan=Convert.ToInt32(userid);
            return ChancesBLL.ChanAddNew(obj);
        }

        /// <summary>
        /// 此方法用于修改销售机会
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [WebMethod]
        public int ChancesEdit(Chances obj)
        {
            return ChancesBLL.ChancesEdit(obj);
        }

        /// <summary>
        /// 此方法用于分页查询销售机会(销售机会分配)
        /// </summary>
        /// <param name="pIndex">当前页</param>
        /// <param name="pSize">每页显示数据</param>
        /// <returns></returns>
        [WebMethod (EnableSession=true)]
        public Dictionary<string, object> ChancesAllocationFindAll(string pIndex, string pSize)
        {
            Dictionary<string, object> dt = ChancesAllocationBLL.ChancesAllocationFindAll("ChancesAllocation", "chanID", "*", " and ChanState not in(3, 4) ", "chanID", StringDisposeBLL.StrToInt(pIndex), Convert.ToInt32(pSize));
            dt.Add("roleId", Session["RoleID"].ToString());
            return dt;
        }

        /// <summary>
        /// 此方法用于修改销售机会分配人
        /// </summary>
        /// <param name="chanId"></param>
        /// <param name="chanDueMan"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ChancesAllocationEdit(int chanId, int chanDueMan)
        {
            return ChancesAllocationBLL.ChancesDueManUpdate(chanId, chanDueMan);
        }

        /// <summary>
        /// 此方法用于分页查询销售机会
        /// </summary>
        /// <param name="chanName">客户名</param>
        /// <param name="chanLinkName">联系人</param>
        /// <param name="chanCreateName">创建人</param>
        /// <param name="chanDueName">分配人</param>
        /// <returns></returns>
        [WebMethod (EnableSession = true)]
        public Dictionary<string, object> ChancesQuery(string chanName, string chanLinkName, string chanCreateName, string chanDueName)
        {
            string where = " and ChanState not in(3, 4) and chanName like '%" + chanName + "%' ";
            where += "and chanLinkMan like '%" + chanLinkName + "%' and userName like '%" + chanCreateName + "%' and chanDueMan like '%" + chanDueName + "%' ";
            Dictionary<string, object> dt = ChancesAllocationBLL.ChancesAllocationFindAll("ChancesAllocation", "chanID", "*", where, "chanID", 1, 16);
            dt.Add("roleId", Session["RoleID"].ToString());
            return dt;
        }
    }
}
