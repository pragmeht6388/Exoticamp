using Exoticamp.Application.Features.Activities.Query.GetActivityList;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.TentType.Query
{
    public class GetTentListQuery : IRequest<Response<IEnumerable<TentVM>>>
    {
    }
}
