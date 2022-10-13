using AutoMapper;
using CookyBook.Server.Factories;
using CookyBook.Server.Factories.IFactories;
using CookyBook.Shared;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;

namespace CookyBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ICookBookRepository<Recipe> repos;
        private readonly IMapper mapper;
        private readonly IRecipeFactory recipeFactory;

        public RecipeController(ICookBookRepository<Recipe> repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
            this.recipeFactory = new RecipeFactory();
        }

        [HttpGet]
        public IEnumerable<RecipeDto> Get()
        {
            List<RecipeDto> recipeDtos = new();
            mapper.Map(repos.GetEntities(), recipeDtos);
            return recipeDtos;
        }

        [HttpPost]
        public void Post(int id, [FromBody]RecipeDto recipeDto)
        {
            Recipe recipe = recipeFactory.CreateRecipe(recipeDto);            
            //repos.SaveRecipe(recipe);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //repos.DeleteRecipe(id);
        }
    }
}