using Exoticamp.Application.Features.Events.Commands.CreateEvent;
using Exoticamp.Application.Features.Events.Commands.UpdateEvent;
using Exoticamp.Application.Features.Events.Queries.GetEventDetail;
using Exoticamp.Application.Features.Events.Queries.GetEventsList;
using Exoticamp.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
        Task<Event> AddEventWithCategory(Event @event);
        Task<Event> AddEvent(CreateEventCommand request);
        Task<EventDetailVm> GetEventById(Guid id);
        Task<List<EventListVm>> GetAllEvents();
        Task<UpdateEventDto> UpdateEvent(UpdateEventCommand request);
    }
}
