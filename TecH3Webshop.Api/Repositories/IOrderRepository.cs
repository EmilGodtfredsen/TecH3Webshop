using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> Create(Order order);
        Task<Order> Update(int id, Order order);
        Task<Order> Delete(int id);
    }
}
