using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Database;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly TecH3WebshopDbContext _context;
        public LoginRepository(TecH3WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Login>> GetAll()
        {
            return await _context.Logins
                .Where(l => l.DeletedAt == null)
                .OrderBy(l => l.Email)
                .OrderBy(l => l.FirstName)
                .Include(l => l.Address).Where(a => a.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Login> GetByEmail(string email)
        {
            return await _context.Logins
                .Where(l => l.DeletedAt == null)
                .Include(l => l.Address).Where(a => a.DeletedAt == null)
                .FirstOrDefaultAsync(l => l.Email == email);
        }

        public async Task<Login> CreateLogin(Login login)
        {
            login.CreatedAt = DateTime.Now;
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();
            return login;
        }


        public async Task<Login> Update(string email, Login login)
        {
            var updateLogin = await _context.Logins.FirstOrDefaultAsync(l => l.Email == email);
            if(updateLogin != null)
            {
                updateLogin.UpdatedAt = DateTime.Now;
                updateLogin.Email = login.Email;
                updateLogin.FirstName = login.Email;
                updateLogin.LastName = login.LastName;
                updateLogin.Password = login.Password;
                updateLogin.Role = login.Role;
                updateLogin.Address = login.Address;
            }
            return updateLogin;
        }
        public async Task<Login> Delete(int id)
        {
            var login = await _context.Logins.FirstOrDefaultAsync(l => l.Id == id);
            if(login != null)
            {
                login.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return login;
        }
    }
}
