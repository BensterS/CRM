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
    /// CustomServicesServices 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class CustomServicesServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        //查询显示所有的客户编号
        [WebMethod]
        public List<Customers> SelectCusID() {
            return ViewCustomServicesBLL.CustomersFindCusID();
        }
        
        //创建一个服务
        [WebMethod(EnableSession=true)]
        public string CreateService(CustomServices c)
        {
            //string CSCreateID= Session["UserIdExi"].ToString(); //获得用户登录的ID（麻烦。。登陆时可以直接保存用户角色）
            string RoleID = Session["RoleID"].ToString();
            string count1 = "0";
            if (RoleID=="2")
            {
                c.CSCreateID = Convert.ToInt32(Session["UserId"].ToString());
                int count = ViewCustomServicesBLL.Insert(c);
                count1 =count.ToString();
            }
            return count1;
            
        }

        //查询出客户服务管理的信息并分页
        [WebMethod]
        public Dictionary<string, object> GetAll(int PIndex, string Types)
        {


            if (PIndex < 0) {
                PIndex = 1;
            }
            int psize = 8; //每页显示的行数
            int count = ViewCustomServicesBLL.GetCount(Types);  //查询出总条数
            int pcount = count % psize == 0 ? count / psize : count / psize + 1;

            CommonPage page = new CommonPage();
            page.KeyFile = "CSID"; //主键
            page.TbName = "ViewCustomServices"; //表名
            page.PIndex = PIndex; //当前页
            page.PSize = psize; //每页显示的条数
            page.ShowFile = "*"; //列名
            if (Types == "处理") {  //条件可以直接写成判断服务状态
                page.Where = " and CSDueID in (select CSDueID from CustomServices) ";
            }else if (Types == "反馈") {
                page.Where = " and CSDealDate>0 ";
            }
            else if (Types == "分配") {
                page.Where = " and 1=1 ";
            }
            else
            {
                page.Where = " and CSState=4 " + Types;
            }

            //查询出所有的客户经理以及客户主管
            List<Users> user = UsersBLL.SelectUserName();
            //查询出已经分配过的人的编号已经姓名
            List<Users> user2 = UsersBLL.SelectCSDueID();

            List<ViewCustomServices> list = ViewCustomServicesBLL.GetAll(page);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("list",list);
            dic.Add("pindex", PIndex); //当前页
            dic.Add("psize", psize); //每一页显示的条数
            dic.Add("count", count); //总条数
            dic.Add("pcount", pcount); //总页数
            dic.Add("users",user); //用户信息
            dic.Add("users2",user2); //分配人姓名

            return dic;
        }

        //调用设置一个指派人，修改客户服务表中的指派人ID，设置指派人的时间，服务状态，
        [WebMethod(EnableSession = true)]
        public string UpdateCSDue(string CSDueID, string CSID)
        {
            string CSCreateID = Session["UserId"].ToString();//获得用户登录的ID
            string RoleID = Session["RoleID"].ToString();//根据用户登录ID查询出用户的角色ID
            string count1="0";
            if (RoleID == "2") {
                int count = CustomServicesBLL.UpdateCSDue(CSDueID, CSID);
                count1 = count.ToString();
            }
            return count1;
        }

        // //根据客户处理ID查询显示信息
        [WebMethod(EnableSession=true)]
        public ViewCustomServices SelectById(string CSID)
        { 
            string CSCreateID = Session["UserIdExi"].ToString(); //获得用户登录的ID
            string RoleID = UsersBLL.SelecRoleID(CSCreateID).ToString(); //根据用户登录ID查询出用户的角色ID
            ViewCustomServices u = null;
            if (RoleID == "3")
            {
                u = ViewCustomServicesBLL.SelectById(CSID);

            }
            return u;
        }
        //调用//服务处理，修改客户服务表中的服务处理，设置服务处理的时间，服务状态，
        [WebMethod]
        public string UpdateCSDeal(string CSDeal, string CSID)
        {
            int count = CustomServicesBLL.UpdateCSDeal(CSDeal,CSID);
            return count > 0 ? "1" : "0";
        }
         //修改处理结果
        [WebMethod]
        public string UpdateCSResult(CustomServices c)
        {
            int count = CustomServicesBLL.UpdateCSResult(c);
            return count > 0 ? "1" : "0";
        }
    }
}
