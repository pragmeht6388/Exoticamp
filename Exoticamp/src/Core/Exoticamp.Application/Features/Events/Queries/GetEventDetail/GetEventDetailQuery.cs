using MediatR;
using System;
using Exoticamp.Application.Responses;

namespace Exoticamp.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<Response<EventDetailVm>>
    {
        public string Id { get; set; }
    }
}
