using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    interface IOrderDetailRepository
    {
        Task<List<OrderDetail>> GetAll();
        Task<OrderDetail> GetById(int id);
        Task<OrderDetail> Create(int id, OrderDetail orderDetail);
        Task<OrderDetail> Update(int id, OrderDetail orderDetail);
        Task<OrderDetail> Delete(int id);
    }
}
