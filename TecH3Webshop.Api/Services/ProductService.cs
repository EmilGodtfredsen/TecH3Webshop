using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Repositories;

namespace TecH3Webshop.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return products;
        }
        public async Task<Product> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            return product;
        }
        public async Task<Product> Create(Product product)
        {
            var newProduct = await _productRepository.Create(product);
            return newProduct;
        }
        public async Task<Product> Update(int id, Product product)
        {
            var updateProduct = await _productRepository.Update(id, product);
            return updateProduct;
        }
        public async Task<Product> Delete(int id)
        {
            var product = await _productRepository.Delete(id);
            return product;
        }
    }
}
