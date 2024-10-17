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