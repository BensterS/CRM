using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class ChancesDAL
    {
        /// <summary>
        /// 使用分页技术查询所有销售机会数据
        /// </summary>
        /// <param name="page">参数列集合</param>
        /// <returns>返回查询结果集</returns>
        public static List<Chances> ChancesFindAll(CommonPage page) 
        {
            List<Chances> list = new List<Chances>();

            string sql = "PagingProc";
            List<SqlParameter> paras = new List<SqlParameter>()
            {
                new SqlParameter("@TbName",page.TbName),
                new SqlParameter("@KeyFile",page.KeyFile),
                new SqlParameter("@ShowFile",page.ShowFile),
                new SqlParameter("@Where",page.Where),
                new SqlParameter("@OrderBy",page.OrderBy),
                new SqlParameter("@PIndex",page.PIndex),
                new SqlParameter("@PSize",page.PSize)
            };
            try
            {
                using (SqlDataReader sdr = DBHelp.ExecuteReaderProc(sql, paras))
                {
                    while (sdr.Read())
                    {
                        Chances obj = new Chances();
                        obj.ChanID=Convert.ToInt32(sdr["chanID"].ToString());
                        obj.ChanName=sdr["chanName"].ToString();
                        obj.ChanRate=Convert.ToInt32(sdr["chanrate"].ToString());
                        obj.ChanLinkMan=sdr["ChanLinkMan"].ToString();
                        obj.ChanLinkTel=sdr["ChanLinkTel"].ToString();
                        obj.ChanTitle=sdr["ChanTitle"].ToString();
                        obj.ChanDesc=sdr["ChanDesc"].ToString();
                        obj.ChanCreateMan=Convert.ToInt32(sdr["ChanCreateMan"].ToString());
                        obj.ChanCreateDate=sdr["ChanCreateDate"]!=null?sdr["ChanCreateDate"].ToString():"";
                        obj.ChanState=Convert.ToInt32(sdr["ChanState"].ToString());
                        list.Add(obj);
                    }
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 此方法用于根据id查询销售机会
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Chances ChanFindById(int id)
        {
            using (SqlDataReader sdr = DBHelp.ExecuteReader("select * from chances where chanid=@ChanId", new List<SqlParameter> { new SqlParameter("@ChanId",id)}))
            {
                Chances obj=null;
                if (sdr.Read())
                {
                    obj = new Chances
                    (
                        Convert.ToInt32(sdr["chanID"].ToString()),
                        sdr["chanName"].ToString(),
                        Convert.ToInt32(sdr["chanrate"].ToString()),
                        sdr["ChanLinkMan"].ToString(),
                        sdr["ChanLinkTel"].ToString(),
                        sdr["ChanTitle"].ToString(),
                        sdr["ChanDesc"].ToString(),
                        Convert.ToInt32(sdr["ChanCreateMan"].ToString()),
                        sdr["ChanCreateDate"].ToString(),
                        Convert.ToInt32(sdr["ChanDueMan"].ToString()),
                        sdr["ChanDueDate"].ToString(),
                        Convert.ToInt32(sdr["ChanState"].ToString()),
                        sdr["ChanError"].ToString()
                    );
                }
                return obj;
            }
        }

        /// <summary>
        /// 此方法用于添加销售机会
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ChanAddNew(Chances obj) 
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@ChanName",obj.ChanName),
                new SqlParameter("@ChanRate",obj.ChanRate),
                new SqlParameter("@ChanLinkMan",obj.ChanLinkMan),
                new SqlParameter("@ChanLinkTel",obj.ChanLinkTel),
                new SqlParameter("@ChanTitle",obj.ChanTitle),
                new SqlParameter("@ChanDesc",obj.ChanDesc),
                new SqlParameter("@ChanCreateMan",obj.ChanCreateMan),
                new SqlParameter("@ChanState",obj.ChanState)
            };
            string sql = "insert into chances values(@ChanName,@ChanRate,@ChanLinkMan,@ChanLinkTel,@ChanTitle,@ChanDesc,@ChanCreateMan, getdate(),null,null,@ChanState,'')";
            return DBHelp.ExecuteCUD(sql,list);
        }

        /// <summary>
        /// 此方法用于修改销售机会表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ChancesEdit(Chances obj)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@ChanName",obj.ChanName),
                new SqlParameter("@ChanRate",obj.ChanRate),
                new SqlParameter("@ChanLinkMan",obj.ChanLinkMan),
                new SqlParameter("@ChanLinkTel",obj.ChanLinkTel),
                new SqlParameter("@ChanTitle",obj.ChanTitle),
                new SqlParameter("@ChanDesc",obj.ChanDesc),
                new SqlParameter("@ChanCreateMan",obj.ChanCreateMan),
                new SqlParameter("@ChanState",obj.ChanState),
                new SqlParameter("@ChanID",obj.ChanID)
            };
            string sql = "update chances set ChanName=@ChanName, ChanRate=@ChanRate, ChanLinkMan=@ChanLinkMan, ChanLinkTel=@ChanLinkTel, ChanTitle=@ChanTitle, ChanDesc=@ChanDesc, ChanCreateMan=@ChanCreateMan, ChanCreateDate=getdate(), ChanState=@ChanState where ChanID=@ChanID";
            return DBHelp.ExecuteCUD(sql, list);
        }

        /// <summary>
        /// 此方法用于根据id删除销售机会信息
        /// </summary>
        /// <param name="id">要删除的销售信息id</param>
        /// <returns>返回是否成功</returns>
        public static bool ChancesDel(int id) 
        {
            return DBHelp.ExecuteCUD(
                "delete from chances where chanid=@ChanId",
                new List<SqlParameter> { new SqlParameter("@ChanId", id) }
                ) > 0 ? true : false;
        }

        /// <summary>
        /// 修改销售机会
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ChancesDueManUpdate(Chances obj)
        {
            return DBHelp.ExecuteCUD("update chances set ChanDueMan = @chanDueMan, ChanDueDate=getdate(), ChanState=@chanstate, ChanError=@chanError where Chanid=@chanid ", 
                new List<SqlParameter> 
                { 
                    new SqlParameter("@chanDueMan", obj.ChanDueMan), 
                    new SqlParameter("@chanid", obj.ChanID),
                    new SqlParameter("@chanstate",obj.ChanState),
                    new SqlParameter("@chanError",obj.ChanError)
                })>0;
        }

        /// <summary>
        /// 此方法用于客户开发失败
        /// </summary>
        /// <param name="chanId"></param>
        /// <param name="chancesError"></param>
        /// <returns></returns>
        public static int PlanError(int chanId, string chancesError)
        {
            return DBHelp.ExecuteCUD("update chances set ChanState=4, ChanError=@chanError where Chanid=@chanid ",
                                        new List<SqlParameter> 
                                            { 
                                                new SqlParameter("@chanid", chanId),
                                                new SqlParameter("@chanError",chancesError)
                                            }
            );
        }

        /// <summary>
        /// 此方法用于客户开发成功
        /// </summary>
        /// <param name="chanId"></param>
        /// <returns></returns>
        public static bool PlanChangeState(int chanId) 
        {
            return DBHelp.ExecuteCUD("update chances set ChanState=3 where Chanid=@chanid ",
                                        new List<SqlParameter> 
                                            { 
                                                new SqlParameter("@chanid", chanId)
                                            }
            )>0;
        }
    }
}
