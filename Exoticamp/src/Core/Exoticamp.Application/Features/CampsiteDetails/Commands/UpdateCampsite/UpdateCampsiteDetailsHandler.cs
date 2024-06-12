using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Campsite.Commands.UpdateCampsite;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
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
        private readonly IAsyncRepository<CampsiteActivities> _campsiteActivities;

        public UpdateCampsiteDetailsHandler(IMapper mapper, ICampsiteDetailsRepository campsiteRepository, IMessageRepository messageRepository, IAsyncRepository<CampsiteActivities> campsiteActivities)
        {
            _mapper = mapper;
            _campsiteRepository = campsiteRepository;
            _messageRepository = messageRepository;
            _campsiteActivities = campsiteActivities;
        }

        //public async Task<Response<UpdateCampsiteDetailsDto>> Handle(UpdateCampsiteDetailsCommand request, CancellationToken cancellationToken)
        //{
        //    var campsiteToUpdate = await _campsiteRepository.GetByIdAsync(request.Id);

        //    if (campsiteToUpdate == null)
        //    {
        //        throw new NotFoundException(nameof(Campsite), request.Id);
        //    }

        //    // Check if the campsite is active
        //    if (campsiteToUpdate.isActive == false)
        //    {
        //        throw new InvalidOperationException("Cannot update an inactive campsite.");
        //    }

        //    var validator = new updateCampsiteDetailsCommandValidator(_messageRepository);
        //    var validationResult = await validator.ValidateAsync(request);

        //    if (validationResult.Errors.Count > 0)
        //    {
        //        throw new ValidationException(validationResult);
        //    }

        //    _mapper.Map(request, campsiteToUpdate);
        //    var campsiteActivities = new CampsiteActivities()
        //    {
        //        Id = Guid.NewGuid(),
        //        ActivityId = request.ActivitiesId,
        //        CampsiteId = request.Id,

        //    };
        //    var activity =( await _campsiteActivities.ListAllAsync()).FirstOrDefault(x=>x.CampsiteId==request.Id);
        //    activity.ActivityId = request.ActivitiesId;
        //    //await  Set<CampsiteActivities>().AddAsync(campsiteActivities);
        //    await _campsiteActivities.UpdateAsync(activity);
        //    await _campsiteRepository.UpdateAsync(campsiteToUpdate);

        //    var dto = new UpdateCampsiteDetailsDto
        //    {
        //        Id = request.Id,
        //        Name = request.Name,
        //        Location = request.Location,
        //        Status = request.Status,
        //        TentType = request.TentType,
        //        isActive = request.isActive,///change is true
        //        ApprovedBy = request.ApprovedBy,
        //        ApprovededDate = request.ApprovededDate,
        //        DeletededBy = request.DeletededBy,
        //        DeletedDate = request.DeletedDate,
        //        Images = request.Images,
        //        DateTime = request.DateTime,
        //        Highlights = request.Highlights,
        //        Ratings = request.Ratings,
        //        AboutCampsite = request.AboutCampsite,
        //        CampsiteRules = request.CampsiteRules,
        //        BestTimeToVisit = request.BestTimeToVisit,
        //        HowToGetHere = request.HowToGetHere,
        //        QuickSummary = request.QuickSummary,
        //        Itinerary = request.Itinerary,
        //        Inclusions = request.Inclusions,
        //        Exclusion = request.Exclusion,
        //        Amenities = request.Amenities,
        //        Accommodation = request.Accommodation,
        //        Safety = request.Safety,
        //        DistanceWithMap = request.DistanceWithMap,
        //        CancellationPolicy = request.CancellationPolicy,
        //        //CategoryId = request.CategoryId,
        //        ActivitiesId = request.ActivitiesId,
        //        FAQs = request.FAQs,
        //        HouseRules = request.HouseRules,
        //        MealPlans = request.MealPlans,
        //        WhyExoticamp = request.WhyExoticamp

        //    };


        //    return new Response<UpdateCampsiteDetailsDto>(dto, "Updated successfully");
        //}

        public async Task<Response<UpdateCampsiteDetailsDto>> Handle(UpdateCampsiteDetailsCommand request, CancellationToken cancellationToken)
        {
            var campsiteToUpdate = await _campsiteRepository.GetByIdAsync(request.Id);

            if (campsiteToUpdate == null)
            {
                throw new NotFoundException(nameof(Campsite), request.Id);
            }

            // Check if the campsite is active
            if (!campsiteToUpdate.isActive.GetValueOrDefault())
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

            // Fetch the existing CampsiteActivities entry
            var existingActivity = (await _campsiteActivities.ListAllAsync())
                .FirstOrDefault(x => x.CampsiteId == request.Id);

            if (existingActivity != null)
            {
                // Delete the existing entry
                await _campsiteActivities.DeleteAsync(existingActivity);
            }

            // Add the new entry with updated ActivityId
            var newCampsiteActivities = new CampsiteActivities
            {
                Id = Guid.NewGuid(),
                ActivityId = request.ActivitiesId,
                CampsiteId = request.Id,
            };

            await _campsiteActivities.AddAsync(newCampsiteActivities);

            await _campsiteRepository.UpdateAsync(campsiteToUpdate);

            var dto = new UpdateCampsiteDetailsDto
            {
                Id = request.Id,
                Name = request.Name,
                Location = request.Location,
                Status = request.Status,
                TentType = request.TentType,
                isActive = request.isActive, // change is true
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
