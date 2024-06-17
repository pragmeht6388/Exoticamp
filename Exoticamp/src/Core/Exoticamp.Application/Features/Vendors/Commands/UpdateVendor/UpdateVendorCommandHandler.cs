using AutoMapper;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Features.Vendors.Queries.GetVendor;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Vendors.Commands.UpdateVendor
{
    public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UpdateVendorCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Response<string>> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
        {
            // Map the command to the GetVendorDto
            var vendorDto = _mapper.Map<GetVendorDto>(request);

            // Update the vendor details
            var result = await _userService.UpdateVendor(vendorDto);

            // Return the response
            return new Response<string>(result, "Vendor updated successfully");
        }
    }
}
