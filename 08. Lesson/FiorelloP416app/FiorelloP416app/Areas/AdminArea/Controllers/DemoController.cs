using FiorelloP416.DAL;
using FiorelloP416app.Entities;
using FiorelloP416app.Entities.DemoEntities;
using FiorelloP416app.Extension;
using FiorelloP416app.ModelViews.AdminBook;
using FiorelloP416app.ModelViews.AdminProduct;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloP416app.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DemoController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DemoController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var books = _appDbContext.Books
                .Include(b=>b.BookGenres)
                .ThenInclude(bg=>bg.Genre)
                .Include(b=>b.BookAuthors)
                .ThenInclude(ba=>ba.Author)
                .Include(b=>b.BookImages)
                .ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Authors = _appDbContext.Authors.ToList();
            ViewBag.Genres = _appDbContext.Genres.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBookVM createBook)
        {
            ViewBag.Authors = _appDbContext.Authors.ToList();
            ViewBag.Genres = _appDbContext.Genres.ToList();

            Book book = new();
            book.Name = createBook.Name;

            foreach (var photo in createBook.Photos)
            {
                if (!photo.CheckImage())
                {
                    ModelState.AddModelError("Photos", "Only image");
                    return View();
                }
                if (photo.CheckImageSize(1000))
                {
                    ModelState.AddModelError("Photos", "Oversize");
                    return View();
                }
                BookImage bookImage = new();

                bookImage.ImageUrl = photo.SaveImage("img", _webHostEnvironment);
                book.BookImages.Add(bookImage);
            }


            foreach (var genreId in createBook.GenreIds)
            {
                BookGenre bookGenre = new();
                bookGenre.BookId = book.Id;
                bookGenre.GenreId = genreId;
                book.BookGenres.Add(bookGenre);
            }

            foreach (var authorId in createBook.AuthorIds)
            {
                BookAuthor bookAuthor = new();
                bookAuthor.BookId = book.Id;
                bookAuthor.AuthorId = authorId;
                book.BookAuthors.Add(bookAuthor);
            }
            _appDbContext.Books.Add(book);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
