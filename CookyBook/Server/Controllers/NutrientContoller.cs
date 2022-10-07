using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookyBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NutrientController : ControllerBase
    {
        private readonly ICookBookRepository repos;
        private readonly IMapper mapper;

        public NutrientController(ICookBookRepository repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<NutrientDto> Get()
        {
            List<NutrientDto> nutrientDtos = new();
            mapper.Map(repos.GetNutrients(), nutrientDtos);
            return nutrientDtos.ToArray();
        }
    }
}
