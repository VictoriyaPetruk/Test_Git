using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Phone_MVC.Models
{
    public class MakeOrderViewModel
    {
        public string Name { get; set; }
        public string Lname { get; set; }
        public double Sum { get; set; }
        public int Count;
        [Required]
        [Display(Name = "Город")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Номер отделения")]
        public string Number_Deartament { get; set; }
       

    }
}
