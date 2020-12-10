using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibraryServicesWorkWithDB;
using LibrarySetOfClases;
using LibraryWorkWithADONET;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Phone_MVC.Models;

namespace Shop_Phone_MVC.Controllers
{
    public class AccountController : Controller
    { //  private ClassCustomer customer = new ClassCustomer();
       private readonly IServicesDB db;
        public  AccountController(IServicesDB ado_)
        {
            db = ado_;
        }
      
        RegistrationViewModel model = new RegistrationViewModel();
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
                ClassCustomer customer = new ClassCustomer { Name = model.Name, Lname = model.Lname, Email = model.Email, Number = model.Number, Country = model.Country, Login = model.Login, Password = model.Password,City=model.City };
                // model.OnPost(name, lname, email, number, country, city, login, password);
                SqlConnection conn = db.Connection;
                db.InsertCustomer(conn, customer).Wait();
                await Authenticate(model.Login);
                return RedirectToAction("Entrance", "Account");
               
            }
            else { ModelState.AddModelError("", "Некорректные логин и(или) пароль"); model.Message = "Error during registration"; return View(model); }
        }
        
        List<ClassCustomer> customers = new List<ClassCustomer>();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entrance(EntranceViewModel loginmodel)
        {
            bool f = true;
            if (ModelState.IsValid)
            { //получить всех пользователей
              //сравнить
                customers =await db.SelectCustomer(db.Connection);
                foreach(ClassCustomer cl in customers)
                {
                    if(cl.Login.Trim()==loginmodel.Login&&cl.Password.Trim() == loginmodel.Password)
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
        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Delete(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add delete logic here

        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        //}
    }
}