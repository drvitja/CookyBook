using CookyBook.Server.Factories.IFactories;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;
using System;

namespace CookyBook.Server.Factories
{
    public class NutrientFactory : INutrientFactory
    {

        public Nutrient CreateNutrient(NutrientDto nutrientDto)
        {
            Nutrient nutrient = new Nutrient();
            nutrient.Id = nutrientDto.Id;
            nutrient.Title = nutrientDto.Title;
            return nutrient;
        }
    }
}
