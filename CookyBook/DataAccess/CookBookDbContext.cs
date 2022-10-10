using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext(DbContextOptions<CookBookDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Category>? Categories { get;set;}

        public DbSet<Ingredient>? Ingredients { get;set;}

        public DbSet<Recipe>? Recipes { get; set; }

        public DbSet<Nutrient>?  Nutrients { get; set; }

    }
}
