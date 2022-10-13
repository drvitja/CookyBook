using AutoMapper;
using CookyBook.Server.Factories;
using CookyBook.Server.Factories.IFactories;
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
        private readonly INutrientFactory nutrientFactory;


        public NutrientController(ICookBookRepository<Nutrient> repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
            this.nutrientFactory = new NutrientFactory();
        }

        [HttpGet]
        public IEnumerable<NutrientDto> Get()
        {
            List<NutrientDto> nutrientDtos = new();
            mapper.Map(repos.GetEntities(), nutrientDtos);
            return nutrientDtos;
        }

        [HttpPost]
        public void Post(int id, [FromBody] NutrientDto nutrientDto)
        {
            Nutrient nutrient = nutrientFactory.CreateNutrient(nutrientDto);
            repos.SetEntity(nutrient);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repos.RemoveEntity(id);
        }
    }
}
