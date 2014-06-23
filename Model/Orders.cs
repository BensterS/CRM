using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Orders
    {
		public int OrderID { get; set; }  
		public string CusID { get; set; }  
		public string OrderDate { get; set; }

        public Orders() { }

        public Orders(string cusid, string orderDate)
        {
            this.CusID = cusid;
            this.OrderDate = orderDate;
        }
    }
}