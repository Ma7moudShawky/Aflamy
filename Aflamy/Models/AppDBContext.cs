using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aflamy.Models
{
    public class AppDBContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
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
            //MovieCategries = new List<Category> { new Category { CategoryId = 2 }, new Category { CategoryId = 1 } }
            modelBuilder.Entity<Movie>().HasData(
            new Movie { MovieID = 1, MovieName = "Last Seen Alive", Poster = "JustTest", Description = "Will's soon-to-be ex-wife mysteriously vanishes " },
            new Movie { MovieID = 2, MovieName = "Interceptor", Description = "One Army captain", Poster = "Another Test" },
            new Movie { MovieID = 3, MovieName = "The Dreamseller", Description = "The Dreamseller Desccccc", Poster = "Another Test" },
            new Movie { MovieID = 4, MovieName = "AmericanEast", Description = "AmericanEastDDDDDDD", Poster = "Another Test" },
            new Movie { MovieID = 5, MovieName = "Frank McKlusky", Description = "Frank McKluskyTDs", Poster = "Another Test" }
            );

            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "Admin" },
                new IdentityRole<int> { Id = 2, Name = "User" }
                );

        }

    }
}
