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

namespace Exoticamp.Application.Features.CampsiteDetails.Commands.AddCampsiteDetails
{
    public class AddCampsiteDetailsHandler : IRequestHandler<AddCampsiteDetailsCommand, Response<CampsiteDetailsDto>>
    {

        private readonly IMapper _mapper;
        private readonly ICampsiteDetailsRepository _campsiteRepository;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IMessageRepository _messageRepository;

        public AddCampsiteDetailsHandler(IMapper mapper, ICampsiteDetailsRepository campsiteRepository, IMessageRepository messageRepository,IActivitiesRepository activitiesRepository)
        {
            _mapper = mapper;
            _campsiteRepository = campsiteRepository;
            _messageRepository = messageRepository;
            _activitiesRepository = activitiesRepository;
        }

        public async Task<Response<CampsiteDetailsDto>> Handle(AddCampsiteDetailsCommand request, CancellationToken cancellationToken)
        {
            Response<CampsiteDetailsDto> addCampsiteCommandResponse = new Response<CampsiteDetailsDto>() ;

            var validator = new AddCampsiteDetailsCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var campsite = new Domain.Entities.CampsiteDetails
                {
                    Name = request.Name,
                    LocationId = request.LocationId,
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
                    //CategoryId = request.CategoryId,
                   // ActivitiesId = request.ActivitiesId,
                    FAQs = request.FAQs,
                    HouseRules = request.HouseRules,
                    MealPlans = request.MealPlans,
                    WhyExoticamp = request.WhyExoticamp
                };

                campsite = await _campsiteRepository.AddAsync(campsite);
                addCampsiteCommandResponse = new Response<CampsiteDetailsDto>(_mapper.Map<CampsiteDetailsDto>(campsite), "success");
            }

            return addCampsiteCommandResponse;

        }
    }
}
