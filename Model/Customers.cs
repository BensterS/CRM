using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Customers
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

        public Customers() { }

        public Customers(string cusID, int userID, string cusName, string cusAddress, string cusZip, string cusFax, string cusWebsite, string cusLicenceNo, string cusChieftain, int cusBankroll, int cusTurnover, string cusBank, string cusBankNo, string cusLocalTaxNo, string cusNationalTaxNo, string cusDate, int cusState)
        {
            this.CusID = cusID;
            this.UserID = userID;
            this.CusName = cusName;
            this.CusAddress = cusAddress;
            this.CusZip = cusZip;
            this.CusFax = cusFax;
            this.CusWebsite = cusWebsite;
            this.CusLicenceNo = cusLicenceNo;
            this.CusChieftain = cusChieftain;
            this.CusBankroll = cusBankroll;
            this.CusTurnover = cusTurnover;
            this.CusBank = cusBank;
            this.CusBankNo = cusBankNo;
            this.CusLocalTaxNo = cusLocalTaxNo;
            this.CusNationalTaxNo = cusNationalTaxNo;
            this.CusDate = cusDate;
            this.CusState = cusState;
        }
    }
}