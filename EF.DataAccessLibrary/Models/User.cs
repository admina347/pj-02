using System.ComponentModel.DataAnnotations;
using EF.DataAccessLibrary.Models;

namespace Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        public List<Book>? Books { get; set; } = new List<Book>();
    }
}