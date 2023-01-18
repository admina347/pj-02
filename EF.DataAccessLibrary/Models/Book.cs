using System.ComponentModel.DataAnnotations;

namespace EF.DataAccessLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        //Авторов может быть несколько
        public List<Author> Authors { get; set; } = new List<Author>();

        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}