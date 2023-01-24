using System.ComponentModel.DataAnnotations;
using EF.DataAccessLibrary.Models;

namespace EF.Web.Models.ViewModels
{
    public class EditBookViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }
        //Авторов может быть несколько
        public List<AuthorBook> Authors { get; set; }

        public List<BookGenre> Genres { get; set; }
    }
}