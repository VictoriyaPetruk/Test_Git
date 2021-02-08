using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBInterfaces
{
    public interface IServiceDBOrder
    {
        Task InsertOrderId(string login, string adress);
        Task ReduceCount(int id, int count);
        Task<int> GetNumberOrder(string login_user);
        Task InsertOrderPhone(string login, int idp);
    }
}
