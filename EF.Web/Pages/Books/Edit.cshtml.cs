using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.DataAccessLibrary.Dataaccess;
using EF.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EF.Web.Pages.Books
{
    public class Edit : PageModel
    {
        private readonly ILogger<Edit> _logger;
        private readonly LibraryContext _db;

        [BindProperty]
        public EditBookViewModel EditBookViewModel { get; set; }

        public Edit(ILogger<Edit> logger, LibraryContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet(int id)
        {
            var book = _db.Books.Find(id);
            if (book != null)
            {
                //Convert Domain model to View Model
                EditBookViewModel = new EditBookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    PublicationDate = book.PublicationDate
                };
            }
        }
        public void OnPost()
        {
            if (EditBookViewModel != null)
            {
                var existingBook = _db.Books.Find(EditBookViewModel.Id);
                if (existingBook != null)
                {
                    //Convert ViewModel to DomainModel
                    existingBook.Id = EditBookViewModel.Id;
                    existingBook.Title = EditBookViewModel.Title;
                    existingBook.PublicationDate = EditBookViewModel.PublicationDate;
                    _db.SaveChanges();
                    ViewData["Message"] = "Книга успешно сохранена!";
                }
            }
        }
    }
}