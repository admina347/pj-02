using EF.DataAccessLibrary.Models;
using EF.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EF.Web.Pages.Books
{
    public class Search : PageModel
    {
        private readonly ILogger<Search> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;

        public SelectList Genres { get; set; }

        //[BindProperty]
        //public int SelectedGenreId  { get; set; }
        [BindProperty]
        public SearchViewModel SearchViewModel { get; set; }

        public List<Book> Books { get; set; }

        
        //[BindProperty]
        //public List<Genre> Genres { get; set; }

        public int totalPages { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(currentPage, pageSize));


        public Search(ILogger<Search> logger, IBookRepository bookRepository, IGenreRepository genreRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }

        public async Task OnGetAsync()
        {
            //SearchViewModel.genres = new List<SelectListItem>();
            var genresData = await _genreRepository.GetAllGenresAsync();
            Genres = new SelectList(genresData, nameof(Genre.Id), nameof(Genre.Name));
            //var model = new SearchViewModel();
            //model.GenresSelectList = new List<SelectListItem>();

            //var genres = new List<Genre>();

            //foreach (var genre in genresData)
            //{
            //    model.GenresSelectList.Add(new SelectListItem { Text = genre.Name, Value = genre.Id.ToString()});
            //}
        }

        public async Task OnPost(int p = 1, int s = 10)
        {
            //Получить жанры
            var genresData = await _genreRepository.GetAllGenresAsync();
            Genres = new SelectList(genresData, nameof(Genre.Id), nameof(Genre.Name));
            //var selectedGenre = model.SelectedGenre;
            if (SearchViewModel != null)
            {
                //Проверим входные параметры
                if (SearchViewModel.SelectedGenreId == null)
                SearchViewModel.SelectedGenreId = 1;
                // Не указана конечная дата
                if (SearchViewModel.EndDate == DateTime.MinValue)
                SearchViewModel.EndDate = DateTime.UtcNow;
                //конечная дата меньше начальной
                if (SearchViewModel.EndDate < SearchViewModel.SatrtDate)
                SearchViewModel.EndDate = SearchViewModel.SatrtDate;
                //поиск книг
                var data = await _bookRepository.GetBooksByGenreSatrtEndDateAsync(SearchViewModel.SelectedGenreId, 
                SearchViewModel.SatrtDate, SearchViewModel.EndDate);   //, SearchViewModel.SatrtDate, SearchViewModel.EndDate
                pageSize = s;
                currentPage = p;
                totalPages = (int)Math.Ceiling((decimal)data.Count() / (decimal)pageSize);      
                Books = data.Skip((p - 1) * s).Take(s).ToList();
                var genreName = genresData[SearchViewModel.SelectedGenreId].Name;
                ViewData["Message"] = "Жанр: " + genreName + " Года: " + SearchViewModel.SatrtDate.Year + " - " + SearchViewModel.EndDate.Year;
            };
        }
    }
}