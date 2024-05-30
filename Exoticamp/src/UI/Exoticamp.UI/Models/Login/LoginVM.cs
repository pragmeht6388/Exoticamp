using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Login
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public  string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
