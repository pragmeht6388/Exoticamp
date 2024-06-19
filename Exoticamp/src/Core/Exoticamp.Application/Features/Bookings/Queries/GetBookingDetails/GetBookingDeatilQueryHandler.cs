using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Events.Queries.GetEventDetail;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Queries.GetBookingDetails
{
    public class GetBookingDeatilQueryHandler : IRequestHandler<GetBookingDeatilQuery, Response<GetBookingByIdDto>>
    {
        private readonly IBookingRepository _bookingRepository;
      
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetBookingDeatilQueryHandler(IMapper mapper, IBookingRepository bookingRepository,  IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _bookingRepository =bookingRepository ;
           
            _protector = provider.CreateProtector("");
        }

        public async Task<Response<GetBookingByIdDto>> Handle(GetBookingDeatilQuery request, CancellationToken cancellationToken)
        {
         

            var bookingDetailDto = await _bookingRepository.GetByIdAsync(request.BookingId);

            var response = new Response<GetBookingByIdDto>();

            if (response == null)
            {
                response.Message="Booking Not found";
                return response;
            }
            response = new Response<GetBookingByIdDto>(_mapper.Map<GetBookingByIdDto>(bookingDetailDto));

            return response;
        }
    }
}
