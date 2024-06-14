using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;

namespace Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteByLocationId
{
    internal class GetCampsiteLocationIdByQueryHandler : IRequestHandler<GetCampsiteLocationIdByQuery, Response<IEnumerable<CampsiteDetailsVM1>>>
    {
        private readonly ICampsiteDetailsRepository _campsiteRepository;
        private readonly IMapper _mapper;
        private readonly ILoactionRepository _loactionRepository;

        private readonly IDataProtector _protector;
        public GetCampsiteLocationIdByQueryHandler(IMapper mapper, ICampsiteDetailsRepository campsiteRepository, IDataProtectionProvider provider,ILoactionRepository loactionRepository)
        {
            _mapper = mapper;

            _campsiteRepository = campsiteRepository;
            _loactionRepository = loactionRepository;
        }

        public async Task<Response<IEnumerable<CampsiteDetailsVM1>>> Handle(GetCampsiteLocationIdByQuery request, CancellationToken cancellationToken)
        {
            var location = await _loactionRepository.GetLocationById(request.Id);
            var allCampsite = await _campsiteRepository.GetAllCampsiteWithCategoryAndActivityDetails();

            var activeCampsites = allCampsite.Where(c => c.isActive == true && c.Location == location.Name && c.ApprovedBy!=null);

            var orderedCampsites = activeCampsites.OrderBy(x => x.Name).ToList();

            var campsiteVMs = _mapper.Map<List<CampsiteDetailsVM1>>(orderedCampsites);

            return new Response<IEnumerable<CampsiteDetailsVM1>>(campsiteVMs, "success");

        }
    }
}
