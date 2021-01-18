using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryServicesWorkWithDB;
using LibrarySetOfClases;
using Microsoft.AspNetCore.Mvc;
using Shop_Phone_MVC.Filters;
using Shop_Phone_MVC.Models;

namespace Shop_Phone_MVC.Controllers
{
    [CustomerExeptionFilter]
    //для отображения страницы оформления заказа и страницы подтверждения заказа
    public class OrderController : Controller
    {
        private readonly IServicesDB db;
        List<ClassPhone> phones = new List<ClassPhone>();
        MakeOrderViewModel modelOrder = new MakeOrderViewModel();
        List<ClassCustomer> customers = new List<ClassCustomer>();
        ConfirmationViewModel model_confrim = new ConfirmationViewModel();
        public OrderController(IServicesDB ado_)
        {
            db = ado_;
        }
        [HttpGet]
        public IActionResult MakeOrder()
        {
            LoadData();
            return View(modelOrder);
        }
        public void LoadData()
        {
            double Sum = 0;
            phones = db.SelectPhoneByCustomer(db.Connection, User.Identity.Name).Result;
            var fio = db.GetCustomer(db.Connection, User.Identity.Name).Result.ToList();
            modelOrder.Name = fio[0];
            modelOrder.Lname = fio[1];
            modelOrder.Count = phones.Count;
            foreach (ClassPhone p in phones)
            {
                Sum = Sum + p.Price;
            }
            modelOrder.Sum = Sum;
        }
        [HttpPost]
        public IActionResult MakeOrder(string city,string numver_dep)
        {
            if (ModelState.IsValid)
            {
                LoadData();
                //внести заказ в две табл +удалить товары с корзины +уменьшить колличество
                 db.InsertOrderId(db.Connection,User.Identity.Name,city+". " + numver_dep).Wait();
                foreach (ClassPhone p in phones)
                {
                    db.InsertOrderPhone(db.Connection, User.Identity.Name,p.IDPhone).Wait();
                    db.DeleteFromBasket(db.Connection, p.IDPhone, User.Identity.Name).Wait();//переделать ,нужно удалять и по юзеру
                    db.ReduceCount(db.Connection, p.IDPhone,p.Count).Wait();
                }
                return RedirectToAction("Confirmation", "Order");

            }
            else { ModelState.AddModelError("", "Некорректные логин и(или) пароль"); LoadData(); return View(modelOrder); }
        }
        [HttpGet]
        public IActionResult Confirmation()
        {
            model_confrim.ID = db.GetNumberOrder(db.Connection, User.Identity.Name).Result;
            return View(model_confrim);
        }
    }
}