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

        /* public User GetById(int id)
        {
            int uid = id;
            User user = new User();
            Console.WriteLine("Получили: " + uid);
            return _db.Users.FirstOrDefault(u => u.Id == id);
        } */

        public async Task OnPostUpdateAsync()
        {
            if (EditUserViewModel != null)
            {
                //var existingUser = _db.Users.Find(EditUserViewModel.Id);
                //if (existingUser != null)
                //{
                
                //existingBook.Id = EditBookViewModel.Id;
                //existingBook.Title = EditBookViewModel.Title;
                //existingBook.PublicationDate = EditBookViewModel.PublicationDate;
                //_db.SaveChanges();

                //Convert ViewModel to DomainModel
                User editUser = new User()
                {
                    Id = EditUserViewModel.Id,
                    FirstName = EditUserViewModel.FirstName
                };
                //Update User
                await _userRepository.UpdateUserAsync(editUser);
                ViewData["Message"] = "Пользователь успешно обновлен!";
                //}
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