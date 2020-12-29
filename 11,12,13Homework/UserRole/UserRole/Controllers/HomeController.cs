using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserRole.Models;

namespace UserRole.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //try
            //{
               string role= User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value??"Вы не авторизовались";
                ViewBag.Role = $"ваша роль: {role}";
               return View();
            //}
            //catch { ViewBag.Role = $"Вы не авторизовались"; return View(); }
           
        }
        //[Authorize(Roles = "user, admin")]
        [Authorize(Roles = "user")]
        public IActionResult Privacy()
        {
            return Content("Вход только для пользователя");
           // return View();
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult About()
        {
            ModelUsers model = new ModelUsers();
           // model.ListUsers = _context.Users.Select(x =>x).ToList();
            var users = (from user in _context.Users.Include(x => x.Role)
                       select user);
            model.ListUsers = users.ToList();
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Message()
        {
            return View();
        }
    }
}
