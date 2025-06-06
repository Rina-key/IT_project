using System.ComponentModel.DataAnnotations;

namespace IT_project.Models
{
    public class User
    {
       // [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
       // public virtual ICollection<User> Users { get; set; }
    }
}
