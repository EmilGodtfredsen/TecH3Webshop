using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public Task<Login> Create(int id, Login login)
        {
            throw new NotImplementedException();
        }

        public Task<Login> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Login>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Login> Update(int id, Login login)
        {
            throw new NotImplementedException();
        }
    }
}
