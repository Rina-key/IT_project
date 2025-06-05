using IT_project.Interfaces;
using IT_project.Models;

namespace IT_project.Services
{
    public class BooksService
    {
        private readonly IBooksRepositories _bookRepositories;

        public BooksService(IBooksRepositories bookRepositories)
        {
            _bookRepositories = bookRepositories;
        }

        public List<Books> sendBooks() 
        {
            return _bookRepositories.sendBooks();
        }
    }
}
