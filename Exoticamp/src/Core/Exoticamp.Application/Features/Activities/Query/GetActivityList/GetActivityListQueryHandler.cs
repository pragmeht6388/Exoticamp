using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Campsite.Query.GetCampsiteList;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Activities.Query.GetActivityList
{
    internal class GetActivityListQueryHandler : IRequestHandler<GetActivityListQuery, Response<IEnumerable<ActivityVM>>>
    {
        private readonly IActivitiesRepository _activityRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetActivityListQueryHandler(IMapper mapper, IActivitiesRepository activityRepository, ILogger<GetActivityListQueryHandler> logger)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ActivityVM>>> Handle(GetActivityListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            // Retrieve all campsites
            var allActivity = await _activityRepository.ListAllAsync();

            // Filter campsites where isActive is true
            //var activeCampsites = allActivity.Where(c => c.isActive == true);

            // Order the active campsites by name
            var orderedActivity = allActivity.OrderBy(x => x.Name);

            // Map the filtered and ordered campsites to view models
            var activityVMs = _mapper.Map<IEnumerable<ActivityVM>>(orderedActivity);

            _logger.LogInformation("Hanlde Completed");

            return new Response<IEnumerable<ActivityVM>>(activityVMs, "success");
        }

    }

}
