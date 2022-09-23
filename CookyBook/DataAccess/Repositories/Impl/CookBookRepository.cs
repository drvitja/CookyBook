using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Impl
{
    public class CookBookRepository : ICookBookRepository
    {
        public CookRecipe[] GetCookRecipes()
        {
             List<CookRecipe> cookRecipes = new List<CookRecipe>
            {
                new CookRecipe
                {
                    Id = 1,
                    Name = "Spaghetti Bolognese",
                    ShortDescription = "Spaghetti mit Bolognesesauce",
                    Time = new TimeSpan(0, 15, 0)
                },
                new CookRecipe
                {
                    Id = 2,
                    Name = "Milchreis",
                    ShortDescription = "Lecker Milchreis",
                    Time = new TimeSpan(0, 45, 0)
                },
                new CookRecipe
                {
                    Id = 3,
                    Name = "Kartoffelauflauf",
                    ShortDescription = "mit Kartoffeln & Hack & Feta",
                    Time = new TimeSpan(0, 40, 0)
                },
                new CookRecipe
                {
                    Id = 4,
                    Name = "Hähnchen mit Reis",
                    ShortDescription = "Hähnchen mit Reis",
                    Time = new TimeSpan(0, 20, 0)
                },
                new CookRecipe
                {
                    Id = 5,
                    Name = "Frenchtoast",
                    ShortDescription = "Toast mit Ei",
                    Time = new TimeSpan(0, 10, 0)
                }
            };

            return cookRecipes.ToArray();
        }
    }
}
