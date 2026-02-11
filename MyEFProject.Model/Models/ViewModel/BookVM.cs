using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyEFProject.Model.Models.ViewModel;

public class BookVM
{
    public Book Book { get; set; }
    public IEnumerable<SelectListItem> PublisherList { get; set; }
    public IEnumerable<SelectListItem> CategoriyList { get; set; }
}
