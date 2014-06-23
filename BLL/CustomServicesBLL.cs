using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class CustomServicesBLL
    {
                //创建一个服务
        public static int Insert(CustomServices c)
        {
            return CustomServicesDAL.Insert(c);
        }

                //设置一个指派人，修改客户服务表中的指派人ID，设置指派人的时间，服务状态，
        public static int UpdateCSDue(string CSDueID, string CSID)
        {
            return CustomServicesDAL.UpdateCSDue(CSDueID,CSID);
        }

                //服务处理，修改客户服务表中的服务处理，设置服务处理的时间，服务状态，
        public static int UpdateCSDeal(string CSDeal, string CSID)
        {
            return CustomServicesDAL.UpdateCSDeal(CSDeal, CSID);
        }

                //修改处理结果
        public static int UpdateCSResult(CustomServices c)
        {
            return CustomServicesDAL.UpdateCSResult(c);
        }
    }
}
