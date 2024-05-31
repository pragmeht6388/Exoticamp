using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Login
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public  string Email { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters long.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password must contain at least one letter, one number, and be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
