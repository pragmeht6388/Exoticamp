using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Activities.Commands.DeleteActivities
{
    public class DeleteActivitiesCommand:IRequest
    {
        public string Id { get; set; }

    }
}
