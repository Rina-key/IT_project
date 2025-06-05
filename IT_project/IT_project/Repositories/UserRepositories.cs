using IT_project.Data;
using IT_project.Interfaces;
using IT_project.Models;

namespace IT_project.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly MyDbContext _context;
        public UserRepositories(MyDbContext myDbContext) 
        {
            _context = myDbContext;
        }

        public bool checkUsers(User user)
        {
            User us = _context.User.FirstOrDefault(u => u.password == user.password && u.username == user.username);
            if (us == null)
            {
                return false;
            }
            return true; 
        }

        public bool checkUsersEmail(string email) 
        {
            User us = _context.User.FirstOrDefault(u => u.Email == email);
            if (us == null)
            {
                return false;
            }
            return true;
        }

        public void addUser(User user) 
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }
    }

}
