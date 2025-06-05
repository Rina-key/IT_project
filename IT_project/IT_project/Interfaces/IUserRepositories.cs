using IT_project.Models;

namespace IT_project.Interfaces
{
    public interface IUserRepositories
    {
        public bool checkUsers(User user); 
        public bool checkUsersEmail(string email);
        
        public void addUser(User user);
    }
}
