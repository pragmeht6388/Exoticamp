using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Campsite.Query.GetCampsiteList;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.EventBooking.Query.EventBookingList
{
    public class GetEventCartListHandler : IRequestHandler<GetEventCartListQuery, Response<IEnumerable<EventCartVM>>>
    {
        private readonly IEventBookingCartRepository _eventCartRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetEventCartListHandler(IMapper mapper, IEventBookingCartRepository eventCartRepository, ILogger<GetEventCartListHandler> logger)
        {
            _mapper = mapper;
            _eventCartRepository = eventCartRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<EventCartVM>>> Handle(GetEventCartListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            // Retrieve all campsites
            var allEventCart = await _eventCartRepository.ListAllAsync();

            // Filter campsites where isActive is true
            var activeEventCart = allEventCart.Where(c => c.IsActive == true);

            // Order the active campsites by name
            var orderedEventCart = allEventCart.OrderBy(x => x.CustomerName);

            // Map the filtered and ordered campsites to view models
            var eventVMs = _mapper.Map<IEnumerable<EventCartVM>>(orderedEventCart);

            _logger.LogInformation("Hanlde Completed");

            return new Response<IEnumerable<EventCartVM>>(eventVMs, "success");
        }
    }
}
