﻿using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<List<Product>> GetAllProducts(bool includePassedEvents);
        Task<Product> AddProduct(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(Product product);
    }
}
