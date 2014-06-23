using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    //服务类型表的相关操作
    public class ServiceTypeDAL
    {
        //查询出所有的服务类型
        public static List<ServiceType> Select() {
            List<ServiceType> list = new List<ServiceType>();
            string sql = "select * from ServiceType";
            using(SqlDataReader sr=DBHelp.ExecuteReader(sql,null)){
                while (sr.Read()) {
                    ServiceType s = new ServiceType();
                    s.STID = Convert.ToInt32(sr["STID"]);
                    s.STName = sr["STName"].ToString();
                    list.Add(s);
                }
                return list;
            }
        }
        //添加一个服务类型
        public static int Add(ServiceType s) {
            string sql = "insert into ServiceType values(@STName)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@STName",s.STName));
            return DBHelp.ExecuteCUD(sql,list);
        }

        //删除一个服务类型
        public static int Delete(string id) {
            string sql = "delete from ServiceType where STID=@STID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@STID",id));
            return DBHelp.ExecuteCUD(sql,list);
        }
        //根据服务类型的ID查询出服务类型
        public static ServiceType SelectByIdServiceType(string id) {
            ServiceType s = null;
            string sql = "select * from ServiceType where STID=@STID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@STID", id));
            using (SqlDataReader sr = DBHelp.ExecuteReader(sql, list)) {
                if (sr.Read()) {
                    s = new ServiceType();
                    s.STName = sr["STName"].ToString();
                    s.STID = Convert.ToInt32(sr["STID"]);
                }
                return s;
            }
        }

        //根据服务类型ID修改服务类型
        public static int Update(ServiceType s) {
            string sql = "update ServiceType set STName=@STName where STID=@STID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@STID", s.STID));
            list.Add(new SqlParameter("@STName", s.STName));
            return DBHelp.ExecuteCUD(sql,list);
        }
    }
}
