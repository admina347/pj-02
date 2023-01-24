using EF.DataAccessLibrary.Dataaccess;
using Microsoft.EntityFrameworkCore;

namespace EF.DataAccessLibrary.Models
{
    public class UserRepository : IUserRepository
    {
        private LibraryContext _db;

        public UserRepository(LibraryContext db)
        {
           _db = db;
        }
        //2.2 - Получить всех пользователей
        public async Task<List<User>> GetAllUsers()
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
                //ViewData["Message"] = "Ошибка";
            }
            return users;
        }
        //2.1 - Получить пользователя
        public async Task<User> GetUserById(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        //2.5 - Оббновить пользователя
        public async Task UpdateUser(User user)
        {
            //var existingUser = _db.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            var existingUser = await _db.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                //Convert ViewModel to DomainModel
                //existingUser.Id = user.Id;
                existingUser.FirstName = user.FirstName;
                _db.SaveChangesAsync();
            }
        }
    }
}