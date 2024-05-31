using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.ContactUs.Command.AddContactUs
{
    public class AddContactUsCommand : IRequest<Response<ContactUsDto>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
