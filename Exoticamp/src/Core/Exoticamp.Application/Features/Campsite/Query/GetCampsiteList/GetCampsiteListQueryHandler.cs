using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Features.Products.Queries.GetProductList;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Campsite.Query.GetCampsiteList
{
    internal class GetCampsiteListQueryHandler : IRequestHandler<GetCampsiteListQuery, Response<IEnumerable<CampsiteVM>>>
    {
        private readonly ICampsiteRepository _campsiteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetCampsiteListQueryHandler(IMapper mapper, ICampsiteRepository campsiteRepository, ILogger<GetCampsiteListQueryHandler> logger)
        {
            _mapper = mapper;
            _campsiteRepository = campsiteRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<CampsiteVM>>> Handle(GetCampsiteListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            // Retrieve all campsites
            var allCampsite = await _campsiteRepository.ListAllAsync();

            // Filter campsites where isActive is true
            var activeCampsites = allCampsite.Where(c => c.isActive == true);

            // Order the active campsites by name
            var orderedCampsites = activeCampsites.OrderBy(x => x.Name);

            // Map the filtered and ordered campsites to view models
            var campsiteVMs = _mapper.Map<IEnumerable<CampsiteVM>>(orderedCampsites);

            _logger.LogInformation("Hanlde Completed");

            return new Response<IEnumerable<CampsiteVM>>(campsiteVMs, "success");
        }

    }
}
