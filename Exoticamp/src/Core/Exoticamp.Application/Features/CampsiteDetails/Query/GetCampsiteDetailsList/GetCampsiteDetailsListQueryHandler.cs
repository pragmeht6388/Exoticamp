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

namespace Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList
{
    public class GetCampsiteDetailsListQueryHandler : IRequestHandler<GetCampsiteDetailsListQuery, Response<IEnumerable<CampsiteDetailsVM>>>
    {
        private readonly ICampsiteDetailsRepository _campsiteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetCampsiteDetailsListQueryHandler(IMapper mapper, ICampsiteDetailsRepository campsiteRepository, ILogger<GetCampsiteDetailsListQueryHandler> logger)
        {
            _mapper = mapper;
            _campsiteRepository = campsiteRepository;
            _logger = logger;
        }
         
        public async Task<Response<IEnumerable<CampsiteDetailsVM>>> Handle(GetCampsiteDetailsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            var allCampsite = (await _campsiteRepository.GetAllCampsiteWithCategoryAndActivityDetails()).OrderBy(x=>x.Name);

            var activeCampsites = allCampsite.Where(c => c.isActive == true);

            var orderedCampsites = activeCampsites.OrderBy(x => x.Name);

            //var campsiteVMs = _mapper.Map<IEnumerable<CampsiteDetailsVM>>(orderedCampsites);

            _logger.LogInformation("Hanlde Completed");

            return new Response<IEnumerable<CampsiteDetailsVM>>(allCampsite, "success");
        }


    }
}
