using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ChancesAllocation_ChanDueMan
    {
        public int ChanDueMan { get; set; }     //分配人id
        public string UserName { get; set; }    //分配人

        public ChancesAllocation_ChanDueMan() { }

        public ChancesAllocation_ChanDueMan(int chanDueMan, string userName)
        {
            this.ChanDueMan = chanDueMan;
            this.UserName = userName;
        }
    }
}
