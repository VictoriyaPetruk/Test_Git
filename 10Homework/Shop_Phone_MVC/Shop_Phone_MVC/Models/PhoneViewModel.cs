using LibrarySetOfClases;
using DBInterfaces;
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
