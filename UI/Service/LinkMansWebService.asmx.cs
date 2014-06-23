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
    /// LinkMansWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class LinkMansWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 此方法用于根据客户编号查询联系人
        /// </summary>
        /// <param name="cusID"></param>
        /// <returns></returns>
        [WebMethod]
        public List<LinkMans> LinkMansFindAll(string cusID)
        {
            return LinkMansBLL.LinkMansFindAll(cusID);
        }

        /// <summary>
        /// 此方法用于根据交往记录id删除联系人
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        [WebMethod]
        public bool LinkManDel(int lmID)
        {
            return LinkMansBLL.LinkManDel(lmID);
        }

        /// <summary>
        /// 此方法用于根据联系id查询
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        [WebMethod]
        public LinkMans LinkManFindByLMID(int lmID)
        {
            return LinkMansBLL.LinkManFindByLMID(lmID);
        }

        /// <summary>
        /// 此方法用于添加新的联系人
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [WebMethod]
        public bool LinkManAdd(LinkMans obj)
        {
            return LinkMansBLL.LinkManAdd(obj);
        }

        /// <summary>
        /// 此方法用于修改联系人
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [WebMethod]
        public bool LinkManEdit(LinkMans obj)
        {
            return LinkMansBLL.LinkManEdit(obj);
        }
    }
}
