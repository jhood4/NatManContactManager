using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "1", Name = "Friend" },
                new Category { CategoryId = "2", Name = "Work" },
                new Category { CategoryId = "3", Name = "Family" }

            );
            
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ContactId = 1,
                FirstName = "Delores",
                LastName = "Del Rio",
                PhoneNumber = "555-987-6543",
                Email = "delores@hotmail.com",
                CategoryId = "1",
                DateAdded = DateTime.Now.AddDays(-5)

            }, new Contact
            {
                ContactId = 2,
                FirstName = "Efren",
                LastName = "Herrera",
                PhoneNumber = "555-456-7890",
                Email = "efren@aol.com",
                CategoryId = "2",
                DateAdded = DateTime.Now.AddYears(-13)
            }, new Contact
            {
                ContactId = 3,
                FirstName = "Mary",
                LastName = "Ellen",
                PhoneNumber = "555-123-4567",
                Email = "MaryEllen@yahoo.com",
                CategoryId = "3",
                DateAdded = DateTime.Now
            });
        }
    }
}
