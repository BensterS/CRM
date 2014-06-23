using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class ChancesBLL
    {
        /// <summary>
        /// 使用分页技术查询所有数据
        /// </summary>
        /// <param name="page">参数列集合</param>
        /// <returns>返回查询结果集</returns>
        public static Dictionary<string,object> ChancesFindAll(string tBName, string keyFile, string showFile, string where, string orderBy, int pIndex, int pSize)
        {
            int count = PagingDAL.GetCount(tBName, where);
            int pageCount = count % pSize == 0 ? count / pSize : count / pSize + 1;
            pIndex = pIndex <= 0 ? 1 : pIndex;
            pIndex = pIndex > pageCount ? pageCount : pIndex;
            CommonPage page = new CommonPage(tBName, keyFile, showFile, where, orderBy, pIndex, pSize);

            Dictionary<string, object> dt = new Dictionary<string, object>();
            dt.Add("list",ChancesDAL.ChancesFindAll(page));
            dt.Add("count",count);
            dt.Add("pageCount",pageCount);
            dt.Add("pIndex", pIndex);
            return dt;
        }

        /// <summary>
        /// 此方法用于根据id查询销售机会
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Chances ChanFindById(int id)
        {
            return ChancesDAL.ChanFindById(id);
        }
        
        /// <summary>
        /// 此方法用于修改销售机会表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回受影响的行数</returns>
        public static int ChancesEdit(Chances obj)
        {
            return ChancesDAL.ChancesEdit(obj);
        }

        /// <summary>
        /// 此方法用于修改销售机会表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ChanAddNew(Chances obj)
        {
            return ChancesDAL.ChanAddNew(obj);
        }

        /// <summary>
        /// 此方法用于根据id删除销售机会信息
        /// </summary>
        /// <param name="id">要删除的销售信息id</param>
        /// <returns>返回是否成功</returns>
        public static bool ChancesDel(int id)
        {
            return ChancesDAL.ChancesDel(id);
        }

        /// <summary>
        /// 修改销售机会
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ChancesDueManUpdate(Chances obj)
        {
            return ChancesDAL.ChancesDueManUpdate(obj);
        }

        /// <summary>
        /// 此方法用于客户开发失败
        /// </summary>
        /// <param name="chanId"></param>
        /// <param name="chancesError"></param>
        /// <returns></returns>
        public static int PlanError(int chanId, string chancesError)
        {
            return ChancesDAL.PlanError(chanId, chancesError);
        }

        /// <summary>
        /// 此方法用于客户开发成功
        /// </summary>
        /// <param name="chanId"></param>
        /// <returns></returns>
        public static bool PlanSuccess(int chanId)
        {
            return ChancesDAL.PlanChangeState(chanId);
        }
    }
}
