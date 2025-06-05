using IT_project.Data;
using IT_project.Interfaces;
using IT_project.Models;

namespace IT_project.Repositories
{
    public class FilmRepositories : IFilmRepositories
    {
        private readonly MyDbContext _context;
        public FilmRepositories(MyDbContext myDbContext) 
        {
            _context = myDbContext;
        }
        public List<Film> sendFilm()
        { 
            List<Film> films = _context.Film.ToList();
            return films;
        }
    }
}
