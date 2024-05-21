using MyCleanProject1.Application.Response;
using MediatR;
using System;

namespace MyCleanProject1.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery: IRequest<Response<EventDetailVm>>
    {
        public string Id { get; set; }
    }
}
