﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<Order> Create(Order order);
        Task<Order> Delete(int id);
    }
}
