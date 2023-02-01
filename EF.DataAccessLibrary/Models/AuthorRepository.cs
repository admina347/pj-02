using EF.DataAccessLibrary.Dataaccess;
using Microsoft.EntityFrameworkCore;

namespace EF.DataAccessLibrary.Models
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _db;

        public AuthorRepository(LibraryContext db)
        {
            _db = db;
        }
        //Получить всех авторов
        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            List<Author> authors = new List<Author>();
            try
            {
                authors = await _db.Authors.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return authors;
        }
        //
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _db.Authors.FindAsync(id);
        }
    }
}