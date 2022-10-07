
using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;

namespace CookyBook.Server.AutoMapperProfiles
{
    public class nutrientProfile : Profile
    {
        public nutrientProfile()
        {
            CreateMap<nutrient, nutrientDto>();
            CreateMap<nutrientDto, nutrient>();
        }
    }
}
