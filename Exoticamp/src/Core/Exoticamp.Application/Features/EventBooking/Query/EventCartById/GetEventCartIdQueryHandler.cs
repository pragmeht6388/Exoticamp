using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Banners.Queries.GetBanner;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetails;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.EventBooking.Query.EventCartById
{
    internal class GetEventCartIdQueryHandler : IRequestHandler<GetEventCartIdQuery, Response<EventCartVM>>
    {
        private readonly IAsyncRepository<EventBookingCart> _cartRepository;
        private readonly IMapper _mapper;

        public GetEventCartIdQueryHandler(IMapper mapper, IAsyncRepository<EventBookingCart> cartRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<Response<EventCartVM>> Handle(GetEventCartIdQuery request, CancellationToken cancellationToken)
        {
            var banner = await _cartRepository.GetByIdAsync(new Guid(request.CartId));

            if (banner == null)
            {
                throw new NotFoundException(nameof(EventBookingCart), request.CartId);
            }

            var bannerDto = _mapper.Map<EventCartVM>(banner);
            var response = new Response<EventCartVM>(bannerDto);

            return response;
        }




    }
}
