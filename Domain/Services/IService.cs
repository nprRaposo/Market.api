using Market.Api.Domain.Models;
using Market.Api.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Api.Domain.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync();

        Task<ActionResponse<T>> SaveAsync(T category);

        Task<ActionResponse<T>> UpdateAsync(int id, T category);

        Task<ActionResponse<T>> DeleteAsync(int id);
    }
}
