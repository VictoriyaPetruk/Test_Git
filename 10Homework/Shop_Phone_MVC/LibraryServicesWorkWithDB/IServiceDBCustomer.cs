using LibrarySetOfClases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBInterfaces
{
    public interface IServiceDBCustomer
    {
        Task InsertCustomer(Customer customer);
        Task<List<Customer>> SelectCustomer();
        Task<List<string>> GetCustomer(string login_user);
    }
}
