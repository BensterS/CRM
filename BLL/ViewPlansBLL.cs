using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class ViewPlansBLL
    {

        /// <summary>
        /// 此方法返回所有的开发计划
        /// </summary>
        /// <returns>List<Plans></returns>
        public static Dictionary<string, object> PlansFindAll(string tBName, string keyFile, string showFile, string where, string orderBy, int pIndex, int pSize)
        {
            int count = PagingDAL.GetCount(tBName, where);
            int pageCount = count % pSize == 0 ? count / pSize : count / pSize + 1;
            pIndex = pIndex <= 0 ? 1 : pIndex;
            pIndex = pIndex > pageCount ? pageCount : pIndex;
            Dictionary<string, object> dt = new Dictionary<string, object>();
            dt.Add("list",ViewPlansDAL.PlansFindAll(new CommonPage(tBName, keyFile, showFile, where, orderBy, pIndex, pSize)));
            dt.Add("count", count);
            dt.Add("pageCount", pageCount);
            dt.Add("pIndex", pIndex);
            return dt;
        }
    }
}
