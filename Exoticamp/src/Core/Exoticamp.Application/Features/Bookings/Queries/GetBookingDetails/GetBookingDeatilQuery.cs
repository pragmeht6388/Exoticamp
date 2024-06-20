using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Queries.GetBookingDetails
{
    public class GetBookingDeatilQuery:IRequest<Response<GetBookingByIdDto>>
    {
        public Guid BookingId {  get; set; }
    }
}
