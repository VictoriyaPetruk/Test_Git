using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryServicesWorkWithDB;
using Microsoft.AspNetCore.Mvc;
using Shop_Phone_MVC.Filters;
using Shop_Phone_MVC.Models;

namespace Shop_Phone_MVC.Controllers
{
    [CustomerExeptionFilter]
    //для отображения страницы корзины
    public class BasketController : Controller
    {
        private readonly IServicesDB db;
        BasketViewModel model = new BasketViewModel();
        public BasketController(IServicesDB ado_)
        {
            db = ado_;
        }
        public IActionResult Basket()
        {
            LoadPhone();
            if (model.phones.Count==0)
            { ViewBag.Message = "У вас не товаров"; }
            return View(model);
        }
       
        public  void LoadPhone()
        {
           model.phones= db.SelectPhoneByCustomer(db.Connection,User.Identity.Name).Result;
        }
        [HttpPost]
        public IActionResult Basket(int id)
        {
            db.DeleteFromBasket(db.Connection, id, User.Identity.Name).Wait();
            LoadPhone();
            return View(model);
        }
    }
}