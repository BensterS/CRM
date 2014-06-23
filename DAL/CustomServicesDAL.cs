using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    //客户服务处理相关操作
    public class CustomServicesDAL
    {
        //创建一个服务
        public static int Insert(CustomServices c) {
            string sql = "insert into CustomServices values(@STID,@CusID,@CSTitle,1,@CSDesc,@CSCreateID,getdate(),NULL,NULL,NULL,NULL,NULL,NULL)";
            List<SqlParameter> list = new List<SqlParameter>() { 
                new SqlParameter("@STID",c.STID),
                new SqlParameter("@CusID",c.CusID),
                new SqlParameter("@CSTitle",c.CSTitle),
                new SqlParameter("@CSDesc",c.CSDesc),
                new SqlParameter("@CSCreateID",c.CSCreateID)
            };
            return DBHelp.ExecuteCUD(sql,list);
        }

        //设置一个指派人，修改客户服务表中的指派人ID，设置指派人的时间，服务状态，
        public static int UpdateCSDue(string CSDueID, string CSID)
        {
            string sql = "update CustomServices set CSDueID=@CSDueID,CSState=2,CSDueDate=getdate() where CSID=@CSID";
            List<SqlParameter> list = new List<SqlParameter>() { 
                new SqlParameter("@CSDueID",CSDueID),
                new SqlParameter("@CSID",CSID)
            };
            return DBHelp.ExecuteCUD(sql,list);
        }

        //服务处理，修改客户服务表中的服务处理，设置服务处理的时间，服务状态，
        public static int UpdateCSDeal(string CSDeal, string CSID)
        {
            string sql = "update CustomServices set CSDeal=@CSDeal,CSState=3,CSDealDate=getdate() where CSID=@CSID";
            List<SqlParameter> list = new List<SqlParameter>() { 
                new SqlParameter("@CSDeal",CSDeal),
                new SqlParameter("@CSID",CSID)
            };
            return DBHelp.ExecuteCUD(sql,list);
        }

        //修改处理结果
        public static int UpdateCSResult(CustomServices c)
        {
            string sql = "update CustomServices set CSResult=@CSResult,CSState=4,CSSatisfy=@CSSatisfy where CSID=@CSID";
            List<SqlParameter> list = new List<SqlParameter>() { 
                new SqlParameter("@CSResult",c.CSResult),
                new SqlParameter("@CSSatisfy",c.CSSatisfy),
                new SqlParameter("@CSID",c.CSID)
            };
            return DBHelp.ExecuteCUD(sql,list);
        }
    }
}
