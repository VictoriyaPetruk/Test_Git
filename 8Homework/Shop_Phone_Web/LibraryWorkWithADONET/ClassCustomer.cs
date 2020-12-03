using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWorkWithADONET
{
    public class ClassCustomer
    {
        private int id;
        private string name;
        private string lname;
        private string email;
        private string number;
        private string country;
        private string city;
        private string login;
        private string password;

        //можно добавить парль и логин, а в корзину id пользовтаеля и товар
        public int IDcustomer { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Lname { get { return lname; } set { lname = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Number { get { return number; } set { number = value; } }

        public string Country { get { return country; } set { country = value; } }

        public string City { get { return city; } set { city = value; } }
        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }
        public ClassCustomer()
            {
            id = 0;
            name = "";
            lname = "";
            email = "";
            number = "";
            country = "";
            city = "";
            password = "";
            Login = "";
            }

    }
}
