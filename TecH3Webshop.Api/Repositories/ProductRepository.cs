using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Database;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TecH3WebshopDbContext _context;
        public ProductRepository(TecH3WebshopDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .Where(p => p.DeletedAt == null)
                .Include(p => p.Category)
                .Where(p => p.Category.DeletedAt == null)
                .Include(p => p.Brand)
                .Where(p => p.Brand.DeletedAt == null)
                .Include(p => p.Images.Where(i => i.DeletedAt == null))
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products
                .Where(p => p.DeletedAt == null)
                .Include(p => p.Category)
                .Where(p => p.Category.DeletedAt == null)
                .Include(p => p.Brand)
                .Where(p => p.Brand.DeletedAt == null)
                .Include(p => p.Images.Where(i => i.DeletedAt == null))
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Product> Create(Product product)
        {
            product.CreatedAt = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Update(int id, Product product)
        {
            var updateProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(updateProduct != null)
            {
                updateProduct.UpdatedAt = DateTime.Now;
                updateProduct.Name = product.Name;
                updateProduct.Description = product.Description;
                updateProduct.Price = product.Price;
                updateProduct.Quantity = product.Quantity;
                updateProduct.BrandId = product.BrandId;
                updateProduct.CategoryId = product.CategoryId;
                updateProduct.Images = product.Images;
                _context.Products.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
            return updateProduct;
        }
        public async Task<Product> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(product != null)
            {
                product.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return product;
        }
    }
}
