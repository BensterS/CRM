using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ViewCustomServices
    {
        public int CSID { get; set; } //客户服务处理ID
        public string CSTitle { get; set; } //概要
        public string CSCreateDate { get; set;}    //创建服务时间
        public string UserName { get; set; }    //创建人姓名
        public string STName { get; set; }  //服务类型
        public string CusName { get; set; } //客户名称

        public int STID { get; set; } //服务类型
        public string CusID { get; set; } //客户编号
        public int CSState { get; set; } //服务状态
        public string CSDesc { get; set; }  //服务请求
        public int CSCreateID { get; set; }    //创建人ID
        public int CSDueID { get; set; }   //指派人ID
        public string CSDueDate { get; set; }   //指派时间
        public string CSDeal { get; set; }  //服务处理
        public string CSDealDate { get; set; }  //处理时间
        public string CSResult { get; set; }    //处理结果
        public int CSSatisfy { get; set; } //满意度
    }
}
