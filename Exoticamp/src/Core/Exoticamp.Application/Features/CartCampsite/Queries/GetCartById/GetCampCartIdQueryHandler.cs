using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CartCampsite.Queries.GetCartById
{
    public class GetCampCartIdQueryHandler : IRequestHandler<GetCampCartIdQuery, Response<CampCartIdVM>>
    {
        private readonly IAsyncRepository<CartCamp> _cartRepository;
        private readonly IMapper _mapper;

        public GetCampCartIdQueryHandler(IMapper mapper, IAsyncRepository<CartCamp> cartRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<Response<CampCartIdVM>> Handle(GetCampCartIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the cart by ID
            var cartCamp = await _cartRepository.GetByIdAsync(new Guid(request.Id));

            // Check if the cart is null
            if (cartCamp == null)
            {
                throw new NotFoundException(nameof(CartCamp), request.Id);
            }

            // Map the cart entity to the view model
            var cartCampVm = _mapper.Map<CampCartIdVM>(cartCamp);

            // Create the response object
            var response = new Response<CampCartIdVM>(cartCampVm);

            return response;
        }
    }
}
