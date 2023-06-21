namespace Todo.WebUi.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> AddCategory(Category category);
}
