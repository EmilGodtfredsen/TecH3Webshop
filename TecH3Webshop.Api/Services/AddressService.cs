using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Repositories;

namespace TecH3Webshop.Api.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<Address> GetById(int id)
        {
            var address = await _addressRepository.GetById(id);
            return address;
        }
        public async Task<Address> Create(Address address)
        {
            var newAddress = await _addressRepository.Create(address);
            return address;
        }
        public async Task<Address> Update(int id, Address address)
        {
            var updateAddress = await _addressRepository.Update(id, address);
            return updateAddress;
        }
        public async Task<Address> Delete(int id)
        {
            var address = await _addressRepository.Delete(id);
            return address;
        }
    }
}
