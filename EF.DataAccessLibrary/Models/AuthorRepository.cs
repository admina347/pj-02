using EF.DataAccessLibrary.Dataaccess;

namespace EF.DataAccessLibrary.Models
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _db;

        public AuthorRepository(LibraryContext db)
        {
            _db = db;
        }
        //
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _db.Authors.FindAsync(id);
        }
    }
}