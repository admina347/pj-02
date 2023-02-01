using EF.DataAccessLibrary.Models;
using EF.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Books
{
    public class Add : PageModel
    {
        private readonly ILogger<Add> _logger;
        
        [BindProperty]
        public AddBookViewModel AddBookRequest { get; set; }

        private IBookRepository _bookRepository;

        public Add(ILogger<Add> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public void OnGet()
        {

        }
        public async Task OnPostAsync()
        {
            //Convert ViewModel to DomainModel
            Book newBook = new Book()
            {
                Title = AddBookRequest.Title,
                PublicationDate = AddBookRequest.PublicationDate
            };
            await _bookRepository.CreateBookAsync(newBook);
            
            ViewData["Message"] = "Книга успешно добавлена!";
        }
    }
}