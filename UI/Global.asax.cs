using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Timers;
using System.Configuration;
using System.Data.SqlClient;

namespace UI
{
    public class Global : System.Web.HttpApplication
    {

        /// <summary>
        /// 自动执行（自动添加流失报警客户信息）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            Timer time = new Timer();
            time.Interval = 60000;
            time.Start();
            time.Elapsed += new ElapsedEventHandler(time_Elapsed);
        }

        void time_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.ToLongTimeString().Split(':')[0] == "12" && DateTime.Now.ToLongTimeString().Split(':')[1] == "00")
            {
                string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = @"insert into dbo.CustomLosts
                                   select cusid,orderdate,getdate(),null,null,1 from dbo.Orders as a
                                   where datediff(mm,
			                                      (select max(orderdate) from orders as b where a.orderid=b.orderid)
			                                      ,getdate())>6 and cusid not in(select cusid from dbo.CustomLosts)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "update customLosts set clstate=2 where (select count(*) from Measures where clid=customLosts.clid)>0 and clstate<>2";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}