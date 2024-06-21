using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Models.Authentication
{
     public class VendorRegistrationRequest
    {
        // ApplicationUser properties
        // ApplicationUser properties
        public string? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string AlternatePhoneNumber { get; set; }

        [EmailAddress]
        public string AlternateEmail { get; set; }

        public string AlternateAddress { get; set; }

        [Required]
        public Guid LocationId { get; set; }
        public string? Role { get; set; }
        [Required]
        public string Password { get; set; }

        // BankDetails properties
        public Guid BankDetailsId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }

        // UserKYC properties
        public Guid UserKYCId { get; set; }
        public string IDCard { get; set; }
        public string License { get; set; }
        public string AddressProof { get; set; }
        public string Others { get; set; }
    }
}
