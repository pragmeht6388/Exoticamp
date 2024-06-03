using Exoticamp.Application.Features.UserQueries.Queries.GetUserQueryList;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.UserQueries.Queries.GetUserQueryById
{
    public class GetUserQueryByIdQuery : IRequest<Response<GetUserQueryListVM>>
    {
        public string UserQueryId { get; set; }
    }
}
