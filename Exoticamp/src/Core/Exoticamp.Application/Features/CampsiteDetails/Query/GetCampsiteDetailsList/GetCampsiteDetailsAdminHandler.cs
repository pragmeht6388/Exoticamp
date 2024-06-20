using AutoMapper;
using Exoticamp.Application.Contracts;
using Exoticamp.Application.Contracts.Persistence;
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
    public class GetCampsiteDetailsAdminHandler : IRequestHandler<GetAllCampsiteDetailsAdminList, Response<IEnumerable<CampsiteDetailsVM>>>
    {
        private readonly ICampsiteDetailsRepository _campsiteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetCampsiteDetailsAdminHandler(IMapper mapper, ICampsiteDetailsRepository campsiteRepository, ILogger<GetCampsiteDetailsAdminHandler> logger, ILoggedInUserService loggedInUserService)
        {
            _mapper = mapper;
            _campsiteRepository = campsiteRepository;
            _logger = logger;
            _loggedInUserService = loggedInUserService;
        }

        //public async Task<Response<IEnumerable<CampsiteDetailsVM>>> Handle(GetCampsiteDetailsListQuery request, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Handle Initiated");

        //    var allCampsite = (await _campsiteRepository.GetAllCampsiteWithCategoryAndActivityDetails()).OrderBy(x=>x.Name);

        //    var activeCampsites = allCampsite.Where(c => c.isActive == true);

        //    var orderedCampsites = activeCampsites.OrderBy(x => x.Name);

        //    //var campsiteVMs = _mapper.Map<IEnumerable<CampsiteDetailsVM>>(orderedCampsites);

        //    _logger.LogInformation("Handle Completed");

        //    return new Response<IEnumerable<CampsiteDetailsVM>>(allCampsite, "success");
        //}
        public async Task<Response<IEnumerable<CampsiteDetailsVM>>> Handle(GetAllCampsiteDetailsAdminList request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = _loggedInUserService.UserId;


            var allCampsite = await _campsiteRepository.GetAllCampsiteWithCategoryAndActivityDetails();

            var activeCampsites = allCampsite.Where(c => c.isActive == true );// the person who have created the campsite 

            var orderedCampsites = activeCampsites.OrderBy(x => x.Name);

            var campsiteVMs = _mapper.Map<IEnumerable<CampsiteDetailsVM>>(orderedCampsites);

            _logger.LogInformation("Handle Completed");

            return new Response<IEnumerable<CampsiteDetailsVM>>(campsiteVMs, "success");
        }

    }
}