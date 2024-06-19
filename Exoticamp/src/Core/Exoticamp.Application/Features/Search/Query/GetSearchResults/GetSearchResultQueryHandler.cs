using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Activities.Query.GetActivityList;
using Exoticamp.Application.Features.Search.Query.GetSearchResults;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Exoticamp.Application.Features.Search.Query.GetSearchResults
{
    public class GetSearchResultQueryHandler : IRequestHandler<GetSearchResultQuery, Response<SearchDto>>
    {
        private readonly IActivitiesRepository _activityRepository;
        private readonly ICampsiteDetailsRepository _campsiteDetailsRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetSearchResultQueryHandler(IMapper mapper, IActivitiesRepository activityRepository, ILogger<GetSearchResultQueryHandler> logger, ICampsiteDetailsRepository campsiteDetailsRepository, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
            _logger = logger;
            _campsiteDetailsRepository = campsiteDetailsRepository;
            _eventRepository = eventRepository;
        }

        public async Task<Response<SearchDto>> Handle(GetSearchResultQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            
            var allActivity = await _activityRepository.ListAllAsync();
            var activityResult = allActivity.Where(x => x.Name.ToLower().Contains(request.Text));
            var campsites = await _campsiteDetailsRepository.ListAllAsync();
           var campsitesResult= campsites.Where(x => x.Name.ToLower().Contains(request.Text));
            var events = await _eventRepository.ListAllAsync();
            var eventResult=events.Where(x => x.Name.ToLower().Contains(request.Text));

            var response = new SearchDto { Activities = activityResult, Campsites = campsitesResult, Events = eventResult };

            return new Response<SearchDto>(response);

        }
    }
}
