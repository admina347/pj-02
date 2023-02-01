namespace EF.DataAccessLibrary.Models
{
    public interface IAuthorRepository
    {
        public  Task<List<Author>> GetAllAuthorsAsync();
        public Task<Author> GetAuthorByIdAsync(int id);
    }
}