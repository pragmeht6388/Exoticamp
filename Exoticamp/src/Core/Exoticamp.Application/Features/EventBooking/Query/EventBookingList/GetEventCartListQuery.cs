using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.EventBooking.Query.EventBookingList
{
    public class GetEventCartListQuery : IRequest<Response<IEnumerable<EventCartVM>>>
    {

    }
}
