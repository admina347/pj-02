using EF.DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Books
{
    public class List : PageModel
    {
        private readonly ILogger<List> _logger;
        public List<Book> Books { get; set; }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }

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

        public async Task OnGetAsync(string sortOrder, int p = 1, int s = 10)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            //NameSort = sortOrder == "name" ? "name_desc" : "name";
            //DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            DateSort = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            CurrentSort = sortOrder;
            List<Book> data; //= await _bookRepository.GetAllBooksAsync();
            switch (sortOrder)
            {
                case "name":
                    data = await _bookRepository.GetAllBooksOrderByTitleAscAsync();
                    break;
                case "date_desc":
                    data = await _bookRepository.GetAllBooksOrderByDateDescAsync();
                    break;
                default:
                    data = await _bookRepository.GetAllBooksAsync();
                    break;
            }
            pageSize = s;
            currentPage = p;
            totalPages = (int)Math.Ceiling((decimal)data.Count() / (decimal)pageSize);
            Books = data.Skip((p - 1) * s).Take(s).ToList();
        }
    }
}