using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigginDeep.API.Models
{
    public class DDDatabase: DbContext
    {
        private readonly IConfiguration Configuration;
        public DDDatabase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("DD_DB"));
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<ToDoList> ToDoLists { get; set; }

        public void Configure(EntityTypeBuilder<Student> modelBuilder)
        {
            modelBuilder.HasKey(s => s.Id);
            modelBuilder.Property(s => s.Name).IsRequired();
            modelBuilder.Property(s => s.Major).IsRequired();
            modelBuilder.Property(s => s.Email).IsRequired();
        }
        public void Configure(EntityTypeBuilder<Department> modelBuilder)
        {
            modelBuilder.HasKey(d => d.Id);
            modelBuilder.Property(d => d.Major).IsRequired();
            modelBuilder.Property(d => d.DepartmentHead).IsRequired();
            modelBuilder.Property(d => d.DepartmentEmail).IsRequired();
        }

        public void Configure(EntityTypeBuilder<Organization> modelBuilder)
        {
            modelBuilder.HasKey(o => o.Id);
            modelBuilder.Property(o => o.Name).IsRequired();
            modelBuilder.Property(o => o.Email).IsRequired();
            modelBuilder.Property(o => o.Description).IsRequired();
            modelBuilder.Property(o => o.website).IsRequired();
        }

        public void Configure(EntityTypeBuilder<ToDoList> modelBuilder)
        {
            modelBuilder.HasKey(t => t.Id);
            modelBuilder.Property(t => t.Task).IsRequired();
            modelBuilder.Property(t => t.Description).IsRequired();
            modelBuilder.Property(t => t.DueDate).IsRequired();
            modelBuilder.Property(t => t.IsComplete).IsRequired();
        }

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
    
            // Organizations
            modelBuilder.Entity<Organization>().HasData(
                new Organization { Id = 1, Name = "Mars Rover Design Team", Email = "marsrover@mst.edu", Description = "Designing and building a rover to compete in the University Rover Challenge", website = "marsrover.mst.edu"});
            modelBuilder.Entity<Organization>().HasData(
                new Organization { Id = 2, Name = "IEEE", Email = "ieee@mst.edu", Description = "The Institute of Electrical and Electronics Engineers student chapter at Missouri S&T", website = "ieee.mst.edu"});
            modelBuilder.Entity<Organization>().HasData(
                new Organization { Id = 3, Name = "ACM", Email = "acm@mst.edu", Description = "The Association for Computing Machinery student chapter at Missouri S&T", website = "acm.mst.edu"});
            modelBuilder.Entity<Organization>().HasData(
                new Organization { Id = 4, Name = "Rocket Design Team", Email = "rocket@mst.edu", Description = "Designing and building a rocket to compete in the Spaceport America Cup", website = "rocket.mst.edu"});

            // ToDoLists
            modelBuilder.Entity<ToDoList>().HasData(
                new ToDoList { Id = 1, Task = "Complete Homework", Description = "Complete the homework for the week", DueDate = DateTime.Today.AddDays(7), IsComplete = false});
        }
    }
}