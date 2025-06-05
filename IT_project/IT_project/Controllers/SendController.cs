using IT_project.Models;
using IT_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace IT_project.Controllers
{
    public class SendController : Controller
    {

        private readonly BooksService _booksService;
        private readonly FilmService _filmService;
        private readonly MusicService _musicService;
        public SendController(BooksService booksService, FilmService filmService, MusicService musicService) 
        {
            _booksService = booksService;
            _filmService = filmService;
            _musicService = musicService;   
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

        [HttpGet]
        public IActionResult Music() 
        {
            List<Music> allMusics = _musicService.sendMusics();
            return View(allMusics);
        }
    }
}
