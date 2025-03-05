using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> Get()
    {
        return await _context.Categories.ToListAsync();
    }

    [HttpGet("{id:int}", Name = "GetCategoryById")]
    public async Task<ActionResult<Category>> Get(int id)
    {
        var Category = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);

        if (Category == null)
        {
            return NotFound();
        }
        return Ok(Category);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Category Category)
    {
        if (Category is null)
            return BadRequest();

        await _context.Categories.AddAsync(Category);
        await _context.SaveChangesAsync();

        return new CreatedAtRouteResult("GetCategoryById",
            new { id = Category.CategoryId }, Category);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Category Category)
    {
        if (id != Category.CategoryId)
        {
            return BadRequest();
        }
        _context.Entry(Category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(Category);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var Category = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);

        if (Category == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(Category);
        await _context.SaveChangesAsync();
        return Ok(Category);
    }

}
