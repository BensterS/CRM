using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Users
    {
        public int UserID { get; set; }         //用户编号
        public string UserLName { get; set; }   //登陆名
        public string UserLPWD { get; set; }    //密码
        public string UserName { get; set; }    //真实姓名
        public int RoleID { get; set; }         //角色ID

        public Users() { }

        public Users(int userID, string userLName, string userLPWD, string userName, int roleID) 
        {
            this.UserID = userID;
            this.UserLName = userLName;
            this.UserLPWD = userLPWD;
            this.UserName = userName;
            this.RoleID = roleID;
        }

        public Users(string userLName, string userLPWD) 
        {
            this.UserLName = userLName;
            this.UserLPWD = userLPWD;
        }
    }
}
