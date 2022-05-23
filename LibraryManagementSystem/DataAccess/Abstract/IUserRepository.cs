using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Abstract
{
    public interface IUserRepository
    {

        List<User> GetAll();
        User GetById(int id);
        bool Add(User book);
        bool Update(User book);
        bool Delete(int id);
        
    }
}
