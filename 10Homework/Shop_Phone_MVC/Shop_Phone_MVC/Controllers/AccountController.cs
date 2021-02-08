using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DBInterfaces;
using LibrarySetOfClases;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Phone_MVC.Filters;
using Shop_Phone_MVC.Models;

namespace Shop_Phone_MVC.Controllers
{//для отображения страниц входа в систему и регестрации
    [CustomerExeptionFilter]
    public class AccountController : Controller
    { 
        private readonly IServiceDBCustomer dbC;
        private  RegistrationViewModel model;
        private List<Customer> customers;
        public  AccountController(IServiceDBCustomer ado_)
        {
            dbC = ado_;
            model = new RegistrationViewModel();
            customers= new List<Customer>();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            model.OnGet();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Message = "You are registrate";
                Customer customer = new Customer { Name = model.Name, Lname = model.Lname, Email = model.Email, Number = model.Number, Country = model.Country, Login = model.Login, Password = model.Password,City=model.City };
                
                dbC.InsertCustomer( customer).Wait();
                await Authenticate(model.Login);
                return RedirectToAction("Entrance", "Account");
               
            }
            else { ModelState.AddModelError("", "Некорректные логин и(или) пароль"); model.Message = "Error during registration"; return View(model); }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entrance(EntranceViewModel loginmodel)
        {
            bool f = true;
            if (ModelState.IsValid)
            { //получить всех пользователей
              //сравнить
                customers =await dbC.SelectCustomer();
                foreach(Customer cl in customers)
                {
                    if(cl.Login==loginmodel.Login&&cl.Password == loginmodel.Password)
                    {
                        f = false;
                        await Authenticate(loginmodel.Login);
                        return RedirectToAction("Phone", "Phone");
                        
                    }
                }
                if(f==true)
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }
           return View(loginmodel);
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        [HttpGet]
        public IActionResult Entrance()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Entrance", "Account");
        }
       
        
      
    }
}