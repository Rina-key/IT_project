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
        public IActionResult books()
        {
            var query = HttpContext.Request.Query;
            string category = query["category"];
            List<Books> allBooks = _booksService.sendBooks();

            return Json(new { success = true, redirectUrl = Url.Action("BooksRec", "Send"), books = allBooks });
            
        }

        [HttpGet]
        public IActionResult BooksRec() 
        {
            return View();
        }
    }
}
