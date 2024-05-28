using Exoticamp.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Exoticamp.Application.Features.Banners.Queries.GetBannerList
{
    public class GetBannerListQuery : IRequest<Response<IEnumerable<BannerDto>>>
    {
    }
}
