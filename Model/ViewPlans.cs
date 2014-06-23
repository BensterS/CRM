using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ViewPlans
    {
        public string PlanID { get; set; }
        public int ChanID { get; set; }
        public string PlanDate { get; set; }
        public string PlanContent { get; set; }
        public string PlanResultDate { get; set; }
        public string PlanResult { get; set; }
        public string ChanError { get; set; }
        public int ChanState { get; set; }

        public ViewPlans() { }

        public ViewPlans(string planID, int chanID, string planDate, string planContent, string planResultDate, string planResult, string chanError, int chanState)
        {
            this.PlanID = planID;
            this.ChanID = chanID;
            this.PlanDate = planDate;
            this.PlanContent = planContent;
            this.PlanResultDate = planResultDate;
            this.PlanResult = planResult;
            this.ChanError = chanError;
            this.ChanState = chanState;
        }
    }
}
