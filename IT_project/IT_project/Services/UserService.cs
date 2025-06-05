using IT_project.Interfaces;
using IT_project.Models;
using IT_project.Repositories;

namespace IT_project.Services
{
    public class UserService
    {
        private readonly IUserRepositories _userRepositories;
        public UserService(IUserRepositories userRepositories) 
        {
            _userRepositories = userRepositories;
        }

        public bool checkUsers(User user)
        {
            return _userRepositories.checkUsers(user);
        }

        public bool checkUserEmail(User user) 
        {
            return _userRepositories.checkUsersEmail(user);
        }

    }
}
