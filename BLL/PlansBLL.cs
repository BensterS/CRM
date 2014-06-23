using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class PlansBLL
    {
        /// <summary>
        /// 此方法用于添加开发计划
        /// </summary>
        /// <param name="chanId">销售机会id</param>
        /// <param name="planContent">开发计划</param>
        /// <returns></returns>
        public static int PlansAddNew(int chanId, string planContent)
        {
            return PlansDAL.PlansAddNew(chanId, planContent);
        }

        /// <summary>
        /// 此方法用于添加执行计划
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="planResultContent"></param>
        /// <returns></returns>
        public static int PlanResultAddNew(string planId, string planResultContent)
        {
            return PlansDAL.PlanResultAddNew(planId, planResultContent);
        }

        /// <summary>
        /// 此方法用于客户开发失败
        /// </summary>
        /// <param name="chanId"></param>
        /// <param name="chancesError"></param>
        /// <returns></returns>
        public static int PlanError(int chanId, string chancesError)
        {
            return ChancesBLL.PlanError(chanId,chancesError);
        }

        /// <summary>
        /// 此方法用于客户开发成功
        /// </summary>
        /// <param name="cus">要添加的客户对象</param>
        /// <param name="lm">要添加的联系人对象</param>
        /// <param name="od">要添加的订单对象</param>
        /// <param name="act">要添加的交往记录对象</param>
        /// <returns></returns>
        public static bool PlanSuccess(int chanID)
        {
            Chances chan = ChancesBLL.ChanFindById(chanID);
            //判断销售机会是否修改成功
            if (null == chan)
            {
                return false;
            }

            List<Plans> plList = PlansDAL.PlanFindByID(chanID);
            //判断客户开发计划是否为空
            if (null == plList) 
            {
                return false;
            }

            //给要添加的客户初始化值
            Customers cus = new Customers();
            cus.CusID = CustomersBLL.GetCusID();
            cus.UserID = chan.ChanDueMan;
            cus.CusName = chan.ChanName;

            //给要添加的联系人初始化值
            LinkMans lm = new LinkMans();
            lm.CusID = cus.CusID;
            lm.LMName = chan.ChanName;
            lm.LMMobileNo = lm.LMOfficeNo = chan.ChanLinkTel;

            //给要添加的订单初始化值
            Orders od = new Orders();
            od.CusID = cus.CusID;
            od.OrderDate = "getdate()";

            //给要添加的交往记录初始化值
            List<Activitys> actList = new List<Activitys>();
            for (int i = 0; i < plList.Count; i++)
            {
                Activitys act = new Activitys();
                act.CusID = cus.CusID;
                act.ActDate = plList[i].PlanResultDate;
                act.ActTitle = plList[i].PlanResult;
                actList.Add(act);
            }

            return CustomersBLL.CustomerAddNew(cus) && LinkMansBLL.LinkManAddNew(lm) && OrdersBLL.OrderAddNew(od) && ActivitysBLL.ActivityAddNew(actList) && ChancesBLL.PlanSuccess(chanID);
        }
    }
}
