using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    interface IAddress
    {
        Task<Address> GetById(int id);
        Task<Address> Create(Address address);
        Task<Address> Update(int id, Address address);
        Task<Address> Delete(int id);


    }
}
