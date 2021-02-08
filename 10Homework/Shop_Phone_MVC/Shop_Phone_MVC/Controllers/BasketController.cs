using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shop_Phone_MVC.Filters;
using Shop_Phone_MVC.Models;

namespace Shop_Phone_MVC.Controllers
{
    [CustomerExeptionFilter]
    //для отображения страницы корзины
    public class BasketController : Controller
    {
        private readonly IServiceDBBasket dbB;
        BasketViewModel model = new BasketViewModel();
        public BasketController(IServiceDBBasket ado_)
        {
            dbB = ado_;
        }
        public IActionResult Basket()
        {
            LoadPhone();
            if (model.phones.Count==0)
            { ViewBag.Message = "У вас нет товаров"; }
            return View(model);
        }
       
        public  void LoadPhone()
        {
           model.phones= dbB.SelectPhoneByCustomer(User.Identity.Name).Result;
        }
        [HttpPost]
        public IActionResult Basket(int id)
        {
            dbB.DeleteFromBasket(id, User.Identity.Name).Wait();
            LoadPhone();
            return View(model);
        }
    }
}