using System.ComponentModel.DataAnnotations;

namespace EF.Web.Models.ViewModels
{
    public class AddUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}