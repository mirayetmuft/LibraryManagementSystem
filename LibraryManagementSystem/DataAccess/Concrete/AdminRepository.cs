using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class AdminRepository : IAdminRepository
    {
        public bool Add(Admin author)
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

        public List<Admin> GetAll()
        {

            using (var context = new LibraryDbContext())
            {
                return context.Set<Admin>().ToList();
            }
        }

        public Admin GetById(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<Admin>().SingleOrDefault(a => a.Id == id);
            }
        }

        public bool Update(Admin admin)
        {
            using (var context = new LibraryDbContext())
            {
                var updatedModel = context.Entry(admin);
                updatedModel.State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}
