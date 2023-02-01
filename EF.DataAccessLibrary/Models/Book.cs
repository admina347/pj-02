using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.DataAccessLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }

        public int? UserId { get; set; }
        //navigation properties
        public User User { get; set; }

        //Авторов может быть несколько
        public List<AuthorBook> Authors { get; set; }

        public List<BookGenre> Genres { get; set; }
    }
}