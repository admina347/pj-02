using EF.DataAccessLibrary.Dataaccess;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Users
{
    public class List : PageModel
    {
        private readonly ILogger<List> _logger;
        
        private readonly LibraryContext _db;
        //public List<EF.DataAccessLibrary.Models.Book> Books { get; set; }

        public List<EF.DataAccessLibrary.Models.User> Users { get; set; }
        public List(ILogger<List> logger, LibraryContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            GetAllUsers();
        }

        public void GetAllUsers()
        {
            try
            {
                Users = _db.Users.ToList();
            }
            catch (Exception ex)   
            {
                Console.WriteLine("Error: " + ex.Message);
            } 
        }
    }
}