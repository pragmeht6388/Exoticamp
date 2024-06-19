using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Vendors.Queries.GetVendor
{
    public class GetVendorQueryByIdQuery : IRequest<Response<GetVendorDto>>
    {
        public string VendorId { get; set; }
    }
}
