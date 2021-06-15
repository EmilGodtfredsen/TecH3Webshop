using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public interface IImageRepository
    {
        Task<List<Image>> GetAll();
        Task<Image> GetById(int id);
        Task<Image> Create(Image image);
        Task<Image> Delete(int id);
    }
}
