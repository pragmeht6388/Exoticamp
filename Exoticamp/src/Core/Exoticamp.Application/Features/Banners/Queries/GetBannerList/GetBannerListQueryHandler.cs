using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Banners.Queries;
using Exoticamp.Application.Features.Banners.Queries.GetBannerList;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Banners.Handlers.Queries
{
    internal class GetBannerListQueryHandler : IRequestHandler<GetBannerListQuery, Response<IEnumerable<BannerDto>>>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetBannerListQueryHandler> _logger;

        public GetBannerListQueryHandler(IMapper mapper, IBannerRepository bannerRepository, ILogger<GetBannerListQueryHandler> logger)
        {
            _mapper = mapper;
            _bannerRepository = bannerRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<BannerDto>>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            // Retrieve all banners from the repository
            var allBanners = await _bannerRepository.ListAllAsync();

            // Filter banners where IsActive is true
            var activeBanners = allBanners.Where(b => b.IsActive);

            // Map the filtered banners to BannerDto
            var bannerDtos = _mapper.Map<IEnumerable<BannerDto>>(activeBanners);

            _logger.LogInformation("Handle Completed");

            return new Response<IEnumerable<BannerDto>>(bannerDtos, "success");
        }
    }
}
