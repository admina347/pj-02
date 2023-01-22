using System.Text.Json;
using EF.DataAccessLibrary.Dataaccess;
using EF.DataAccessLibrary.Models;
using EF.Web.Exceptions;
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

    }    
}
