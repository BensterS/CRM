using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class MeasuresBLL
    {
        /// <summary>
        /// 此方法用于根据流失用户id查询流失措施
        /// </summary>
        /// <param name="clID"></param>
        /// <returns></returns>
        public static List<Measures> MeasursFindByCLID(int clID)
        {
            return MeasuresDAL.MeasursFindByCLID(clID);
        }

        /// <summary>
        /// 此方法用于添加流失措施
        /// </summary>
        /// <param name="clID"></param>
        /// <param name="mDesc"></param>
        /// <returns></returns>
        public static bool MeasuresAddNew(int clID, string mDesc)
        {
            return MeasuresDAL.MeasuresAddNew(clID, mDesc);
        }
    }
}
