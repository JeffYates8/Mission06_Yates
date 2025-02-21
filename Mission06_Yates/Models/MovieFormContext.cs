using Microsoft.EntityFrameworkCore;

namespace Mission06_Yates.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
        {
        }
        public DbSet<MovieForm> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed data
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryName = "Drama", CategoryId = 2 },
                new Category { CategoryName = "Television", CategoryId = 3 },
                new Category { CategoryName = "Horror/Suspense", CategoryId = 4 },
                new Category { CategoryName = "Comedy", CategoryId = 5 },
                new Category { CategoryName = "Family", CategoryId = 6 },
                new Category { CategoryName = "Action/Adventure", CategoryId = 7 },
                new Category { CategoryName = "VHS", CategoryId = 8 }
            );

        }
    }
}
