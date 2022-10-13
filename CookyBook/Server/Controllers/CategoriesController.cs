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
    public class CategoriesController : ControllerBase
    {
        private readonly ICookBookRepository<Category> repos;
        private readonly IMapper mapper;
        private readonly ICategoryFactory categoryFactory;

        public CategoriesController(ICookBookRepository<Category> repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
            this.categoryFactory = new CategoryFactory();
        }

        [HttpGet]
        public IEnumerable<CategoryDto> Get()
        { 
            List<CategoryDto> CategoryDtos = new();
            mapper.Map(repos.GetEntities(), CategoryDtos);
            return CategoryDtos;
        }

        [HttpPost]
        public void Post(int id, [FromBody] CategoryDto categoryDto)
        {
            Category category = categoryFactory.CreateCategory(categoryDto);
            repos.SetEntity(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repos.RemoveEntity(id);
        }

    }
}