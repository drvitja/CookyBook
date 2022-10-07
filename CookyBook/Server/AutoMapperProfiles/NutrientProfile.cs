
using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;

namespace CookyBook.Server.AutoMapperProfiles
{
    public class NutrientProfile : Profile
    {
        public NutrientProfile()
        {
            CreateMap<Nutrient, NutrientDto>();
            CreateMap<NutrientDto, Nutrient>();
        }
    }
}
