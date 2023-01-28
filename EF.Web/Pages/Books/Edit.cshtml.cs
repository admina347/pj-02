using EF.DataAccessLibrary.Models;
using EF.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Books
{
    public class Edit : PageModel
    {
        private readonly ILogger<Edit> _logger;
        private IBookRepository _bookRepository;

        [BindProperty]
        public EditBookViewModel EditBookViewModel { get; set; }

        public Edit(ILogger<Edit> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task OnGetAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book != null)
            {
                //Convert Domain model to View Model
                EditBookViewModel = new EditBookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    PublicationDate = book.PublicationDate
                };
            }
        }
        public async Task OnPostUpdateAsync()
        {
            if (EditBookViewModel != null)
            {
                //Convert ViewModel to DomainModel
                Book editBook = new Book()
                {
                    Id = EditBookViewModel.Id,
                    Title = EditBookViewModel.Title,
                    PublicationDate = EditBookViewModel.PublicationDate
                };
                //Update User
                await _bookRepository.UpdateBookAsync(editBook);
                ViewData["Message"] = "Книга успешно сохранена!";
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (EditBookViewModel != null)
            {
                //Convert ViewModel to DomainModel
                Book delBook = new Book()
                {
                    Id = EditBookViewModel.Id,
                };
                //Delete User
                await _bookRepository.DeleteBookAsync(delBook);
                return RedirectToPage("/Books/List");
            }
            return Page();
        }
    }
}