﻿using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public IEnumerable<Product> GetProductsByCategory(int categoryId)
    {
        return GetAll().Where(p => p.CategoryId == categoryId);
    }
}
