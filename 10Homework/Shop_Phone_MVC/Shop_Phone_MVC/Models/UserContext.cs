using LibrarySetOfClases;
using LibraryWorkWithADONET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Phone_MVC.Models
{
    public class UserContext
    {
        public List<ClassCustomer> customers = new List<ClassCustomer>();
        public void SetAll()
        {
            ClassADONET ado = new ClassADONET();
            //получить всех пользователей
        }
    }
}
