using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> Create(Category category);
        Task<Category> Update(int id, Category category);
        Task<Category> Delete(int id);
    }
}
