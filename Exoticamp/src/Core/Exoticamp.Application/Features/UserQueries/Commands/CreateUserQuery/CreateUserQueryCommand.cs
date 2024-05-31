using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.UserQueries.Commands.CreateUserQuery
{
    public class CreateUserQueryCommand : IRequest<Response<int>>
    {
        public string Email { get; set; }
        public string Query { get; set; }
    }
}
