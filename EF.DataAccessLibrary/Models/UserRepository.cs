using EF.DataAccessLibrary.Dataaccess;
using Microsoft.EntityFrameworkCore;

namespace EF.DataAccessLibrary.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _db;

        public UserRepository(LibraryContext db)
        {
            _db = db;
        }
        //2.2 - Получить всех пользователей
        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> users = new List<User>();
            //var users = await _db.Users.ToListAsync();
            try
            {
                users = await _db.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return users;
        }
        //2.1 - Получить пользователя
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }
        //2.5 - Оббновить пользователя
        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _db.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                //Convert ViewModel to DomainModel
                existingUser.FirstName = user.FirstName;
                await _db.SaveChangesAsync();
            }
        }
        //2.3 Add user
        public async Task CreateUserAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }
        //2.4 Delete user
        public async Task DeleteUserAsync(User user)
        {
            var existingUser = await _db.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                //вернуть книги - разрыв связи
                List<Book> books = new List<Book>();
                books = await _db.Books.Where(u => u.UserId == user.Id).ToListAsync();
                foreach (var book in books)
                {
                    book.UserId = null;
                }
                _db.Users.Remove(existingUser);
                await _db.SaveChangesAsync();
            }
        }
        //Получить количество книг на руках у пользователя.
        public async Task<int> GetBooksCountByUserIdAsync(int id)
        {
            List<Book> books = new List<Book>();
            books = await _db.Books.Where(u => u.UserId == id).ToListAsync();
            return books.Count;
        }
    }
}