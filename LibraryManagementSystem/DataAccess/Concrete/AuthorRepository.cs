using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class AuthorRepository : IAuthorRepository
    {
        public bool Add(Author author)
        {
            using (var context = new LibraryDbContext())
            {
                var addedModel = context.Entry(author);
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

        public List<Author> GetAll()
        {

            using (var context = new LibraryDbContext())
            {
                return context.Set<Author>().ToList();
            }
        }

        public Author GetById(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<Author>().SingleOrDefault(a =>a.Id==id);
            }
        }

        public bool Update(Author author)
        {
            using (var context = new LibraryDbContext())
            {
                var updatedModel = context.Entry(author);
                updatedModel.State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}
