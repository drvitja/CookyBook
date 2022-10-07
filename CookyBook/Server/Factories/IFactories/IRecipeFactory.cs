using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace CookyBook.Server.Factories.IFactories
{
    public interface IRecipeFactory
    {
        public Recipe CreateRecipe(RecipeDto recipeDto);

    }
}
