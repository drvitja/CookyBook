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

        public DbSet<Category>? Category { get;set;}

        public DbSet<Ingredient>? Ingredient { get;set;}

        public DbSet<Recipe>? Recipe { get; set; }

        public DbSet<Nutrient>? Nutrient { get; set; }

    }
}
