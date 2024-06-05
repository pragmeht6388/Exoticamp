using MediatR;
using System;
using Exoticamp.Application.Responses;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Response<CreateEventCommandDto>>
    {

   

        public string Name { get; set; }

        public decimal Price { get; set; }


        public int Capacity { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }


        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public string Highlights { get; set; }

        public string EventRules { get; set; }
        public Guid CampsiteId { get; set; }

     
        public Guid ActivityId { get; set; }

        
        public string location { get; set; }
        public bool Status { get; set; } 
    }
}
