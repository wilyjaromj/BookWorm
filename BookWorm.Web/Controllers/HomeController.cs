using BookWorm.Data;
using BookWorm.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BookWorm.Web.Controllers
{
    public class HomeController : Controller
    {
        IBookRepository bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = bookRepository.All();
            return View(model);
        }

        [HttpGet]
        public IActionResult Book(int id)
        {
            var model = bookRepository.Get(id);

            List<Book> relatedBooks = GetRelatedBooks(id, model.Author, model.Series);
            ViewBag.ShowAuthor = !string.IsNullOrWhiteSpace(model.Author) && relatedBooks.Any(b => b.Author ==model.Author);
            ViewBag.ShowSeries = !string.IsNullOrWhiteSpace(model.Series) && relatedBooks.Any(b => b.Series == model.Series);
            ViewBag.RelatedBooks = relatedBooks;

            return View(model);
        }

        
        private List<Book> GetRelatedBooks(int id, string author, string series)
        {
            var relatedBooks = bookRepository.Find(b => b.Id != id && 
                                                        ((!string.IsNullOrWhiteSpace(author) && b.Author == author) || 
                                                        (!string.IsNullOrWhiteSpace(series) && b.Series == series))
                                                  )
                                             .ToList();
            return relatedBooks;
        }

        [HttpGet]
        public IActionResult AddEditBook(int? id = null)
        {
            var model = id.HasValue ? bookRepository.Get(id.Value) : new Book();

            ViewBag.Ratings = new List<SelectListItem>
            {
                new SelectListItem("1 Star", "1"),
                new SelectListItem("2 Star", "2"),
                new SelectListItem("3 Star", "3"),
                new SelectListItem("4 Star", "4"),
                new SelectListItem("5 Star", "5")
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddEditBook(Book book, IFormFile file)
        {
            if (file != null)
            {
                using (var fs = file.OpenReadStream())
                {
                    byte[] bytes = new byte[file.Length];
                    fs.Read(bytes, 0, (int)file.Length);
                    book.CoverArt = bytes;
                }
            }

            var result = book.Id > 0 ? bookRepository.Update(book) : bookRepository.Add(book);
            bookRepository.SaveChanges();

            return RedirectToAction("Book", new { id = result.Id });
        }

        [HttpPost]
        public IActionResult DeleteBook(int id)
        {
            var deleted = bookRepository.Delete(id);
            bookRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchResults(string searchParameter, int rating, SearchTypes type)
        {
            IEnumerable<Book> results = new List<Book>();
            switch (type)
            {
                case SearchTypes.Title:
                    results = bookRepository.Find(b => b.Title.Contains(searchParameter));
                    break;
                case SearchTypes.Author:
                    results = bookRepository.Find(b => b.Author.Contains(searchParameter));
                    break;
                case SearchTypes.Rating:
                    results = bookRepository.Find(b => b.Rating == rating);
                    break;
                case SearchTypes.Series:
                    results = bookRepository.Find(b => b.Series.Contains(searchParameter));
                    break;
            }

            return View(results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
