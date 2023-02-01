namespace EF.DataAccessLibrary.Models
{
    public interface IGenreRepository
    {
        public Task<List<Genre>> GetAllGenresAsync();
    }
}