using Market.Api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Api.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}
