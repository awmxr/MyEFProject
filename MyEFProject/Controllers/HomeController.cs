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

    public IActionResult Upsert(int? id)
    {
        Category category = new();
        if(id == null)
        {
            return View(category);
        }
        category = _db.Categories.FirstOrDefault(c => c.Id == id);
        if(category == null)
        {
            return NotFound();
        }

        return View(category);

    }

    [HttpPost]
    public IActionResult Upsert(Category category)
    {
        if(category.Id == 0)
        {
            _db.Categories.Add(category);
        }
        else
        {
            _db.Categories.Update(category);
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }


    public IActionResult Delete(int id)
    {
        var category = _db.Categories.FirstOrDefault(c => c.Id == id);

        _db.Categories.Remove(category);
        _db.SaveChanges();
        return RedirectToAction("Index");


    }


}
