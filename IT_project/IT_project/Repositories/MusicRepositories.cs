using IT_project.Data;
using IT_project.Interfaces;
using IT_project.Models;

namespace IT_project.Repositories
{
    public class MusicRepositories : IMusicRepositories
    {
        private readonly MyDbContext _context;
        public MusicRepositories(MyDbContext myDbContext) 
        {
            _context = myDbContext;
        }

        public List<Music> sendMusic() 
        {
            List<Music> musics = _context.Music.ToList();
            return musics;
        }
    }
}
