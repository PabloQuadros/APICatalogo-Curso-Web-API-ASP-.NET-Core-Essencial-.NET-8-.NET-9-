using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public ActionResult<IEnumerable<Category>> Get()
    {
        return _context.Categories.ToList();
    }

    [HttpGet("{id:int}", Name = "GetCategoryById")]
    public ActionResult<Category> Get(int id)
    {
        var Category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

        if (Category == null)
        {
            return NotFound();
        }
        return Ok(Category);
    }

    [HttpPost]
    public ActionResult Post(Category Category)
    {
        if (Category is null)
            return BadRequest();

        _context.Categories.Add(Category);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetCategoryById",
            new { id = Category.CategoryId }, Category);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Category Category)
    {
        if (id != Category.CategoryId)
        {
            return BadRequest();
        }
        _context.Entry(Category).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(Category);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var Category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

        if (Category == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(Category);
        _context.SaveChanges();
        return Ok(Category);
    }

}
