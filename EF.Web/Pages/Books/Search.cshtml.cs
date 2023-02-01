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
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;

        public SelectList Genres { get; set; }
        public SelectList Authors { get; set; }


        [BindProperty]
        public SearchViewModel SearchViewModel { get; set; }

        public List<Book> Books { get; set; }

        //Pagination
        public int totalPages { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(currentPage, pageSize));

        public Search(ILogger<Search> logger, IBookRepository bookRepository, IGenreRepository genreRepository, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
        }
 
        public async Task OnGetAsync()
        {
            //SelectList
            var genresData = await _genreRepository.GetAllGenresAsync();
            genresData = await _genreRepository.GetAllGenresAsync();
            Genres = new SelectList(genresData, nameof(Genre.Id), nameof(Genre.Name));

            var authorsData = await _authorRepository.GetAllAuthorsAsync();
            authorsData = await _authorRepository.GetAllAuthorsAsync();
            Authors = new SelectList(authorsData, nameof(Author.Id), nameof(Author.FirstName), null, (nameof(Author.LastName)));
        }
        //1 -Получать список книг определенного жанра и вышедших между определенными годами.
        public async Task OnPostSearchBookByGenreYearsAsync(int p = 1, int s = 10)
        {
            //Получить жанры
            var genresData = await _genreRepository.GetAllGenresAsync();
            Genres = new SelectList(genresData, nameof(Genre.Id), nameof(Genre.Name));
            //Получим Аторов
            var authorsData = await _authorRepository.GetAllAuthorsAsync();
            Authors = new SelectList(authorsData, nameof(Author.Id), nameof(Author.FirstName), null, nameof(Author.LastName));

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
                SearchViewModel.SatrtDate, SearchViewModel.EndDate);
                pageSize = s;
                currentPage = p;
                totalPages = (int)Math.Ceiling((decimal)data.Count() / (decimal)pageSize);      
                Books = data.Skip((p - 1) * s).Take(s).ToList();
                var genreName = genresData[SearchViewModel.SelectedGenreId - 1].Name;
                ViewData["Message"] = "Жанр: " + genreName + ", Года: " + SearchViewModel.SatrtDate.Year + " - " + SearchViewModel.EndDate.Year;
            };
        }
        //2 - Получить количество книг определенного автора в библиотеке.
        public async Task OnPostGetBookCountByAuthorAsync()
        {
            //Получить жанры
            var genresData = await _genreRepository.GetAllGenresAsync();
            Genres = new SelectList(genresData, nameof(Genre.Id), nameof(Genre.Name));
            //Получим Аторов
            var authorsData = await _authorRepository.GetAllAuthorsAsync();
            Authors = new SelectList(authorsData, nameof(Author.Id), nameof(Author.FirstName), null, nameof(Author.LastName));
    
            if (SearchViewModel != null)
            {
                int authorBooksCount = await _bookRepository.GetBooksCountByAuthorIdAsync(SearchViewModel.SelectedAuthorId);
                var authorName = authorsData[SearchViewModel.SelectedAuthorId - 1].FirstName + " " + 
                authorsData[SearchViewModel.SelectedAuthorId - 1].LastName;
                ViewData["Message"] = "Автор: " + authorName + ", Количество книг: " + authorBooksCount;
            }
        }
        //3 - Получить количество книг определенного жанра в библиотеке.
        public async Task OnPostGetBookCountByGenreAsync()
        {
            //Получить жанры
            var genresData = await _genreRepository.GetAllGenresAsync();
            Genres = new SelectList(genresData, nameof(Genre.Id), nameof(Genre.Name));
            //Получим Аторов
            var authorsData = await _authorRepository.GetAllAuthorsAsync();
            Authors = new SelectList(authorsData, nameof(Author.Id), nameof(Author.FirstName), null, nameof(Author.LastName));
    
            if (SearchViewModel != null)
            {
                int genreBooksCount = await _bookRepository.GetBooksCountByGenreIdAsync(SearchViewModel.SelectedGenreId);
                var genreName = genresData[SearchViewModel.SelectedGenreId - 1].Name;
                ViewData["Message"] = "Жанр: " + genreName + ", Количество книг: " + genreBooksCount;
            }
        }
        //4 - Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public async Task OnPostCheckByNameAuthorAsync()
        {
            //Получить жанры
            var genresData = await _genreRepository.GetAllGenresAsync();
            Genres = new SelectList(genresData, nameof(Genre.Id), nameof(Genre.Name));
            //Получим Аторов
            var authorsData = await _authorRepository.GetAllAuthorsAsync();
            Authors = new SelectList(authorsData, nameof(Author.Id), nameof(Author.FirstName), null, nameof(Author.LastName));

            if (SearchViewModel != null)
            {
                bool booksExist = await _bookRepository.CheckBookByNameAuthorIdAsync(SearchViewModel.SelectedAuthorId, SearchViewModel.BookTitle);
                var authorName = authorsData[SearchViewModel.SelectedAuthorId - 1].FirstName + " " + 
                authorsData[SearchViewModel.SelectedAuthorId - 1].LastName;
                if (booksExist == true)
                {
                    ViewData["Message"] = "Книги Автора: " + authorName + ", c Названием: " + SearchViewModel.BookTitle +" Есть!";
                }
                else
                {
                    ViewData["Message"] = "Книг Автора: " + authorName + ", c Названием: " + SearchViewModel.BookTitle +" Нет!";
                }
            }
        }
        //Получение последней вышедшей книги.
        public async Task OnPostGetLastBookAsync()
        {
            //Получить жанры
            var genresData = await _genreRepository.GetAllGenresAsync();
            Genres = new SelectList(genresData, nameof(Genre.Id), nameof(Genre.Name));
            //Получим Аторов
            var authorsData = await _authorRepository.GetAllAuthorsAsync();
            Authors = new SelectList(authorsData, nameof(Author.Id), nameof(Author.FirstName), null, nameof(Author.LastName));
            
            //Полседняя 
            var lastBook = await _bookRepository.GetLastBookAsync();
            ViewData["Message"] = "Последняя вышедшая книга: " + lastBook.Title + ", Год: " + lastBook.PublicationDate.Year;
        }
    }
}