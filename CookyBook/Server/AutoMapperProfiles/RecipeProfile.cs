using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;

namespace CookyBook.Server.AutoMapperProfiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeDto, Recipe>();
        }
    }
}
