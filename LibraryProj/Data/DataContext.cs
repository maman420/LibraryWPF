using LibraryProj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryProj.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Additional configuration or initialization logic can be included here
        }        
        public DbSet<Book> Books { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Library;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId);

            // Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Science Fiction" },
                new Category { Id = 2, Name = "Money" },
                new Category { Id = 3, Name = "Health" }
            );

            // Seed books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "Dune", Author = "Frank Herbert", Stock = 10, Price = 20, Description = "A science fiction masterpiece", CategoryId = 1 },
                new Book { Id = 2, Name = "Rich Dad Poor Dad", Author = "Robert Kiyosaki", Stock = 5, Price = 15, Description = "A personal finance classic", CategoryId = 2 }
            );

            // Seed journals
            modelBuilder.Entity<Journal>().HasData(
                new Journal { Id = 3, Name = "New England Journal of Medicine", Author = "Massachusetts Medical Society", Stock = 8, Price = 25, Description = "A renowned medical journal", CategoryId = 3 },
                new Journal { Id = 4, Name = "Scientific American", Author = "Springer Nature", Stock = 12, Price = 30, Description = "A popular science magazine", CategoryId = 1 }
            );

        }
    }
}
