
using EF.DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EF.DataAccessLibrary.Dataaccess
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}