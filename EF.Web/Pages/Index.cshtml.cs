using EF.DataAccessLibrary.Dataaccess;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
