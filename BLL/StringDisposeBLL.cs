using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class StringDisposeBLL
    {
        /// <summary>
        /// 将对象转换为Int32类型,转换失败返回0
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str)
        {
            return StringDisposeDAL.StrToInt(str);
        }
    }
}
