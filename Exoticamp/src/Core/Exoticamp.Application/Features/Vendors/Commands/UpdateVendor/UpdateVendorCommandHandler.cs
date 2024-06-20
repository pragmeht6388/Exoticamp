using AutoMapper;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Features.Vendors.Queries.GetVendor;
using Exoticamp.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Vendors.Commands.UpdateVendor
{
    public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, Response<UpdatedVendorDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UpdateVendorCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Response<UpdatedVendorDto>> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
        {
            // Map the command to the UpdatedVendorDto
            var vendorDto = _mapper.Map<UpdatedVendorDto>(request);

            // Update the vendor details
            var updatedVendorDto = await _userService.UpdateVendor(vendorDto);

            // Return the response with the updated vendor details
            return new Response<UpdatedVendorDto>(updatedVendorDto, "Vendor updated successfully");
        }
    }
}
