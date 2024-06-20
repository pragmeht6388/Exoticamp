using Exoticamp.Application.Features.Banners.Queries;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Queries.GetBookingList
{
    public class GetBookingListQuery : IRequest<Response<IEnumerable<BookingVM>>>
    {
    }
}
