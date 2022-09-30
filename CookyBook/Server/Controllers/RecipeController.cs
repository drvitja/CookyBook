using AutoMapper;
using CookyBook.Shared;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookyBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ICookBookRepository repos;
        private readonly IMapper mapper;

        public RecipeController(ICookBookRepository repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<RecipeDto> Get()
        {
            List<RecipeDto> recipeDtos = new();
            mapper.Map(repos.GetRecipes(), recipeDtos);
            return recipeDtos.ToArray();
        }
    }
}