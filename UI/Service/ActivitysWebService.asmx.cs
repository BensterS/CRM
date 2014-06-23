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
    /// ActivitysWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ActivitysWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 此方法用于按照客户编号查询交往记录
        /// </summary>
        /// <param name="cusID"></param>
        /// <returns></returns>
        [WebMethod]
        public List<Activitys> ActivityFindByID(string cusID)
        {
            return ActivitysBLL.ActivityFindByID(cusID);
        }

        /// <summary>
        /// 此方法用于根据交往记录id删除交往记录
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ActivityDel(int actID)
        {
            return ActivitysBLL.ActivityDel(actID);
        }

        /// <summary>
        /// 此方法用于根据交往记录id查询
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        [WebMethod]
        public Activitys ActivityFindByACTID(int actID)
        {
            return ActivitysBLL.ActivityFindByACTID(actID);
        }
        /// <summary>
        /// 此方法用于添加新的交往记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ActivitysAdd(Activitys obj)
        {
            return ActivitysBLL.ActivitysAdd(obj);
        }

        /// <summary>
        /// 此方法用于修改交往记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ActivitysEdit(Activitys obj)
        {
            return ActivitysBLL.ActivitysEdit(obj);
        }
    }
}
