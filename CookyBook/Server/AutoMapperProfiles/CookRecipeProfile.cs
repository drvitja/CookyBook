using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;

namespace CookyBook.Server.AutoMapperProfiles
{
    public class CookRecipeProfile : Profile
    {
        public CookRecipeProfile()
        {
            CreateMap<CookRecipe, CookRecipeDto>();
            CreateMap<CookRecipeDto, CookRecipe>();
        }
    }
}
