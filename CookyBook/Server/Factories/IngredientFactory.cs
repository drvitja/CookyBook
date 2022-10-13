using CookyBook.Server.Factories.IFactories;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;
using System;

namespace CookyBook.Server.Factories
{
    public class IngredientFactory : IIngredientFactory
    {

        public Ingredient CreateIngredient(IngredientDto ingredientDto)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Id = ingredientDto.Id;
            ingredient.Title = ingredientDto.Title;
            return ingredient;
        }
    }
}
