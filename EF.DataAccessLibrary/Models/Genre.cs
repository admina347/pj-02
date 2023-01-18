using System.ComponentModel.DataAnnotations;

namespace EF.DataAccessLibrary.Models
{
    public class Genre
    {
        public int Id { get; set;}
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set;}

        public List<Book> Books { get; set; } = new List<Book>();
    }
}