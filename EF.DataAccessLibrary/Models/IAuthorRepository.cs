namespace EF.DataAccessLibrary.Models
{
    public interface IAuthorRepository
    {
        public Task<Author> GetAuthorByIdAsync(int id);
    }
}