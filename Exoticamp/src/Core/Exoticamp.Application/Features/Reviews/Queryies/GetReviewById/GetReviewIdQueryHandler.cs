using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetails;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Reviews.Queryies.GetReviewById
{
    public class GetReviewIdQueryHandler : IRequestHandler<GetReviewIdQuery, Response<ReviewsVM>>
    {
        private readonly IAsyncRepository<Domain.Entities.Reviews> _campsiteRepository;
        private readonly IMapper _mapper;
        //private readonly IReviewRepository _campsiteRepository1;
        private readonly IDataProtector _protector;
        public GetReviewIdQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Reviews> campsiteRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;

            _campsiteRepository = campsiteRepository;
        }

        public async Task<Response<ReviewsVM>> Handle(GetReviewIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the campsite by ID
            var campsite = await _campsiteRepository.GetByIdAsync(new Guid(request.Id));

            // Check if the campsite is null or not active
            if (campsite == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Reviews), request.Id);
            }

            // Map the campsite to the view model
            var campsiteDto = _mapper.Map<ReviewsVM>(campsite);

            // Create the response object
            var response = new Response<ReviewsVM>(campsiteDto);
            return response;
        }
    }
}
