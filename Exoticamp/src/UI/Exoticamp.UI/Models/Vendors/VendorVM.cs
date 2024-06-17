using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Vendors
{
    public class VendorVM
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Vendor name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Business type is required.")]

        public string AltPhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string AltEmail { get; set; }

        public string AltAddress { get; set; }
        public string LocationId { get; set; }
        public string Location { get; set; }

        public bool IsLocked { get; set; }
        public int LoginAttemptCount { get; set; }
    }
}
