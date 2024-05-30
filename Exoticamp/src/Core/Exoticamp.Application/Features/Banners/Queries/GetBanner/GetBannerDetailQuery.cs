using Exoticamp.Application.Responses;
using MediatR;

namespace Exoticamp.Application.Features.Banners.Queries.GetBanner
{
    public class GetBannerDetailQuery : IRequest<Response<BannerVM>>
    {
        public string BannerId { get; set; }
    }
}
