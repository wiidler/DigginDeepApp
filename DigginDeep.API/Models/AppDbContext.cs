using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DigginDeep.API.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Students

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "John Doe", Major = "Computer Science", Email = "johndoe@mst.edu"});
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 2, Name = "Jane Doe", Major = "Computer Engineering", Email = "janedoe@mst.edu"});
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 3, Name = "John Smith", Major = "Information Science and Technology", Email = "johnsmith@mst.edu"}); 
            

            // Departments

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Major = "Computer Science", DepartmentHead = "Dr. Dan Lin", DepartmentEmail = "danlin@mst.edu"});
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 2, Major = "Computer Engineering", DepartmentHead = "Dr. Bruce McMillin", DepartmentEmail = "bmcmillin@mst.edu"});
    


        }
    }
}