using AutoMapper;
using CookyBook.Shared;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookyBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookRecipeController : ControllerBase
    {
        private readonly ICookBookRepository repos;
        private readonly IMapper mapper;

        public CookRecipeController(ICookBookRepository repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CookRecipeDto> Get()
        {
            List<CookRecipeDto> recipeDtos = new();
            mapper.Map(repos.GetCookRecipes(), recipeDtos);
            return recipeDtos.ToArray();
        }
    }
}