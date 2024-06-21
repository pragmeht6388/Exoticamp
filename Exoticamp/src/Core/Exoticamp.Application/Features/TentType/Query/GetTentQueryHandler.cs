using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Activities.Query.GetActivityList;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.TentType.Query
{
    public class GetTentQueryHandler : IRequestHandler<GetTentListQuery, Response<IEnumerable<TentVM>>>
    {
        private readonly ITentRepository _tentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetTentQueryHandler(IMapper mapper, ITentRepository tentRepository, ILogger<GetTentListQuery> logger)
        {
            _mapper = mapper;
            _tentRepository = tentRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<TentVM>>> Handle(GetTentListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            // Retrieve all campsites
            var allTent = await _tentRepository.ListAllAsync();

            // Filter campsites where isActive is true
            //var activeCampsites = allActivity.Where(c => c.isActive == true);

            // Order the active campsites by name
            var orderedTent = allTent.OrderBy(x => x.Name);

            // Map the filtered and ordered campsites to view models
            var tentVMs = _mapper.Map<IEnumerable<TentVM>>(orderedTent);

            _logger.LogInformation("Hanlde Completed");

            return new Response<IEnumerable<TentVM>>(tentVMs, "success");
        }
    }
}
