using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class UsersBLL
    {
        /// <summary>
        /// 此方法用于登录CRM系统
        /// </summary>
        /// <param name="obj">要登录的用户</param>
        /// <returns>返回登录成功的用户</returns>
        public static Users Login(Users obj)
        {
            return UsersDAL.Login(obj);
        }

                //用户表信息查询
        public static List<Users> Select()
        {
            return UsersDAL.Select();
        }

                //根据用户ID查询信息
        public static Users SelectById(string id)
        {
            return UsersDAL.SelectById(id);
        }

        //根据用户ID修改用户信息
        public static int Update(Users u)
        {
            return UsersDAL.Update(u);
        }

                //根据用户ID来删除用户
        public static int Delete(string id)
        {
            return UsersDAL.Delete(id);
        }

        //添加一个用户
        public static int AddUsrs(Users u)
        {
            return UsersDAL.AddUsrs(u);
        }

        //根据用户ID查询出该用户的状态
        public static object SelecRoleID(string id)
        {
            return UsersDAL.SelecRoleID(id);
        }

        //查询出所有的客户经理以及客户主管
        public static List<Users> SelectUserName()
        {
            return UsersDAL.SelectUserName();
        }

        //查询出所有的客户经理
        public static List<Users> SelectUserName2()
        {
            return UsersDAL.SelectUserName2();
        }

        //查询出已经分配过的人的编号已经姓名
        public static List<Users> SelectCSDueID()
        {
            return UsersDAL.SelectCSDueID();
        }
    }
}
