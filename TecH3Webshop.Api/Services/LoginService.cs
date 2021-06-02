using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Repositories;

namespace TecH3Webshop.Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<List<Login>> GetAll()
        {
            var logins = await _loginRepository.GetAll();
            return logins;
        }
        public async Task<Login> GetByEmail(string email)
        {
            var login = await _loginRepository.GetByEmail(email);
            return login;
        }
        public async Task<Login> Create(Login login)
        {
            var newLogin = await _loginRepository.Create(login);
            return login;
        }
        public async Task<Login> Update(string email, Login login)
        {
            var updateLogin = await _loginRepository.Update(email, login);
            return updateLogin;
        }
        public async Task<Login> Delete(int id)
        {
            var login = await _loginRepository.Delete(id);
            return login;
        }
    }
}
