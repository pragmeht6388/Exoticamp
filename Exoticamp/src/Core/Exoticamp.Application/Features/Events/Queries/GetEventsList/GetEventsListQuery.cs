using MediatR;
using System.Collections.Generic;
using Exoticamp.Application.Responses;

namespace Exoticamp.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
