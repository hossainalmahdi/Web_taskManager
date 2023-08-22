using System.ComponentModel.DataAnnotations;

namespace taskManagerWeb.Models;
public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    [Required]
    public string Comments { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    
}
