using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public Category GetCategory(int id)
    {
        return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
    }

    public IEnumerable<Category> GetGategories()
    {
        return _context.Categories.ToList();
    }

    public Category Create(Category category)
    {
        if (category is null)
        {
            throw new ArgumentNullException(nameof(category));
        }
        _context.Add(category);
        _context.SaveChanges();
        return category;
    }

    public Category Delete(int id)
    {
        var category = _context.Categories.Find(id);
        if (category is null)
        {
            throw new ArgumentNullException(nameof(category));
        }
        _context.Remove(category);
        _context.SaveChanges();
        return category;
    }

    public Category Update(Category category)
    {
        if (category is null)
        {
            throw new ArgumentNullException(nameof(category));
        }
        _context.Entry(category).State = EntityState.Modified;
        _context.SaveChanges();
        return category;
    }
}
