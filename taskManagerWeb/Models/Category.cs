using System.ComponentModel.DataAnnotations;

namespace taskManagerWeb.Models;
public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Display(Name = "Display Order")]
    [Range(1,100,ErrorMessage ="Must Be Between 1 to 100 only!")]
    public int DisplayOrder { get; set; }
    
    [Required]
    [Display(Name = "Task Notes")]
    public string Comments { get; set; }
    
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    
}
