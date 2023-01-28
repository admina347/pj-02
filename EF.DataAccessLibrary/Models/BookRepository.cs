using EF.DataAccessLibrary.Dataaccess;
using Microsoft.EntityFrameworkCore;

namespace EF.DataAccessLibrary.Models
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        private readonly LibraryContext _db;

        public BookRepository(LibraryContext db)
        {
            _db = db;
        }
        //2.2 - Получить все книги
        public async Task<List<Book>> GetAllBooksAsync()
        {
            List<Book> books = new List<Book>();
            //var users = await _db.Users.ToListAsync();
            try
            {
                books = await _db.Books.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return books;
        }
        //2.1 - Получить книгу
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _db.Books.FindAsync(id);
        }
        //2.1 - Получить книгу
        public async Task<Book> GetBookDetailsByIdAsync(int id)
        {
            return await _db.Books.Include(ab => ab.Authors).ThenInclude(a => a.Author)
                .Include(ab => ab.Genres).ThenInclude(g => g.Genre)
                .Where(b => b.Id == id).FirstOrDefaultAsync();  //SingleOrDefault
        }
        //2.5 - Оббновить книгу
        public async Task UpdateBookAsync(Book book)
        {
            var existingBook = await _db.Books.FindAsync(book.Id);
            if (existingBook != null)
            {
                //Convert ViewModel to DomainModel
                existingBook.Title = book.Title;
                existingBook.PublicationDate = book.PublicationDate;
                await _db.SaveChangesAsync();
            }
        }
        //2.3 Add Book
        public async Task CreateBookAsync(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
        }
        //2.4 Delete book
        public async Task DeleteBookAsync(Book book)
        {
            var existingBook = await _db.Books.FindAsync(book.Id);
            if (existingBook != null)
            {
                _db.Books.Remove(existingBook);
                await _db.SaveChangesAsync();
            }
        }
    }
}