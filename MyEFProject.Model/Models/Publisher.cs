using System.ComponentModel.DataAnnotations;

namespace MyEFProject.Model.Models;

public class Publisher
{
    [Key]
    public int Publisher_Id { get; set; }
    [Required]
    [MaxLength(400)]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }

    public ICollection<Book>? Books { get; set; }
}
