using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Shop_Phone_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Http;

namespace Shop_Phone_MVC.Filters
{
    public class CustomerExeptionFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            var exeption = context.Exception;
            if(exeption is Exception)
            {
                
                context.Result = new ViewResult { ViewName = "Error" };
            }
            
        }
    }
}
