using CookyBook.Server.Factories.IFactories;
using CookyBook.Shared.DataTransferObjects;
using DataAccess.Entities;
using System;

namespace CookyBook.Server.Factories
{
    public class CategoryFactory : ICategoryFactory
    {

        public Category CreateCategory(CategoryDto categoryDto)
        {
            Category category = new Category();
            category.Title = categoryDto.Title;
            category.Description = categoryDto.Description;
            category.Id = categoryDto.Id;
            return category;
        }
    }
}
