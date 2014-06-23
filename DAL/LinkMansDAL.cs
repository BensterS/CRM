using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class LinkMansDAL
    {

        /// <summary>
        /// 从方法用于添加新的联系人
        /// </summary>
        /// <param name="obj">新的联系人对象</param>
        /// <returns></returns>
        public static bool LinkManAddNew(LinkMans obj) {
            List<SqlParameter> list = new List<SqlParameter> {
                new SqlParameter("@CusID", obj.CusID),
                new SqlParameter("@LMName", obj.LMName),
                new SqlParameter("@LMSex", "男"),
                new SqlParameter("@LMDuty", ""),
                new SqlParameter("@LMMobileNo", obj.LMMobileNo),
                new SqlParameter("@LMOfficeNo", obj.LMOfficeNo),
                new SqlParameter("@LMMemo", "")
            };
            string sql = "insert into LinkMans values(@CusID, @LMName, @LMSex, @LMDuty, @LMMobileNo, @LMOfficeNo, @LMMemo)";
            return DBHelp.ExecuteCUD(sql, list)>0;
        }

        /// <summary>
        /// 此方法用于根据客户编号查询联系人
        /// </summary>
        /// <param name="cusID"></param>
        /// <returns></returns>
        public static List<LinkMans> LinkMansFindAll(string cusID) 
        {
            using (SqlDataReader sdr = DBHelp.ExecuteReader("select * from LinkMans where cusid=@CusID", new List<SqlParameter> { new SqlParameter("@CusID", cusID) }))
            {
                List<LinkMans> list = new List<LinkMans>();
                while (sdr.Read())
                {
                    LinkMans obj = new LinkMans();
                    obj.LMID = Convert.ToInt32(sdr["LMID"].ToString());
                    obj.CusID = cusID;
                    obj.LMName = sdr["LMName"].ToString();
                    obj.LMSex = sdr["LMSex"].ToString();
                    obj.LMDuty = sdr["LMDuty"].ToString();
                    obj.LMMobileNo = sdr["LMMobileNo"].ToString();
                    obj.LMOfficeNo = sdr["LMOfficeNo"].ToString();
                    obj.LMMemo = sdr["LMMemo"].ToString();
                    list.Add(obj);
                }
                return list;
            }
        }

        /// <summary>
        /// 此方法用于根据交往记录id删除联系人
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        public static bool LinkManDel(int lmID)
        {
            return DBHelp.ExecuteCUD("delete from LinkMans where lmID=@lmID",
                                        new List<SqlParameter> { new SqlParameter("@lmID", lmID) 
                                    }) > 0;
        }

        /// <summary>
        /// 此方法用于根据联系id查询
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        public static LinkMans LinkManFindByLMID(int lmID)
        {
            using (SqlDataReader sdr = DBHelp.ExecuteReader("select * from LinkMans where lmID=@lmID", new List<SqlParameter> { new SqlParameter("@lmID", lmID) }))
            {
                LinkMans obj = null;
                if (sdr.Read())
                {
                    obj = new LinkMans();
                    obj.LMID = lmID;
                    obj.CusID = sdr["CusID"].ToString();
                    obj.LMName = sdr["LMName"].ToString();
                    obj.LMSex = sdr["LMSex"].ToString();
                    obj.LMDuty = sdr["LMDuty"].ToString();
                    obj.LMMobileNo = sdr["LMMobileNo"].ToString();
                    obj.LMOfficeNo = sdr["LMOfficeNo"].ToString();
                    obj.LMMemo = sdr["LMMemo"].ToString();
                }
                return obj;
            }
        }

        /// <summary>
        /// 此方法用于添加新的联系人
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool LinkManAdd(LinkMans obj)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@CusID", obj.CusID),
                new SqlParameter("@LMName", obj.LMName),
                new SqlParameter("@LMSex", obj.LMSex),
                new SqlParameter("@LMDuty", obj.LMDuty),
                new SqlParameter("@LMMobileNo", obj.LMMobileNo),
                new SqlParameter("@LMOfficeNo", obj.LMOfficeNo),
                new SqlParameter("@LMMemo", obj.LMMemo)
            };
            return DBHelp.ExecuteCUD("insert into LinkMans values(@CusID, @LMName , @LMSex, @LMDuty, @LMMobileNo, @LMOfficeNo ,@LMMemo)", list) > 0;
        }

        /// <summary>
        /// 此方法用于修改联系人
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool LinkManEdit(LinkMans obj)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@LMName", obj.LMName),
                new SqlParameter("@LMSex", obj.LMSex),
                new SqlParameter("@LMDuty", obj.LMDuty),
                new SqlParameter("@LMMobileNo", obj.LMMobileNo),
                new SqlParameter("@LMOfficeNo", obj.LMOfficeNo),
                new SqlParameter("@LMMemo", obj.LMMemo),
                new SqlParameter("@LMID",obj.LMID)
            };
            return DBHelp.ExecuteCUD("update LinkMans set LMName=@LMName, LMSex=@LMSex, LMDuty=@LMDuty, LMMobileNo=@LMMobileNo, LMOfficeNo=@LMOfficeNo, LMMemo=@LMMemo where LMID=@LMID", list) > 0;
        }
    }
}
