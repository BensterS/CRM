using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class ActivitysBLL
    {
        /// <summary>
        /// 此方法用于添加交往记录
        /// </summary>
        /// <param name="obj">要添加的交往记录对象</param>
        /// <returns></returns>
        public static bool ActivityAddNew(List<Activitys> actList)
        {
            return ActivitysDAL.ActivityAddNew(actList);
        }

        /// <summary>
        /// 此方法用于按照客户编号查询交往记录
        /// </summary>
        /// <param name="cusID"></param>
        /// <returns></returns>
        public static List<Activitys> ActivityFindByID(string cusID)
        {
            return ActivitysDAL.ActivityFindByID(cusID);
        }

        /// <summary>
        /// 此方法用于根据交往记录id删除交往记录
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        public static bool ActivityDel(int actID)
        {
            return ActivitysDAL.ActivityDel(actID);
        }

        /// <summary>
        /// 此方法用于根据交往记录id查询
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        public static Activitys ActivityFindByACTID(int actID)
        {
            return ActivitysDAL.ActivityFindByACTID(actID);
        }

        /// <summary>
        /// 此方法用于添加新的交往记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ActivitysAdd(Activitys obj)
        {
            return ActivitysDAL.ActivitysAdd(obj);
        }

        /// <summary>
        /// 此方法用于修改交往记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ActivitysEdit(Activitys obj)
        {
            return ActivitysDAL.ActivitysEdit(obj);
        }
    }
}
