using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class MeasuresDAL
    {
        
        /// <summary>
        /// 此方法用于根据流失用户id查询流失措施
        /// </summary>
        /// <param name="clID"></param>
        /// <returns></returns>
        public static List<Measures> MeasursFindByCLID(int clID) {
            string sql = "select * from Measures where clID=@clID";
            using (SqlDataReader sdr = DBHelp.ExecuteReader(sql, new List<SqlParameter> { new SqlParameter("@clID", clID) }))
            {
                List<Measures> list = new List<Measures>();
                while (sdr.Read())
                {
                    Measures obj = new Measures();
                    obj.MeID = Convert.ToInt32(sdr["MeID"].ToString());
                    obj.CLID = clID;
                    obj.MeDate = sdr["MeDate"].ToString();
                    obj.MeDesc = sdr["MeDesc"].ToString();
                    list.Add(obj);
                }
                return list;
            }
        }

        /// <summary>
        /// 此方法用于添加流失措施
        /// </summary>
        /// <param name="clID"></param>
        /// <param name="mDesc"></param>
        /// <returns></returns>
        public static bool MeasuresAddNew(int clID,string mDesc) {
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@clid",clID),
                new SqlParameter("@medesc",mDesc)
            };
            return DBHelp.ExecuteCUD("insert into Measures values(@clid,getdate(),@medesc)", list) > 0;

        }
    }
}
