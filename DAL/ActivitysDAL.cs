using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class ActivitysDAL
    {
        /// <summary>
        /// 此方法用于添加交往记录
        /// </summary>
        /// <param name="obj">要添加的交往记录对象</param>
        /// <returns></returns>
        public static bool ActivityAddNew(List<Activitys> actList)
        {
            bool falg = false;
            for (int i = 0; i < actList.Count; i++)
            {
                falg=DBHelp.ExecuteCUD("insert into activitys values(@CusID, getdate() , '', @ActTitle, '', '')",
                new List<SqlParameter>{
                    new SqlParameter("@CusID" ,actList[i].CusID),
                    //new SqlParameter("@ActDate" ,actList[i].ActDate),
                    new SqlParameter("@ActTitle" ,actList[i].ActTitle)
                }) > 0;
            }
            return falg;
        }

        /// <summary>
        /// 此方法用于按照客户编号查询交往记录
        /// </summary>
        /// <param name="cusID"></param>
        /// <returns></returns>
        public static List<Activitys> ActivityFindByID(string cusID)
        {
            using (SqlDataReader sdr = DBHelp.ExecuteReader("select * from activitys where cusid=@CusID order by ActDate desc", new List<SqlParameter> { new SqlParameter("@CusID", cusID) })) 
            {
                List<Activitys> list = new List<Activitys>();
                while (sdr.Read()) 
                {
                    Activitys obj = new Activitys();
                    obj.ActID = Convert.ToInt32(sdr["ActID"].ToString());
                    obj.CusID = cusID;
                    obj.ActDate = sdr["ActDate"].ToString();
                    obj.ActAdd = sdr["ActAdd"].ToString();
                    obj.ActTitle = sdr["ActTitle"].ToString();
                    obj.ActMemo = sdr["ActMemo"].ToString();
                    obj.ActDesc = sdr["ActDesc"].ToString();
                    list.Add(obj);
                }
                return list;
            }
        }

        /// <summary>
        /// 此方法用于根据交往记录id删除交往记录
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        public static bool ActivityDel(int actID)
        {
            return DBHelp.ExecuteCUD("delete from activitys where actid=@ActID",
                                        new List<SqlParameter> { new SqlParameter("@ActID", actID) 
                                    }) > 0;
        }

        /// <summary>
        /// 此方法用于根据交往记录id查询
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        public static Activitys ActivityFindByACTID(int actID) 
        {
            using (SqlDataReader sdr = DBHelp.ExecuteReader("select * from activitys where ActID=@ActID", new List<SqlParameter> { new SqlParameter("@ActID", actID) }))
            {
                Activitys obj = null;
                if (sdr.Read())
                {
                    obj = new Activitys();
                    obj.ActID = actID;
                    obj.CusID = sdr["CusID"].ToString();
                    obj.ActDate = sdr["ActDate"].ToString();
                    obj.ActAdd = sdr["ActAdd"].ToString();
                    obj.ActTitle = sdr["ActTitle"].ToString();
                    obj.ActMemo = sdr["ActMemo"].ToString();
                    obj.ActDesc = sdr["ActDesc"].ToString();
                }
                return obj;
            }
        }

        /// <summary>
        /// 此方法用于添加新的交往记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ActivitysAdd(Activitys obj)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@CusID", obj.CusID),
                new SqlParameter("@ActAdd", obj.ActAdd),
                new SqlParameter("@ActDate", DateTime.Parse(obj.ActDate)),
                new SqlParameter("@ActTitle", obj.ActTitle),
                new SqlParameter("@ActMemo", obj.ActMemo),
                new SqlParameter("@ActDesc", obj.ActDesc)
            };
            return DBHelp.ExecuteCUD("insert into activitys values(@CusID, @ActDate , @ActAdd, @ActTitle, @ActMemo, @ActDesc)", list) > 0;
        }

        /// <summary>
        /// 此方法用于修改交往记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ActivitysEdit(Activitys obj)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@ActDate",DateTime.Parse(obj.ActDate)),
                new SqlParameter("@ActAdd", obj.ActAdd),
                new SqlParameter("@ActTitle", obj.ActTitle),
                new SqlParameter("@ActMemo", obj.ActMemo),
                new SqlParameter("@ActDesc", obj.ActDesc),
                new SqlParameter("@ActID",obj.ActID)
            };
            return DBHelp.ExecuteCUD("update activitys set ActDate=@ActDate, ActAdd=@ActAdd, ActTitle=@ActTitle, ActMemo=@ActMemo, ActDesc=@ActDesc where ActID=@ActID", list)>0;
        }
    }
}
