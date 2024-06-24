using Exoticamp.Application.Features.TentType.Query;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.TentAvailability
{
    public class GetAllTentsListQuery : IRequest<Response<IEnumerable<TentAvailabilityVM>>>
    {
    }
}
