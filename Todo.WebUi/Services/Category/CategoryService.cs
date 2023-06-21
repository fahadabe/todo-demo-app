

namespace Todo.WebUi.Services;

public class CategoryService : ICategoryService
{
    private readonly Supabase.Client supabaseClient;

    public CategoryService(Supabase.Client _supabaseClient)
    {
        supabaseClient = _supabaseClient;
    }
    public async Task<Category> AddCategory(Category category)
    {
        var result = await supabaseClient.From<Category>().Insert(category);
        return result.Model;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        var result = await supabaseClient.From<Category>().Get();
        return result.Models;
    }
}
