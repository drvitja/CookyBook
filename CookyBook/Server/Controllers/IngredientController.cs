﻿using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookyBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly ICookBookRepository repos;
        private readonly IMapper mapper;

        public IngredientController(ICookBookRepository repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<IngredientDto> Get()
        {
            List<IngredientDto> IngredientDtos = new();
            mapper.Map(repos.GetIngredients(), IngredientDtos);
            return IngredientDtos.ToArray();
        }
    }
}
