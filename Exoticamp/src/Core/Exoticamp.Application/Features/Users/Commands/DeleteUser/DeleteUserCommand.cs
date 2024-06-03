using Exoticamp.Application.Features.Banners.Commands.UpdateBanner;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public string Id { get; set; }

    }
}
