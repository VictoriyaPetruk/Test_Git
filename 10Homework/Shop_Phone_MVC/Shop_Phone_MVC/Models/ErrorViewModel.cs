using System;

namespace Shop_Phone_MVC.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
      

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}