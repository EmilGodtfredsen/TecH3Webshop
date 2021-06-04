using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Repositories;

namespace TecH3Webshop.Api.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task<List<Image>> GetAll()
        {
            var images = await _imageRepository.GetAll();
            return images;
        }
        public async Task<Image> GetById(int id)
        {
            var image = await _imageRepository.GetById(id);
            return image;
        }
        public async Task<Image> Create(Image image)
        {
            var newImage = await _imageRepository.Create(image);
            return newImage;
        }
        public async Task<Image> Update(int id, Image image)
        {
            var updateImage = await _imageRepository.Update(id, image);
            return updateImage;
        }
        public async Task<Image> Delete(int id)
        {
            var image = await _imageRepository.Delete(id);
            return image;
        }
    }
}

