namespace EF.DataAccessLibrary.Models
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task UpdateUserAsync(User user);
        public Task CreateUserAsync(User user);
        public Task DeleteUserAsync(User user);
    }
}