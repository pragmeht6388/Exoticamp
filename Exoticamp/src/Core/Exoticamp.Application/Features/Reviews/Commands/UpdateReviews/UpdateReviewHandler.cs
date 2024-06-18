using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Campsite.Commands.UpdateCampsite;
using Exoticamp.Application.Features.CampsiteDetails.Commands.UpdateCampsite;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Reviews.Commands.UpdateReviews
{
    internal class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, Response<UpdateReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
       // private readonly IAsyncRepository<CampsiteActivities> _campsiteActivities;

        public UpdateReviewHandler(IMapper mapper, IReviewRepository reviewRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _messageRepository = messageRepository;
        }
        public async Task<Response<UpdateReviewDto>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _reviewRepository.GetByIdAsync(request.Id);

            if (reviewToUpdate == null)
            {
                throw new NotFoundException(nameof(Campsite), request.Id);
            }

            // Check if the campsite is active
            //if (reviewToUpdate.Status == false)
            //{
            //    throw new InvalidOperationException("Cannot update an inactive campsite.");
            //}

            var validator = new UpdateReviewValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, reviewToUpdate);

            await _reviewRepository.UpdateAsync(reviewToUpdate);

            var dto = new UpdateReviewDto
            {
                Id = request.Id,
                Name = request.Name,
                Status = request.Status,
                Description = request.Description,
                BookingId = request.BookingId,
                DateTime = request.DateTime,
                Ratings = request.Ratings,
                UserId = request.UserId
            };

            return new Response<UpdateReviewDto>(dto, "Updated successfully");
        }
    }
}
