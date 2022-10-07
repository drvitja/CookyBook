﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface ICookBookRepository
    {
        public Recipe[] GetRecipes();
        public Ingredient[] GetIngredients();
        public Nutrient[] GetNutrients();
        public Category[] GetCategory();
        public void SaveRecipe(Recipe recipe);
        public void DeleteRecipe(long id);
    }
}
