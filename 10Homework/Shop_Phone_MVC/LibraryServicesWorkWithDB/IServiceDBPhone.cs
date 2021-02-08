using LibrarySetOfClases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBInterfaces
{
    public interface IServiceDBPhone
    {
        Task InsertPhone(ClassPhone phone);
        Task<List<ClassPhone>> SelectPhone();
       
    }
}
