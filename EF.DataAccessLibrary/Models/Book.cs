using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;

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

        public User User { get; set; }
        //Авторов может быть несколько
        public List<Author> Authors { get; set; } = new List<Author>();

        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}