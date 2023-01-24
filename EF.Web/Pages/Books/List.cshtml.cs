using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.DataAccessLibrary.Dataaccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EF.Web.Pages.Books
{
    public class List : PageModel
    {
        private readonly ILogger<List> _logger;
        private readonly LibraryContext _db;
        public List<EF.DataAccessLibrary.Models.Book> Books { get; set; }

        public List(ILogger<List> logger, LibraryContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            try
            {
                Books = _db.Books.ToList();
            }
            catch (Exception ex)   
            {
                Console.WriteLine("Error: " + ex.Message);
            }         
        }
    }
}