using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEFProject.Model.Models;


[Table("tbl_Genre")]
public class Genre
{
    
    public int GenreId { get; set; }
    [Column("Name")]
    public string GenreName { get; set; }
    public int DisplayOrder { get; set; }
}
