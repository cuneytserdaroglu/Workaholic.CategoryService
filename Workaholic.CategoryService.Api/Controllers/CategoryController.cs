using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workaholic.CategoryService.Domain;
using Workaholic.CategoryService.Repository.MongoDB.Interfaces;

namespace Workaholic.CategoryService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _categoryRepository.AsQueryableAsync();
            return categories.Result;
        }

        [HttpPost]
        public async Task<string> Post(Category category)
        {
            //Adding category
        var categoryEntity =   await _categoryRepository.InsertOneAsync(category);
        return categoryEntity.Messsage;
        }
    }
}
