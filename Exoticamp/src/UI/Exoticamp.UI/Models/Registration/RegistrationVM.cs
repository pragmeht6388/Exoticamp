    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using Exoticamp.UI.Models.Location;

    namespace Exoticamp.UI.Models.Registration
    {
        public class RegistrationVM
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

        [Required(ErrorMessage = "You must accept the terms and conditions")]
        [RegularExpression("true", ErrorMessage = "You must accept the terms and conditions.")]
        public bool TermsandCondition { get; set; }
        

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters long.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password must contain at least one letter, one number, and be at least 6 characters long.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Location is required.")]
            public string LocationId { get; set; }
            public string? Role { get; set; }
            public IEnumerable<LocationVM> Locations { get; set; }

        }
    }
