using Exoticamp.Application.Responses;
using MediatR;
using System;

namespace Exoticamp.Application.Features.CartCampsite.Commands.DeleteCartCamp
{
    public class DeleteCartCampCommand : IRequest<Response<bool>>
    {
        public Guid CartId { get; set; }
    }
}
