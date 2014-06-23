using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class ViewCustomLostsBLL
    {
        /// <summary>
        /// 使用分页技术查询所有客户流失信息
        /// </summary>
        /// <param name="page">参数列集合</param>
        /// <returns>返回查询结果集</returns>
        public static Dictionary<string, object> VCLFindAll(string tBName, string keyFile, string showFile, string where, string orderBy, int pIndex, int pSize)
        {
            int count = PagingDAL.GetCount(tBName, where);
            int pageCount = count % pSize == 0 ? count / pSize : count / pSize + 1;
            pIndex = pIndex <= 0 ? 1 : pIndex;
            pIndex = pIndex > pageCount ? pageCount : pIndex;
            CommonPage page = new CommonPage(tBName, keyFile, showFile, where, orderBy, pIndex, pSize);

            Dictionary<string, object> dt = new Dictionary<string, object>();
            dt.Add("list", ViewCustomLostsDAL.VCLFindAll(page));
            dt.Add("count", count);
            dt.Add("pageCount", pageCount);
            dt.Add("pIndex", pIndex);
            return dt;
        }

        /// <summary>
        /// 此方法用于根据流失用户id查询流失措施
        /// </summary>
        /// <param name="clID"></param>
        /// <returns></returns>
        public static List<Measures> MeasursFindByCLID(int clID)
        {
            return MeasuresBLL.MeasursFindByCLID(clID);
        }

        /// <summary>
        /// 此方法用于添加流失措施
        /// </summary>
        /// <param name="clID"></param>
        /// <param name="mDesc"></param>
        /// <returns></returns>
        public static bool MeasuresAddNew(int clID, string mDesc)
        {
            return MeasuresBLL.MeasuresAddNew(clID, mDesc);
        }
    }
}
