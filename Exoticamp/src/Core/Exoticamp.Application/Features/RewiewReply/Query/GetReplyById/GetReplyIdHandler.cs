using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Reviews.Queryies.GetReviewById;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.RewiewReply.Query.GetReplyById
{
    internal class GetReplyIdHandler : IRequestHandler<GetReplyIdQuery, Response<ReviewReplyVm>>
    {
        private readonly IAsyncRepository<Domain.Entities.ReviewReply> _replyRepository;
        private readonly IMapper _mapper;
        //private readonly IReviewRepository _campsiteRepository1;
        private readonly IDataProtector _protector;
        public GetReplyIdHandler(IMapper mapper, IAsyncRepository<Domain.Entities.ReviewReply> replyRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;

            _replyRepository = replyRepository;
        }

        public async Task<Response<ReviewReplyVm>> Handle(GetReplyIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the campsite by ID
            var campsite = await _replyRepository.GetByIdAsync(new Guid(request.Id));

            // Check if the campsite is null or not active
            if (campsite == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.ReviewReply), request.Id);
            }

            // Map the campsite to the view model
            var campsiteDto = _mapper.Map<ReviewReplyVm>(campsite);

            // Create the response object
            var response = new Response<ReviewReplyVm>(campsiteDto);
            return response;
        }
    }
}
