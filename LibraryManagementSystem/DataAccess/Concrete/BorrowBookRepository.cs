using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class BorrowBookRepository : IBorrowBookRepository
    {
        public bool Add(BorrowBook borrowBook)
        {
            using (var context = new LibraryDbContext())
            {
                var addedModel = context.Entry(borrowBook);
                addedModel.State = EntityState.Added;
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            var model = this.GetById(id);
            using (var context = new LibraryDbContext())
            {
                var deletedModel = context.Entry(model);
                deletedModel.State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }

        }

        public List<BorrowBook> GetAll()
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<BorrowBook>().ToList();
            }
        }

        public List<BookUserBookBarrowVM> GetBorrowingDetails()
        {
            using (var context =new LibraryDbContext())
            {
                var result = from u in context.Users
                             join bb in context.BorrowBooks
                             on u.Id equals bb.UserId
                             join b in context.Books
                             on bb.BookId equals b.Id
                             select new BookUserBookBarrowVM()
                             {
                                 Id = bb.Id,
                                 UserFullName = u.FullName,
                                 BookName = b.Name,
                                 BorrowingDate = bb.BorrowingDate,
                                 ReturnDate = bb.ReturnDate,
                                 DateToBeReturned = bb.DateToBeReturned

                             };
                return result.ToList();
            }
        }

        public BorrowBook GetById(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<BorrowBook>().SingleOrDefault(b => b.Id == id);
            }
        }

        public bool Update(BorrowBook borrowBook)
        {
            using (var context = new LibraryDbContext())
            {
                var updatedModel = context.Entry(borrowBook);
                updatedModel.State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}
