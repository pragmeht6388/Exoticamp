using AutoMapper;
using Exoticamp.Application.Contracts;
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

namespace Exoticamp.Application.Features.Reviews.Commands.AddReviews
{
    public class AddReviewHandler : IRequestHandler<AddReviewCommand, Response<ReviewDto>>
    {

        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public AddReviewHandler(IMapper mapper, IReviewRepository reviewRepository, IMessageRepository messageRepository,ILoggedInUserService loggedInUserService)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _messageRepository = messageRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<Response<ReviewDto>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            Response<ReviewDto> addReviewCommandResponse = null;

            var validator = new AddReviewCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);
            request.DateTime= DateTime.Now;
            var user = _loggedInUserService.UserId;

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var review = new Domain.Entities.Reviews { Name = request.Name, DateTime = DateTime.Now, Ratings = request.Ratings, Status = false, Description = request.Description, BookingId = request.BookingId, UserId = Guid.Parse(_loggedInUserService.UserId.ToString()) };
                review = await _reviewRepository.AddAsync(review);
                addReviewCommandResponse = new Response<ReviewDto>(_mapper.Map<ReviewDto>(review), "success");
            }

            return addReviewCommandResponse;

        }
    }
}
