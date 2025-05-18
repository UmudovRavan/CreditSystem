using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class CategoryService : GenericService<CategoryVM, Category>, ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
