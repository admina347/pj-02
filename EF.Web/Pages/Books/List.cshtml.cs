using EF.DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Books
{
    public class List : PageModel
    {
        private readonly ILogger<List> _logger;
        public List<Book> Books { get; set; }

        public int totalPages { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(currentPage, pageSize));

        private readonly IBookRepository _bookRepository;
        public List(ILogger<List> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task OnGetAsync(int p = 1, int s = 10)
        {
            var data = await _bookRepository.GetAllBooksAsync();
            pageSize = s;
            currentPage = p;
            totalPages = (int)Math.Ceiling((decimal)data.Count() / (decimal)pageSize);      
            Books = data.Skip((p - 1) * s).Take(s).ToList(); 
        }
    }
}