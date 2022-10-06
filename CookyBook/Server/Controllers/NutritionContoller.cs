using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookyBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NutritionController : ControllerBase
    {
        private readonly ICookBookRepository repos;
        private readonly IMapper mapper;

        public NutritionController(ICookBookRepository repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<NutritionDto> Get()
        {
            List<NutritionDto> NutritionDtos = new();
            mapper.Map(repos.GetIngredients(), NutritionDtos);
            return NutritionDtos.ToArray();
        }
    }
}
