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
        //2.1 - Получить книгу по Id
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _db.Books.FindAsync(id);
        }
        //2.1 - Получить книгу детали
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
        //Получить список книг определенного жанра и вышедших между определенными годами.
        public async Task<List<Book>> GetBooksByGenreSatrtEndDateAsync(int genreId, DateTime sDate, DateTime eDate)
        {
            List<Book> books = new List<Book>();
            /* //Проверим входные параметры
            if (genreId == null)
            genreId = 1;
            // Не указана конечная дата
            if (eDate == DateTime.MinValue)
            eDate = DateTime.UtcNow;
            //конечная дата меньше начальной
            if (eDate < sDate)
            eDate = sDate; */
            books = await _db.Books.Where(bg => bg.Genres.Any(g => g.GenreId == genreId))
                .Where(bg => bg.PublicationDate >= sDate && bg.PublicationDate <= eDate).ToListAsync();
            return books;
        }
        //Получить количество книг определенного автора в библиотеке.
        public async Task<int> GetBooksCountByAuthorIdAsync(int id)
        {
            List<Book> books = new List<Book>();
            books = await _db.Books.Where(ba => ba.Authors.Any(a => a.AuthorId == id)).ToListAsync();
            return books.Count;
        }
        //Получить количество книг определенного жанара в библиотеке.
        public async Task<int> GetBooksCountByGenreIdAsync(int id)
        {
            List<Book> books = new List<Book>();
            books = await _db.Books.Where(bg => bg.Genres.Any(g => g.GenreId == id)).ToListAsync();
            return books.Count;
        }
        //Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public async Task<bool> CheckBookByNameAuthorIdAsync(int id, string name)
        {
            List<Book> books = new List<Book>();
            books = await _db.Books.Where(ba => ba.Authors.Any(a => a.AuthorId == id))
            .Where(bg => bg.Title.Contains(name)).ToListAsync();
            if (books.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }        
        }
        //Получить булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public async Task<bool> CheckBookUserByIdAsync(int id)
        {
            Book book = new Book();
            book = await _db.Books.FindAsync(id);
            if (book.UserId == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //Взять книгу на руки
        public async Task TakeBookAsync(Book book)
        {
            var existingBook = await _db.Books.FindAsync(book.Id);
            if (existingBook != null)
            {
                //Convert ViewModel to DomainModel
                existingBook.UserId = book.UserId;
                await _db.SaveChangesAsync();
            }
        }
        //Вернуть книгу в библиотеку
        public async Task ReturnBookAsync(int id)
        {
            var existingBook = await _db.Books.FindAsync(id);
            if (existingBook != null)
            {
                //Convert ViewModel to DomainModel
                existingBook.UserId = null;
                await _db.SaveChangesAsync();
            }
        }
        //Получение последней вышедшей книги.
        public async Task<Book> GetLastBookAsync()
        {
            return await _db.Books.OrderByDescending(d => d.PublicationDate).FirstOrDefaultAsync();
        }
        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public async Task<List<Book>> GetAllBooksOrderByTitleAscAsync()
        {
            List<Book> books = new List<Book>();
            //var users = await _db.Users.ToListAsync();
            try
            {
                books = await _db.Books.OrderBy(b => b.Title).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return books;
        }
        //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public async Task<List<Book>> GetAllBooksOrderByDateDescAsync()
        {
            List<Book> books = new List<Book>();
            //var users = await _db.Users.ToListAsync();
            try
            {
                books = await _db.Books.OrderByDescending(b => b.PublicationDate).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return books;
        }
    }
}