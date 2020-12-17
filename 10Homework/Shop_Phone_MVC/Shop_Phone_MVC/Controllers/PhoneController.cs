using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LibraryServicesWorkWithDB;
using LibrarySetOfClases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Phone_MVC.Filters;
using Shop_Phone_MVC.Models;

namespace Shop_Phone_MVC.Controllers
{
    [CustomerExeptionFilter]
    public class PhoneController : Controller
    {
        private readonly IServicesDB db;
        public List<ClassPhone> phones = new List<ClassPhone>();
        public List<ClassPhone> basket_phone = new List<ClassPhone>();
        List<ClassCustomer> customers = new List<ClassCustomer>();
        List<ClassBasket> users_basket = new List<ClassBasket>();
        PhonesViewModel phoneViewModel = new PhonesViewModel();
        List<PhoneViewModel> phoneViews = new List<PhoneViewModel>();
        public PhoneController(IServicesDB ado_)
        {

            db = ado_;
            // throw new Exception();
        }
        [HttpGet]
        public IActionResult Phone()
        {
            Load_Data();
            phoneViewModel = new PhonesViewModel { NameUser = User.Identity.Name, Message = "Hello", phonesview = phoneViews };
            return View(phoneViewModel);
        }
        public void Load_Data()
        {
            
            phones = db.SelectPhone(db.Connection).Result;
            foreach(ClassPhone cl in phones)
            {
                PhoneViewModel p = new PhoneViewModel();
                p.ID = cl.IDPhone;
                p.Marka = cl.Marka;
                p.Memory = cl.Memory;
                p.Model = cl.Model;
                p.Price = cl.Price;
                p.Sourse = "~/images/phone.jpg";
                p.Description = cl.Desc;
                p.Count = cl.Count;
                p.Camera = cl.Camera;
                p.Battery = p.Battery;
                phoneViews.Add(p);
            }
        }
       
        [HttpPost]
        public IActionResult Phone(int id)
        {
            Load_Data();
            if (User.Identity.Name ==null)
            {
                phoneViewModel.Message = "You need to registration";
                phoneViewModel = new PhonesViewModel { NameUser = User.Identity.Name, Message = "Hello", phonesview = phoneViews };
                return View(phoneViewModel);
                
            }
            else
            {
                for (int i = 0; i < phones.Count; i++)
                {
                    if (phones[i].IDPhone == id)
                    {
                        AddProductToBasket(id);
                        phoneViewModel = new PhonesViewModel { NameUser = User.Identity.Name, Message = "Phone is aded to basket", phonesview = phoneViews };
                        break;
                    }
                }
                return View(phoneViewModel);
            }
           
            
        }
        
        public void AddProductToBasket(int id_phone)
        {
            bool f = true;
            customers= db.SelectCustomer(db.Connection).Result;
            users_basket = db.SelectUsersBasket(db.Connection).Result;
            foreach (ClassCustomer cl in customers)
            {if(cl.Login.Trim()==User.Identity.Name)
                { foreach(ClassBasket b in users_basket)
                    {
                        if(b.Login_U.Trim()==User.Identity.Name)
                        {
                            db.InsertInBasketPhone(db.Connection, cl.IDcustomer, id_phone).Wait();f = false; break;
                        }
                    }
                    if (f == true)
                    {
                        db.InsertInBasketID(db.Connection, cl.IDcustomer).Wait();
                        db.InsertInBasketPhone(db.Connection, cl.IDcustomer, id_phone).Wait(); break;
                    }
                }
            }
            
        }
       
    }
}