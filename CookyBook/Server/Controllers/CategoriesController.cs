using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookyBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICookBookRepository repos;
        private readonly IMapper mapper;

        public CategoriesController(ICookBookRepository repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> Get()
        {
            List<CategoryDto> CategoryDtos = new();
            mapper.Map(repos.GetCategory(), CategoryDtos);
            return CategoryDtos.ToArray();
        }
    }
}