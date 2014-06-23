using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ViewCustomLosts
    {
        public int CLID { get; set; }  
		public string CusID { get; set; }  
		public string CLOrderDate { get; set; }  
		public string CLDate { get; set; }  
		public string CLEnterDate { get; set; }  
		public string CLReason { get; set; }  
		public int CLState { get; set; }
        public string CusName { get; set; }

        public ViewCustomLosts() { }

        public ViewCustomLosts(string cusID, string cLOrderDate, string cLDate, string cLEnterDate, string cLReason, int cLState,string cusName)
        {
            this.CusID = cusID;
            this.CLOrderDate = cLOrderDate;
            this.CLDate = cLDate;
            this.CLEnterDate = cLEnterDate;
            this.CLReason = cLReason;
            this.CLState = cLState;
            this.CusName = CusName;
        }
    }
}
