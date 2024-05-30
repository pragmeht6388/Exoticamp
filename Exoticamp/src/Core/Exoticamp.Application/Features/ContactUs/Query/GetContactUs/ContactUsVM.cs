using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.ContactUs.Query.GetContactUs
{
    internal class ContactUsVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
