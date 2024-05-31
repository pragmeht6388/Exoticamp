using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.UserQueries.Commands.RespondToUserQuery
{
    public class RespondToUserQueryCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string Response {  get; set; }
        public string Email { get; set; }
    }
}
