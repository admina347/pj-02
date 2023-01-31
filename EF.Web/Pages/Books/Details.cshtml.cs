using EF.DataAccessLibrary.Models;
using EF.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EF.Web.Pages.Books
{
    public class Details : PageModel
    {
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;
        private readonly ILogger<Details> _logger;
        
        [BindProperty]
        public DetailsBookViewModel DetailsBookViewModel { get; set; }

        [BindProperty]
        public EditBookViewModel EditBookViewModel { get; set; }
        public SelectList Users { get; set; }


        public Details(ILogger<Details> logger, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task OnGetAsync(int id)
        {
            var book = await _bookRepository.GetBookDetailsByIdAsync(id);
            if (book != null)
            {
                //Convert Domain model to View Model
                EditBookViewModel = new EditBookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    PublicationDate = book.PublicationDate,
                    UserId = book.UserId,
                    Authors = book.Authors.ToList(),
                    Genres = book.Genres.ToList()
                };
            }
            //список пользователей
            var userData = await _userRepository.GetAllUsersAsync();
            Users = new SelectList(userData, nameof(EF.DataAccessLibrary.Models.User.Id), nameof(EF.DataAccessLibrary.Models.User.FirstName));
        }
        //получить книгу «на руки» пользователем
        public async Task<IActionResult> OnPostTakeBookAsync(int id)
        {
            if (DetailsBookViewModel != null)
            {
                //Convert ViewModel to DomainModel
                Book editBook = new Book()
                {
                    Id = EditBookViewModel.Id,
                    UserId = DetailsBookViewModel.SelectedUserId
                };
                await _bookRepository.TakeBookAsync(editBook);
            }
            return RedirectToPage("/Books/List");
        }
        //Вернуть книгу
        public async Task<IActionResult> OnPostReturnBookAsync(int id)
        {
            await _bookRepository.ReturnBookAsync(id);
            return RedirectToPage("/Books/List");
        }
    }
}