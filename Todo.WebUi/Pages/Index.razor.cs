

namespace Todo.WebUi.Pages;

public partial class Index
{
    [Inject]
    public ITodoItemService todoItemService { get; set; }
    [Inject]
    public ICategoryService categoryService { get; set; }

    public bool IsLoadingItems { get; set; } = true;
    public bool IsLoadingCategories { get; set; } = true;    


    protected override async Task OnInitializedAsync()
    {
        ToggleView();
        ActiveItems = new();
        Categories = new();
        IsLoadingItems = true;
        IsLoadingCategories = true;
        IsCategoryViewVisible = true;
        
        
        var categories = (await categoryService.GetCategories()).ToList();
        var activeItems = (await todoItemService.GetActiveTodoItems()).ToList();

        
        foreach (var activeItem in activeItems)
        {
            activeItem.Category = categories.FirstOrDefault(c => c.Id == activeItem.CategoryId);
        }

        ActiveItems = activeItems;
        Categories = categories;
        SelectedCategory = Categories.FirstOrDefault();
        IsLoadingItems = false;
        IsLoadingCategories = false;
        StateHasChanged();
    }
    public List<TodoItem> ActiveItems { get; set; }
    public List<Category> Categories { get; set; }
    public Category SelectedCategory { get; set; } = new();
    public TodoItem NewTodoItem { get; set; } = new();
    public bool IsCategoryViewVisible { get; set; } = true;
    public string SectionTitle { get; set; } = "Active";
    public string CategoryCssClass { get; set; } = "none";
    public string ItemCssClass { get; set; } = "none";

    private void OnCategorySelected(Category category)
    {
        SelectedCategory = category;
        ToggleView();
    }

    private void ToggleView()
    {
        if (IsCategoryViewVisible)
        {
            IsCategoryViewVisible = false;
            CategoryCssClass = "none";
            ItemCssClass = "";
            SectionTitle = "Active";
        }
        else
        {
            IsCategoryViewVisible = true;
            CategoryCssClass = "";
            ItemCssClass = "none";
            SectionTitle = "Select Category";
        }

    }

    protected async void OnIsItemChecked(TodoItem item)
    {
        if (item.IsCompleted)
        {
            if (await todoItemService.UpdateTodoItem(item) is not null)
            {
                ActiveItems.Remove(item);
                StateHasChanged();
            }
        }
    }

    private async Task AddTodoItem()
    {
        if (SelectedCategory is null || NewTodoItem is null)
        {
            return;
        }
        NewTodoItem.CategoryId =  SelectedCategory.Id;

        if (string.IsNullOrWhiteSpace(NewTodoItem.Title) || string.IsNullOrWhiteSpace(NewTodoItem.Description))
        {
            return;
        }


        var result = await todoItemService.AddTodoItem(NewTodoItem);
        if (result is not null)
        {
            result.Category = Categories.FirstOrDefault(c => c.Id == result.CategoryId);
            ActiveItems.Add(result);
            StateHasChanged();
        }
        // You can now use the result variable here

        NewTodoItem = new();

    }
}

