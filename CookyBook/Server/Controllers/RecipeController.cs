using AutoMapper;
using CookyBook.Server.Factories;
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
        }

        [HttpGet]
        public IEnumerable<RecipeDto> Get()
        {
            List<RecipeDto> recipeDtos = new();
            mapper.Map(repos.GetRecipes(), recipeDtos);
            return recipeDtos.ToArray();
        }

        [HttpPut]
        public void Put(int id, [FromBody]RecipeDto recipeDto)
        {
            Recipe recipe = recipeFactory.CreateRecipe(recipeDto);
            mapper.Map(recipeDto, recipe);
            
            repos.SaveRecipe(recipe);
        }
    }
}