using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CommonPage
    {
        public string TbName { get; set; } //表名
        public string KeyFile { get; set; } //主键名
        public string ShowFile { get; set; } //字段名
        public string Where { get; set; }  //条件
        public string OrderBy { get; set; } //排序
        public int PIndex { get; set; } //当前页
        public int PSize { get; set; }  //每页大小

        public CommonPage()
        {
            this.TbName = "";
            this.KeyFile = "";
            this.ShowFile = "*";
            this.Where = "";
            this.OrderBy = "";
            this.PIndex = 1;
            this.PSize = 8;
        }

        public CommonPage(string tBName, string keyFile, string showFile, string where, string orderBy, int pIndex, int pSize) 
        {
            this.TbName = tBName;
            this.KeyFile = keyFile;
            this.ShowFile = showFile;
            this.Where = where;
            this.OrderBy = orderBy;
            this.PIndex = pIndex;
            this.PSize = pSize;
        }
    }
}
