using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Repositories;

namespace TecH3Webshop.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<Category>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            return categories;
        }
        public async Task<Category> Create(Category category)
        {
            var newCategory = await _categoryRepository.Create(category);
            return newCategory;
        }
        public async Task<Category> Update(int id, Category category)
        {
            var updateCategory = await _categoryRepository.Update(id, category);
            return updateCategory;
        }
        public async Task<Category> Delete(int id)
        {
            var category = await _categoryRepository.Delete(id);
            return category;
        }
    }
}
