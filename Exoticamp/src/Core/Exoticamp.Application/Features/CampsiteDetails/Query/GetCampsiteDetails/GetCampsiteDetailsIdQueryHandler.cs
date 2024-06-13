using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetails
{
    internal class GetCampsiteDetailsIdQueryHandler : IRequestHandler<GetCampsiteDetailsIdIdQuery, Response<CampsiteDetailsVM>>
    {

        private readonly IAsyncRepository<Domain.Entities.CampsiteDetails> _campsiteRepository;
        private readonly IMapper _mapper;
        private readonly ICampsiteDetailsRepository _campsiteRepository1;
        private readonly IDataProtector _protector;
        public GetCampsiteDetailsIdQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.CampsiteDetails> campsiteRepository, IDataProtectionProvider provider, ICampsiteDetailsRepository campsiteRepository1)
        {
            _mapper = mapper;

            _campsiteRepository = campsiteRepository;
            _campsiteRepository1 = campsiteRepository1;
        }

        //public async Task<Response<CampsiteDetailsVM>> Handle(GetCampsiteDetailsIdIdQuery request, CancellationToken cancellationToken)
        //{
        //    // Retrieve the campsite by ID
        //    var campsite = await _campsiteRepository.GetByIdAsync(new Guid(request.Id));

        //    // Check if the campsite is null or not active
        //    if (campsite == null || !campsite.isActive == true)
        //    {
        //        throw new NotFoundException(nameof(Domain.Entities.Campsite), request.Id);
        //    }

        //    // Map the campsite to the view model
        //    var campsiteDto = _mapper.Map<CampsiteDetailsVM>(campsite);

        //    // Create the response object
        //    var response = new Response<CampsiteDetailsVM>(campsiteDto);
        //    return response;
        //}
        public async Task<Response<CampsiteDetailsVM>> Handle(GetCampsiteDetailsIdIdQuery request, CancellationToken cancellationToken)
        {
            // Call the method to get campsite details by ID
            var campsite = await _campsiteRepository1.GetCampsiteByIdWithCategoryAndActivityDetails(new Guid(request.Id));

            // Check if the campsite is null or not active
            if (campsite == null || !campsite.isActive.GetValueOrDefault() )
            {
                throw new NotFoundException(nameof(Domain.Entities.Campsite), request.Id);
            }

            // Create the response object
            var response = new Response<Application.Features.CampsiteDetails.Query.GetCampsiteDetails.CampsiteDetailsVM>(campsite);

            return response;
        }


    }
}
