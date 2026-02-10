using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEFProject.Model.Models;

public class Author
{
    [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Author_Id { get; set; }
    [Required]
    [MaxLength(400)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(400)]
    public string LastName { get; set; }
    [Required]
    public DateTime BirthDay { get; set; }
    public string Location { get; set; }

    [NotMapped]
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    } 

}
