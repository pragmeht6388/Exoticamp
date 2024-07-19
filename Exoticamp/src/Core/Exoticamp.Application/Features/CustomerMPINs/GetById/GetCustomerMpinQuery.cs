using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerMPINs.GetById
{
    public class GetCustomerMpinQuery:IRequest<Response<GetCustomerMpinVM>>
    {
        public int CustomerId { get; set; }
    }
}
