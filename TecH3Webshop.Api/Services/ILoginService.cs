using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Services
{
    public interface ILoginService
    {
        Task<List<Login>> GetAll();
        Task<Login> GetByEmail(string email);
        Task<Login> Create(Login login);
        Task<Login> Update(string email, Login login);
        Task<Login> Delete(int id);

    }
}
