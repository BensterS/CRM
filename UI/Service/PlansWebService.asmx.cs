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
    /// PlansWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class PlansWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 此方法返回所有的开发计划
        /// </summary>
        /// <returns>List<Plans></returns>
        [WebMethod]
        public Dictionary<string, object> PlansFindAll(int chanId, string pIndex, string pSize)
        {
            return ViewPlansBLL.PlansFindAll("view_plans", "planID", "*", " and chanid=" + chanId, " PlanDate desc ", StringDisposeBLL.StrToInt(pIndex), Convert.ToInt32(pSize));
        }

        /// <summary>
        /// 此方法用于添加开发计划
        /// </summary>
        /// <param name="chanId">销售机会id</param>
        /// <param name="planContent">开发计划</param>
        /// <returns></returns>
        [WebMethod]
        public bool PlanAddNew(int chanId, string planContent)
        {
            return PlansBLL.PlansAddNew(chanId, planContent) > 0;
        }

        /// <summary>
        /// 此方法用于添加执行计划
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="planResultContent"></param>
        /// <returns></returns>
        [WebMethod]
        public bool PlanResultAddNew(string planId, string planResultContent)
        {
            return PlansBLL.PlanResultAddNew(planId, planResultContent) > 0;
        }

        /// <summary>
        /// 此方法用于客户开发失败
        /// </summary>
        /// <param name="chanId"></param>
        /// <param name="chancesError"></param>
        /// <returns></returns>
        [WebMethod]
        public bool PlanError(int chanId, string chancesError)
        {
            return PlansBLL.PlanError(chanId,chancesError)>0;
        }

        /// <summary>
        /// 此方法用于客户开发成功
        /// </summary>
        /// <param name="chanid"></param>
        /// <returns></returns>
        [WebMethod]
        public bool PlanSuccess(int chanid)
        {
            return PlansBLL.PlanSuccess(chanid);
        }
    }
}
