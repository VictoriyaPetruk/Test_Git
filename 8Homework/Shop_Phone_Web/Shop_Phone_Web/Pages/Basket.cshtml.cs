using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shop_Phone_Web.Pages
{
    public class BasketModel : PageModel
    {
        public void OnGet()
        {
            var user = HttpContext.User.Identity.Name;
        }
    }
}