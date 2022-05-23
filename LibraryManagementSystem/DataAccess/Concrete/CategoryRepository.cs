using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class CategoryRepository:ICategoryRepository
    {
        public bool Add(Category category)
        {
            using (var context = new LibraryDbContext())
            {
                var addedModel = context.Entry(category);
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

        public List<Category> GetAll()
        {

            using (var context = new LibraryDbContext())
            {
                return context.Set<Category>().ToList();
            }
        }

        public Category GetById(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<Category>().SingleOrDefault(c => c.Id == id);
            }
        }

        public bool Update(Category category)
        {
            using (var context = new LibraryDbContext())
            {
                var updatedModel = context.Entry(category);
                updatedModel.State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}
