using System.ComponentModel.DataAnnotations;
using EF.DataAccessLibrary.Models;

namespace EF.Web.Pages.Books
{
    public class AddAuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        // Навигационное свойство
        public List<AuthorBook> Books { get; set; }    // = new List<Book>();
    }
}