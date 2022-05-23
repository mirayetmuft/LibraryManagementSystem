using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Abstract
{
    public interface ICategoryRepository
    {

        List<Category> GetAll();
        Category GetById(int id);
        bool Add(Category category);
        bool Update(Category category);
        bool Delete(int id);
    }
}
