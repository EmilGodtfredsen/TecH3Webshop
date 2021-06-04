using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Database;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly TecH3WebshopDbContext _context;
        public ImageRepository(TecH3WebshopDbContext context)
        {
            _context = context;
        }
        public async Task<List<Image>> GetAll()
        {
            return await _context.Images
                .Where(i => i.DeletedAt == null)
                .ToListAsync();
        }
        public async Task<Image> GetById(int id)
        {
            return await _context.Images
                .Where(i => i.DeletedAt == null)
                .FirstOrDefaultAsync();
        }
        public async Task<Image> Create(Image image)
        {
            image.CreatedAt = DateTime.Now;
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }
        public async Task<Image> Update(int id, Image image)
        {
            var updateImage = await _context.Images.FirstOrDefaultAsync(i => i.Id == id);
            if(updateImage != null)
            {
                updateImage.UpdatedAt = DateTime.Now;
                _context.Images.Update(updateImage);
                await _context.SaveChangesAsync();
            }
            return updateImage;
        }
        public async Task<Image> Delete(int id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(i => i.Id == id);
            if(image != null)
            {
                image.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return image;
        }
    }
}
