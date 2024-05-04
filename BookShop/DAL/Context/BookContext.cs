using BookShop.DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DAL.Context
{
    public class DBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("BookDatabase"));
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BookHistory> BooksHistory { get; set; }

    }
}
