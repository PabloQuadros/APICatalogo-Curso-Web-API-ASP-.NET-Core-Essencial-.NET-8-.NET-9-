using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IRepository<Category> _repository;

    public CategoriesController(IRepository<Category> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
        var categories = _repository.GetAll();
        return Ok(categories);
    }

    [HttpGet("{id:int}", Name = "GetCategoryById")]
    public ActionResult<Category> Get(int id)
    {
        var category = _repository.Get(c => c.CategoryId == id);

        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public ActionResult Post(Category category)
    {
        if (category is null)
            return BadRequest();

        var createdCategory = _repository.Create(category);

        return new CreatedAtRouteResult("GetCategoryById",
            new { id = createdCategory.CategoryId }, createdCategory);
    }

    [HttpPut("{id:int}")]
    public  ActionResult Put(int id, Category category)
    {
        if (id != category.CategoryId)
        {
            return BadRequest();
        }
        var updatedCategory = _repository.Update(category);
        return Ok(updatedCategory);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var category = _repository.Get(c => c.CategoryId == id);
        return category is null ? NotFound() : Ok(_repository.Delete(category));
    }

}
