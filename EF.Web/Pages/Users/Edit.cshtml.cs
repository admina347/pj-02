using EF.DataAccessLibrary.Models;
using EF.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Users
{
    public class Edit : PageModel
    {
        private readonly ILogger<Edit> _logger;
        private IUserRepository _userRepository;

        [BindProperty]
        public EditUserViewModel EditUserViewModel { get; set; }

        public Edit(ILogger<Edit> logger, IUserRepository userRepository)
        { 
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task OnGetAsync(int id)
        {
            //User user = new User();
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                //Convert Domain model to View Model
                EditUserViewModel = new EditUserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName
                };
            }
        }

        public async Task OnPostUpdateAsync()
        {
            if (EditUserViewModel != null)
            {
                //Convert ViewModel to DomainModel
                User editUser = new User()
                {
                    Id = EditUserViewModel.Id,
                    FirstName = EditUserViewModel.FirstName
                };
                //Update User
                await _userRepository.UpdateUserAsync(editUser);
                ViewData["Message"] = "Пользователь успешно обновлен!";
            }
        }
        //Получить количество книг на руках у пользователя.
        public async Task OnPostGetBookCountAsync()
        {
            if (EditUserViewModel != null)
            {
                int userBooksCount = await _userRepository.GetBooksCountByUserIdAsync(EditUserViewModel.Id);
                ViewData["Message"] = "Количество книг: " + userBooksCount;
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (EditUserViewModel != null)
            {
                //Convert ViewModel to DomainModel
                User delUser = new User()
                {
                    Id = EditUserViewModel.Id,
                };
                //Delete User
                await _userRepository.DeleteUserAsync(delUser);
                return RedirectToPage("/Users/List");
            }
            return Page();
        }
    }
}