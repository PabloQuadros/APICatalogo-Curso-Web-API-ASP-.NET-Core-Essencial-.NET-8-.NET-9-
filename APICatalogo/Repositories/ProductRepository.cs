using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public Product GetProduct(int id)
    {
        return _context.Products.FirstOrDefault(p => p.ProductId == id);
    }

    public IEnumerable<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public Product Create(Product product)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        _context.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Product Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        _context.Remove(product);
        _context.SaveChanges();
        return product;
    }

    public Product Update(Product product)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();
        return product;
    }
}
