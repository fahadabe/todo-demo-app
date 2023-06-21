
namespace Todo.Models.Models;
[Table("category")]
public class Category : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }
    [Column("category_name")]
    public string CategoryName { get; set; } = "";
    [Column("color")]
    public string Color { get; set; } = "";
}
