using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Products.Queries.GetProduct;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exoticamp.Domain.Entities;

namespace Exoticamp.Application.Features.Campsite.Query.GetCampsite
{
    internal class GetCampsiteDetailQueryHandler : IRequestHandler<GetCampsiteDetailQuery, Response<CampsiteVM>>
    {

        private readonly IAsyncRepository<Domain.Entities.Campsite> _campsiteRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetCampsiteDetailQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Campsite> campsiteRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;

            _campsiteRepository = campsiteRepository;

        }

        public async Task<Response<CampsiteVM>> Handle(GetCampsiteDetailQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the campsite by ID
            var campsite = await _campsiteRepository.GetByIdAsync(new Guid(request.Id));

            // Check if the campsite is null or not active
            if (campsite == null || !campsite.isActive==true)
            {
                throw new NotFoundException(nameof(Domain.Entities.Campsite), request.Id);
            }

            // Map the campsite to the view model
            var campsiteDto = _mapper.Map<CampsiteVM>(campsite);

            // Create the response object
            var response = new Response<CampsiteVM>(campsiteDto);

            return response;
        }

    }
}
