using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Campsite.Query.GetCampsite
{
    public class GetCampsiteDetailQuery : IRequest<Response<CampsiteVM>>
    {
        public string Id { get; set; }
    }
}
