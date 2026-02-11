using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyEFProject.Model.Models.ViewModel;

public class BookAuthorVM
{
    public BookAuthor BookAuthor { get; set; }
    public Book Book { get; set; }
    public IEnumerable<BookAuthor> BookAuthors { get; set; }
    public IEnumerable<SelectListItem> AuthorList { get; set; }
}
