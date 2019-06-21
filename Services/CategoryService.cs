using Market.Api.Domain.Repositories;
using Market.Api.Domain.Services;
using Market.Api.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Api.Services
{
    public class BaseService<T> : IService<T> where T: class
    {
        private readonly IRepository<T> _entityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IRepository<T> entityRepository, IUnitOfWork unitOfWork)
        {
            this._entityRepository = entityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _entityRepository.Get();
        }

        public async Task<ActionResponse<T>> SaveAsync(T entity)
        {
            try
            {
                await _entityRepository.AddAsync(entity);
                await _unitOfWork.CompleteAsync();

                return new ActionResponse<T>(entity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ActionResponse<T>($"An error occurred when saving the entity: {ex.Message}");
            }
        }

        public async Task<ActionResponse<T>> UpdateAsync(int id, T entity)
        {
            var existingEntity = await _entityRepository.GetById(id);

            if (existingEntity == null)
                return new ActionResponse<T>("Entity not found.");

            try
            {
                _entityRepository.Update(entity);
                await _unitOfWork.CompleteAsync();

                return new ActionResponse<T>(existingEntity);
            }
            catch (Exception ex)
            {
                return new ActionResponse<T>($"An error occurred when updating the entity: {ex.Message}");
            }
        }

        public async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var existingEntity = await _entityRepository.GetById(id);

            if (existingEntity == null)
                return new ActionResponse<T>("Entity not found.");

            try
            {
                _entityRepository.Remove(id);
                await _unitOfWork.CompleteAsync();

                return new ActionResponse<T>(existingEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ActionResponse<T>($"An error occurred when deleting the entity: {ex.Message}");
            }
        }
    }
}
