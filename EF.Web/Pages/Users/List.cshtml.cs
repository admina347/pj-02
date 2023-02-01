using EF.DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Users
{
    public class List : PageModel
    {
        private readonly ILogger<List> _logger;
        public List<User> Users { get; set; }

        public int totalPages { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(currentPage, pageSize));

        private readonly IUserRepository _userRepository;

        public List(ILogger<List> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task OnGetAsync(int p = 1, int s = 10)
        {
            var data = await _userRepository.GetAllUsersAsync();
            pageSize = s;
            currentPage = p;
            totalPages = (int)Math.Ceiling((decimal)data.Count() / (decimal)pageSize); //data.Count()/s;
            Users = data.Skip((p - 1) * s).Take(s).ToList();
        }
    }
}