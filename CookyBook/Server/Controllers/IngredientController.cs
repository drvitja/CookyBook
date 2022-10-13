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
    public class IngredientController : ControllerBase
    {
        private readonly ICookBookRepository<Ingredient> repos;
        private readonly IMapper mapper;
        private readonly IIngredientFactory ingredientFactory;

        public IngredientController(ICookBookRepository<Ingredient> repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
            this.ingredientFactory = new IngredientFactory();
        }

        [HttpGet]
        public IEnumerable<IngredientDto> Get()
        {
            List<IngredientDto> IngredientDtos = new();
            mapper.Map(repos.GetEntities(), IngredientDtos);
            return IngredientDtos;
        }

        [HttpPost]
        public void Post(int id, [FromBody] IngredientDto ingredientDto)
        {
            Ingredient ingredient = ingredientFactory.CreateIngredient(ingredientDto);
            repos.SetEntity(ingredient);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repos.RemoveEntity(id);
        }
    }
}
