using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Exoticamp.Application.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Banners.Queries.GetBanner
{
    internal class GetBannerDetailQueryHandler : IRequestHandler<GetBannerDetailQuery, Response<BannerVM>>
    {
        private readonly IAsyncRepository<Banner> _bannerRepository;
        private readonly IMapper _mapper;

        public GetBannerDetailQueryHandler(IMapper mapper, IAsyncRepository<Banner> bannerRepository)
        {
            _mapper = mapper;
            _bannerRepository = bannerRepository;
        }

        public async Task<Response<BannerVM>> Handle(GetBannerDetailQuery request, CancellationToken cancellationToken)
        {
            var banner = await _bannerRepository.GetByIdAsync(new Guid(request.BannerId));

            if (banner == null)
            {
                throw new NotFoundException(nameof(Banner), request.BannerId);
            }

            var bannerDto = _mapper.Map<BannerVM>(banner);
            var response = new Response<BannerVM>(bannerDto);

            return response;
        }
    }
}
