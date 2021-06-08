using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Services
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAll();
        Task<OrderDetail> GetById(int id);
        Task<List<OrderDetail>> Create(List<OrderDetail> orderDetails);
        Task<OrderDetail> Update(int id, OrderDetail orderDetail);
        Task<OrderDetail> Delete(int id);
    }
}
