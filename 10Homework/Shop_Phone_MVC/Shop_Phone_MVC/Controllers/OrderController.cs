using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBInterfaces;
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
        private readonly IServiceDBOrder dbO;
        private readonly IServiceDBBasket dbB;
        private readonly IServiceDBCustomer dbC;
        List<ClassPhone> phones=new List<ClassPhone>();
        MakeOrderViewModel modelOrder = new MakeOrderViewModel();
        List<Customer> customers = new List<Customer>();
        ConfirmationViewModel model_confrim = new ConfirmationViewModel();
        public OrderController(IServiceDBOrder dbO, IServiceDBBasket dbB, IServiceDBCustomer dbC)
        {
            this.dbO = dbO;
            this.dbB = dbB;
            this.dbC = dbC;
           
        }
        //public OrderController(IServiceDBOrder dbO, List<ClassPhone> phones, IServiceDBBasket dbB, IServiceDBCustomer dbC)
        //{
        //    this.phones = phones;
        //    this.dbO = dbO;
        //    this.dbB = dbB;
        //    this.dbC = dbC;
        //}

       [HttpGet]
        public IActionResult MakeOrder()
        {
            modelOrder=LoadData();
            return View(modelOrder);
        }

       virtual public MakeOrderViewModel LoadData()
        {
            MakeOrderViewModel modelOrder = new MakeOrderViewModel();
            phones = dbB.SelectPhoneByCustomer( User.Identity.Name).Result;
            var fio = dbC.GetCustomer(User.Identity.Name).Result.ToList();
            modelOrder.Name = fio[0];
            modelOrder.Lname = fio[1];
            modelOrder.Count = phones.Count;
            modelOrder.Sum = GetSum();
            return modelOrder;
        }
        public double GetSum()
        {
            double Sum =0;
            foreach (ClassPhone p in phones)
            {
                Sum = Sum + p.Price;
            }
            return Sum;
        }
        [HttpPost]
        public IActionResult MakeOrder(string city,string numver_dep)
        {
            if (ModelState.IsValid)
            {
                LoadData();
                //внести заказ в две табл +удалить товары с корзины +уменьшить колличество
                 dbO.InsertOrderId(User.Identity.Name,city+". " + numver_dep).Wait();
                foreach (ClassPhone p in phones)
                {
                    dbO.InsertOrderPhone(User.Identity.Name,p.IDPhone).Wait();
                    dbB.DeleteFromBasket( p.IDPhone, User.Identity.Name).Wait();//переделать ,нужно удалять и по юзеру
                    dbO.ReduceCount( p.IDPhone,p.Count).Wait();
                }
                return RedirectToAction("Confirmation", "Order");

            }
            else { ModelState.AddModelError("", "Некорректные логин и(или) пароль"); LoadData(); return View(modelOrder); }
        }
        [HttpGet]
        public IActionResult Confirmation()
        {
            model_confrim.ID = dbO.GetNumberOrder( User.Identity.Name).Result;
            return View(model_confrim);
        }
    }
}