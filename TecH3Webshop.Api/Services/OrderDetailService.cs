using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Repositories;

namespace TecH3Webshop.Api.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailsRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailsRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetail>> GetAll()
        {
            var orderDetails = await _orderDetailsRepository.GetAll();
            return orderDetails;
        }
        public async Task<OrderDetail> GetById(int id)
        {
            var orderDetail = await _orderDetailsRepository.GetById(id);
            return orderDetail;
        }
        public async Task<OrderDetail> Create(OrderDetail orderDetail)
        {
            var newOrderDetail = await _orderDetailsRepository.Create(orderDetail);
            return newOrderDetail;
        }
        public async Task<OrderDetail> Update(int id, OrderDetail orderDetail)
        {
            var updateOrderDetail = await _orderDetailsRepository.Update(id, orderDetail);
            return updateOrderDetail;
        }
        public async Task<OrderDetail> Delete(int id)
        {
            var orderDetail = await _orderDetailsRepository.Delete(id);
            return orderDetail;
        }
    }
}
