
namespace Todo.WebUi.Pages;

public partial class Completed
{

    [Inject]
    private ITodoItemService todoItemService { get; set; }
    [Inject]
    private ICategoryService categoryService { get; set; }

    public bool IsLoadingCompletedItems { get; set; }


    protected override async Task OnInitializedAsync()
    {
        IsLoadingCompletedItems = true;
        var categories = (await categoryService.GetCategories()).ToList();
        var completedItems = (await todoItemService.GetCheckedTodoItems()).ToList();

        foreach (var item in completedItems)
        {
            item.Category = categories.FirstOrDefault(c => c.Id == item.CategoryId);
        }

        CompletedItems = completedItems;
        Categories = categories;
        IsLoadingCompletedItems = false;
    }

    public List<TodoItem> CompletedItems { get; set; } = new();
    public List<Category> Categories { get; set; } = new();

    private async void OnRemoveItem(TodoItem itemToRemove)
    {
        if (itemToRemove is not null)
        {
            await todoItemService.DeleteTodoItem(itemToRemove.Id);
            CompletedItems.Remove(itemToRemove);
            StateHasChanged();
        }
    }

    
}