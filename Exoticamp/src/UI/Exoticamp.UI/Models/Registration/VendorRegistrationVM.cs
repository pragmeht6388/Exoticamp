using Exoticamp.UI.Models.Location;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Registration
{
    public class VendorRegistrationVM
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Name cannot contain numbers.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string AlternatePhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid alternate email address.")]
        public string AlternateEmail { get; set; }

        public string AlternateAddress { get; set; }

        //[Required(ErrorMessage = "You must accept the terms and conditions")]
        //[RegularExpression("true", ErrorMessage = "You must accept the terms and conditions.")]
        //public bool TermsandCondition { get; set; } = true;


        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters long.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password must contain at least one letter, one number, and be at least 6 characters long.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Location is required.")]
        public string LocationId { get; set; }
        public string? Role { get; set; }
        public string? IDCard { get; set; }
        public string? License { get; set; }
        public string? AddressProof { get; set; }
        public string? Others { get; set; }

        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }

        public IFormFile IDCardFile { get; set; }
        public IFormFile LicenseFile { get; set; }
        public IFormFile AddressProofFile { get; set; }
        public IFormFile OthersFile { get; set; }
        public IEnumerable<LocationVM>? Locations { get; set; }


    }
}
