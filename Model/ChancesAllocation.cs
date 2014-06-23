using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ChancesAllocation
    {
        public int ChanID { get; set; }
        public string ChanName { get; set; }
        public string ChanLinkMan { get; set; }
        public string ChanLinkTel { get; set; }
        public string ChanTitle { get; set; }
        public string ChanCreateDate { get; set; }
        public int ChanDueMan { get; set; }
        public string UserName { get; set; }
        public int ChanState { get; set; }

        public ChancesAllocation() { }

        public ChancesAllocation(int chanID, string chanName, string chanLinkMan, string chanLinkTel, string chanTitle, string chanCreateDate, int chanDueMan, string userName)
        {
            this.ChanID = chanID;
            this.ChanName = chanName;
            this.ChanLinkMan = chanLinkMan;
            this.ChanLinkTel = chanLinkTel;
            this.ChanTitle = chanTitle;
            this.ChanCreateDate = chanCreateDate;
            this.ChanDueMan = chanDueMan;
            this.UserName = userName;
        }
    }
}
