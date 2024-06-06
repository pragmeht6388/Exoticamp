using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Users.Queries.GetUser
{
    public class GetUserQuery :IRequest<Response<GetUserDto>>
    {
        public string UserId {  get; set; }
    }
}

