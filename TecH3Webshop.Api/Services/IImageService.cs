using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Services
{
    interface IImageService
    {
        Task<List<Image>> GetAll();
        Task<Image> GetById(int id);
        Task<Image> Create(Image picture);
        Task<Image> Update(int id, Image picture);
        Task<Image> Delete(int id);
    }
}
