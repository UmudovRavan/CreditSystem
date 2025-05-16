using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel, TEntity> where TEntity : BaseEntity, new() where TModel : class, new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public GenericService(IMapper mapper, IGenericRepository<Branch> repository)
        {
            _mapper = mapper;
            this.repository = repository;
        }

        private readonly IMapper _mapper;
        private IGenericRepository<Branch> repository;

        public async Task<TModel> CreateAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var result = await _genericRepository.AddAsync(entity);

            return _mapper.Map<TModel>(result);
        }

        public async Task<bool> DeleteAsync(int id) => await _genericRepository.DeleteAsync(id);

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            return _mapper.Map<TModel>(entity);
        }

        public async Task<TModel> Update(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var result = await _genericRepository.UpdateAsync(entity);
            return _mapper.Map<TModel>(result);
        }
    }
}
