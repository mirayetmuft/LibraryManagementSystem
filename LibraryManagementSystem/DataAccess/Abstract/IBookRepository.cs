using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Abstract
{
   public interface IBookRepository
    {
        List<Book> GetAll();
        List<Book> GetAll(Expression<Func<Book, bool>> filter);
        Book GetById(int id);
        bool Add(Book book);
        bool Update(Book book);
        bool Delete(int id);
        List<BookVM> GetAllWithDetail();
    }
}
            