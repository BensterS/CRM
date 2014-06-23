using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class ServiceTypeBLL
    {
                //查询出所有的服务类型
        public static List<ServiceType> Select()
        {
            return ServiceTypeDAL.Select();
        }

        //添加一个服务类型
        public static int Add(ServiceType s)
        {
            return ServiceTypeDAL.Add(s);
        }

        //删除一个服务类型
        public static int Delete(string id)
        {
            return ServiceTypeDAL.Delete(id);
        }

                //根据服务类型的ID查询出服务类型
        public static ServiceType SelectByIdServiceType(string id)
        {
            return ServiceTypeDAL.SelectByIdServiceType(id);
        }

        //根据服务类型ID修改服务类型
        public static int Update(ServiceType s)
        {
            return ServiceTypeDAL.Update(s);
        }
    }
}
