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
    /// LoginWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class LoginWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 此方法用于登录
        /// </summary>
        /// <param name="obj">要登陆的用户</param>
        /// <returns></returns>
        [WebMethod (enableSession:true)]
        public string ISLogin(string UserLName, string UserLPWD)
        {
            Users obj = new Users(UserLName, UserLPWD);
            Users rObj=UsersBLL.Login(obj);
            if (null != rObj)
            {
                Session["UserName"] = rObj.UserName;
                Session["UserId"] = rObj.UserID;
                Session["RoleID"] = rObj.RoleID;
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 判断是否登录
        /// </summary>
        /// <returns></returns>
        [WebMethod(enableSession: true)]
        public Object GetUserName() 
        {
            return Session["UserName"];
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [WebMethod(enableSession: true)]
        public bool Close()
        {
            Session.Clear();
            return true;
        } 
    }
}
