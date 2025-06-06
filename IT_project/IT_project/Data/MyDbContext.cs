using IT_project.Models;
using Microsoft.EntityFrameworkCore;
namespace IT_project.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<BookRec> bookRecs { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .WithMany(u =>u.Books)

        //}
    }
}
