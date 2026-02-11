using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEFProject.DataAccess.Data;
using MyEFProject.Model.Models.ViewModel;

namespace MyEFProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var books = _db.Books.Include(c=> c.Category).Include(c=>c.Publisher).Include(c=>c.BookDetail).Include(c=> c.BookAuthors).ThenInclude(c=> c.Author).ToList();

            //foreach(var book in books)
            //{
            //    _db.Entry(book).Reference(c => c.BookDetail).Load();
            //}

            return View(books);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM book = new();
            book.PublisherList = _db.Publishers.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = c.Name,
                Value = c.Publisher_Id.ToString()
            });

            book.CategoriyList = _db.Categories.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            if (id == null)
            {
                book.Book = new();
                return View(book);
            }

            book.Book = _db.Books.Find(id);

            if (book.Book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Upsert(BookVM crBk)
        {
            //if (ModelState.IsValid)
            //{
            if (crBk.Book.Book_Id == 0)
            {
                //crBk.Book.BookDetail_Id = 1;
                _db.Books.Add(crBk.Book);
                //_db.SaveChanges();
            }
            else
            {
                _db.Update(crBk.Book);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
            //}

            return View(crBk);
        }

        public IActionResult Delete(int id)
        {
            var book = _db.Books.Find(id);
            _db.Books.Remove(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public void PlayGround()
        {
            //var bookTemp = _db.Books.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _db.Books;
        }

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM bookAuthor = new()
            {
                BookAuthors = _db.BookAuthors.Include(c => c.Author)
                                    .Include(c => c.Book)
                                    .Where(c => c.Book_Id == id).ToList(),
                BookAuthor = new()
                {
                     Book_Id = id
                },
                Book = _db.Books.Find(id)

            };
            List<int> listOfAuthors = bookAuthor.BookAuthors.Select(c => c.Author_Id).ToList();
            var tempList = _db.Authors.Where(c=> !listOfAuthors.Contains(c.Author_Id)).ToList();

            bookAuthor.AuthorList = tempList.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Value = c.Author_Id.ToString(),
                Text = c.FullName
            });


            return View(bookAuthor);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVm)
        {
            if(bookAuthorVm.BookAuthor.Book_Id !=0 && bookAuthorVm.BookAuthor.Author_Id != 0)
            {
                _db.BookAuthors.Add(bookAuthorVm.BookAuthor);
                _db.SaveChanges();
                

            }
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookAuthorVm.Book.Book_Id });

        }


        public IActionResult RemoveAuthor(int authorId, BookAuthorVM bookAuthorVm)
        {

            int bookId = bookAuthorVm.Book.Book_Id;

            var ba = _db.BookAuthors.FirstOrDefault(c=> c.Book_Id == bookId && c.Author_Id == authorId);
            _db.BookAuthors.Remove(ba);
            _db.SaveChanges();

            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });

        }
    }
}
