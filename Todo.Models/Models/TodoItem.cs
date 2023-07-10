using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Todo.Models.Models;

[Table("todoitem")]
public class TodoItem : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; } = "";

    [Column("description")]
    public string Description { get; set; } = "";

    [Column("is_completed")]
    public bool IsCompleted { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public Category Category { get; set; } = new();

    [Column("completed_date")]
    public DateTime CompletedDate { get; set; } = DateTime.Now;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}