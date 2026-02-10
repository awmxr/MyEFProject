using Microsoft.AspNetCore.Mvc;
using MyEFProject.DataAccess.Data;
using MyEFProject.Model.Models;
using System.Diagnostics;


namespace MyEFProject.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Category> list = _db.Categories.ToList();

        return View(list);
    }

    
}
