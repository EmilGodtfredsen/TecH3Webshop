using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Database;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TecH3WebshopDbContext _context;
        public CategoryRepository(TecH3WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories
                .Where(c => c.DeletedAt == null)
                .Include(c => c.Products.Where(p => p.DeletedAt == null))
                .ThenInclude(p => p.Brand)
                .Include(c => c.Products.Where(p => p.DeletedAt == null))
                .ThenInclude(p => p.Images.Where(i => i.DeletedAt == null))
                .ToListAsync();
        }

        public async Task<Category> Create(Category category)
        {
            category.CreatedAt = DateTime.Now;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }


        public async Task<Category> Update(int id, Category category)
        {
            var updateCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(updateCategory != null)
            {
                updateCategory.UpdatedAt = DateTime.Now;
                updateCategory.Name = category.Name;
                _context.Categories.Update(updateCategory);
                await _context.SaveChangesAsync();
            }
            return updateCategory;
        }
        public async Task<Category> Delete(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(category != null)
            {
                category.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return category;
        }
    }
}
