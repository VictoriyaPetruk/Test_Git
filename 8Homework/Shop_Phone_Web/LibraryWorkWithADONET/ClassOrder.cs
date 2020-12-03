using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWorkWithADONET
{
    public class ClassOrder
    {
        private int id;
        private int idcustomer;
        private DateTime date;
        private string adress;
        public int IDOrder { get { return id; } }
        public int IDCustomer { get { return idcustomer; } set { idcustomer = value; } }
        public DateTime DateOrder { get { return date; } set { date = value; } }
        public string Adress { get { return adress; } set { adress = value; } }
        public ClassOrder()
        {
            idcustomer = 0;
            date = new DateTime(2020,11,15); adress = "KHARKIV";
        }
    }
}
