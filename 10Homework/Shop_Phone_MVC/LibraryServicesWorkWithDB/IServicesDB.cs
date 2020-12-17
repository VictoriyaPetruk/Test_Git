using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using LibrarySetOfClases;

namespace LibraryServicesWorkWithDB
{
    public interface IServicesDB
    {
      SqlConnection Connection { get; set; }
      SqlConnection GetConncection();
      Task InsertPhone(SqlConnection connection, ClassPhone phone);
      Task InsertCustomer(SqlConnection connection, ClassCustomer customer);
        Task<List<ClassCustomer>> SelectCustomer(SqlConnection connection);
      Task<List<ClassPhone>> SelectPhone(SqlConnection connection);
        Task InsertInBasketID(SqlConnection connection, int id);
        Task InsertInBasketPhone(SqlConnection connection, int idc, int idp);
        Task<List<ClassPhone>> SelectPhoneByCustomer(SqlConnection connection, string login_user);
        Task<List<ClassBasket>> SelectUsersBasket(SqlConnection connection);
        Task<List<string>> GetCustomer(SqlConnection connection, string login_user);
        Task InsertOrderId(SqlConnection connection, string login, string adress);
        Task InsertOrderPhone(SqlConnection connection, string login, int idp);
        Task DeleteFromBasket(SqlConnection connection, int id, string login);
        Task ReduceCount(SqlConnection connection, int id, int count);
        Task<int> GetNumberOrder(SqlConnection connection, string login_user);

    }
}
