using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Database;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly TecH3WebshopDbContext _context;
        public PictureRepository(TecH3WebshopDbContext context)
        {
            _context = context;
        }
        public async Task<List<Picture>> GetAll()
        {
            return await _context.Pictures
                .Where(p => p.DeletedAt == null)
                .ToListAsync();
        }
        public async Task<Picture> GetById(int id)
        {
            return await _context.Pictures
                .Where(p => p.DeletedAt == null)
                .FirstOrDefaultAsync();
        }
        public async Task<Picture> Create(Picture picture)
        {
            picture.CreatedAt = DateTime.Now;
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
            return picture;
        }
        public async Task<Picture> Update(int id, Picture picture)
        {
            var updatePicture = await _context.Pictures.FirstOrDefaultAsync(p => p.Id == id);
            if(updatePicture != null)
            {
                updatePicture.UpdatedAt = DateTime.Now;
                _context.Pictures.Update(updatePicture);
                await _context.SaveChangesAsync();
            }
            return updatePicture;
        }
        public async Task<Picture> Delete(int id)
        {
            var picture = await _context.Pictures.FirstOrDefaultAsync(p => p.Id == id);
            if(picture != null)
            {
                picture.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return picture;
        }
    }
}
