using IT_project.Models;
using IT_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace IT_project.Controllers
{
    public class SendController : Controller
    {

        private readonly BooksService _booksService;
        public SendController(BooksService booksService) 
        {
            _booksService = booksService;
        }

        [HttpGet]
        
        public IActionResult Book()
        {
            List<Books> allBooks = _booksService.sendBooks();
            return View(allBooks);
        }
    }
}
