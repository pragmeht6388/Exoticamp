using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetails
{
    public class GetCampsiteDetailsIdIdQuery : IRequest<Response<CampsiteDetailsVM>>
    {
        public string Id { get; set; }
    }
}
