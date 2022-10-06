using CookyBook.Server.Factories.IFactories;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;
using System;

namespace CookyBook.Server.Factories
{
    public class RecipeFactory : IRecipeFactory
    {

        public Recipe CreateRecipe(RecipeDto recipeDto)
        {
            Recipe recipe = new Recipe();
            recipe.Id = recipeDto.Id;
            recipe.Title = recipeDto.Title;
            recipe.Description = recipeDto.Description;
            recipe.Preparation = recipeDto.Preparation;
            recipe.Duration = recipeDto.Duration;

            return recipe;
        }
    }
}
