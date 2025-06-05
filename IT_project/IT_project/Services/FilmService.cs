using IT_project.Interfaces;
using IT_project.Models;

namespace IT_project.Services
{
    public class FilmService
    {
        private readonly IFilmRepositories _filmRepositories;
        public FilmService(IFilmRepositories filmRepositories) 
        {
            _filmRepositories = filmRepositories;
        }

        public List<Film> sendFilm()
        {
            List<Film> films = _filmRepositories.sendFilm();
            return films;
        }
    }
}
