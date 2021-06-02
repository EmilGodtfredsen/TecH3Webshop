using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Database;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TecH3WebshopDbContext _context;
        public OrderRepository(TecH3WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders
                .Where(o => o.DeletedAt == null)
                .Include(o => o.Login)
                .Where(o => o.Login.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders
                .Where(o => o.DeletedAt == null)
                .Include(o => o.Login)
                .Where(o => o.Login.DeletedAt == null)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<Order> Create(Order order)
        {
            order.CreatedAt = DateTime.Now;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<Order> Delete(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if(order != null)
            {
                order.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return order;
        }
    }
}
