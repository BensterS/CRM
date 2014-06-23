using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Activitys
    {
		public int ActID { get; set; }  
		public string CusID { get; set; }  
		public string ActDate { get; set; }  
		public string ActAdd { get; set; }  
		public string ActTitle { get; set; }  
		public string ActMemo { get; set; }  
		public string ActDesc { get; set; }

        public Activitys() { }

        public Activitys(string cusID, string actDate, string actAdd, string actTitle, string actMemo, string actDesc)
        {
            this.CusID = cusID;
            this.ActDate = actDate;
            this.ActAdd = actAdd;
            this.ActTitle = actTitle;
            this.ActMemo = actMemo;
            this.ActDesc = actDesc;
        }
    }
}