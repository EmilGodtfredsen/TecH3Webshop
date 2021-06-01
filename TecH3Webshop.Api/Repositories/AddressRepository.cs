using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Database;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly TecH3WebshopDbContext _context;
        public AddressRepository(TecH3WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<Address> GetById(int id)
        {
            return await _context.Addresses
                .Where(a => a.DeletedAt == null)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Address> Create(Address address)
        {
            address.CreatedAt = DateTime.Now;
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }
        public async Task<Address> Update(int id, Address address)
        {
            var updateAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            if(updateAddress != null)
            {
                updateAddress.Street = address.Street;
                updateAddress.House = address.House;
                updateAddress.Zipcode = address.Zipcode;
                updateAddress.City = address.City;
                updateAddress.Country = address.Country;
                _context.Update(updateAddress);
                await _context.SaveChangesAsync();
            }
            return updateAddress;
        }

        public async Task<Address> Delete(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            if(address != null)
            {
                address.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return address;
        }


    }
}
