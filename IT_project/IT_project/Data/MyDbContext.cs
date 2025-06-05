using IT_project.Models;
using Microsoft.EntityFrameworkCore;
namespace IT_project.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
