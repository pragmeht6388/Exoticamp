using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.RewiewReply.Command.AddReviewReply
{
    public class AddReviewReplyHandler : IRequestHandler<AddReviewReplyCommand, Response<ReviewReplyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReviewReplyRepository _reviewReplyRepository;
        private readonly IMessageRepository _messageRepository;

        public AddReviewReplyHandler(IMapper mapper, IReviewReplyRepository reviewReplyRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _reviewReplyRepository = reviewReplyRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<ReviewReplyDto>> Handle(AddReviewReplyCommand request, CancellationToken cancellationToken)
        {
            Response<ReviewReplyDto> addCampsiteCommandResponse = null;

            var validator = new AddReviewReplyValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var campsite = new Domain.Entities.ReviewReply { Reply=request.Reply, ReviewId=request.ReviewId, ReviewsId=request.ReviewId};
                campsite = await _reviewReplyRepository.AddAsync(campsite);
                addCampsiteCommandResponse = new Response<ReviewReplyDto>(_mapper.Map<ReviewReplyDto>(campsite), "success");
            }

            return addCampsiteCommandResponse;

        }
    }
}
