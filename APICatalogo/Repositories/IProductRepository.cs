﻿using APICatalogo.Models;

namespace APICatalogo.Repositories;

public interface IProductRepository : IRepository<Product>
{
    IEnumerable<Product> GetProductsByCategory(int categoryId);
}
