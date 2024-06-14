using AutoMapper;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Vendors.Queries.GetVendor
{
    public class GetVendorQueryHandler : IRequestHandler<GetVendorQueryByIdQuery, Response<GetVendorDto>>
    {
        private readonly IUserService _vendorService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetVendorQueryHandler> _logger;
        private readonly IAsyncRepository<Location> _location;

        public GetVendorQueryHandler(IMapper mapper, IUserService vendorService, ILogger<GetVendorQueryHandler> logger,
            IAsyncRepository<Location> location)
        {
            _mapper = mapper;
            _logger = logger;
            _vendorService = vendorService;
            _location = location;
        }

        public async Task<Response<GetVendorDto>> Handle(GetVendorQueryByIdQuery request, CancellationToken cancellationToken)
        {
            var vendor = await _vendorService.GetUserDetailsById(request.VendorId);
            //if (vendor == null)
            //{
            //    _logger.LogError($"Vendor with ID {request.VendorId} not found.");
            //    return new Response<GetVendorDto>(null, $"Vendor with ID {request.VendorId} not found.", false);
            //}

            var location = await _location.GetByIdAsync(vendor.LocationId);
            if (location != null)
            {
                vendor.Location = location.Name;
            }

            var vendorDto = _mapper.Map<GetVendorDto>(vendor);
            return new Response<GetVendorDto>(vendorDto, "success");
        }
    }

}
