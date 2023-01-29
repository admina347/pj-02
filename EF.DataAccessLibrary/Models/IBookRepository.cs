namespace EF.DataAccessLibrary.Models
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllBooksAsync();
        public Task<Book> GetBookByIdAsync(int id);
        public Task<Book> GetBookDetailsByIdAsync(int id);
        public Task UpdateBookAsync(Book book);
        public Task CreateBookAsync(Book book);
        public Task DeleteBookAsync(Book book);
        public Task<List<Book>> GetBooksByGenreSatrtEndDateAsync(int genreId, DateTime sDate, DateTime eDate);
    }
}