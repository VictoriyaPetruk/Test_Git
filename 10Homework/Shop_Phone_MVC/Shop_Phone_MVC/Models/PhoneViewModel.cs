using LibrarySetOfClases;
using LibraryWorkWithADONET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Phone_MVC.Models
{
    public class PhoneViewModel
    {
        public int ID{ get; set; }
        public string Model { get; set; }
        public string Marka { get; set; }
        public int Camera { get; set; }
        public int Memory { get; set; }
        public int Battery { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public string Sourse { get; set; }
        //ClassADONET adonet = new ClassADONET();
       
        //public List<ClassPhone> phones = new List<ClassPhone>();
       
        //public void OnGet()
        //{
        //    SqlConnection conn = adonet.GetConncection();
        //    Load_Data(conn);
        //    NameUser = "Vika";
        //    Message = "Hello " + NameUser;
        //}
        //public List<ClassPhone> basket_phone = new List<ClassPhone>();
        //public void OnPost(int id)
        //{
        //    NameUser = "Vika";
        //    SqlConnection conn = adonet.GetConncection();
        //    phones = adonet.SelectPhone(conn).Result;
        //    if (NameUser == "")
        //    {
        //        Message = "You need to registration";
        //    }
        //    else
        //    {
        //        for (int i = 0; i < phones.Count; i++)
        //        {
        //            if (phones[i].IDPhone == id)
        //            {
        //                basket_phone.Add(phones[i]); Message = "Phone is aded to basket"; break;
        //            }
        //        }
        //    }


        //}
        //public void Load_Data(SqlConnection conn)
        //{
            
        //    phones = adonet.SelectPhone(conn).Result;
        //}
    }
    public class PhonesViewModel
    {
        private string message;
        public string NameUser { get; set; }
        public string Message { get { return message; } set
            {
                if (NameUser == null)
                {
                    message = value + ". " + "You need sign in";
                }
                else { message = value + " " + NameUser; }
            }
        }
       
        public List<PhoneViewModel> phonesview = new List<PhoneViewModel>();
    }
}
