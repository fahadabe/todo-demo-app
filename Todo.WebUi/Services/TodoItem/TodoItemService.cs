

using Microsoft.AspNetCore.Http.HttpResults;

namespace Todo.WebUi.Services;

public class TodoItemService : ITodoItemService
{
    private readonly Supabase.Client supabaseClient;

    public TodoItemService(Supabase.Client _supabaseClient)
    {
        supabaseClient = _supabaseClient;
    }
    public async Task<TodoItem> AddTodoItem(TodoItem todoItem)
    {
        try
        {
            var result = await supabaseClient.From<TodoItem>().Insert(todoItem);
            return result.Model;
        }
        catch (Exception ex)
        {
            
            return null;
        }

    }

    public async Task DeleteTodoItem(int id)
    {
        if (id <= 0)
        {
            return;
        }
        await supabaseClient.From<TodoItem>().Where(x => x.Id == id).Delete();
    }
    public Task<TodoItem> GetTodoItem(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TodoItem>> GetActiveTodoItems()
    {
        var result = await supabaseClient.From<TodoItem>().Where(x => x.IsCompleted == false).Get();
        return result.Models;
    }
    public async Task<IEnumerable<TodoItem>> GetCheckedTodoItems()
    {
        var result = await supabaseClient.From<TodoItem>().Where(x => x.IsCompleted == true).Get();
        return result.Models;
    }

    public async Task<TodoItem> UpdateTodoItem(TodoItem todoItem)
    {
        try
        {
            var result = await supabaseClient
               .From<TodoItem>()
               .Where(x => x.Id == todoItem.Id)
               .Set(x => x.IsCompleted, todoItem.IsCompleted)
               .Update();

            return result.Model;
        }
        catch (Exception)
        {
            return null;
        }

          
    }
}
