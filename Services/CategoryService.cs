using Market.Api.Domain.Models;
using Market.Api.Domain.Repositories;
using Market.Api.Domain.Services;
using Market.Api.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.Get();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.GetById(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.GetById(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            try
            {
                _categoryRepository.Remove(id);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
