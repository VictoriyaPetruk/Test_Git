using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryServicesWorkWithDB;
using Microsoft.AspNetCore.Mvc;
using Shop_Phone_MVC.Models;

namespace Shop_Phone_MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IServicesDB db;
        public BasketController(IServicesDB ado_)
        {
            db = ado_;
        }
        BasketViewModel model = new BasketViewModel();
        public IActionResult Basket()
        {
            LoadPhone();
            return View(model);
        }
        public  void LoadPhone()
        {
           model.phones= db.SelectPhoneByCustomer(db.Connection,User.Identity.Name).Result;
        }
        [HttpPost]
        public IActionResult Basket(int id)
        {


            return View();
        }
    }
}