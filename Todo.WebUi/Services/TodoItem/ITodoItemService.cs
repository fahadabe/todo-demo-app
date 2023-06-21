namespace Todo.WebUi.Services;

public interface ITodoItemService
{
    Task<IEnumerable<TodoItem>> GetActiveTodoItems();
    Task<IEnumerable<TodoItem>> GetCheckedTodoItems();
    Task<TodoItem> AddTodoItem(TodoItem todoItem);
    
    Task<TodoItem> UpdateTodoItem(TodoItem todoItem);
    Task DeleteTodoItem(int id);
}
