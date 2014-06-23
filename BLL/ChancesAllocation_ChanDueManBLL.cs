using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class ChancesAllocation_ChanDueManBLL
    {
        /// <summary>
        /// 此方法用于查询所有的销售机会分配人
        /// </summary>
        /// <returns></returns>
        public static List<ChancesAllocation_ChanDueMan> ChancesAllocation_ChanDueManDALFindAll()
        {
            return ChancesAllocation_ChanDueManDAL.ChancesAllocation_ChanDueManDALFindAll();
        }
    }
}
