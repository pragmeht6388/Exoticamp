using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Vendors.Commands.UpdateVendor
{
    public class UpdatedVendorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string AltPhoneNumber { get; set; }
        public string AltEmail { get; set; }
        public string AltAddress { get; set; }
        public Guid LocationId { get; set; }
    }

}
