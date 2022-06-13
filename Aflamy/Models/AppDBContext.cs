using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aflamy.Models
{
    public class AppDBContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Fantasy" },
                new Category { CategoryId = 5, CategoryName = "Horror" },
                new Category { CategoryId = 6, CategoryName = "Mystery" }
                );

            modelBuilder.Entity<IdentityRole<int>>().HasData(
              new IdentityRole<int> { Id = 1, Name = "Admin" },
              new IdentityRole<int> { Id = 2, Name = "User" }
              );
        }

    }
}
