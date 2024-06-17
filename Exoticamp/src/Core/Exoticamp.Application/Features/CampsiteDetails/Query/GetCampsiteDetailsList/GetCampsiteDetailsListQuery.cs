using AutoMapper;
using Exoticamp.Application.Contracts;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList
{
    public class GetCampsiteDetailsListQuery :  IRequest<Response<IEnumerable<CampsiteDetailsVM>>>
    {
    }
}
