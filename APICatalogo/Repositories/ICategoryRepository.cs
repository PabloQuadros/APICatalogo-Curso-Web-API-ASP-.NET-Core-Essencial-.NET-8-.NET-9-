using APICatalogo.Models;

namespace APICatalogo.Repositories;

public interface ICategoryRepository
{
    IEnumerable<Category> GetGategories();
    Category GetCategory(int id);
    Category Create(Category category);
    Category Update(Category category);
    Category Delete(int id);
}
