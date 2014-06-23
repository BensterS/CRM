using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class CustomLostsBLL
    {
        /// <summary>
        /// 此方法用于成功流失
        /// </summary>
        /// <param name="clID"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static bool CustomLostsSuccess(int clID, string Content)
        {
            return CustomersBLL.CustomChangeState(CustomLostsDAL.CustomLostsFindCusID(clID))&&CustomLostsDAL.CustomLostsSuccess(clID,Content);
        }

    }
}
