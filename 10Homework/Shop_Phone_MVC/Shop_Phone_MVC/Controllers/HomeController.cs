using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DBInterfaces;

using LibrarySetOfClases;

using Microsoft.AspNetCore.Mvc;
using Shop_Phone_MVC.Filters;
using Shop_Phone_MVC.Models;

namespace Shop_Phone_MVC.Controllers
{   [CustomerExeptionFilter]
    public class HomeController : Controller
    {
        //private readonly IServicesDB  db;
     
        public  HomeController()
        {
            //db = ado_;
           // throw new Exception();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Content(User.Identity.Name);
            // return View();
        }
        
        public IActionResult MakeOrder()
        {
            return View();
        }
       
        public IActionResult About()
        {
            ViewData["Message"] = "Про наш сайт";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Наши контакты";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
