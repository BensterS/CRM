using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class ChancesAllocationBLL
    {
        /// <summary>
        /// 使用分页技术查询所有数据
        /// </summary>
        /// <param name="page">参数列集合</param>
        /// <returns>返回查询结果集</returns>
        public static Dictionary<string, object> ChancesAllocationFindAll(string tBName, string keyFile, string showFile, string where, string orderBy, int pIndex, int pSize)
        {
            int count = PagingDAL.GetCount(tBName, where);
            int pageCount = count % pSize == 0 ? count / pSize : count / pSize + 1;
            pIndex = pIndex <= 0 ? 1 : pIndex;
            pIndex = pIndex > pageCount ? pageCount : pIndex;
            CommonPage page = new CommonPage(tBName, keyFile, showFile, where, orderBy, pIndex, pSize);
            Dictionary<string, object> dt = new Dictionary<string, object>();
            dt.Add("list", ChancesAllocationDAL.ChancesAllocationFindAll(page));
            dt.Add("cList", ChancesAllocation_ChanDueManBLL.ChancesAllocation_ChanDueManDALFindAll());
            dt.Add("count", count);
            dt.Add("pageCount", pageCount);
            dt.Add("pIndex", pIndex);
            return dt;
        }

        /// <summary>
        /// 修改销售机会
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ChancesDueManUpdate(int chanId, int chanDueMan)
        {
            Chances obj = new Chances();
            obj.ChanID = chanId;
            obj.ChanState = 2;
            obj.ChanDueMan = chanDueMan;
            obj.ChanError = "";
            return ChancesDAL.ChancesDueManUpdate(obj);
        }
    }
}
