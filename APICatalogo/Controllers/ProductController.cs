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
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        var products = await _context.Products.ToListAsync();
        if(products is null)
        {
            return NotFound();
        }
        return products;
    }

    [HttpGet("{id:int}", Name= "GetProductById")]
    public async Task<ActionResult<Product>> Get(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        if (product is null)
        {
            return NotFound();
        }
        return product;
    }


    [HttpPost]
    public async Task<ActionResult> Post(Product product)
    {
        if(product is null)
        {
            return BadRequest();
        }
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return new CreatedAtRouteResult("GetProductById", new { id = product.ProductId }, product);

    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        if(product is null)
        {
            return BadRequest();
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }
}
