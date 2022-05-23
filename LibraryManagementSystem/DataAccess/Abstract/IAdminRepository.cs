using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Abstract
{
    public interface IAdminRepository
    {
        Admin GetById(int id);
        List<Admin> GetAll();
        bool Add(Admin admin);
        bool Update(Admin admin);
        bool Delete(int id);
        //Admin Get(Expression<Func<Admin, bool>> filter);
    }
}
