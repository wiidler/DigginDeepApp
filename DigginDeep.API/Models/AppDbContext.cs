using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DigginDeep.API.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        // DbSet for the Student entity
        public DbSet<Student> Students { get; set; }

        // Overriding OnModelCreating to seed initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "John Doe",
                    Major = "Computer Science",
                    Email = "jdoe@mst.edu"
                }
            );
        }
    }
}
