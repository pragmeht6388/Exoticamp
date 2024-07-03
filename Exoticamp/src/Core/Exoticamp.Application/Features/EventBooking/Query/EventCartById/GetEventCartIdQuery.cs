using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.EventBooking.Query.EventCartById
{
    public class GetEventCartIdQuery : IRequest<Response<EventCartVM>>
    {
        public string CartId { get; set; }
    }
   
}
