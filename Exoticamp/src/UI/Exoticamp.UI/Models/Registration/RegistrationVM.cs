using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Exoticamp.UI.Models.Registration
{
    public class RegistrationVM
    {
        [Required]
        public string Name { get; set; }


        [Required]

        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "You must accept the terms and conditions")]
        public bool TermsandCondition { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
