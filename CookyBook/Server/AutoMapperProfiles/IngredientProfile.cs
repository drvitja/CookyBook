using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;

namespace CookyBook.Server.AutoMapperProfiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto, Ingredient>();
        }
    }
}
