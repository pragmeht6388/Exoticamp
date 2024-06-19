using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Events.Queries.GetEventsList;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Queries.GetBookingList
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingListQuery, Response<IEnumerable<BookingVM>>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public GetBookingQueryHandler(IMapper mapper, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }

        public async Task<Response<IEnumerable<BookingVM>>> Handle(GetBookingListQuery request, CancellationToken cancellationToken)
        {
            var allBookings = (await _bookingRepository.ListAllAsync()).OrderBy(x => x.CheckIn);
             var bookinglist = _mapper.Map<List<BookingVM>>(allBookings);
            var response = new Response<IEnumerable<BookingVM>>(bookinglist);
            return response;
        }
    }
}
