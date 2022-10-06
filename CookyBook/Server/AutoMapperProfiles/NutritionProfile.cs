
using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;

namespace CookyBook.Server.AutoMapperProfiles
{
    public class NutritionProfile : Profile
    {
        public NutritionProfile()
        {
            CreateMap<Nutrition, NutritionDto>();
            CreateMap<NutritionDto, Nutrition>();
        }
    }
}
