using System.Text.Json;
using EF.DataAccessLibrary.Dataaccess;
using EF.DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace EF.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly LibraryContext _db;

    public IndexModel(ILogger<IndexModel> logger, LibraryContext db)
    {
        _logger = logger;
        _db = db;
    }

    public void OnGet()
    {   
        //Заполним базу начальными данными - первый запуск
        LoadSampleDataBooks();
        LoadSampleDataUsers();
    }

    private void LoadSampleDataBooks()
    {
        if (_db.Books.Count() == 0)
        {
            string file = System.IO.File.ReadAllText("generated_books.json");
            var book = JsonSerializer.Deserialize<List<Book>>(file);
            _db.AddRange(book);
            _db.SaveChanges();
        }
    }
    private void LoadSampleDataUsers()
    {
        if (_db.Users.Count() == 0)
        {
            string file = System.IO.File.ReadAllText("generated_users.json");
            var user = JsonSerializer.Deserialize<List<User>>(file);
            _db.AddRange(user);
            _db.SaveChanges();
        }
    }
}
