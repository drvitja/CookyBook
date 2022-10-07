﻿using AutoMapper;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookyBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class nutrientController : ControllerBase
    {
        private readonly ICookBookRepository repos;
        private readonly IMapper mapper;

        public nutrientController(ICookBookRepository repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<nutrientDto> Get()
        {
            List<nutrientDto> nutrientDtos = new();
            mapper.Map(repos.GetIngredients(), nutrientDtos);
            return nutrientDtos.ToArray();
        }
    }
}