using System.ComponentModel.DataAnnotations;

namespace EF.DataAccessLibrary.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        public List<Book> Books { get; set; }
    }
}