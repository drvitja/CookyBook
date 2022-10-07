using AutoMapper;
using CookyBook.Server.Factories;
using CookyBook.Server.Factories.IFactories;
using CookyBook.Shared;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CookyBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ICookBookRepository repos;
        private readonly IMapper mapper;
        private readonly IRecipeFactory recipeFactory;

        public RecipeController(ICookBookRepository repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
            this.recipeFactory = new RecipeFactory();
           
        }

        [HttpGet]
        public IEnumerable<RecipeDto> Get()
        {
            List<RecipeDto> recipeDtos = new();
            mapper.Map(repos.GetRecipes(), recipeDtos);
            return recipeDtos.ToArray();
        }

        [HttpPost]
        public void Post(int id, [FromBody]RecipeDto recipeDto)
        {
            RecipeDto recDto = recipeDto;
            Recipe recipe = recipeFactory.CreateRecipe(recDto);            
            repos.SaveRecipe(recipe);
        }
    }
}