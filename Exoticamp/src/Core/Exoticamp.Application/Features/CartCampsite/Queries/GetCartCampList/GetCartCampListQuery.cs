using Exoticamp.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Exoticamp.Application.Features.CartCampsite.Query.GetCartCampList
{
    public class GetCartCampListQuery : IRequest<Response<IEnumerable<CartCampVM>>>
    {
    }
}
