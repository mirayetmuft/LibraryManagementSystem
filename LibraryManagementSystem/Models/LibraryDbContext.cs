using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class LibraryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HNE43R2; Initial Catalog=LibraryDb; User Id=sa; Password=12345");
            //optionsBuilder.UseSqlServer(@"Server=localhost;Database=LibraryDb;Trusted_Connection=true");

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowBook> BorrowBooks { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
