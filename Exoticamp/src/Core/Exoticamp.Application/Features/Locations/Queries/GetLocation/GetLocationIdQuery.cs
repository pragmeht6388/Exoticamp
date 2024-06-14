using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Locations.Queries.GetLocation
{
    public class GetLocationIdQuery :  IRequest<Response<LocationVM>>
    {
        public string Id { get; set; }
    }
}
