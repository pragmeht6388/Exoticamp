using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Campsite.Commands.UpdateCampsite;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CampsiteDetails.Commands.UpdateCampsite
{
    internal class UpdateCampsiteDetailsHandler : IRequestHandler<UpdateCampsiteDetailsCommand, Response<UpdateCampsiteDetailsDto>>
    {
        private readonly ICampsiteDetailsRepository _campsiteRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public UpdateCampsiteDetailsHandler(IMapper mapper, ICampsiteDetailsRepository campsiteRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _campsiteRepository = campsiteRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<UpdateCampsiteDetailsDto>> Handle(UpdateCampsiteDetailsCommand request, CancellationToken cancellationToken)
        {
            var campsiteToUpdate = await _campsiteRepository.GetByIdAsync(request.Id);

            if (campsiteToUpdate == null)
            {
                throw new NotFoundException(nameof(Campsite), request.Id);
            }

            // Check if the campsite is active
            if (campsiteToUpdate.isActive == false)
            {
                throw new InvalidOperationException("Cannot update an inactive campsite.");
            }

            var validator = new updateCampsiteDetailsCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, campsiteToUpdate);

            await _campsiteRepository.UpdateAsync(campsiteToUpdate);

            var dto = new UpdateCampsiteDetailsDto
            {
                Id=request.Id,
                Name = request.Name,
                Location = request.Location,
                Status = request.Status,
                TentType = request.TentType,
                isActive = true,
                ApprovedBy = request.ApprovedBy,
                ApprovededDate = request.ApprovededDate,
                DeletededBy = request.DeletededBy,
                DeletedDate = request.DeletedDate,
                Images = request.Images,
                DateTime = request.DateTime,
                Highlights = request.Highlights,
                Ratings = request.Ratings,
                AboutCampsite = request.AboutCampsite,
                CampsiteRules = request.CampsiteRules,
                BestTimeToVisit = request.BestTimeToVisit,
                HowToGetHere = request.HowToGetHere,
                QuickSummary = request.QuickSummary,
                Itinerary = request.Itinerary,
                Inclusions = request.Inclusions,
                Exclusion = request.Exclusion,
                Amenities = request.Amenities,
                Accommodation = request.Accommodation,
                Safety = request.Safety,
                DistanceWithMap = request.DistanceWithMap,
                CancellationPolicy = request.CancellationPolicy,
                CategoryId = request.CategoryId,
                ActivitiesId = request.ActivitiesId,
                FAQs = request.FAQs,
                HouseRules = request.HouseRules,
                MealPlans = request.MealPlans,
                WhyExoticamp = request.WhyExoticamp

            };

            return new Response<UpdateCampsiteDetailsDto>(dto, "Updated successfully");
        }



    }
}
