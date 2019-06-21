using Market.Api.Domain.Models;
using Market.Api.Domain.Repositories;
using Market.Api.Domain.Services;
using Market.Api.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Api.Services
{
    public class CategoryService : BaseService<Category>
    {

        public CategoryService(IRepository<Category> entityRepository, IUnitOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
        }

        public override async Task<ActionResponse<Category>> UpdateAsync(int id, Category entity)
        {
            var existingEntity = await _entityRepository.GetById(id);

            if (existingEntity == null)
                return new ActionResponse<Category>("Entity not found.");

            existingEntity.Name = entity.Name;

            return await base.UpdateAsync(id, existingEntity);
        }
    }
}
