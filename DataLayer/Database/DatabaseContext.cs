using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Model;
using Welcome.Others;

namespace DataLayer.Database
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }

        public DbSet<DatabaseLog> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);

            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            var adminUser = new DatabaseUser()
            {
                Id = 1,
                Names = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };

            var inspectorUser = new DatabaseUser()
            {
                Id = 2,
                Names = "Georgi Ivanov",
                Password = "121212",
                Role = UserRolesEnum.INSPECTOR,
                Expires = DateTime.Now.AddYears(5)
            };

            var professorUser = new DatabaseUser()
            {
                Id = 3,
                Names = "Kalina Marinova",
                Password = "152637",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(8)
            };

            var studentUser = new DatabaseUser()
            {
                Id = 4,
                Names = "Marina Georgieva",
                Password = "111222",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(4)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(adminUser);
            modelBuilder.Entity<DatabaseUser>().HasData(inspectorUser);
            modelBuilder.Entity<DatabaseUser>().HasData(professorUser);
            modelBuilder.Entity<DatabaseUser>().HasData(studentUser);
        }
    }
}
