using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Repositories;

namespace TecH3Webshop.Api.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<List<Brand>> GetAll()
        {
            var brands = await _brandRepository.GetAll();
            return brands;
        }
        public async Task<Brand> GetById(int id)
        {
            var brand = await _brandRepository.GetById(id);
            return brand;
        }
        public async Task<Brand> Create(Brand brand)
        {
            var newBrand = await _brandRepository.Create(brand);
            return newBrand;
        }
        public async Task<Brand> Update(int id, Brand brand)
        {
            var updateBrand = await _brandRepository.Update(id, brand);
            return updateBrand;
        }
        public async Task<Brand> Delete(int id)
        {
            var brand = await _brandRepository.Delete(id);
            return brand;
        }
    }
}
