using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using  LibraryWorkWithADONET;
using Microsoft.AspNetCore.Http;

namespace Shop_Phone_Web.Pages
{
    public class IndexModel : PageModel
    {
       ClassADONET adonet = new ClassADONET();
        public string Message { get; set; }
        public string Name { get; set; }
        public List<ClassPhone> phones = new List<ClassPhone>();
        public void OnGet()
        {
            Load_Data();
            Name = "Vika";
            Message = "Hello "+Name;
        }
        public List<ClassPhone> basket_phone = new List<ClassPhone>();
        public void  OnPost(int id)
        {
            Name = "Vika";
            SqlConnection conn = adonet.GetConncection();
            phones = adonet.SelectPhone(conn).Result;
            if (Name == "")
            {
                Message = "You need to registration";
            }
            else
            {
                for (int i = 0; i < phones.Count; i++)
                {
                    if (phones[i].IDPhone == id)
                    {
                        basket_phone.Add(phones[i]); Message = "Phone is aded to basket"; break;
                    }
                }
            }
           

        }
        
        public void Load_Data()
        {
            SqlConnection conn = adonet.GetConncection();
            phones=adonet.SelectPhone(conn).Result;
        }
       
    }
}
