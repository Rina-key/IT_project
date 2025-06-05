using IT_project.Interfaces;
using IT_project.Models;

namespace IT_project.Services
{
    public class MusicService
    {
        private readonly IMusicRepositories _musicRepositories;
        public MusicService(IMusicRepositories musicRepositories) 
        {
            _musicRepositories = musicRepositories;
        }

        public List<Music> sendMusics() 
        {
            List<Music> musics = _musicRepositories.sendMusic();
            return musics;
        }
    }
}
