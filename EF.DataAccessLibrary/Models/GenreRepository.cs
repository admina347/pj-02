using EF.DataAccessLibrary.Dataaccess;
using Microsoft.EntityFrameworkCore;

namespace EF.DataAccessLibrary.Models
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LibraryContext _db;

        public GenreRepository(LibraryContext db)
        {
            _db = db;
        }
        //2.2 - Получить все жанры
        public async Task<List<Genre>> GetAllGenresAsync()
        {
            //new SelectListItem
            List<Genre> genres = new List<Genre>();
            //var users = await _db.Users.ToListAsync();
            try
            {
                genres = await _db.Genres.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return genres;
        }
    }
}