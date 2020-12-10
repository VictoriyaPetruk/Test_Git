using LibrarySetOfClases;
using LibraryWorkWithADONET;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Phone_MVC.Models
{
    public class RegistrationViewModel
    {
        public string Message { get; set; }
       
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [MinLength(4,ErrorMessage ="Фамилия не должна быть меньше 4")]
        [Required]
        [Display(Name = "Фамилия")]
        public string Lname { get; set; }
        [Required]
        [Display(Name = "Почта")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"(\+?38(\()?0|^0)\d{2}(\))?(\-)?\d{3}(\-)?\d{2}(\-)?\d{2}", ErrorMessage = "В номере телефона могут быть только цифры и он должен быть от 10-12")]
        [Display(Name = "Номер телефона")]
        public string Number { get; set; }
        [Required]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Город")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public void OnGet()
        {
            Message = null;
        }
        //
        // [RegularExpression(@"^\w+?", ErrorMessage = "В имени могут быть только буквы")]
        public void OnPost(string name, string lname, string email, string number, string country, string city, string login, string password)
        {
            try
            {
                ClassADONET ado = new ClassADONET();
                SqlConnection conn = ado.GetConncection();
                ClassCustomer customer = new ClassCustomer();
                customer.City = city;
                customer.Country = country;
                customer.Email = email;
                customer.Lname = lname;
                customer.Name = name;
                customer.Number = number;
                customer.Password = password;
                customer.Login = login;
                customer.IDcustomer = 1;
                ado.InsertCustomer(conn, customer).Wait();
                Message = "Вы зарегестрировались";
            }
            catch (Exception ex)
            {
                Message = "Возникли ошибки с корректностью данных.Попробуйте еще раз.";
            }
        }
    }
}

