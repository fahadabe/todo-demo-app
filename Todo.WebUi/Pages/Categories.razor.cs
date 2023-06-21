using Todo.WebUi.Services;

namespace Todo.WebUi.Pages
{
    public partial class Categories
    {
        [Inject]
        private ICategoryService categoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsLoadingCategories = true;
            CategoriesList = (await categoryService.GetCategories()).ToList();
            GenerateRandomColor();
            IsLoadingCategories = false;
        }

        public List<Category> CategoriesList { get; set; } = new();
        public Category NewCategory { get; set; } = new();
        public bool IsLoadingCategories { get; set; }   

        private static Random random = new();
        private void GenerateRandomColor()
        {
            var listOfColors = GetListOfGeneratedColors();
            NewCategory.Color = GenerateRandomHexColor(listOfColors);
        }

        public static string GenerateRandomHexColor(List<string> previousColors)
        {
            int r, g, b;
            string color;
            do
            {
                r = random.Next(256);
                g = random.Next(256);
                b = random.Next(256);
                color = $"#{r:X2}{g:X2}{b:X2}";
            }
            while (previousColors.Contains(color));
            return color;
        }

        private async void AddNewCategory()
        {
            if (string.IsNullOrWhiteSpace(NewCategory.CategoryName) || string.IsNullOrWhiteSpace(NewCategory.Color))
            {
                return;
            }

            var result = await categoryService.AddCategory(NewCategory);
            if (result is not null)
            {
                CategoriesList.Add(result);
                NewCategory = new();
                GenerateRandomColor();
                StateHasChanged();
            }
        }

        private List<string> GetListOfGeneratedColors()
        {
            List<string> generatedColorList = new();
            foreach (var item in CategoriesList)
            {
                generatedColorList.Add(item.Color);
            }

            return generatedColorList;
        }
    }
}