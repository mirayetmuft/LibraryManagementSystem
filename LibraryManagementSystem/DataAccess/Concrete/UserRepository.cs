using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class UserRepository:IUserRepository
    {
        public bool Add(User user)
        {
            using (var context = new LibraryDbContext())
            {
                var addedModel = context.Entry(user);
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

        public List<User> GetAll()
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<User>().ToList();
            }
        }

        public User GetById(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<User>().SingleOrDefault(u => u.Id == id);
            }
        }

        public bool Update(User user)
        {
            using (var context = new LibraryDbContext())
            {
                var updatedModel = context.Entry(user);
                updatedModel.State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}
