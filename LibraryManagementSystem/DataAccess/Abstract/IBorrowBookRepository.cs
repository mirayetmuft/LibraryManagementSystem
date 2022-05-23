using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Abstract
{
    public interface IBorrowBookRepository
    {
        List<BorrowBook> GetAll();
        BorrowBook GetById(int id);
        List<BookUserBookBarrowVM> GetBorrowingDetails();
        bool Add(BorrowBook borrowBook);
        bool Update(BorrowBook borrowBook);
        bool Delete(int id);
    }
}
