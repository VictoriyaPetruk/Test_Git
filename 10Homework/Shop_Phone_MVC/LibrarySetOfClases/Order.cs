using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySetOfClases
{
    public class Order
    {
        public int IDOrder { get; }
        public int IDCustomer { get; set; }
        public DateTime DateOrder { get; set; }
        public string Adress { get; set; }
        public Order()
        {
            IDCustomer= 0;
            DateOrder = new DateTime(2020,11,15); Adress = "KHARKIV";
        }
    }
}
