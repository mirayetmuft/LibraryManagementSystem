using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class BookRepository : IBookRepository
    {
        public bool Add(Book book)
        {
            using (var context = new LibraryDbContext())
            {
                var addedModel = context.Entry(book);
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

        public List<Book> GetAll()
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<Book>().ToList();
            }
        }
        public List<Book> GetAll(Expression<Func<Book,bool>> filter)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<Book>().Where(filter).ToList();
            }
        }

        public Book GetById(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<Book>().SingleOrDefault(b => b.Id == id);
            }
        }

        public bool Update(Book book)
        {
            using (var context = new LibraryDbContext())
            {
                var updatedModel = context.Entry(book);
                updatedModel.State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
        public List<BookVM> GetAllWithDetail()
        {
            using (var context = new LibraryDbContext())
            {
                var result = from b in context.Books
                             join c in context.Categories on b.CategoryId equals c.Id
                             join a in context.Authors on b.AuthorId equals a.Id
                             select new BookVM()
                             {
                                 Id = b.Id,
                                 CategoryName = c.Name,
                                 Name = b.Name,
                                 AuthorName = a.FullName,
                                 Shelf = b.Shelf,
                                 Status = b.Status,
                                 Page = b.Page

                             };
                return result.ToList();
            }
        }

        
    }
}
