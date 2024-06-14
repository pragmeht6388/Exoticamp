using Exoticamp.Application.Responses;
using MediatR;

namespace Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteByLocationId
{
    public class GetCampsiteLocationIdByQuery : IRequest<Response<IEnumerable<CampsiteDetailsVM1>>>
    {
       public string Id { get; set; }

    }
}
