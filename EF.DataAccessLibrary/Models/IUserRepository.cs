namespace EF.DataAccessLibrary.Models
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task UpdateUser(User user);
    }
}