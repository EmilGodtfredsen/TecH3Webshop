using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Services
{
    interface IPictureService
    {
        Task<List<Picture>> GetAll();
        Task<Picture> GetById(int id);
        Task<Picture> Create(Picture picture);
        Task<Picture> Update(int id, Picture picture);
        Task<Picture> Delete(int id);
    }
}
