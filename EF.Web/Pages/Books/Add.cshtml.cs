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

        //[BindProperty]
        //public List<AddAuthorViewModel> AddAuthors { get; set; }

        //[BindProperty]
        //public List<AuthorBook> AddAuthorBook { get; set;} = new List<AuthorBook>();
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
            /* Author newAuthor = new Author()
            {
                FirstName = AddAuthorViewModel.FirstName,
                LastName = AddAuthorViewModel.LastName
            }; */
            //newBook.Authors.Add()
            await _bookRepository.CreateBookAsync(newBook);
            
            ViewData["Message"] = "Книга успешно добавлена!";
        }
    }
}