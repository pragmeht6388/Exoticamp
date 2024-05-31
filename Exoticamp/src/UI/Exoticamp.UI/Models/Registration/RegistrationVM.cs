using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Exoticamp.UI.Models.Registration
{
    public class RegistrationVM
    {
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Name cannot contain numbers.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "You must accept the terms and conditions")]
        public bool TermsandCondition { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
