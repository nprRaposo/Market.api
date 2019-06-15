using Market.Api.Domain.Models;
using Market.Api.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Api.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();

        Task<SaveCategoryResponse> SaveAsync(Category category);

        Task<SaveCategoryResponse> UpdateAsync(int id, Category category);
    }
}
