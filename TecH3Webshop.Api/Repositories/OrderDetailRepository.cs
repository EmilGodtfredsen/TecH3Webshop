using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Database;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly TecH3WebshopDbContext _context;
        public OrderDetailRepository(TecH3WebshopDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDetail>> GetAll()
        {
            return await _context.OrderDetails
                .Where(od => od.DeletedAt == null)
                .Include(od => od.Product)
                .Where(od => od.Product.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<OrderDetail> GetById(int id)
        {
            return await _context.OrderDetails
                .Where(od => od.DeletedAt == null)
                .Include(od => od.Product)
                .Where(od => od.Product.DeletedAt == null)
                .FirstOrDefaultAsync(od => od.Id == id);
        }

        public async Task<List<OrderDetail>> Create(List<OrderDetail> orderDetails)
        {
            foreach(OrderDetail orderDetail in orderDetails)
            {
                orderDetail.CreatedAt = DateTime.Now;
                _context.OrderDetails.Add(orderDetail);
            } 
            await _context.SaveChangesAsync();
            return orderDetails;
        }

        public async Task<OrderDetail> Update(int id, OrderDetail orderDetail)
        {
            var updateOrderDetail = await _context.OrderDetails.FirstOrDefaultAsync(od => od.Id == id);
            if (updateOrderDetail != null)
            {
                updateOrderDetail.UpdatedAt = DateTime.Now;
                updateOrderDetail.Price = orderDetail.Price;
                updateOrderDetail.Product = orderDetail.Product;
                updateOrderDetail.Quantity = orderDetail.Quantity;
                _context.OrderDetails.Update(updateOrderDetail);
                await _context.SaveChangesAsync();
            }
            return updateOrderDetail;
        }
        public async Task<OrderDetail> Delete(int id)
        {
            var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(od => od.Id == id);
            if(orderDetail != null)
            {
                orderDetail.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return orderDetail;
        }

    }
}
