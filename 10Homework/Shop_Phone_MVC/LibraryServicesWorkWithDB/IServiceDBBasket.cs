using LibrarySetOfClases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBInterfaces
{
   public interface IServiceDBBasket
    {
        Task InsertInBasketID(int id);
        Task InsertInBasketPhone(int idc, int idp);
        Task<List<ClassPhone>> SelectPhoneByCustomer(string login_user);
        Task<List<Basket>> SelectUsersBasket();
        Task DeleteFromBasket(int id, string login);
    }
}
