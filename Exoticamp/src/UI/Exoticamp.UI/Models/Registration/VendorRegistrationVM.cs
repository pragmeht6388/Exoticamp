using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Registration
{
    public class VendorRegistrationVM
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

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters long.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password must contain at least one letter, one number, and be at least 6 characters long.")]
        public string Password { get; set; }

        
    }
}
