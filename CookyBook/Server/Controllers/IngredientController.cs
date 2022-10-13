using AutoMapper;
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

        public IngredientController(ICookBookRepository<Ingredient> repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<IngredientDto> Get()
        {
            List<IngredientDto> IngredientDtos = new();
            mapper.Map(repos.GetEntities(), IngredientDtos);
            return IngredientDtos;
        }
    }
}
