using System.ComponentModel.DataAnnotations;

namespace EF.DataAccessLibrary.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        // Навигационное свойство
        public List<Book> Books { get; set; } = new List<Book>();
    }
}