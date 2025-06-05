using IT_project.Data;
using IT_project.Interfaces;
using IT_project.Models;
using Microsoft.EntityFrameworkCore;

namespace IT_project.Repositories
{
    public class BooksRepositories : IBooksRepositories
    {
        private readonly MyDbContext _context;
        public BooksRepositories(MyDbContext myDbContext)
        {
            _context = myDbContext;
        }

        public  List<Books> sendBooks()
        {
            List<Books> books =  _context.Books.ToList();
            return books;
        }
    }
}
