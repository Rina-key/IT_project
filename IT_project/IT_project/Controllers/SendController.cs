using IT_project.Models;
using IT_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace IT_project.Controllers
{
    public class SendController : Controller
    {

        private readonly BooksService _booksService;
        private readonly FilmService _filmService;
        public SendController(BooksService booksService, FilmService filmService) 
        {
            _booksService = booksService;
            _filmService = filmService;
        }



        [HttpGet]
        
        public IActionResult Book()
        {
            List<Books> allBooks = _booksService.sendBooks();
            return View(allBooks);
        }

        [HttpGet]
        public IActionResult Film() 
        {
            List<Film> allFilms = _filmService.sendFilm();
            return View(allFilms);
        }
    }
}
