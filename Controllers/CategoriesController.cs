using AutoMapper;
using Market.Api.Domain.Models;
using Market.Api.Domain.Services;
using Market.Api.Extensions;
using Market.Api.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Market.Api.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<CategoryResourceGet>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResourceGet>>(categories);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryResourcePost resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<CategoryResourcePost, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResourceGet>(result.Category);
            return Ok(categoryResource);
        }
    }
}