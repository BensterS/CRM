using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Chances
    {
        public int ChanID { get; set; }
        public string ChanName { get; set; }
        public int ChanRate { get; set; }
        public string ChanLinkMan { get; set; }
        public string ChanLinkTel { get; set; }
        public string ChanTitle { get; set; }
        public string ChanDesc { get; set; }
        public int ChanCreateMan { get; set; }
        public string ChanCreateDate { get; set; }
        public int ChanDueMan { get; set; }
        public string ChanDueDate { get; set; }
        public int ChanState { get; set; }
        public string ChanError { get; set; }

        public Chances() { }

        public Chances(int chanID, string chanName, int chanRate, string chanLinkMan, string chanLinkTel, string chanTitle, string chanDesc, int chanCreateMan, string chanCreateDate) 
        {
            this.ChanID = chanID;
            this.ChanName = chanName;
            this.ChanRate = chanRate;
            this.ChanLinkMan = chanLinkMan;
            this.ChanLinkTel = chanLinkTel;
            this.ChanTitle = chanTitle;
            this.ChanDesc = chanDesc;
            this.ChanCreateMan = chanCreateMan;
            this.ChanCreateDate = chanCreateDate;
        }

        public Chances(int chanID, string chanName, int chanRate, string chanLinkMan, string chanLinkTel, string chanTitle, string chanDesc, int chanCreateMan, string chanCreateDate, int chanDueMan, string chanDueDate, int chanState, string chanError)
        {
            this.ChanID = chanID;
            this.ChanName = chanName;
            this.ChanRate = chanRate;
            this.ChanLinkMan = chanLinkMan;
            this.ChanLinkTel = chanLinkTel;
            this.ChanTitle = chanTitle;
            this.ChanDesc = chanDesc;
            this.ChanCreateMan = chanCreateMan;
            this.ChanCreateDate = chanCreateDate;
            this.ChanDueMan = chanDueMan;
            this.ChanDueDate = chanDueDate;
            this.ChanState = chanState;
            this.ChanError = chanError;
        }
    }
}
