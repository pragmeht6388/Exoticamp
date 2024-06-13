using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Campsite.Query.GetCampsite;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetails;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Locations.Queries.GetLocation
{
    public class GetLocationIdQueryHandler : IRequestHandler<GetLocationIdQuery, Response<LocationVM>>
    {
        private readonly IAsyncRepository<Domain.Entities.Location> _locationRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetLocationIdQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Location> locationRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;

            _locationRepository = locationRepository;

        }

        public async Task<Response<LocationVM>> Handle(GetLocationIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the campsite by ID
            var location = await _locationRepository.GetByIdAsync(new Guid(request.Id));

            // Check if the campsite is null or not active
            if (location == null )
            {
                throw new NotFoundException(nameof(Domain.Entities.Location), request.Id);
            }

            // Map the campsite to the view model
            var locationDto = _mapper.Map<LocationVM>(location);

            // Create the response object
            var response = new Response<LocationVM>(locationDto);

            return response;
        }
    }
}
