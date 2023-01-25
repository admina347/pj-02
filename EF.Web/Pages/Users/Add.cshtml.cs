using EF.DataAccessLibrary.Models;
using EF.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Users
{
    public class Add : PageModel
    {
        [BindProperty]
        public AddUserViewModel AddUserRequest { get; set; }
        private IUserRepository _userRepository;
        private readonly ILogger<Add> _logger;

        public Add(ILogger<Add> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }
        public async Task OnPost()
        {
            //Convert ViewModel to DomainModel
            User newUser = new User()
            {
                FirstName = AddUserRequest.FirstName,
                Email = AddUserRequest.Email
            };
            await _userRepository.CreateUserAsync(newUser);
            
            ViewData["Message"] = "Пользовтель создан успешно!";
        }
    }
}