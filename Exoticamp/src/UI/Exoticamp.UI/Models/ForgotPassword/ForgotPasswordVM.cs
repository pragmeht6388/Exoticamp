using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.ForgotPassword
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
    }
}
