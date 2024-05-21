using MyCleanProject1.Application.Response;
using MediatR;
using System.Collections.Generic;

namespace MyCleanProject1.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
