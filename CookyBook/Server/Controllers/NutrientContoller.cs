using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookyBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NutrientController : ControllerBase
    {
        private readonly ICookBookRepository<Nutrient> repos;
        private readonly IMapper mapper;

        public NutrientController(ICookBookRepository<Nutrient> repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<NutrientDto> Get()
        {
            List<NutrientDto> nutrientDtos = new();
            mapper.Map(repos.GetEntities(), nutrientDtos);
            return nutrientDtos;
        }
    }
}
