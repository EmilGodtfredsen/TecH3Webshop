using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Database;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly TecH3WebshopDbContext _context;
        public BrandRepository(TecH3WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Brand>> GetAll()
        {
            return await _context.Brands
                .Where(b => b.DeletedAt == null)
                .Include(b => b.Products.Where(p => p.DeletedAt == null))
                .ToListAsync();
        }

        public async Task<Brand> GetById(int id)
        {
            return await _context.Brands
                .Where(b => b.DeletedAt == null)
                .Include(b => b.Products.Where(p => p.DeletedAt == null))
                .FirstOrDefaultAsync();
        }       
        public async Task<Brand> Create(Brand brand)
        {
            brand.CreatedAt = DateTime.Now;
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }
        public async Task<Brand> Update(int id, Brand brand)
        {
            var updateBrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if(updateBrand != null)
            {
                updateBrand.Name = brand.Name;
                _context.Brands.Update(updateBrand);
                await _context.SaveChangesAsync();
            }
            return updateBrand;
        }
        public async Task<Brand> Delete(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if(brand != null)
            {
                brand.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return brand;
        }
    }
}
