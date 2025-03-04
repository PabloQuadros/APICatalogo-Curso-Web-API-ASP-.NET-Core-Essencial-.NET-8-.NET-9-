using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        var products = _context.Products.ToList();
        if(products is null)
        {
            return NotFound();
        }
        return products;
    }

    [HttpGet("{id:int}", Name= "GetProductById")]
    public ActionResult<Product> Get(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if (product is null)
        {
            return NotFound();
        }
        return product;
    }


    [HttpPost]
    public ActionResult Post(Product product)
    {
        if(product is null)
        {
            return BadRequest();
        }
        _context.Products.Add(product);
        _context.SaveChanges();
        return new CreatedAtRouteResult("GetProductById", new { id = product.ProductId }, product);

    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }
        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if(product is null)
        {
            return BadRequest();
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
        return Ok(product);
    }
}
