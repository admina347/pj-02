using EF.DataAccessLibrary.Dataaccess;

namespace EF.DataAccessLibrary.Models
{
    public class UserRepository
    {
        private readonly LibraryContext _db;
        //public List<EF.DataAccessLibrary.Models.Book> Books { get; set; }

        public List<EF.DataAccessLibrary.Models.User> Users { get; set; }

        public UserRepository(LibraryContext db)
        {
            _db = db;
        }

        /* public void GetAllUsers()
        {
             
        } */
        public void GetUserById()
        {

        }
    }
}