using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public interface ILogin
    {
        Task<List<Login>> GetAll();
        Task<Login> GetById(int id);
        Task<Login> Create(int id, Login login);
        Task<Login> Update(int id, Login login);
        Task<Login> Delete(int id);

    }
}
