using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Abstract
{
    public interface IAuthorRepository
    {
        Author GetById(int id);
        List<Author> GetAll();
        bool Add(Author author);
        bool Update(Author author);
        bool Delete(int id);

    }
}
