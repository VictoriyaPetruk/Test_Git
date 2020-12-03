using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using LibraryWorkWithADONET;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shop_Phone_Web.Pages
{
    public class RegistrationModel : PageModel
    {   public string Message { get; set; }
        public void OnGet()
        {
            Message = null;
        }
       
        public void OnPost(string name,string lname,string email,string number,string country,string city,string login,string password)
        {
            try
            {
                ClassADONET ado = new ClassADONET();
                SqlConnection conn = ado.GetConncection();
                ClassCustomer customer = new ClassCustomer();
                customer.City = city;
                customer.Country = country;
                customer.Email = email;
                customer.Lname = lname;
                customer.Name = name;
                customer.Number = number;
                customer.Password = password;
                customer.Login = login;
                customer.IDcustomer = 1;
                ado.InsertCustomer(conn, customer).Wait();
                Message = "Вы зарегестрировались";
            }
            catch(Exeption ex)
            {
                Message = "Возникли ошибки с корректностью данных.Попробуйте еще раз.";
            }
        }
    }

    [Serializable]
    internal class Exeption : Exception
    {
        public Exeption()
        {
        }

        public Exeption(string message) : base(message)
        {
        }

        public Exeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Exeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}