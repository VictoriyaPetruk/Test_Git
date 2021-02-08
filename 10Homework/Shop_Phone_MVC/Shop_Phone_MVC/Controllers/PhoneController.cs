using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DBInterfaces;
using LibrarySetOfClases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Phone_MVC.Filters;
using Shop_Phone_MVC.Models;

namespace Shop_Phone_MVC.Controllers
{
    [CustomerExeptionFilter]
    //для отображения главной страницы покупки телефонов
    public class PhoneController : Controller
    {
        private readonly IServiceDBPhone dbP;
        private readonly IServiceDBBasket dbB;
        private readonly IServiceDBCustomer dbC;
        private List<ClassPhone> phones = new List<ClassPhone>();
        private List<ClassPhone> basket_phone = new List<ClassPhone>();
        private List<Customer> customers = new List<Customer>();
        private List<Basket> users_basket = new List<Basket>();
        private PhonesViewModel phoneViewModel = new PhonesViewModel();
        private List<PhoneViewModel> phoneViews = new List<PhoneViewModel>();
        public PhoneController(IServiceDBPhone dbP, IServiceDBBasket dbB, IServiceDBCustomer dbC)
        {
            this.dbP = dbP;
            this.dbC = dbC;
            this.dbB = dbB;
            //проверка отображения error-страницы
            // throw new Exception();
        }
        [HttpGet]
        public IActionResult Phone()
        {
            phoneViews=Load_Data();
            phoneViewModel = new PhonesViewModel { NameUser = User.Identity.Name, Message = "Hello", phonesview = phoneViews };
            return View(phoneViewModel);
        }
        public List<PhoneViewModel> Load_Data()
        {
            List<PhoneViewModel> phoneViews = new List<PhoneViewModel>();
            phones = dbP.SelectPhone().Result;
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
            return phoneViews; 
        }
       
        [HttpPost]
        public IActionResult Phone(int id)
        {
            phoneViews=Load_Data();
            if (User.Identity.Name ==null)
            {
                phoneViewModel.Message = "You need to registration";
                phoneViewModel = new PhonesViewModel { NameUser = User.Identity.Name, Message = "Sorry.You can`t buy phones.", phonesview = phoneViews };
                return View(phoneViewModel);
                
            }
            else
            {
                for (int i = 0; i < phones.Count; i++)
                {
                    if (phones[i].IDPhone == id)
                    {
                        AddProductToBasket(id);
                        phoneViewModel = new PhonesViewModel { NameUser ="", Message = "Phone is aded to basket", phonesview = phoneViews };
                        break;
                    }
                }
                return View(phoneViewModel);
            }
            
        }
        
        public void AddProductToBasket(int id_phone)
        {
            bool f = true;
            customers= dbC.SelectCustomer().Result;
            users_basket = dbB.SelectUsersBasket().Result;
            foreach (Customer cl in customers)
            {if(cl.Login.Trim()==User.Identity.Name)
                { foreach(Basket b in users_basket)
                    {
                        if(b.Login_U.Trim()==User.Identity.Name)
                        {
                            dbB.InsertInBasketPhone( cl.IDcustomer, id_phone).Wait();f = false; break;
                        }
                    }
                    if (f == true)
                    {
                        dbB.InsertInBasketID(cl.IDcustomer).Wait();
                        dbB.InsertInBasketPhone( cl.IDcustomer, id_phone).Wait(); break;
                    }
                }
            }
            
        }
       
    }
}