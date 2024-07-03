using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.EventBooking.Commands.DeleteBookingCart
{
    public class DeleteEventCartCommand : IRequest<Response<bool>>
    {
        public Guid CartId { get; set; }
    }
}
