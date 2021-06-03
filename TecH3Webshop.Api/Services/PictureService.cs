using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Repositories;

namespace TecH3Webshop.Api.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;

        public PictureService(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }
        public async Task<List<Picture>> GetAll()
        {
            var pictures = await _pictureRepository.GetAll();
            return pictures;
        }
        public async Task<Picture> GetById(int id)
        {
            var picture = await _pictureRepository.GetById(id);
            return picture;
        }
        public async Task<Picture> Create(Picture picture)
        {
            var newPicture = await _pictureRepository.Create(picture);
            return newPicture;
        }
        public async Task<Picture> Update(int id, Picture picture)
        {
            var updatePicture = await _pictureRepository.Update(id, picture);
            return updatePicture;
        }
        public async Task<Picture> Delete(int id)
        {
            var picture = await _pictureRepository.Delete(id);
            return picture;
        }
    }
}

