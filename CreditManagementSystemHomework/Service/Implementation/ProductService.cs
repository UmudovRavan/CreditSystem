using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Models.Product;
using CreditManagementSystemHomework.Repository.Implementation;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class ProductService : GenericService<ProductVM, Product>, IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductService(IProductRepository repository, IMapper mapper, IWebHostEnvironment webHostEnvironment) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ProductCreateVM> CreateWithCategoryAsync(ProductCreateVM model)
        {
            if (model == null) return null;

            var entity = _mapper.Map<Product>(model);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ProductCreateVM>(entity);
        }

        public async Task<ProductCreateVM> CreateWithImageAsync(ProductCreateVM vm)
        {
            if (vm == null) return null;

            if (vm.Image != null && vm.Image.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(vm.Image.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await vm.Image.CopyToAsync(fileStream);
                }
                vm.ImageUrl = $"/images/products/{uniqueFileName}";
            }

            var productEntity = _mapper.Map<Product>(vm);
            var created = await _repository.AddAsync(productEntity);
            await _repository.SaveChangesAsync(); 
            return _mapper.Map<ProductCreateVM>(created);
        }


        public async Task<bool> DeleteWithImageAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;

            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(imagePath)) File.Delete(imagePath);
            }
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductVM>> GetAllWithCategoryAsync()
        {
            var products = await _repository.GetAllWithCategoryAsync();
            return _mapper.Map<IEnumerable<ProductVM>>(products);
        }

        public async Task<ProductVM?> GetByIdWithCategoryAsync(int id)
        {
            if (id <= 0) return (ProductVM?)Enumerable.Empty<ProductVM>();
            var product = await _repository.GetByIdWithCategoryAsync(id);
            return _mapper.Map<ProductVM>(product);
        }

        public async Task<IEnumerable<ProductVM>> GetProductsByCategoryIdAsync(int categoryId)
        {
            if (categoryId <= 0) return Enumerable.Empty<ProductVM>();
            var products = await _repository.GetProductsByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<ProductVM>>(products);
        }

        public async Task<ProductEditVM?> GetUpdateVMByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null) return null;
            return _mapper.Map<ProductEditVM>(data);
        }

        public async Task<ProductEditVM> UpdateWithCategoryAsync(ProductEditVM productUpdateVM)
        {
            return productUpdateVM == null ? null : _mapper.Map<ProductEditVM>(await _repository.UpdateAsync(_mapper.Map<Product>(productUpdateVM)));
        }

        public async Task<ProductEditVM> UpdateWithImageAsync(ProductEditVM updateVM)
        {
            if (updateVM == null || updateVM.Id <= 0)
                return null;

            var product = await _repository.GetByIdAsync(updateVM.Id);
            if (product == null)
                return null;

            if (updateVM.Image != null && updateVM.Image.Length > 0)
            {
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    if (File.Exists(oldImagePath))
                        File.Delete(oldImagePath);
                }

                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(updateVM.Image.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateVM.Image.CopyToAsync(stream);
                }

                product.ImageUrl = $"/images/products/{uniqueFileName}";
            }


            product.Name = updateVM.Name;
            product.Description = updateVM.Description;
            product.Price = updateVM.Price;
            product.Stock = updateVM.Stock;
            product.Brand = updateVM.Brand;
            product.BrandModel = updateVM.BrandModel;
            product.CategoryId = updateVM.CategoryId;

            await _repository.UpdateAsync(product);
            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductEditVM>(product);
        }
    }
}
