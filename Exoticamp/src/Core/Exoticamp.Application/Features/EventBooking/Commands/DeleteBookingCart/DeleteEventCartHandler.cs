using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.EventBooking.Commands.DeleteBookingCart
{
    public class DeleteEventCartHandler : IRequestHandler<DeleteEventCartCommand, Response<bool>>
    {
        private readonly IEventBookingCartRepository _eventBookingCartRepository;

        public DeleteEventCartHandler(IEventBookingCartRepository eventBookingCartRepository)
        {
            _eventBookingCartRepository = eventBookingCartRepository;
        }

        public async Task<Response<bool>> Handle(DeleteEventCartCommand request, CancellationToken cancellationToken)
        {
            var cartToDelete = await _eventBookingCartRepository.GetByIdAsync(request.CartId);

            if (cartToDelete == null)
            {
                return new Response<bool>($"Event Cart with id {request.CartId} not found.");
            }

            await _eventBookingCartRepository.DeleteAsync(cartToDelete);

            return new Response<bool>(true, "Event Cart deleted successfully.");
        }
    }
}
