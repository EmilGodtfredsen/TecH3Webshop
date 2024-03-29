﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Repositories
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAll();
        Task<Brand> GetById(int id);
        Task<Brand> Create(Brand brand);
        Task<Brand> Update(int id, Brand brand);

        Task<Brand> Delete(int id);
    }
}
