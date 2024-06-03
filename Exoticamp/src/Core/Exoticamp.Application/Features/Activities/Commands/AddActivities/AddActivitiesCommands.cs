using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Activities.Commands.AddActivities
{
    public class AddActivitiesCommands:IRequest<Response<ActivityDto>>
    {
        public string Name { get; set; }

        //public ICollection<Domain.Entities.CampsiteDetails> CampsiteDetails { get; set; }
    }
}
