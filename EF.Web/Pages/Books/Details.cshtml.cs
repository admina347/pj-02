using EF.DataAccessLibrary.Models;
using EF.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Books
{
    public class Details : PageModel
    {
        private IBookRepository _bookRepository;
        private readonly ILogger<Details> _logger;
        
        [BindProperty]
        public EditBookViewModel EditBookViewModel { get; set; }

        public Details(ILogger<Details> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
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
                    Authors = book.Authors.ToList(),
                    Genres = book.Genres.ToList()
                };
                //Author author = book.Authors.Where()
                
            }
        }
    }
}