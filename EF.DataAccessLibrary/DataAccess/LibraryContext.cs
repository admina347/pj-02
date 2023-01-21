
using EF.DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EF.DataAccessLibrary.Dataaccess
{
    public class LibraryContext : DbContext
    {
        internal User user1;

        public LibraryContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}