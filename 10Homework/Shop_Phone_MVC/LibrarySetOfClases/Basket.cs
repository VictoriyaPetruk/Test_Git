using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySetOfClases
{
   public class Basket
    {
        public int IDBasket { get; set; }
        public string Login_U { get; set; }
        public int IDCustomer { get; set; }
       
    }
   public  class ClassBasketPhone
    {
        public int ID { get; }
        public int IDBasket { get; set; }
        public int IDPhone { get; set; }
       
    }
}
