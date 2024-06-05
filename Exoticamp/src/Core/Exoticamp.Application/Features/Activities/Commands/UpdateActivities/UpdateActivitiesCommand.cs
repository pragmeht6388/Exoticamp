using Exoticamp.Application.Features.CampsiteDetails.Commands.UpdateCampsite;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Activities.Commands.UpdateActivities
{
    public class UpdateActivitiesCommand : IRequest<Response<UpdateActivitiesDto>>
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public ICollection<Domain.Entities.CampsiteDetails> CampsiteDetails { get; set; } = new List<Domain.Entities.CampsiteDetails>();
    }
}
