using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Repositories;

namespace TecH3Webshop.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<Order>> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            return orders;
        }
        public async Task<Order> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);
            return order;
        }
        public async Task<Order> Create(Order order)
        {
            var newOrder = await _orderRepository.Create(order);
            return newOrder;
        }
        public async Task<Order> Delete(int id)
        {
            var order = await _orderRepository.Delete(id);
            return order;
        }
    }
}
