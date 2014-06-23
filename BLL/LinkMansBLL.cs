using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class LinkMansBLL
    {
        /// <summary>
        /// 从方法用于添加新的联系人
        /// </summary>
        /// <param name="obj">新的联系人对象</param>
        /// <returns></returns>
        public static bool LinkManAddNew(LinkMans obj){
            return LinkMansDAL.LinkManAddNew(obj);
        }

        /// <summary>
        /// 此方法用于根据客户编号查询联系人
        /// </summary>
        /// <param name="cusID"></param>
        /// <returns></returns>
        public static List<LinkMans> LinkMansFindAll(string cusID)
        {
            return LinkMansDAL.LinkMansFindAll(cusID);
        }

        /// <summary>
        /// 此方法用于根据交往记录id删除联系人
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        public static bool LinkManDel(int lmID)
        {
            return LinkMansDAL.LinkManDel(lmID);
        }

        /// <summary>
        /// 此方法用于根据联系id查询
        /// </summary>
        /// <param name="actID"></param>
        /// <returns></returns>
        public static LinkMans LinkManFindByLMID(int lmID)
        {
            return LinkMansDAL.LinkManFindByLMID(lmID);
        }

        /// <summary>
        /// 此方法用于添加新的联系人
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool LinkManAdd(LinkMans obj)
        {
            return LinkMansDAL.LinkManAdd(obj);
        }

        /// <summary>
        /// 此方法用于修改联系人
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool LinkManEdit(LinkMans obj)
        {
            return LinkMansDAL.LinkManEdit(obj);
        }
    }
}
