using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Vendors.Queries.GetVendor
{
    public class GetVendorDto
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? AltPhoneNumber { get; set; }

        [EmailAddress]
        public string? AltEmail { get; set; }

        public string? AltAddress { get; set; }

        public Guid LocationId { get; set; }
        public string Location { get; set; }
    }
}
