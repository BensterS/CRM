using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ViewCustomers
    {
        public string CusID { get; set; }
        public int UserID { get; set; }
        public string CusName { get; set; }
        public string CusAddress { get; set; }
        public string CusZip { get; set; }
        public string CusFax { get; set; }
        public string CusWebsite { get; set; }
        public string CusLicenceNo { get; set; }
        public string CusChieftain { get; set; }
        public int CusBankroll { get; set; }
        public int CusTurnover { get; set; }
        public string CusBank { get; set; }
        public string CusBankNo { get; set; }
        public string CusLocalTaxNo { get; set; }
        public string CusNationalTaxNo { get; set; }
        public string CusDate { get; set; }
        public int CusState { get; set; }
        public string UserName { get; set; } 


        public ViewCustomers() { }

        public ViewCustomers(string cusID, int userID, string cusName, string userName, string cusDate)
        {
            this.CusID = cusID;
            this.UserID = userID;
            this.CusName = cusName;
            this.UserName = userName;
            this.CusDate = cusDate;
        }
    }
}
