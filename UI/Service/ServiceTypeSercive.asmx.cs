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
    /// ServiceTypeSercive 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ServiceTypeSercive : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //查询显示所有的服务类型
        [WebMethod]
        public List<ServiceType> Select() {
            return ServiceTypeBLL.Select();
        }
        //添加一个服务类型
        [WebMethod]
        public string Add(ServiceType a) {
            int count = ServiceTypeBLL.Add(a);
            return count > 0 ? "1" : "0";
        }

        //删除一个服务类型
        [WebMethod]
        public string Delete(string id) {
            int count = ServiceTypeBLL.Delete(id);
            return count > 0 ? "1" : "0";
        }

        //根据服务类型ID查询服务信息
        [WebMethod]
        public ServiceType SelectById(string id) {
            return ServiceTypeBLL.SelectByIdServiceType(id);
        }

        //根据服务类型ID修改服务类型
        [WebMethod]
        public string Update(ServiceType s) {
            int count = ServiceTypeBLL.Update(s);
            return count > 0 ? "1" : "0";
        }
    }
}
