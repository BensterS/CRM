using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class UsersDAL
    {
        /// <summary>
        /// 此方法用于登录CRM系统
        /// </summary>
        /// <param name="obj">要登录的用户</param>
        /// <returns>返回登录成功的用户</returns>
        public static Users Login(Users obj) 
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@UserLName",obj.UserLName),
                new SqlParameter("@UserLPWD",EncryptionAndDeciphering.string_Encrypt(obj.UserLPWD,""))
            };
            SqlDataReader sdr=DBHelp.ExecuteReader("select * from users where UserLName=@UserLName and UserLPWD=@UserLPWD",list);
            Users rObj = null;
            if (sdr.Read()) 
            {
                rObj = new Users();
                rObj.UserID = Convert.ToInt32(sdr["UserID"].ToString());
                rObj.UserLName = obj.UserLName;
                rObj.UserName = sdr["UserName"].ToString();
                rObj.RoleID = Convert.ToInt32(sdr["RoleID"].ToString());
            }
            return rObj;
        }


        //用户表信息查询
        public static List<Users> Select()
        {
            List<Users> list = new List<Users>();
            string sql = "select * from  Users";
            using (SqlDataReader sr = DBHelp.ExecuteReader(sql, null))
            {
                while (sr.Read())
                {
                    Users u = new Users();
                    u.UserID = Convert.ToInt32(sr["UserID"]);
                    u.UserLName = sr["UserLName"].ToString();
                    u.UserName = sr["UserName"].ToString();
                    u.UserLPWD = sr["UserLPWD"].ToString();
                    u.RoleID = Convert.ToInt32(sr["RoleID"]);
                    list.Add(u);
                }
                return list;
            }
        }

        //根据用户ID查询信息
        public static Users SelectById(string id)
        {
            Users u = null;
            string sql = "select * from Users where UserID=@UserID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", id));
            using (SqlDataReader sr = DBHelp.ExecuteReader(sql, list))
            {
                if (sr.Read())
                {
                    u = new Users();
                    u.RoleID = Convert.ToInt32(sr["RoleID"]);
                    u.UserName = sr["UserName"].ToString();
                    u.UserLName = sr["UserLName"].ToString();
                    u.UserLPWD = sr["UserLPWD"].ToString();
                    u.UserID = Convert.ToInt32(sr["UserID"]);
                }
                return u;
            }
        }

        //根据用户ID修改用户信息
        public static int Update(Users u)
        {
            string sql = "update Users set UserLName=@UserLName, UserLPWD=@UserLPWD, UserName=@UserName, RoleID=@RoleID where UserID=@UserID";
            List<SqlParameter> list = new List<SqlParameter>() { 
                new SqlParameter("@UserLName",u.UserLName),
                new SqlParameter("@UserLPWD",u.UserLPWD),
                new SqlParameter("@UserName",u.UserName),
                new SqlParameter("@RoleID",u.RoleID),
                new SqlParameter("@UserID",u.UserID)
            };
            return DBHelp.ExecuteCUD(sql, list);
        }

        //根据用户ID来删除用户
        public static int Delete(string id)
        {
            string sql = "delete from Users where UserID=@id";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            return DBHelp.ExecuteCUD(sql, list);
        }
        //添加一个用户
        public static int AddUsrs(Users u)
        {
            string sql = "insert into Users values(@UserLName, @UserLPWD, @UserName, @RoleID)";
            List<SqlParameter> list = new List<SqlParameter>() { 
                new SqlParameter("@UserLName",u.UserLName),
                new SqlParameter("@UserLPWD",u.UserLPWD),
                new SqlParameter("@UserName",u.UserName),
                new SqlParameter("@RoleID",u.RoleID)
            };
            return DBHelp.ExecuteCUD(sql, list);
        }

        //根据用户ID查询出该用户的状态
        public static object SelecRoleID(string id)
        {
            string sql = "select RoleID from Users where UserID=@UserID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", id));
            return DBHelp.ExecuteSingle(sql, list);
        }

        //查询出所有的客户经理以及客户主管
        public static List<Users> SelectUserName()
        {
            List<Users> list = new List<Users>();
            string sql = "select * from USERS WHERE RoleID !=3";
            using (SqlDataReader sr = DBHelp.ExecuteReader(sql, null))
            {
                while (sr.Read())
                {
                    Users u = new Users();
                    u.UserName = sr["UserName"].ToString();
                    u.UserID = Convert.ToInt32(sr["UserID"]);
                    list.Add(u);
                }
            }
            return list;
        }
        //查询出所有的客户经理
        public static List<Users> SelectUserName2()
        {
            List<Users> list = new List<Users>();
            string sql = "select * from USERS WHERE RoleID =2";
            using (SqlDataReader sr = DBHelp.ExecuteReader(sql, null))
            {
                while (sr.Read())
                {
                    Users u = new Users();
                    u.UserName = sr["UserName"].ToString();
                    u.UserID = Convert.ToInt32(sr["UserID"]);
                    list.Add(u);
                }
            }
            return list;
        }

        //查询出已经分配过的人的编号已经姓名
        public static List<Users> SelectCSDueID()
        {
            List<Users> list = new List<Users>();
            string sql = "select * from Users where UserID in (select CSDueID from CustomServices)";
            using (SqlDataReader sr = DBHelp.ExecuteReader(sql, null))
            {
                while (sr.Read())
                {
                    Users u = new Users();
                    u.UserName = sr["UserName"].ToString();
                    u.UserID = Convert.ToInt32(sr["UserID"]);
                    list.Add(u);
                }
            }
            return list;
        }
    }
}
