using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWorkWithADONET
{
    class ClassBasket
    {
        private int id;
        private int idcustomer;
        public int IDBasket { get {return id; } }
        public int IDCustomer { get { return idcustomer; } set { idcustomer = value; } }
        public ClassBasket()
        {
            
            idcustomer = 0;
        }
    }
   public  class ClassBasketPhone
    {
        private int id;
        private int idbasket;
        private int idphone;
        public int ID { get { return id; }  }
        public int IDBasket { get { return idbasket; } set { idbasket = value; } }
        public int IDPhone { get { return idphone; } set { idphone = value; } }
        public ClassBasketPhone()
        {
            idbasket = 0;
            idphone = 0;
        }
    }
}
