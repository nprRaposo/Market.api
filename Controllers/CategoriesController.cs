﻿using AutoMapper;
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
        private readonly IService<Category> _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(IService<Category> categoryService, IMapper mapper)
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
        public async Task<IActionResult> PostAsync([FromBody] CategoryResourceSave resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<CategoryResourceSave, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResourceGet>(result.Entity);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CategoryResourceSave resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<CategoryResourceSave, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResourceGet>(result.Entity);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResourceGet>(result.Entity);
            return Ok(categoryResource);
        }
    }
}