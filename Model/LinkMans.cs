using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class LinkMans
    {
		public int LMID { get; set; }  
		public string CusID { get; set; }  
		public string LMName { get; set; }  
		public string LMSex { get; set; }  
		public string LMDuty { get; set; }  
		public string LMMobileNo { get; set; }  
		public string LMOfficeNo { get; set; }  
		public string LMMemo { get; set; }

        public LinkMans() { }

        public LinkMans(string cusID, string lmName, string lmSex, string lmDuty, string lmMobileNo, string lmOfficeNo, string lmMemo) {
            this.CusID = cusID;
            this.LMName = lmName;
            this.LMSex = lmSex;
            this.LMDuty = lmDuty;
            this.LMMobileNo = lmMobileNo;
            this.LMOfficeNo = lmOfficeNo;
            this.LMMemo = lmMemo;
        }
    }
}