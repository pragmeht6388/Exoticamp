using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Exoticamp.Application.Features.Events.Queries.GetEventsList;
using Exoticamp.Domain.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.Application.Profiles
{
    public class EventVmCustomMapper : ITypeConverter<Event, EventListVm>
    {
        private readonly IDataProtector _protector;

        public EventVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public EventListVm Convert(Event source, EventListVm destination, ResolutionContext context)
        {
            EventListVm dest = new EventListVm()
            {
                EventId = source.EventId,
                Name = source.Name,
                ImageUrl = source.ImageUrl,
                StartDate = source.StartDate,
                EndDate= source.EndDate,
                Price =source.Price,
                Capacity = source.Capacity,
                Description=source.Description,
                Highlights=source.Highlights,
                EventRules=source.EventRules
            };

            return dest;

        }
    }
}
